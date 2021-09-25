using System;
using System.Collections.Generic;

namespace MoviePlexTheatreApp
{


    class Program
    {
        const string pw = "1234";
        static int tries = 5;
        static int MovieCount;
        static List<string> MovieList;
        static List<string> RatingList;




        static void Main(string[] args)
        {
            MovieList = new List<string>();
            RatingList = new List<string>();
            Selection();
        }

        public static void Header()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t************************************");
            Console.WriteLine("\t\t\t\t\t*** Welcome to MoviePlex Theatre ***");
            Console.WriteLine("\t\t\t\t\t************************************");
            Console.WriteLine("\n\n\n");
        }



        public static void Selection()
        {
            int select = 0;

            Header();

            Console.WriteLine("Please Select From The Following Options:");          
            Console.WriteLine("1: Administrator \n2: Guests");
            Console.WriteLine("\n\n");
            Console.WriteLine("Selection:");

            select = Convert.ToInt32(Console.ReadLine());

            if (select == 1)
            {
                Admin();
            }
            else if (select == 2)
            {
                if (MovieList.Count > 0)
                {
                    Guest();
                }
                else
                {
                    Console.WriteLine("No movies are currently playing, please select admin to set up a catalog\npress any key");
                    string x = Console.ReadLine();
                    Selection();
                }

            }
            else
            {
                Selection();
            }
        }




        public static void Admin()
        {
            Header();

            authenticate();
            
        }

        public static void authenticate()
        {

            Console.WriteLine("\n\n");
            Console.WriteLine("Please Enter The Admin Password:");

            string password = Console.ReadLine();


            if (password.Equals(pw))
            {
                tries = 5;
                setCatalog();

            }
            else if(password == "B")
            {
                Selection();
            }
            else
            {
                tries--;

                if (tries == 0)
                {
                    tries = 5;
                    Selection();
                }
                else
                {
                    Console.WriteLine("You entered an Invalid password");
                    Console.WriteLine("\nYou have " + tries + " more attempts to enter the correct password OR press B to go back to the previous screen");
                    authenticate();
                }
            }

        }



        public static void setCatalog()  
        {

            Console.WriteLine("\nWelcome MoviePlex Administrator");
            Console.WriteLine("\nHow many movies are playing today?:");

            MovieCount = Convert.ToInt32(Console.ReadLine());

            if(MovieCount > 0)
            {
                for (int i = 0; i < MovieCount; i++)
                {
                    getMovie(i + 1);
                }


                Console.WriteLine("\n");
                for (int i = 0; i < MovieCount; i++)
                {
                    int num = i + 1;
                    Console.WriteLine("\t" + num + ". " + MovieList[i] + " [" + RatingList[i] + "]");
                }

                Console.WriteLine("Your Movies Playing Today Are Listed Above. Are You Satisfied? [Y/N]?");


                string YN = "";
                YN = Console.ReadLine();

                if (YN.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
                {
                    Selection();
                }
                else if (YN.Equals("N", StringComparison.CurrentCultureIgnoreCase))
                {
                    setCatalog();
                }
                else
                {
                    Selection();
                }
            }
            else
            {
                Selection();
            }

          

        }

        public static void getMovie(int position)
        {

            string count = "";


            switch (position)
            {
                case 1: count = "First";
                    break;
                case 2:
                    count = "Second";
                    break;
                case 3:
                    count = "Third";
                    break;
                case 4:
                    count = "Fourth";
                    break;
                case 5:
                    count = "Fifth";
                    break;
                case 6:
                    count = "Sixth";
                    break;
                case 7:
                    count = "Seventh";
                    break;
                case 8:
                    count = "Eighth";
                    break;
                case 9:
                    count = "Nineth";
                    break;
                case 10:
                    count = "Tenth";
                    break;
                case 11:
                    count = "Eleventh";
                    break;
                case 12:
                    count = "Twelveth";
                    break;
                case 13:
                    count = "Thirteenth";
                    break;
                case 14:
                    count = "Forteenth";
                    break;
                case 15:
                    count = "Fifteenth";
                    break;
                case 16:
                    count = "Sixteenth";
                    break;
                case 17:
                    count = "Seventeenth";
                    break;
                case 18:
                    count = "Eighteenth";
                    break;
                case 19:
                    count = "Nineteenth";
                    break;
                case 20:
                    count = "Twentieth";
                    break;
            }


            Console.WriteLine("\nPlease enter the " + count + " movie :");
            string name = Console.ReadLine();
            MovieList.Add(name);
            Console.WriteLine("\nPlease enter the Age limit or Rating for the " + count + " movie :");
            string rating = Console.ReadLine(); 
            RatingList.Add(rating);

        }


        public static int getAgeLimit(int option)
        {

            string rating = RatingList[option];

            int Limit = 1;

            if(rating ==  "G")
            {
                Limit = 0;
            }
            else if(rating == "PG")
            {
                Limit = 9;
            }
            else if (rating == "PG-13")
            {
                Limit = 12;
            }
            else if (rating == "R")
            {
                Limit = 14;
            }
            else if (rating == "NC-17")
            {
                Limit = 16;
            }
            else if(Convert.ToInt32(rating) > 0 && Convert.ToInt32(rating) < 120)
            {
                Limit = Convert.ToInt32(rating);
            }


            return Limit;
        }


        public static void Guest()
        {

            Header();

            Console.WriteLine("There are " + MovieCount + " movies playing today. Please choose from the following movies:");
            Console.WriteLine("\n");
            for (int i = 0; i < MovieCount; i++)
            {
                int num = i + 1;
                Console.WriteLine("\t" + num + ". " + MovieList[i] + " [" + RatingList[i] + "]");
            }

            
            int option;
            do
            {
                Console.WriteLine("Which Movie Would You Like To Watch: ");
                option = Convert.ToInt32(Console.ReadLine());
                if (option > MovieList.Count)
                {
                    Console.WriteLine("Please enter a valid option: ");
                }

            }
            while (option > MovieList.Count);
           

            Console.WriteLine("Please Enter Your Age For Verification: ");
            int age = Convert.ToInt32(Console.ReadLine());


            if (MovieList.Count > 0)
            {
                if (age >= getAgeLimit(option-1))
                {
                    Console.WriteLine("Enjoy the movie!");
                }
                else
                {
                    Console.WriteLine("You are the under the age limit to watch this movie, please select another movie");
                    Console.WriteLine("enter any key");
                    string hold = Console.ReadLine();
                    Guest();
                }
            }

            Console.WriteLine("Press M to go back to the Guest Main Menu.");
            Console.WriteLine("Press S to go back to the Start Page.");

            string goback = Console.ReadLine();

            if(goback == "M" || goback == "m")
            {
                Guest();
            }
            else if(goback == "S" || goback == "s")
            {
                Selection();
            }

        }

    }
}
