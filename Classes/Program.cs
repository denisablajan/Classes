using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageBoardLibrary;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            User denisa = new User("denisablajan@gmail.com", "koalabear", "Denisa", "Blajan", new DateTime(1999, 04, 08));
            User cosmin = new User("cosminbalauta@gmail.com", "kangaroo", "Cosmin", "Balauta", new DateTime(1996, 02, 18));

            denisa.CreateAccount();
            cosmin.CreateAccount();

            Post messageFromDenisa = new Post(denisa, "Hello everyone!");
            Post messageFromCosmin = new Post(cosmin, "How are you today?");

            messageFromDenisa.CreatePost();
            messageFromCosmin.CreatePost();

            Board messagesBoard = new Board();
            messagesBoard.AddPost(messageFromDenisa);
            messagesBoard.AddPost(messageFromDenisa);
            messagesBoard.SortPostsChronologically();
            messagesBoard.DisplayPosts();
        }
    }
}
