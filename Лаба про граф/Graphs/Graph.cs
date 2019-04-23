using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Лаба_про_граф.Graphs;

namespace Лаба_про_граф
{
    class Graph
    {
        public const string isolated = "ISOLATED";
        public const string rootTag = "ROOT";
        public const string finalTag = "FINAL";
        public const string defaultTag = "DEFAULT";

        public delegate void nodeCallback(Node n);
        public delegate void nodeToLinkCallback(Node n, Node link);


        public List<Node> nodes
        {
            get;
        }

        public List<Node> tempNodes;

        public Node root
        {
            get;
        }

        public Graph(String rootData)
        {
            nodes = new List<Node>();
            root = new Node(rootData);
            nodes.Add(root);
        }

        public Graph(Node root)
        {
            nodes = new List<Node>();
            this.root = root;
            nodes.Add(root);
        }

        public void addNode(Node to, Node added, String linkData)
        {
            to.links.Add(new KeyValuePair<string, Node>(linkData,added));
            nodes.Add(added);
        }

        public void addNode(Node node)
        {
            nodes.Add(node);
        }

        private Node finded;

        public Node depthSearh(String data)
        {
            
            subSearh(root, data);
            return finded;
        }

        private void subSearh(Node currNode, String data)
        {
            currNode.isChecked = true;
            if (currNode.data == data)
            {
                finded = currNode;
            }
            foreach (var n in currNode.links)
            {
                if (!n.Value.isChecked)
                {
                    subSearh(n.Value, data);
                }
            }
            currNode.isChecked = false;
        }

        public void forAllExceptIsolated(nodeCallback nodeCallback)
        {
            forAllSub(nodeCallback, root);
        }

        public void forAll(nodeCallback callback)
        {
            tempNodes = new List<Node>();
            forAllSub(callback, root);
            forIsoalted(callback);
            tempNodes.Clear();
        }

        private void forAllSub(nodeCallback callback, Node currNode)
        {
            currNode.isChecked = true;
            tempNodes.Add(currNode);
            callback(currNode);
            foreach (var n in currNode.links)
            {
                if (!n.Value.isChecked)
                {
                    forAllSub(callback, n.Value);
                }
            }
            currNode.isChecked = false;
        }

        public void forAll(nodeCallback nodeCallback, nodeToLinkCallback linkCallback)
        {
            tempNodes = new List<Node>();
            forAllSub(nodeCallback, linkCallback, root);
            forIsoalted(nodeCallback, linkCallback);
            tempNodes.Clear();
        }

        private void forAllSub(nodeCallback nodeCallback, nodeToLinkCallback linkCallback, Node currNode)
        {
            currNode.isChecked = true;
            tempNodes.Add(currNode);
            nodeCallback(currNode);
            foreach (var n in currNode.links)
            {
                linkCallback(currNode, n.Value);
                if (!n.Value.isChecked)
                {
                    forAllSub(nodeCallback, linkCallback, n.Value);
                }
            }
            currNode.isChecked = false;
        }

        private void forIsoalted(nodeCallback nodeCallback)
        {
            foreach (Node n in nodes)
            {
                if (!tempNodes.Contains(n))
                {
                    forAllSub(nodeCallback, n);
                }
            }
        }

        private void forIsoalted(nodeCallback nodeCallback, nodeToLinkCallback linkCallback)
        {
            foreach (Node n in nodes)
            {
                if (!tempNodes.Contains(n))
                {
                    forAllSub(nodeCallback, linkCallback, n);
                }
            }
        }

        public void link(Node from, Node to, String linkData)
        {
            if (from.links.Select(e => e.Value).Contains(to))
            {
                var link = from.links.Find(e => e.Value == to);
                if (link.Key != linkData)
                {
                    linkData = link.Key + linkData;
                }
            }
            from.links.Add(new KeyValuePair<string, Node>(linkData,to));
            forAllSub(e => { if (e.tag == Graph.isolated)
                    e.tag = Graph.defaultTag;},
                    to);
        }

        public void markIsolated()
        {
            tempNodes = new List<Node>();
            forAllSub(e => { }, root);
            foreach (Node n in nodes)
            {
                if (!tempNodes.Contains(n))
                {
                    n.tag = isolated;
                }
                
            }
        }

        public void deleteByData(String data)
        {
            Node finded = depthSearh(data);
            if (finded!=null)
            delete(finded);
        }

        public void deleteFirstByTag(String tag)
        {
            Node finded = null;
            forAll(e => { if (e.tag == tag) finded = e; });
            if (finded!=null)
            delete(finded);
        }

        public void deleteAllByTag(String tag)
        {
            List<Node> finded = new List<Node>();
            forAll(e => { if (e.tag == tag) finded.Add(e); });
            foreach (Node n in finded)
            {
                delete(n);
            }
        }

        public void delete(Node node)
        {
            foreach (Node n in nodes)
            {
                n.links.RemoveAll(e => { return e.Value == node; });
            }
            nodes.Remove(node);
        }

        public void optimize()
        {
            List<Node> allStates = new List<Node>();
            List<Node> endStates = new List<Node>();
            foreach (Node n in nodes)
            {
                if (n.tag == Graph.finalTag)
                {
                    endStates.Add(n);
                }
                else allStates.Add(n);
            }
            bool isChanged = true;
            while(isChanged)
            {
                isChanged = false;
                //Для каждого конечного состояния
                //Собрать все узлы, ведущие в конечное сотояние
                
                //Сгрупировать узлы по символам
                //Создать из них конечные состояния
                foreach (var finalState in endStates)
                {
                    var temp = nodes.Where(
                        e =>
                        {
                            return e.links.Select(
                         u => u.Value).Contains(finalState);
                        });
                    var grouped = temp.GroupBy(
                        e => e.links.Find(
                            u => { return u.Value == finalState; }).Key);

                }

            }
            

            //nodes.All(e => {if (e.tag == Graph.finalTag) endStates.Add(e) })

        }

        private Node uniteToFinalState(List<Node> nodes)
        {
            string resData = "";
            nodes.ForEach(node => resData += (node.data + " "));
            Node res = new Node(resData);
            //nodes.ForEach(node =>
            //{if (res.links.Contains(node)) })
            return null;
        }
          
    }
}
