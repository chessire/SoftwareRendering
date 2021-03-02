using System.Linq;
using System.Runtime.InteropServices;

namespace SoftwareRendering.Math
{
    [StructLayout(LayoutKind.Explicit)]
    class Vector4
    {
        [FieldOffset(0)]
        private float[] data;

        [FieldOffset(0)]
        public float x;
        [FieldOffset(4)]
        public float y;
        [FieldOffset(8)]
        public float z;
        [FieldOffset(12)]
        public float w;

        [FieldOffset(0)]
        public float r;
        [FieldOffset(4)]
        public float g;
        [FieldOffset(8)]
        public float b;
        [FieldOffset(12)]
        public float a;

        public float this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }

        public Vector4()
            : this(0.0f)
        {
        }

        public Vector4(float scalar)
            : this(scalar, scalar, scalar, scalar)
        {
        }

        public Vector4(Vector4 other)
            : this(other.x, other.y, other.z, other.w)
        {
        }

        public Vector4(float x, float y, float z, float w)
        {
            data = new float[4] { x, y, z, w };
        }

        public static Vector4 operator +(Vector4 a, Vector4 b)
        {
            Vector4 result = new Vector4(a);

            result[0] += b[0];
            result[1] += b[1];
            result[2] += b[2];
            result[3] += b[3];

            return result;
        }

        public static Vector4 operator -(Vector4 a, Vector4 b)
        {
            Vector4 result = new Vector4(a);

            result[0] -= b[0];
            result[1] -= b[1];
            result[2] -= b[2];
            result[3] -= b[3];

            return result;
        }

        public static Vector4 operator +(Vector4 a, float b)
        {
            Vector4 result = new Vector4(a);

            result[0] += b;
            result[1] += b;
            result[2] += b;
            result[3] += b;

            return result;
        }

        public static Vector4 operator -(Vector4 a, float b)
        {
            Vector4 result = new Vector4(a);

            result[0] -= b;
            result[1] -= b;
            result[2] -= b;
            result[3] -= b;

            return result;
        }

        public static Vector4 operator *(Vector4 a, float b)
        {
            Vector4 result = new Vector4(a);

            result[0] *= b;
            result[1] *= b;
            result[2] *= b;
            result[3] *= b;

            return result;
        }

        public static Vector4 operator /(Vector4 a, float b)
        {
            Vector4 result = new Vector4(a);

            result[0] /= b;
            result[1] /= b;
            result[2] /= b;
            result[3] /= b;

            return result;
        }

        public static float Dot(Vector4 a, Vector4 b)
        {
            return a[0] * b[0] +
                a[1] * b[1] +
                a[2] * b[2] +
                a[3] *b[3];
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    class Vector3
    {
        [FieldOffset(0)]
        private float[] data;

        [FieldOffset(0)]
        public float x;
        [FieldOffset(4)]
        public float y;
        [FieldOffset(8)]
        public float z;

        [FieldOffset(0)]
        public float r;
        [FieldOffset(4)]
        public float g;
        [FieldOffset(8)]
        public float b;

        [FieldOffset(0)]
        public float u;
        [FieldOffset(4)]
        public float v;
        [FieldOffset(8)]
        public float w;

        public float this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }

        public Vector3()
            : this(0.0f)
        {
        }

        public Vector3(float scalar)
            : this(scalar, scalar, scalar)
        {
        }

        public Vector3(Vector3 other)
            : this(other.x, other.y, other.z)
        {
        }

        public Vector3(float x, float y, float z)
        {
            data = new float[3] { x, y, z };
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            Vector3 result = new Vector3(a);

            result[0] += b[0];
            result[1] += b[1];
            result[2] += b[2];

            return result;
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            Vector3 result = new Vector3(a);

            result[0] -= b[0];
            result[1] -= b[1];
            result[2] -= b[2];

            return result;
        }

        public static Vector3 operator +(Vector3 a, float b)
        {
            Vector3 result = new Vector3(a);

            result[0] += b;
            result[1] += b;
            result[2] += b;

            return result;
        }

        public static Vector3 operator -(Vector3 a, float b)
        {
            Vector3 result = new Vector3(a);

            result[0] -= b;
            result[1] -= b;
            result[2] -= b;

            return result;
        }

        public static Vector3 operator *(Vector3 a, float b)
        {
            Vector3 result = new Vector3(a);

            result[0] *= b;
            result[1] *= b;
            result[2] *= b;

            return result;
        }

        public static Vector3 operator /(Vector3 a, float b)
        {
            Vector3 result = new Vector3(a);

            result[0] /= b;
            result[1] /= b;
            result[2] /= b;

            return result;
        }

        public static float Dot(Vector3 a, Vector3 b)
        {
            return a[0] * b[0] +
                a[1] * b[1] +
                a[2] * b[2];
        }

        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            return new Vector3(
                a[2] * b[3] - a[3] * b[2],
                a[3] * b[1] - a[1] * b[3],
                a[1] * b[2] - a[2] * b[1]
                );
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    class Vector2
    {
        [FieldOffset(0)]
        private float[] data;

        [FieldOffset(0)]
        public float x;
        [FieldOffset(4)]
        public float y;

        [FieldOffset(0)]
        public float r;
        [FieldOffset(4)]
        public float g;

        [FieldOffset(0)]
        public float u;
        [FieldOffset(4)]
        public float v;

        public float this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }

        public Vector2()
            : this(0.0f)
        {
        }

        public Vector2(float scalar)
            : this(scalar, scalar)
        {
        }

        public Vector2(Vector2 other)
            : this(other.x, other.y)
        {
        }

        public Vector2(float x, float y)
        {
            data = new float[2] { x, y };
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            Vector2 result = new Vector2(a);

            result[0] += b[0];
            result[1] += b[1];

            return result;
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            Vector2 result = new Vector2(a);

            result[0] -= b[0];
            result[1] -= b[1];

            return result;
        }

        public static Vector2 operator +(Vector2 a, float b)
        {
            Vector2 result = new Vector2(a);

            result[0] += b;
            result[1] += b;

            return result;
        }

        public static Vector2 operator -(Vector2 a, float b)
        {
            Vector2 result = new Vector2(a);

            result[0] -= b;
            result[1] -= b;

            return result;
        }

        public static Vector2 operator *(Vector2 a, float b)
        {
            Vector2 result = new Vector2(a);

            result[0] *= b;
            result[1] *= b;

            return result;
        }

        public static Vector2 operator /(Vector2 a, float b)
        {
            Vector2 result = new Vector2(a);

            result[0] /= b;
            result[1] /= b;

            return result;
        }

        public static float Dot(Vector2 a, Vector2 b)
        {
            return a[0] * b[0] +
                a[1] * b[1];
        }
    }
}
