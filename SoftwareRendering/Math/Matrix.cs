using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareRendering.Math
{
    class Matrix4x4
    {
        private const int DIMENSIONS_COUNT = 4;
        private const int DATA_COUNT = 16;

        private float[] data = new float[DATA_COUNT];

        public float this[int row, int column]
        {
            get { return data[row + column * DIMENSIONS_COUNT]; }
            set { data[row + column * DIMENSIONS_COUNT] = value; }
        }

        public Matrix4x4()
        {
            System.Array.Clear(this.data, 0, DATA_COUNT);
        }

        public Matrix4x4(float data)
        {
            for (int i = 0; i < DATA_COUNT; ++i)
            {
                this.data[i] = data;
            }
        }

        public Matrix4x4(float[] data)
        {
            for (int i = 0; i < DATA_COUNT; ++i)
            {
                if (data.Length <= i)
                    this.data[i] = 0.0f;
                else
                    this.data[i] = data[i];
            }
        }

        public Matrix4x4(Matrix4x4 matrix)
        {
            for (int i = 0; i < DATA_COUNT; ++i)
            {
                this.data[i] = matrix.data[i];
            }
        }

        public static Matrix4x4 operator +(Matrix4x4 a, Matrix4x4 b)
        {
            Matrix4x4 ret = new Matrix4x4(a);
            for (int i = 0; i < DATA_COUNT; ++i)
            {
                ret.data[i] += b.data[i];
            }
            return ret;
        }

        public static Matrix4x4 operator -(Matrix4x4 a, Matrix4x4 b)
        {
            Matrix4x4 ret = new Matrix4x4(a);
            for (int i = 0; i < DATA_COUNT; ++i)
            {
                ret.data[i] -= b.data[i];
            }
            return ret;
        }

        public static Matrix4x4 operator *(float a, Matrix4x4 b)
        {
            Matrix4x4 ret = new Matrix4x4(b);
            for (int i = 0; i < DATA_COUNT; ++i)
            {
                ret.data[i] *= a;
            }
            return ret;
        }

        public static Matrix4x4 operator *(Matrix4x4 a, Matrix4x4 b)
        {
            Matrix4x4 ret = new Matrix4x4();
            for (int i = 0; i < DATA_COUNT; ++i)
            {
                float value = 0.0f;
                int x = (i / DIMENSIONS_COUNT) * DIMENSIONS_COUNT;
                int y = (i % DIMENSIONS_COUNT) * DIMENSIONS_COUNT;

                for (int j = 0; j < DIMENSIONS_COUNT; ++j)
                {
                    value = a.data[x + j] * b.data[y + j * DIMENSIONS_COUNT];
                }
                ret.data[i] = value;
            }
            return ret;
        }

        public static Vector4 operator *(Matrix4x4 a, Vector4 b)
        {
            Vector4 ret = new Vector4(
                a.data[0] * b.x + a.data[1] * b.y + a.data[2] * b.z + a.data[3] * b.w,
                a.data[4] * b.x + a.data[5] * b.y + a.data[6] * b.z + a.data[7] * b.w,
                a.data[8] * b.x + a.data[9] * b.y + a.data[10] * b.z + a.data[11] * b.w,
                a.data[12] * b.x + a.data[13] * b.y + a.data[14] * b.z + a.data[15] * b.w);

            return ret;
        }

        public static Matrix4x4 operator /(float a, Matrix4x4 b)
        {
            Matrix4x4 ret = new Matrix4x4();

            ret.data[0] = b.data[5] * b.data[10] * b.data[15] -
                     b.data[5] * b.data[11] * b.data[14] -
                     b.data[9] * b.data[6] * b.data[15] +
                     b.data[9] * b.data[7] * b.data[14] +
                     b.data[13] * b.data[6] * b.data[11] -
                     b.data[13] * b.data[7] * b.data[10];

            ret.data[4] = -b.data[4] * b.data[10] * b.data[15] +
                      b.data[4] * b.data[11] * b.data[14] +
                      b.data[8] * b.data[6] * b.data[15] -
                      b.data[8] * b.data[7] * b.data[14] -
                      b.data[12] * b.data[6] * b.data[11] +
                      b.data[12] * b.data[7] * b.data[10];

            ret.data[8] = b.data[4] * b.data[9] * b.data[15] -
                     b.data[4] * b.data[11] * b.data[13] -
                     b.data[8] * b.data[5] * b.data[15] +
                     b.data[8] * b.data[7] * b.data[13] +
                     b.data[12] * b.data[5] * b.data[11] -
                     b.data[12] * b.data[7] * b.data[9];

            ret.data[12] = -b.data[4] * b.data[9] * b.data[14] +
                       b.data[4] * b.data[10] * b.data[13] +
                       b.data[8] * b.data[5] * b.data[14] -
                       b.data[8] * b.data[6] * b.data[13] -
                       b.data[12] * b.data[5] * b.data[10] +
                       b.data[12] * b.data[6] * b.data[9];

            ret.data[1] = -b.data[1] * b.data[10] * b.data[15] +
                      b.data[1] * b.data[11] * b.data[14] +
                      b.data[9] * b.data[2] * b.data[15] -
                      b.data[9] * b.data[3] * b.data[14] -
                      b.data[13] * b.data[2] * b.data[11] +
                      b.data[13] * b.data[3] * b.data[10];

            ret.data[5] = b.data[0] * b.data[10] * b.data[15] -
                     b.data[0] * b.data[11] * b.data[14] -
                     b.data[8] * b.data[2] * b.data[15] +
                     b.data[8] * b.data[3] * b.data[14] +
                     b.data[12] * b.data[2] * b.data[11] -
                     b.data[12] * b.data[3] * b.data[10];

            ret.data[9] = -b.data[0] * b.data[9] * b.data[15] +
                      b.data[0] * b.data[11] * b.data[13] +
                      b.data[8] * b.data[1] * b.data[15] -
                      b.data[8] * b.data[3] * b.data[13] -
                      b.data[12] * b.data[1] * b.data[11] +
                      b.data[12] * b.data[3] * b.data[9];

            ret.data[13] = b.data[0] * b.data[9] * b.data[14] -
                      b.data[0] * b.data[10] * b.data[13] -
                      b.data[8] * b.data[1] * b.data[14] +
                      b.data[8] * b.data[2] * b.data[13] +
                      b.data[12] * b.data[1] * b.data[10] -
                      b.data[12] * b.data[2] * b.data[9];

            ret.data[2] = b.data[1] * b.data[6] * b.data[15] -
                     b.data[1] * b.data[7] * b.data[14] -
                     b.data[5] * b.data[2] * b.data[15] +
                     b.data[5] * b.data[3] * b.data[14] +
                     b.data[13] * b.data[2] * b.data[7] -
                     b.data[13] * b.data[3] * b.data[6];

            ret.data[6] = -b.data[0] * b.data[6] * b.data[15] +
                      b.data[0] * b.data[7] * b.data[14] +
                      b.data[4] * b.data[2] * b.data[15] -
                      b.data[4] * b.data[3] * b.data[14] -
                      b.data[12] * b.data[2] * b.data[7] +
                      b.data[12] * b.data[3] * b.data[6];

            ret.data[10] = b.data[0] * b.data[5] * b.data[15] -
                      b.data[0] * b.data[7] * b.data[13] -
                      b.data[4] * b.data[1] * b.data[15] +
                      b.data[4] * b.data[3] * b.data[13] +
                      b.data[12] * b.data[1] * b.data[7] -
                      b.data[12] * b.data[3] * b.data[5];

            ret.data[14] = -b.data[0] * b.data[5] * b.data[14] +
                       b.data[0] * b.data[6] * b.data[13] +
                       b.data[4] * b.data[1] * b.data[14] -
                       b.data[4] * b.data[2] * b.data[13] -
                       b.data[12] * b.data[1] * b.data[6] +
                       b.data[12] * b.data[2] * b.data[5];

            ret.data[3] = -b.data[1] * b.data[6] * b.data[11] +
                      b.data[1] * b.data[7] * b.data[10] +
                      b.data[5] * b.data[2] * b.data[11] -
                      b.data[5] * b.data[3] * b.data[10] -
                      b.data[9] * b.data[2] * b.data[7] +
                      b.data[9] * b.data[3] * b.data[6];

            ret.data[7] = b.data[0] * b.data[6] * b.data[11] -
                     b.data[0] * b.data[7] * b.data[10] -
                     b.data[4] * b.data[2] * b.data[11] +
                     b.data[4] * b.data[3] * b.data[10] +
                     b.data[8] * b.data[2] * b.data[7] -
                     b.data[8] * b.data[3] * b.data[6];

            ret.data[11] = -b.data[0] * b.data[5] * b.data[11] +
                       b.data[0] * b.data[7] * b.data[9] +
                       b.data[4] * b.data[1] * b.data[11] -
                       b.data[4] * b.data[3] * b.data[9] -
                       b.data[8] * b.data[1] * b.data[7] +
                       b.data[8] * b.data[3] * b.data[5];

            ret.data[15] = b.data[0] * b.data[5] * b.data[10] -
                      b.data[0] * b.data[6] * b.data[9] -
                      b.data[4] * b.data[1] * b.data[10] +
                      b.data[4] * b.data[2] * b.data[9] +
                      b.data[8] * b.data[1] * b.data[6] -
                      b.data[8] * b.data[2] * b.data[5];

            float det = b.data[0] * ret.data[0] + b.data[1] * ret.data[4] + b.data[2] * ret.data[8] + b.data[3] * ret.data[12];

            if (det == 0.0f)
                return null;

            det = a / det;

            for (int i = 0; i < DATA_COUNT; ++i)
                ret.data[i] *= det;

            return ret;
        }

        public static Matrix4x4 operator /(Matrix4x4 a, Matrix4x4 b)
        {
            return a * (1.0f / b);
        }

        public static readonly Matrix4x4 ZERO_MATRIX = new Matrix4x4(0.0f);
        public static readonly Matrix4x4 IDENTITY_MATRIX = new Matrix4x4(new float[DATA_COUNT]{
            1.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 1.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 1.0f, 0.0f,
            0.0f, 0.0f, 0.0f, 1.0f
            });
    }
}
