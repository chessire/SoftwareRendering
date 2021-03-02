using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftwareRendering.Math;
using SoftwareRendering.Rendering;

namespace SoftwareRendering
{
    public partial class Form1 : Form
    {
        Model model;

        public Form1()
        {
            InitializeComponent();
            model = new Model(
                new List<Vector3>{
                    new Vector3(-0.5f, -0.5f, 0.5f),
                    new Vector3(0.5f, -0.5f, 0.5f),
                    new Vector3(0.5f, 0.5f, 0.5f),
                    new Vector3(0.0f, 0.5f, 0.5f),
                    new Vector3(-0.5f, -0.5f, -0.5f),
                    new Vector3(0.5f, -0.5f, -0.5f),
                    new Vector3(0.5f, 0.5f, -0.5f),
                    new Vector3(0.0f, 0.5f, -0.5f)
                },
                new List<Index>{
                    // front
                    new Index(0, 1, 2),
                    new Index(0, 2, 3),
                    // left
                    new Index(4, 0, 3),
                    new Index(4, 3, 7),
                    // back
                    new Index(5, 4, 7),
                    new Index(5, 7, 6),
                    // right
                    new Index(1, 5, 6),
                    new Index(1, 6, 2),
                }
            );
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            model.OnPaint(e);
        }
    }
}
