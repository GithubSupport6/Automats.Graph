using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Лаба_про_граф.Graphs;

namespace Лаба_про_граф
{
    public partial class Form1 : Form
    {
        int size = 30;
        private Graph graph;
        Node choosed;
        bool isClicked = false;
        bool isLinking = false;
        bool isMovedOnNode = false;


        int mouseX = 0;
        int mouseY = 0;

        int childNumber = 0;

        int step = 0;

        Node finded = new Node("");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nameBox.Enabled = false;
            timer1.Interval = 1;
            timer1.Enabled = true;
            stepButton.Visible = false;
        }


        private void initGraph()
        {
            Node root = new Node("root", Width / 2, Height / 2);
            root.tag = Graph.rootTag;
            root.size = 45;
            graph = new Graph(root);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nameBox.Text = "child" + childNumber;
            try
            {
                if (!nameBox.Enabled)
                {
                    initGraph();
                    nameBox.Enabled = true;
                    return;
                }
                
                Node toAdd = new Node(nameBox.Text, this.Width / 2 - 30, this.Height / 2 - 30);
                toAdd.size = 40;
                if (isFinalState.Checked) toAdd.tag = Graph.finalTag;

                graph.addNode(toAdd);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            childNumber++;
        }

        private void drawGraph(Graph graph, Graphics G)
        {
            subDraw(graph.root, G);
        }

        private void subDraw(Node root, Graphics G)
        {
            graph.forAll(e => {
                drawNode(e, G);
            }, (y,u)=> {
                KeyValuePair<float, float> pos = getCrossing(u, y.centerX, y.centerY);
                G.FillEllipse(Brushes.Blue, pos.Key - 3, pos.Value - 3, 6, 6);
                G.DrawLine(Pens.Blue, y.centerX, y.centerY, pos.Key, pos.Value);
            });
        }

        private KeyValuePair<float,float> getCrossing(Node node, int x, int y)
        {
            float absX = Math.Abs(node.centerX - x);
            float absY = Math.Abs(node.centerY - y);
            float hypotenuse = (float)Math.Sqrt(absX * absX + absY * absY);

            float sin = absY / hypotenuse;
            float cos = absX / hypotenuse;

            float newY = node.size/2 * sin;

            float newX = node.size/2 * cos;

            if (node.centerX < x)
            {
                newX = node.centerX + newX;
            }
            else
            {
                newX = node.centerX - newX;
            }
            if (node.centerY < y)
            {
                newY = node.centerY + newY;
            }
            else
            {
                newY = node.centerY - newY;
            }


            return new KeyValuePair<float, float>(newX, newY);
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                if (!isLinking)
                {
                    choosed = getNode(e.Location.X, e.Location.Y);
                    if (choosed!=null)
                    {
                        isLinking = true;
                    }
                }
                else
                {
                    Node h = getNode(e.Location.X, e.Location.Y);
                    if (h!=null)
                    {
                        graph.link(choosed, h, "new link");
                        isLinking = false;
                        //G.Clear(DefaultBackColor);
                        //drawGraph(graph);
                    }
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                if (!isClicked)
                {
                    choosed = getNode(e.X, e.Y);
                    if (choosed!=null)
                    {
                        isClicked = !isClicked;
                    }
                }
                else
                    isClicked = false;
                isLinking = false;
            }
            else if (e.Button == MouseButtons.Right)
            {
                nodeContext.Show(mouseX, mouseY);
                //choosed = getNode(e.Location.X, e.Location.Y);
                //choosed.links.Clear();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
            if (isLinking)
            {
                return;
            }
        
            if (isClicked)
            {
                choosed.X = e.X - choosed.size / 2;
                choosed.Y = e.Y - choosed.size / 2;
            }
            else if (graph!=null)
            {
                Node ifFinded = getNode(e.X, e.Y);
            }
        }

        private Node getNode(int x, int y)
        {
            if (graph == null)
            {
                return null;
            }
            foreach (Node n in graph.nodes)
            {
                if (Math.Sqrt(Math.Pow(x - n.centerX, 2) + Math.Pow(y - n.centerY, 2)) <= n.size)
                {
                    return n;
                }
            }
            return null;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (graph!=null)
            drawGraph(graph,e.Graphics);
            if (isLinking)
            {
                e.Graphics.DrawLine(Pens.Black, choosed.centerX, choosed.centerY, mouseX, mouseY);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            step = 0;
            stepButton.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (step)
            {
                case 0: graph.markIsolated(); step++; stepButton.Text = "Шаг 2"; statusStrip.Text = "Изолированные вершины помечены"; break;
                case 1: graph.deleteAllByTag(Graph.isolated); step++; stepButton.Text = "Шаг 3"; statusStrip.Text = "Изолированные вершины удалены"; break;
                case 2: graph.optimize(); step = 0; stepButton.Text = "Шаг 1"; statusStrip.Text = "Оптимизация выполнена"; break;
            }
        }

        private void drawNode(Node e, Graphics G)
        {
            if (e.tag == Graph.rootTag)
            {
                G.DrawEllipse(Pens.Green, e.X, e.Y, e.size, e.size);
                G.FillEllipse(Brushes.ForestGreen, e.X, e.Y, e.size, e.size);
                G.DrawString(e.data, DefaultFont, Brushes.Black, e.centerX, e.centerY);
            }
            else if (e.tag == Graph.isolated)
            {
                G.DrawEllipse(Pens.Yellow, e.X, e.Y, e.size, e.size);
                G.FillEllipse(Brushes.YellowGreen, e.X, e.Y, e.size, e.size);
                G.DrawString(e.data, DefaultFont, Brushes.Black, e.centerX, e.centerY);
            }
            else if (e.tag == Graph.finalTag)
            {
                G.DrawEllipse(Pens.Red, e.X, e.Y, e.size, e.size);
                G.DrawEllipse(Pens.Red, e.X-3, e.Y-3, e.size + 6, e.size + 6);
                G.DrawString(e.data, DefaultFont, Brushes.Black, e.centerX, e.centerY);
            }
                else
            {
                G.DrawEllipse(Pens.Red, e.X, e.Y, e.size, e.size);
                G.DrawString(e.data, DefaultFont, Brushes.Black, e.centerX, e.centerY);
            }
        }

        private void isFinalState_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void nodeContext_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
