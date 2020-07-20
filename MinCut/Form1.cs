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
    public partial class Form1 : Form
    {
        List<Edge> edges = new List<Edge>();
        List<int> vertices = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int src = Int32.Parse(textBox1.Text);
                int dest = Int32.Parse(textBox2.Text);
                Edge edge = new Edge(src , dest);
                if (!edges.Contains(edge))
                {
                    edges.Add(edge);
                }

                if (!vertices.Contains(src))
                {
                    vertices.Add(src);
                }

                if (!vertices.Contains(dest))
                {
                    vertices.Add(dest);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("INVALID INPUTS!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                textBox2.Text = "";
                return;
            }

            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graph graph = new Graph(edges, vertices.Count);
            int cuts =  graph.MinCut();
            MessageBox.Show("MinCut Result: " + cuts, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form2 form2 = new Form2(graph.contractedVertices, graph.edges, vertices.Count);
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            edges.Clear();
            vertices.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
