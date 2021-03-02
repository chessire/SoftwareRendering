using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using SoftwareRendering.Math;

namespace SoftwareRendering.Rendering
{
    class Model
    {
        private Vector3 position = new Vector3();
        private Vector3 rotate = new Vector3();
        private Vector3 scale = new Vector3();

        private List<Vector3> vertices;
        private List<Index> indices;

        public Model(List<Vector3> vertices, List<Index> indices)
        {
            this.vertices = vertices;
            this.indices = indices;
        }

        private void ProcessVertices()
        {
        }

        public void OnPaint(PaintEventArgs e)
        {
            ProcessVertices();

            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            e.Graphics.DrawLine(pen, 20, 10, 300, 100);
        }
    }
}
