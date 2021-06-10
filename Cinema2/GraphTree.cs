using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema2
{
    public class GraphTree
    {
        List<Movie> movieList;
        int movieListDuration;

        Node root;
        public List<TimeTable> allTablesWithFreeTime = new List<TimeTable>();
        public GraphTree(List<Movie> list, int FreeTime)
        {
            movieList = list;
            movieListDuration = CalcMovieListDuration(movieList);
            if (movieListDuration < CinemaGraph.CinemaTimeOfWork)
            {
                root = new Node(FreeTime, new List<Movie>(movieList));
                root.RemainingTime -= movieListDuration;
            }
            else
            {
                root = new Node(FreeTime, new List<Movie>());
            }
        }

        public int CalcMovieListDuration(List<Movie> movieList)
        {
            foreach (var movie in movieList)
            {
                movieListDuration += movie.Duration;
            }
            return movieListDuration;
        }
        public void CreateTree()
        {
            CreateGraph(root);
        }

        public void CreateGraph(Node node)
        {
            foreach (var movie in movieList)
            {
                if (node.RemainingTime >= movie.Duration)
                {
                    List<Movie> tmp = new List<Movie>(node.CurrentMovies);
                    tmp.Add(movie);
                    Node newNode = new Node(node.RemainingTime - movie.Duration, tmp);
                    node.AddNext(newNode);
                    CreateGraph(newNode);
                }
            }

            bool b = true;
            foreach (var item in movieList)
            {
                if (node.RemainingTime >= item.Duration)
                { b = false; }
            }
            if (b)
            {
                TimeTable currentTable = new TimeTable();
                currentTable.FreeTime = node.RemainingTime;
                currentTable.Table = new List<Movie>();
                foreach (var value in node.CurrentMovies)
                {
                    currentTable.Table.Add(new Movie { Name = value.Name, Duration = value.Duration });
                }
                allTablesWithFreeTime.Add(currentTable);
            }
        }

        public TimeTable FindOptimalTable()
        {
            List<TimeTable> result = new List<TimeTable>(allTablesWithFreeTime);
            int minFreeTime = CinemaGraph.CinemaTimeOfWork;
            TimeTable optimalTable = new TimeTable();
            foreach (var item in result)
            {
                if (minFreeTime > item.FreeTime)
                {
                    minFreeTime = item.FreeTime;
                    optimalTable = item;
                }
            }
            return optimalTable;
        }
    }
}
