using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinCut
{
    public partial class Form2 : Form
    {
        private readonly int _radius = 20;
        private List<int> contractedVertices { get; set; }
        private List<Edge> edges { get; set; }
        private int vertices;
        public Form2(List<int> contractedVertices , List<Edge> edges , int vertices)
        {
            this.edges = edges;
            this.contractedVertices = contractedVertices;
            this.vertices = vertices;
            this.Height = 800;
            this.Width = 800;
            InitializeComponent();

        }

        private void Draw(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            
            // creating graph coordinates 
            var angle = Math.PI*2 / vertices;
            PointF center = new PointF(400F, 400F);

            var points = Enumerable.Range(0, vertices).Select(i => PointF.Add(center, new SizeF(Convert.ToSingle(Math.Sin(i * angle) * 100.0),
                                      Convert.ToSingle(Math.Cos(i * angle) * 100.0)))).ToArray();

            // drawing edges
            for (int i = 0; i < edges.Count; i++)
            {   
                if(contractedVertices.Contains(edges[i].Src) && contractedVertices.Contains(edges[i].Dest))
                    graphics.DrawLine(Pens.Black, points[edges[i].Src], points[edges[i].Dest]);
                else
                    graphics.DrawLine(Pens.Red, points[edges[i].Src], points[edges[i].Dest]);
            }

            // drawing vertices 
            foreach (var p in points.ToArray())
            {
                graphics.DrawEllipse(Pens.Yellow, p.X - _radius, p.Y - _radius, 2 * _radius, 2 * _radius);
                graphics.FillEllipse(Brushes.Yellow, p.X - _radius, p.Y - _radius, 2 * _radius, 2 * _radius);
            }

            e.Dispose();
        }
    }
}
