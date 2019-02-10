using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoardLibrary
{
    public class Post
    {
        public Account Author;
        public string Message;
        public DateTime timePosted;

        public Post(Account Author)
        {
            this.Author = Author;
            this.Message = "";
            this.timePosted = DateTime.Now;
        }

        public Post(Account Author, string Message)
        {
            this.Author = Author;
            this.Message = Message;
            this.timePosted = DateTime.Now;
        }

        public override string ToString()
        {
            return "\t" + this.Author.FullName + " : '" + this.Message + "'";
        }
    }
}
