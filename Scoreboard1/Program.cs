using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoreboard1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. present top 10 scores
            Console.WriteLine("Welcome to Paradis's scoreboard!");

            string[] username = new string[] { "suruzz", "venuslyx", "kise", "kira", "shey", "kuronami", "blossom", "kai", "kasikezz", "linty" };

            int[] scores = new int[] { 2863, 600, 9999, 7623, 736, 876, 38, 287, 98, 263 };

            string answer = "";

            do
            {

                // Perform a sort on the scores array
                for (int i = 0; i < scores.Length - 1; i++)
                {
                    // Find the maximum element in the unsorted array
                    int maxIndex = i;
                    for (int j = i + 1; j < scores.Length; j++)
                    {
                        if (scores[j] > scores[maxIndex])
                        {
                            maxIndex = j;
                        }
                    }

                    // Swap the found maximum element with the first element
                    int tempScore = scores[maxIndex];
                    scores[maxIndex] = scores[i];
                    scores[i] = tempScore;

                    string tempUsername = username[maxIndex];
                    username[maxIndex] = username[i];
                    username[i] = tempUsername;
                }

                // Print the sorted arrays
                Console.WriteLine("Sorted usernames by scores:");
                //for (int i = 0; i < username.Length; i++)
                for (int i = 0; i < 10; i++)
                {
                    //Console.WriteLine($"{username[i]}: {scores[i]}");
                    Console.WriteLine("{0,-16} \t {1, 4}", username[i], scores[i]);
                }

                // 2. ask user to enter new score or exit(requires input validation)
                Console.Write("Enter [N] New Score or [X] to Exit: ");
                answer = Console.ReadLine().ToLower();

                while (answer != "n" && answer != "x")
                {
                    Console.WriteLine("Invalid Input, try again.");
                    Console.Write("Enter [N] New Score or [X] to Exit: ");
                    answer = Console.ReadLine().ToLower();
                }

                // 3. if user exits, go to step 9
                if (answer == "x")
                {
                    Console.WriteLine("Thanks");
                    return;
                }

                // If the user did not write "x" ... means that wants to insert a new user...

                string newUser = "";
                int newScore = 0;

                Console.Write("Username: ");
                newUser = Console.ReadLine();

                // 4. ask user to enter the username(1 to 16 characters)
                while (answer.Length < 1 || answer.Length > 16)
                {
                    Console.WriteLine("Invalid answer, username has to be 1 or 16 characters long");
                    Console.Write("Username: ");
                    newUser = Console.ReadLine();
                }

                // 5. ask user to enter the score(0 to 9999)
                Console.Write("Score: ");
                int.TryParse(Console.ReadLine(), out newScore);

                while (newScore < 1 || newScore > 9999)
                {
                    Console.WriteLine("Invalid answer, score has to be between 1 and 9999");
                    Console.Write("Score: ");
                    newScore = int.Parse(Console.ReadLine());
                }


                Console.Write("Analyzing to insert or not...");
                // Create new arrays with one extra slot for the new user and score
                string[] newUsername = new string[username.Length + 1];
                int[] newScores = new int[scores.Length + 1];

                bool inserted = false;
                for (int i = 0, j = 0; i < scores.Length; i++, j++)
                {
                    // Insert the new user in the correct position
                    if (!inserted && newScore > scores[i])
                    {
                        newUsername[j] = newUser;
                        newScores[j] = newScore;
                        inserted = true;
                        j++; // Increment the index for the new arrays
                    }
                    newUsername[j] = username[i];
                    newScores[j] = scores[i];
                }

                // If the new user has the lowest score, add them at the end
                if (!inserted)
                {
                    newUsername[newUsername.Length - 1] = newUser;
                    newScores[newScores.Length - 1] = newScore;
                }

                // Update the original arrays
                username = newUsername;
                scores = newScores;


                // 8. If answer was not "x", go to step 1
            }
            while (answer == "n" || answer == "x");


            // 9. exit program

        }
    }
}
