using System;
using System.Collections.Generic;
using System.Threading;

namespace Assessed_Exercise_4_Graph
{
    class Program
    {
        public static void Main(string[] args)
        {

            Graph<string> myGraph = new Graph<string>();

            // Airport nodes in the graph
            myGraph.AddNode("BRU"); // Brussels - Brussels Airport (BRU)
            myGraph.AddNode("MAD"); // Madrid - Barajas Airport (MAD)
            myGraph.AddNode("BER"); // Berlin - Brandenburg Airport (BER) 
            myGraph.AddNode("CDG"); // Paris - Charles de Gaulle (CDG)
            myGraph.AddNode("MXP"); // Milan - Malpensa  (MXP)
            myGraph.AddNode("LCY"); // London - City Airport (LCY)
            myGraph.AddNode("WAW"); // Warsaw - Frédéric Chopin (WAW)
            myGraph.AddNode("LUX"); // Luxembourg - Luxembourg Airport (LUX)
            myGraph.AddNode("AMS"); // Amsterdam - Schiphol Airport (AMS)
            myGraph.AddNode("LIS"); // Lisboa - Humberto Delgado Airport (LIS) [10]

            var airports = new List<string> { "BRU", "MAD", "BER", "CDG", "MXP", "LCY", "WAW", "LUX", "AMS", "LIS" };

            // Add connections between the nodes. these are direct edges
            myGraph.AddEdge("MAD", "BRU"); // MAD => BRU (1)
            myGraph.AddEdge("BER", "MAD"); // BER => MAD (2)
            myGraph.AddEdge("MAD", "LCY"); // MAD => LCY (3)
            myGraph.AddEdge("MAD", "CDG"); // MAD => CDG (4)
            myGraph.AddEdge("CDG", "LIS"); // CDG => LIS (5)
            myGraph.AddEdge("AMS", "CDG"); // AMS => CDG (6)
            myGraph.AddEdge("LUX", "AMS"); // LUX => AMS (7)
            myGraph.AddEdge("WAW", "LUX"); // WAW => LUX (8)
            myGraph.AddEdge("MXP", "WAW"); // MXP => WAW (9)
            myGraph.AddEdge("MXP", "BER"); // MXP => BER (10)
            myGraph.AddEdge("MXP", "LCY"); // MXP => LCY (11)

            while (true)
            {

                Console.WriteLine("|----------------------------------------------|");
                Console.WriteLine("|           Choice your destination            |");
                Console.WriteLine("|  Direct flights from the following airports: |");
                Console.WriteLine("|----------------------------------------------|");
                Console.WriteLine("|                 MAD => BRU (1)               |");
                Console.WriteLine("|                 BER => MAD (2)               |");
                Console.WriteLine("|                 MAD => LCY (3)               |");
                Console.WriteLine("|                 MAD => CDG (4)               |");
                Console.WriteLine("|                 CDG => LIS (5)               |");
                Console.WriteLine("|                 AMS => CDG (6)               |");
                Console.WriteLine("|                 LUX => AMS (7)               |");
                Console.WriteLine("|                 WAW => LUX (8)               |");
                Console.WriteLine("|                 MXP => WAW (9)               |");
                Console.WriteLine("|                 MXP => BER (10)              |");
                Console.WriteLine("|                 MXP => LCY (11)              |");
                Console.WriteLine("|----------------------------------------------|");

                Console.Write("Type here airport you want to remove: ");
                string airportRemoved = Console.ReadLine();
                // myGraph.RemoveEdge(airportRemoved, myGraph.GetNodeByID(airportRemoved).DisplayAdjList());
                // myGraph.DeleteNode(airportRemoved);

                if (airportRemoved == "CDG")
                {
                    myGraph.RemoveEdge(airportRemoved, myGraph.GetNodeByID(airportRemoved).DisplayAdjList());
                    myGraph.RemoveEdge("MAD", airportRemoved);
                    myGraph.RemoveEdge("AMS", airportRemoved);
                    myGraph.DeleteNode(airportRemoved);
                }

                // myGraph.GetNodeByID(airportRemoved).GetAdjList();

                Console.Write("Enter here the airport code where you want to travel from: ");
                string startingAirport = Console.ReadLine();

                if (airports.Contains(startingAirport))
                {
                    Console.WriteLine("|--------------------------------------------------------|");
                    Console.Write("  Airports that can be reached from {0}: => ",
                        myGraph.GetNodeByID(startingAirport).ID);
                    Console.WriteLine(myGraph.GetNodeByID(startingAirport).DisplayAdjList());
                    Console.WriteLine("|--------------------------------------------------------|");
                }

                if (!airports.Contains(startingAirport))
                {
                    Console.WriteLine("!!Error!! Type a correct airport code from the table");
                }

                Console.WriteLine("Number of nodes in the graph: " + myGraph.NumNodesGraph());
                Console.WriteLine("Number of edges in the graph: " + myGraph.NumEdgesGraph());

                Thread.Sleep(5000);
            }
        }
    }
}
