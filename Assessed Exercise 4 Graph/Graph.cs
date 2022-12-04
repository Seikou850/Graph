using System;
using System.Collections.Generic;

namespace Assessed_Exercise_4_Graph
{
    public class Graph<T> where T : IComparable
    {
        // list of all the nodes in the graph.
        private LinkedList<GraphNode<T>> nodes;
        private int counteredges;

        // constructor – set nodes to new empty list
        public Graph()
        {
            nodes = new LinkedList<GraphNode<T>>();
        }

        // only returns true if the graph’s list of nodes is empty
        public bool IsEmptyGraph()
        {
            return nodes.Count == 0;
        }
        
        // add a new node (with this “id”) to the list of nodes of the graph
        public void AddNode(T id)
        {
            nodes.AddLast(new GraphNode<T>(id));
        }
        public void DeleteNode(T id)
        {
            nodes.Remove(GetNodeByID(id));

        }
        
        // only returns true if node is present in the graph
        public bool ContainsGraph(GraphNode<T> node)
        {
            foreach (GraphNode<T> n in nodes)
            {
                if (n.ID.CompareTo(node.ID) == 0)
                {
                    return true;
                }

            }
            return false;
        }
        
        //returns the node with this id
        public GraphNode<T> GetNodeByID(T id)
        {
            foreach (GraphNode<T> n in nodes)
            {
                if (id.CompareTo(n.ID)==0) return n;
            }
            return null;
        }
        
        // Directed edge between the node with id "from" and the node with id “to” 
        public void AddEdge(T from, T to)
        {
            GraphNode<T> n1 = GetNodeByID(from);
            GraphNode<T> n2 = GetNodeByID(to);


            if (n1 != null & n2 != null)
            {
                n1.AddEdge(n2);
                counteredges++;
            }
            else
                Console.WriteLine("Node/s not found in the graph. Cannot add the edge");
        }
        
        public void RemoveEdge(T from, T to)
        {
            GraphNode<T> n1 = GetNodeByID(from);
            GraphNode<T> n2 = GetNodeByID(to);
            
            if (n1 != null & n2 != null)
            {
                n1.RemoveEdge(n2);
                counteredges--;
            }
            else
                Console.WriteLine("Node/s not found in the graph. Cannot remove the edge");
        }
        
        // only returns true if nodes “from “ and “to” are adjacent
        public bool IsAdjacent(GraphNode<T> from, GraphNode<T> to)
        {
            foreach (GraphNode<T> n in nodes)
            {

                if (n.ID.CompareTo(from.ID) == 0)
                {
                    if (from.GetAdjList().Contains(to.ID))
                    {
                        return true;
                    }

                    return false;
                }
            }
            return false;
        }
        
        // returns the total number of nodes present in the graph
        public int NumNodesGraph()
        {
            return nodes.Count;
        }
        
        // returns the total number of edges present in the graph
        public int NumEdgesGraph()
        {
            return counteredges;
        }

    }
}