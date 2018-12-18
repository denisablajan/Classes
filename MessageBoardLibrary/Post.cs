using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoardLibrary
{
    public class Post
    {
        User Author;
        string Message;

        public Post(User Author, string Message)
        {
            this.Author = Author;
            this.Message = Message;
        }

        public void CreatePost() { }
    }
}
