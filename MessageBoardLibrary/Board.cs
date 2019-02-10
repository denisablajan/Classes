using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoardLibrary
{
    public class Board : IComparer<Post>
    {
        Post[] posts;

        public Board()
        {
            posts = new Post[0];
        }

        public void CreatePost(Post postToCreate)
        {
            Console.Write(" Introduce your message: ");
            string Message = Console.ReadLine().ToString();
            postToCreate.Message = Message;
            AddPost(postToCreate);
        }

        public void AddPost(Post postToAdd)
        {
            int newLenght = posts.Length + 1;
            Post[] aux = new Post[newLenght];

            int item = 0;

            foreach(Post post in posts)
            {
                aux[item++] = post;
            }
            aux[item] = postToAdd;

            this.posts = new Post[newLenght];
            Array.Copy(aux, 0, posts, 0, newLenght);

            Console.WriteLine("\n Post created");
        }

        public void RemovePost(Post postToDelete)
        {
            if (posts.Length >= 1)
            {
                int newLenght = posts.Length - 1;
                Post[] aux = new Post[newLenght];
                int item = 0;

                foreach (Post post in posts)
                {
                    if ((!post.Author.Equals(postToDelete.Author)) && (!post.Message.Equals(postToDelete.Message)))
                    {
                        aux[item++] = post;
                    }
                }

                this.posts = new Post[newLenght];
                Array.Copy(aux, 0, posts, 0, newLenght);

                Console.WriteLine("\n Post removed");
            }
            else
            {
                Console.WriteLine("\n No posts to remove!");
            }
        }

        public int Compare(Post x, Post y)
        {
            if (x.timePosted > y.timePosted)
                return -1;
            else if (x.timePosted < y.timePosted)
                return 1;
            else return 0;
        }

        public void DisplayPosts()
        {
            Console.WriteLine("\t\tMessages:\n");
            if (posts.Length != 0)
            {
                foreach (Post post in posts)
                {
                    Console.WriteLine(post);
                }
            }
            else
            {
                Console.WriteLine("\n No posts yet!");
            }
        }

        public void SortPostsChronologically()
        {
            int newLenght = posts.Length;
            Post aux;
            for(int i = 0; i < newLenght; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    if(Compare(posts[i],posts[j]) == -1)
                    {
                        aux = posts[i];
                        posts[i] = posts[j];
                        posts[j] = aux;
                    }
                }
            }
        }
    }
}
