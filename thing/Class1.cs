using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace thing
{
    class Class1
    {
        string[,] songAndArtist = new string[1000, 3];

        

        public void AddSongAndArtist() 
        {
            Console.Clear();
            Console.WriteLine("=============== Add Song to Library ===============");
            Console.Write("Enter the song title: ");
            string songName = Console.ReadLine();
            Console.Write("Enter the artist: ");
            string songArtist = Console.ReadLine();
            Console.Write("Enter genre: ");
            string songGenre = Console.ReadLine();

            // ^^ takes user inputs and stores them into variables temporarily 
            
            for (int i = 0; i <= songAndArtist.GetLength(0); i++) // Loop that gets the row length, which is 1000 
            {

                if (songName.Equals(songAndArtist[i, 0], StringComparison.CurrentCultureIgnoreCase) && songArtist.Equals(songAndArtist[i, 1], StringComparison.CurrentCultureIgnoreCase) && songGenre.Equals(songAndArtist[i, 2], StringComparison.CurrentCultureIgnoreCase)) // Checks if the song exists in the library, if so, throws message the breaks loop
                {
                    Console.WriteLine("Song already exists in library! Please re-enter. ");
                    break;
                }

                else
                {
                    if (string.IsNullOrEmpty(songAndArtist[i, 0]))      // Checks if array is empty, if it is it adds the content, displaying a message that the song has been added, then breaks the loop.
                    {
                        songAndArtist[i, 0] = songName;
                        songAndArtist[i, 1] = songArtist;
                        songAndArtist[i, 2] = songGenre;
                        Console.WriteLine("Song added to library!");
                        break;
                        
                    }
                }
                }
           /* for (int j = 0; j < songAndArtist.GetLength(0); j++)
            {
                if (string.IsNullOrEmpty(songAndArtist[j, 1]))
                {
                    songAndArtist[j, 1] = songArtist;
                    break;
                }
            }
            for (int k = 0; k < songAndArtist.GetLength(0); k++)
            {
                if (string.IsNullOrEmpty(songAndArtist[k, 2]))
                {
                    songAndArtist[k, 2] = songGenre;
                    break;
                }
            }*/

        }

        public void viewAll()
        {
            Console.Clear();
            Console.WriteLine("=============== View Options ===============");
            Console.Write("What do you want to view? \n[1] - Entire Library\n[2] - Specific Artist's Songs\n[3] - Specific Songs under a Genre\n>>  ");
            int viewOpt = int.Parse(Console.ReadLine());
            if (viewOpt == 1)
            {
                Console.Clear();
                Console.WriteLine("=============== All Songs ===============");
                
                for (int i = 0; i < songAndArtist.GetLength(0); i++)
                {
                    if (!string.IsNullOrEmpty(songAndArtist[i, 0])) // If the array/library is not empty, then it shows  all the contents till it hits a null
                    {
                        Console.WriteLine($"{i+1}. {songAndArtist[i, 0]} -- {songAndArtist[i, 1]} || Genre: {songAndArtist[i, 2]}");
                    }
                   

                }
            }
            else if (viewOpt == 2)
            {
                Console.Clear();
                Console.WriteLine("=============== Artist Search ===============");
                Console.Write("Who is the artist you want to search for?: ");
                string artistName = Console.ReadLine();


                Console.WriteLine($"Songs by {artistName}: \n");
                for (int i = 0; i < songAndArtist.GetLength(0); i++)
                {
                    if (artistName.Equals(songAndArtist[i, 1], StringComparison.CurrentCultureIgnoreCase))
                    {
                        Console.WriteLine($"{i + 1}. {songAndArtist[i, 0]}");
                        
                    }
                    
                }
            }
            else if (viewOpt == 3)
            {
                Console.Clear();
                Console.WriteLine("=============== Genre Search ===============");
                Console.Write("What is the genre you want to search? ");
                string genre = Console.ReadLine();

                Console.WriteLine($"Songs that are {genre}: \n");
                for (int i = 0; i < songAndArtist.GetLength(0); i++)
                {
                    if (genre.ToLower() == songAndArtist[i, 2])
                    {
                        Console.WriteLine($"{i +1}. {songAndArtist[i, 0]}");
                    }
                }
            }
        }

        public void update()
        {
            Console.Clear();
            Console.WriteLine("=============== Edit Song ===============");

            /*
                Console.Write("What song do you want to edit? [Input the song title]: ");
                string songToBeEdited = Console.ReadLine();                                     !!! If we want to go specific searching !!!
                Console.Write("Who is the artist of the song? [Input song artist]: ");
                string artistOfSong = Console.ReadLine();
            */

            Console.Write("What is the number of the song do you wish to edit?: ");
            int songNum = int.Parse(Console.ReadLine());

            for (int i = 1; i < songAndArtist.GetLength(0); i++)
                //  if (songAndArtist[i, 0].ToLower() == songToBeEdited.ToLower() && songAndArtist[i, 1].ToLower() == artistOfSong.ToLower()) // Searches for song with song title and artist name
                    if(songNum == i)    
                    {
                        Console.WriteLine($"Song found!\n{songAndArtist[i-1, 0]} -- {songAndArtist[i-1, 1]} || Genre: {songAndArtist[i-1, 2]}");

                        Console.Write("What do you want to edit? [1 for title, 2 for artist, 3 for genre]:\n>> ");
                        int editOpt = int.Parse(Console.ReadLine());
                        if (editOpt == 1) // Title Update
                        {
                            Console.WriteLine("=============== Edit Song Title ===============");
                            Console.Write("Enter new song title: ");
                            string newSongTitle = Console.ReadLine();

                            songAndArtist[i, 0] = newSongTitle;
                            Console.Clear();
                            Console.WriteLine("Title changed successfully!");
                            Console.WriteLine($"New details:\n{songAndArtist[i, 0]} -- {songAndArtist[i, 1]} || Genre: {songAndArtist[i, 2]}");

                            break;
                        }
                        else if (editOpt == 2) // Artist Update
                        {
                            Console.WriteLine("=============== Edit Song Artist===============");
                            Console.Write("Enter new artist name: ");
                            string newArtistName = Console.ReadLine();

                            songAndArtist[i, 1] = newArtistName;
                            Console.Clear();
                            Console.WriteLine("Artist name changed successfully!");
                            Console.WriteLine($"New details:\n{songAndArtist[i, 0]} -- {songAndArtist[i, 1]} || Genre: {songAndArtist[i, 2]}");
                            break;
                        }
                        else if (editOpt == 3) // Genre Update
                        {
                            Console.WriteLine("=============== Edit Song Genre ===============");
                            Console.Write("Enter new song genre: ");
                            string newSongGenre = Console.ReadLine();

                            songAndArtist[i, 2] = newSongGenre;
                            Console.Clear();
                            Console.WriteLine("Genre changed successfully!");
                            Console.WriteLine($"New details:\n{songAndArtist[i, 0]} -- {songAndArtist[i, 1]} || Genre: {songAndArtist[i, 2]}");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid option.");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Cannot be found...");
                        break;
                    }
        }
                
        
        public void deleteSong()
        {
            Console.Write("What song do you want to delete? [Input the song title]: ");
            string songToBeEdited = Console.ReadLine();
            Console.Write("Who is the artist of the song? [Input song artist]: ");
            string artistOfSong = Console.ReadLine();
            Boolean found = false;
            for (int i = 0; i < songAndArtist.GetLength(0); i++)
            {
                if (songAndArtist[i, 0].ToLower() == songToBeEdited.ToLower() && songAndArtist[i, 1].ToLower() == artistOfSong.ToLower())
                {
                    found = true;
                        if(!string.IsNullOrEmpty(songAndArtist[i, 0]))
                        {
                            songAndArtist[i, 0] = songAndArtist[i + 1, 0];
                            songAndArtist[i, 1] = songAndArtist[i + 1, 1];
                            songAndArtist[i, 2] = songAndArtist[i + 1, 2];

                            songAndArtist[i + 1, 0] = null;
                            songAndArtist[i + 1, 1] = null;
                            songAndArtist[i + 1, 2] = null;
                        Console.WriteLine("Song deleted successfully");
                        }
                    
                    break;
                }
               
            }
            if(!found)
            {
                Console.WriteLine("Cannot be found...");
            }
        }
        class Mainthing
        {

            public static void Main(String[] args)
            {
                Class1 methods = new Class1();



                while (true)
                {
                    Console.WriteLine("=============== Music List ===============");
                    Console.Write("[1] - Add Song to List \n" +
                    "[2] - View Songs in List \n" +
                    "[3] - Update Song List \n" +
                    "[4] - Delete Song in List \n" +
                    "[0] - Exit \n\n>> ");

                    int option = int.Parse(Console.ReadLine());



                    if (option == 1)
                    {
                        methods.AddSongAndArtist();

                    }
                    else if (option == 2)
                    {
                        methods.viewAll();
                    }
                    else if (option == 3)
                    {
                        methods.update();
                    }
                    else if (option == 4)
                    {
                        methods.deleteSong();
                    }
                    else if (option == 0)
                    {
                        Console.WriteLine("Exiting application...");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Please enter a valid option.");

                    }


                }
            }
        }
    }
}
