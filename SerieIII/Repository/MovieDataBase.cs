using SerieIII.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeBInDisk.Tree;

namespace SerieIII.Repository
{
    public class MovieDataBase
    {
        Tree<Movie> myTree = new Tree<Movie>;
        public string GetMovie()
        { 
            return myTree.PrintInOrder();
        }

        public string inorden()
        {            
            return myTree.PrintInOrder(); 
        }

        public string postorden()
        {
            return myTree.PrintPostOrder();
        }

        public string preorden()
        {
            return myTree.PrintPreOrder();
        }


        public void AddNewMovie(string MovieName, Movie newMovie)
        {
            myTree.Add(newMovie);
        }

        public void addOrderTree(int orden)
        {
            
        }

        public void deleteCompleteTree()
        {
            myTree.Delete();
        }

        public void deleteElement(string element)
        {

        }

    }
}
