////////////////////////////////////////////////////////////
//Title:   Generic Graph                                  //
//Author:  Chin Okoronkwo <chinwendu.okoronkwo@gmail.com> //
//Date:    July 19, 2018                                  //
//Comment: See README file                                //
////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;

namespace Graph
{
    class Program
    {
		public class Graph<T>
		{
			public Graph() { }
			public Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges)
			{
				foreach (var vertex in vertices)
				{
					AddVertex(vertex);
				}
				foreach (var edge in edges)
				{
					AddEdge(edge);
				}
			}

			public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();

			public void AddVertex(T vertex)
			{
				AdjacencyList[vertex] = new HashSet<T>();
			}
			public void AddEdge(Tuple<T, T> edge)
			{
				if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
				{
					AdjacencyList[edge.Item1].Add(edge.Item2);
					AdjacencyList[edge.Item2].Add(edge.Item1);
				}
			}

			public void Print()
			{
				foreach(KeyValuePair<T, HashSet<T>> r in AdjacencyList)
				{
					Console.Write(r.Key + " : ");
					foreach (var v in r.Value)
					{
						Console.Write(String.Join(",", v));
					}
					Console.WriteLine();
				}
			}
		}
		public class Permutations<T>
		{
			public Graph<T> g { get; set; }
			public List<HashSet<T>> ListOfPaths { get; set; }
			public Dictionary<T, List<HashSet<T>>> AllPaths { get; }
			
			public Permutations(Graph<T> g)
			{
				this.g = g;
				ListOfPaths = new List<HashSet<T>>();
				AllPaths = new Dictionary<T, List<HashSet<T>>>();
			}

			public Dictionary<T, List<HashSet<T>>> GetPermutations(T begin, T end)
			{
				HashSet<T> currentPath = new HashSet<T>();
				var list = g.AdjacencyList[begin];

				foreach (var v in list)
				{
					currentPath = new HashSet<T>();
					currentPath.Add(begin);
					FindValidPathToEnd(v, end, currentPath);
				}

				AllPaths.Add(begin, ListOfPaths);
				return AllPaths;
			}

			private void FindValidPathToEnd(T listKey, T end, HashSet<T> currentPath)
			{
				var sublist = g.AdjacencyList[listKey];

				if (sublist.Contains(end))
				{
					currentPath.Add(listKey);
					currentPath.Add(end);
					ListOfPaths.Add(currentPath);

					HashSet<T> newPath = new HashSet<T>(currentPath);
					newPath.Remove(end);
					foreach (var v in sublist)
					{
						if (!newPath.Contains(v))
						{
							newPath.Add(v);
						}
					}
					ListOfPaths.Add(newPath);
				}				
			}
		}
		public class Algoritms
		{
			public HashSet<T> DftBegin<T>(Graph<T> graph, T start)
			{
				var visited = new HashSet<T>();
				bool finished = false;

				if (!graph.AdjacencyList.ContainsKey(start))
				{
					return visited;
				}

				var stack = new Stack<T>();
				stack.Push(start);

				while (stack.Count > 0 && !finished)
				{
					var vertex = stack.Pop();

					if (visited.Contains(vertex))
						continue;

					visited.Add(vertex);

					foreach (var av in graph.AdjacencyList[vertex])
					{
						if (!visited.Contains(av))
						{
							stack.Push(av);
						}
					}
				}
				return visited;
			}

			public HashSet<T> DftBeginEnd<T>(Graph<T> graph, T begin, T end)
			{
				var visited = new HashSet<T>();
				bool finished = false;

				if (!graph.AdjacencyList.ContainsKey(begin))
				{
					return visited;
				}

				var stack = new Stack<T>();
				stack.Push(begin);

				while (stack.Count > 0 && !finished)
				{
					var vertex = stack.Pop();

					if (visited.Contains(vertex))
						continue;

					visited.Add(vertex);

					foreach (var av in graph.AdjacencyList[vertex])
					{
						if (!visited.Contains(av))
						{
							stack.Push(av);
							if (EqualityComparer<T>.Default.Equals(av, end))
							{
								finished = true;
								break;
							}
						}
					}
				}
				return visited;
			}
		}
				
		static void Main(string	[] args)
        {
			var vertices = new[] { 'A','B','C','D' };
			var edges = new[]{Tuple.Create('A','B'), Tuple.Create('B', 'A'),
							  Tuple.Create('A','C'), Tuple.Create('C','A'),
							  Tuple.Create('A','D'), Tuple.Create('D','A'),
							  Tuple.Create('B','C'), Tuple.Create('B','D')};

			var graph = new Graph<char>(vertices, edges);
			
			var perms = new Permutations<char>(graph);

			var result = perms.GetPermutations('C', 'D');

			foreach (KeyValuePair<char, List<HashSet<char>>> tp in result)
			{
				foreach (var v in tp.Value)
				{
					Console.WriteLine("[{0}]",string.Join(",",v));
				}
			}

			Console.ReadLine();
		}
	}
}
			
