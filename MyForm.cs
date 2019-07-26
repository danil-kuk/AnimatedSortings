using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using ZedGraph;

namespace AnimatedSorting
{
    class MyForm : Form
    {
        public ZedGraphControl zedGraph = new ZedGraphControl
        {
            Dock = DockStyle.Fill
        };

        List<double> data = new List<double>();

        public MyForm()
        {
            ClientSize = new Size(1000, 600);
            StartPosition = FormStartPosition.CenterScreen;
            zedGraph.GraphPane.XAxis.Title.Text = "X";
            zedGraph.GraphPane.YAxis.Title.Text = "Y";
            zedGraph.GraphPane.Title.Text = "Sort";
            Controls.Add(zedGraph);
            data = GenerateData(10);
            DrawGraph(data);

            zedGraph.KeyDown += (sender, args) => KeyAction(args);
        }

        private void KeyAction(KeyEventArgs key)
        {
            switch (key.KeyCode)
            {
                case Keys.Space:
                    {
                        SortData();
                        break;
                    }
                case Keys.D1:
                    {
                        Sortings.BubbleSort(this, data);
                        break;
                    }
                case Keys.D2:
                    {
                        Sortings.InsertionSort(this, data);
                        break;
                    }
                case Keys.D3:
                    {
                        Sortings.ShellSort(this, data);
                        break;
                    }
                case Keys.D4:
                    {
                        Sortings.SelectionSort(this, data);
                        break;
                    }
                case Keys.D5:
                    {
                        Sortings.QuickSort(this, data);
                        break;
                    }
                case Keys.R:
                    {
                        ResetData();
                        break;
                    }
                case Keys.X:
                    {
                        AddColumn();
                        break;
                    }
                case Keys.Z:
                    {
                        RemoveColumn();
                        break;
                    }
                case Keys.Escape:
                    {
                        Application.Exit();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void RemoveColumn()
        {
            if (data.Count > 0)
                data.RemoveAt(data.Count - 1);
            DrawGraph(data);
        }

        private void AddColumn()
        {
            data.Add(new Random().NextDouble());
            DrawGraph(data);
        }

        private void SortData()
        {
            zedGraph.GraphPane.Title.Text = "Sort";
            data.Sort();
            DrawGraph(data);
        }

        private void ResetData()
        {
            zedGraph.GraphPane.Title.Text = "Sort";
            data = GenerateData(data.Count);
            DrawGraph(data);
        }

        public void DrawGraph(ICollection<double> array)
        {
            GraphPane pane = zedGraph.GraphPane;
            pane.CurveList.Clear();

            var itemscount = array.Count;

            var barPosition = new double[itemscount];
            for (int i = 0; i < itemscount; i++)
            {
                barPosition[i] = i + 1;
            }

            pane.AddBar("", barPosition, array.ToArray(), Color.Blue);

            pane.XAxis.Scale.Min = 0;
            pane.XAxis.Scale.Max = itemscount + 1;
            pane.YAxis.Scale.Max = 1;
            pane.XAxis.Scale.MajorStepAuto = true;
            pane.XAxis.Scale.MinorStep = 1;

            zedGraph.AxisChange();
            zedGraph.Invalidate();
        }

        private List<double> GenerateData(int itemscount)
        {
            Random rnd = new Random();
            var values = new List<double>(); ;

            for (int i = 0; i < itemscount; i++)
            {
                values.Add(rnd.NextDouble());
            }
            return values;
        }
    }
}
