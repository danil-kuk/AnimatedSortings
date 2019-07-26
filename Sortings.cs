using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimatedSorting
{
    static class Sortings
    {
        public static void BubbleSort(MyForm form, List<double> data)
        {
            form.zedGraph.GraphPane.Title.Text = "BubbleSort";
            for (int i = 0; i < data.Count - 1; i++)
            {
                for (int j = 0; j < data.Count - i - 1; j++)
                {
                    if (data[j] > data[j + 1])
                    {
                        var temp = data[j + 1];
                        data[j + 1] = data[j];
                        data[j] = temp;
                        form.DrawGraph(data);
                        form.zedGraph.Refresh();
                    }
                }
            }
            form.DrawGraph(data);
            form.zedGraph.Refresh();
        }

        public static void InsertionSort(MyForm form, List<double> data)
        {
            form.zedGraph.GraphPane.Title.Text = "InsertionSort";
            for (int i = 1; i < data.Count; i++)
            {
                var cur = data[i];
                int j = i;
                while (j > 0 && cur < data[j - 1])
                {
                    data[j] = data[j - 1];
                    j--;
                    form.DrawGraph(data);
                    form.zedGraph.Refresh();
                }
                data[j] = cur;
            }
            form.DrawGraph(data);
            form.zedGraph.Refresh();
        }

        public static void ShellSort(MyForm form, List<double> data)
        {
            form.zedGraph.GraphPane.Title.Text = "ShellSort";
            int step = data.Count / 2;
            while (step > 0)
            {
                int i, j;
                for (i = step; i < data.Count; i++)
                {
                    var value = data[i];
                    for (j = i - step; (j >= 0) && (data[j] > value); j -= step)
                        data[j + step] = data[j];
                    data[j + step] = value;
                    form.DrawGraph(data);
                    form.zedGraph.Refresh();
                }
                step /= 2;
            }
            form.DrawGraph(data);
            form.zedGraph.Refresh();
        }

        public static void SelectionSort(MyForm form, List<double> data)
        {
            form.zedGraph.GraphPane.Title.Text = "SelectionSort";
            int min;
            double temp;
            int length = data.Count;

            for (int i = 0; i < length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < length; j++)
                {
                    if (data[j] < data[min])
                    {
                        min = j;
                    }
                    form.DrawGraph(data);
                    form.zedGraph.Refresh();
                }
                if (min != i)
                {
                    temp = data[i];
                    data[i] = data[min];
                    data[min] = temp;
                }
                form.DrawGraph(data);
                form.zedGraph.Refresh();
            }
            form.DrawGraph(data);
            form.zedGraph.Refresh();
        }

        public static void QuickSort(MyForm form, List<double> data)
        {
            form.zedGraph.GraphPane.Title.Text = "QuickSort";
            QuickSort(form, data, 0, data.Count - 1);
            form.DrawGraph(data);
            form.zedGraph.Refresh();
        }
        private static void QuickSort(MyForm form, List<double> data, int left, int right)
        {
            var i = left;
            var j = right;
            var x = data[(left + right) / 2];
            while (true)
            {
                form.DrawGraph(data);
                form.zedGraph.Refresh();
                while (data[i] < x)
                    i++;
                while (x < data[j])
                    j--;
                form.DrawGraph(data);
                form.zedGraph.Refresh();
                if (i <= j)
                {
                    var temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                }
                form.DrawGraph(data);
                form.zedGraph.Refresh();
                if (i > j)
                    break;
            }
            if (left < j)
                QuickSort(form, data, left, j);
            if (i < right)
                QuickSort(form, data, i, right);
        }
    }
}
