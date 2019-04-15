using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_про_граф.Graphs
{
    class Node
    {
        public LinkedList<KeyValuePair<String, Node>> links
        {
            get;
        }

        public String data
        {
            get;
        }

        public Node(String data)
        {
            links = new LinkedList<KeyValuePair<string, Node>>();
        }
    }
}
