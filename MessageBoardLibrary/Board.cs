using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoardLibrary
{
    public class Board
    {
        Post[] posts;

        public Board()
        {
            posts = new Post[0];
        }

        public void AddPost(Post postToAdd) { }
        public void DisplayPosts() { }
        public void SortPostsChronologically() { }
    }
}
