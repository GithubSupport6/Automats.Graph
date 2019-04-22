using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_про_граф.Graphs
{
    class Node
    {
        public List<KeyValuePair<String, Node>> links
        {
            get;
        }

        public String data
        {
            get;
        }

        public String tag
        {
            get;
            set;
        }

        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public int size
        {
            get;
            set;
        }

        public int centerX
        {
            get
            {
                return X + size / 2;
            }
        }

        public int centerY
        {
            get
            {
                return Y + size / 2;
            }
        }

        public bool isChecked
        {
            get;
            set;
        }

        public Node(String data)
        {
            isChecked = false;
            links = new List<KeyValuePair<string, Node>>();
            this.data = data;
            X = 50;
            Y = 50;
            this.size = 20;
        }

        public Node(String data, int x, int y) : this(data)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
