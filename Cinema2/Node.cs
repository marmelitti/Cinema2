using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema2
{
    public class Node
    {
        public int RemainingTime { get; set; }
        public List<Movie> CurrentMovies;
        public List<Node> Next { get; set; }
        public Node(int freeTime, List<Movie> currentMovies)
        {
            RemainingTime = freeTime;
            CurrentMovies = currentMovies;
            Next = new List<Node>();
        }

        public void AddNext(Node node)
        {
            Next.Add(node);
        }
    }
}
