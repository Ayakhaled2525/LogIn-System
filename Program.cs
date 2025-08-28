using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace frist_project
{
    internal class Program
    {
         // ArrayLists to store user data.
        static ArrayList users = new ArrayList();        // for save usernames
        static ArrayList passwords = new ArrayList();    // for save passwords
        static ArrayList names = new ArrayList();       // for save names
        static ArrayList DateOfBirths = new ArrayList();        // for save  dates
        static ArrayList hobbies = new ArrayList();         // for save hobbies

        // function for user registeration
        static void Register()
        {
            
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Console.WriteLine("--- Register New User ---\n");

            Console.Write("Enter User Name : ");
            string username;

            // Confirm if the username exists
            do
            {

                username = Console.ReadLine();

                
                if (users.Contains(username))
                {
                    Console.ForegroundColor= ConsoleColor.DarkRed;
                    Console.Write(" username  already exists ,try again: ");
                    continue;

                }
                Console.ForegroundColor=ConsoleColor.DarkMagenta;

            } while (users.Contains(username));

            users.Add(username);       //add username to arraylist users.

            // take name from user
            Console.Write("Enter Name : ");
            string name = Console.ReadLine();
            names.Add(name);            // add name to arraylist names

            // take password from user
            Console.Write("Enter Password : ");
            string password = Console.ReadLine();
            passwords.Add(password);            // add password to arraylist passwords


            Console.Write("Enter Date of Birth (DD/MM/YYYY) : ");
            String date;
            bool validdate;

            // confirm if date of barth is correct format.
            do
            {
                date = Console.ReadLine();

                validdate = DateTime.TryParseExact(date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _);    /*DataTime.TryParseExact --> to convert date of birth to datatime
                                                                                                                                    null --> No language specified (default)
                                                                                                                                   "dd/MM/yyyy --> correct Format of date
                                                                                                                                    DataTimeStyles.None --> date must mutch format                   
                                                                                                                                      out _ --> to store date in variable , here not store in any thing*/
                if (!validdate)
                {
                    Console.ForegroundColor=ConsoleColor.DarkRed;
                    Console.Write("wrong format ,try again: ");
                }
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            } while (!validdate);

            DateOfBirths.Add(date);    // add date to araylist DateOfBirth

            // take hobby from user
            Console.Write("Enter your hobbies : ");
            string hobby = Console.ReadLine();
            hobbies.Add(hobby);         // add hobby to arraylist hobbies
            Console.ForegroundColor=ConsoleColor.Green;     //change color

            Console.WriteLine("\n     === Registration completed successfully ===\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
        }


        // Login Function
        static void login()
        {
            
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            Console.WriteLine("\n--- Login for user ---");
            Console.WriteLine();

            String username, password;
            int index;


            Console.Write("Enter your username : ");
            //confirm if username exists 
            do
            {
                username = Console.ReadLine();

                if (!users.Contains(username))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("Username not exist , try again : ");
                    continue;
                }
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            } while (!users.Contains(username));

            index = users.IndexOf(username); // find index of username

            Console.Write("Enter your password : ");
            // confirm if password is correct
            do
            {
                password = Console.ReadLine();
                if (passwords[index].ToString() != password)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("Password is wrong, try again : ");
                }
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            } while (passwords[index].ToString() != password);

               Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine($"\n   Login successfully . \n\n   welcome {names[index]}\n");
        }

        // Edit function
        static void Edit()
        {
            // change color
            Console.ForegroundColor=ConsoleColor.Cyan;

            Console.WriteLine("\n--- Edit your Data ---\n");
            String username, password;
            int index;
            Console.Write("Enter your username : ");
            do
            {
                
                username= Console.ReadLine();

                // Confirm if usename exists or no
                if (!users.Contains(username))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("Username not exist , try again : ");
                    continue;
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
            } while (!users.Contains(username));

            index = users.IndexOf(username);     // find index of this username

            Console.Write("Enter your password : ");
            do
            {
               
                password = Console.ReadLine();

                // confirm if password is correct or no.
                if (passwords[index].ToString() != password)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("Password is wrong , try again : ");
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
            } while (passwords[index].ToString() != password);


            Console.WriteLine("\nwhat would you want to Edit?");
            Console.WriteLine("1) Edit Name.");
            Console.WriteLine("2) Edit password.");
            Console.WriteLine("3) Edit Date of birth.");
            Console.WriteLine("4) Edit Hobbies.\n");

            char ans;

            do
            {

                Console.Write("Enter num (1-4): ");
                int num;
                // confirm if input has same data type
                while (!int.TryParse(Console.ReadLine(), out num) || num < 1 || num > 4)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("invalid number . try again : ");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    continue;
                }

                switch (num)
                {
                    case 1:
                        Console.Write("Enter new name : ");
                        names[index] = Console.ReadLine();        // change name
                        // change color
                        Console.ForegroundColor= ConsoleColor.Green;
                        Console.WriteLine("\t\tName has been updated");
                        //return color
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                        
                    case 2:
                        Console.Write("Enter new password : ");
                        passwords[index] = Console.ReadLine();          // change password
                        // change color
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t\tpassword has been updated");
                        // return color
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case 3:
                        Console.Write("Enter new date : ");
                        bool validdate;
                        string date;
                        do
                        {
                            date = Console.ReadLine();
                            validdate = DateTime.TryParseExact(date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _);
                            if (!validdate)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("wrong format ,try again: ");
                            }
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        } while (!validdate);

                        DateOfBirths[index] = date;    // change date of birth

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t\tbirth date has been updated");
                        // return color
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;

                    case 4:
                        Console.Write("Enter new hobby : ");
                        hobbies[index] = Console.ReadLine();        // change hobby

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t\tHobby has been updated");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                }

                Console.Write ("Do you want to choose another num? --> (y|Y): ");
                 ans=char.Parse(Console.ReadLine());
                // confirm if input his data type is char
                if ( ans != 'y' || ans != 'Y' )
                {
                    continue;
                }

            } while (ans == 'y' || ans == 'Y');

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n   === Your data has been Edit successfully ===\n");
        }

        // Delete Function
        static void delete()
        {
            //set color for delet function
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n--- Delete your account ---\n");

            String username, password;
            int index;

            Console.Write("Enter your username : ");
            // confirm if user name exist or no.
            do
            {
               
                username = Console.ReadLine();
               
                if (!users.Contains(username))
                {
                    // change color
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("Username not exist , try again : ");

                    continue;      //Ignore the rest of the code below and start the loop from the beginning.
                }
                Console.ForegroundColor = ConsoleColor.Blue;

            } while (!users.Contains(username));

            index = users.IndexOf(username);

            Console.Write("Enter your password : ");
            // confirm if password is correct or no.
            do
            {
                
                password = Console.ReadLine();
                if (passwords[index].ToString() != password)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("Password is wrong , try again : ");

                    continue;    //Ignore the rest of the code below and start the loop from the beginning.
                }
                Console.ForegroundColor = ConsoleColor.Blue;
            } while (passwords[index].ToString() != password);

            Console.Write("Are you sure you want to delete the account?  (y / Y): ");

            char answer=char.Parse(Console.ReadLine());
            
            if (answer == 'y' || answer == 'Y')
            {
                // Delete Data
                users.RemoveAt(index);
                names.RemoveAt(index);
                passwords.RemoveAt(index);
                DateOfBirths.RemoveAt(index);
                hobbies.RemoveAt(index);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\tyour account has been deleted successfully");
            }
            else
            {
                Console.ForegroundColor= ConsoleColor.Green;
                //cancel deleting
                Console.WriteLine("\t\tCancel account deletion");
              
            }
        }

        // view  sorted usernames  function 
        static void ViewUsernames()
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n--- All usernames ---\n");

           
            // To sort usernames
            ArrayList SortedUsers =new ArrayList();

            for (int i = 0; i < users.Count; i++)
            {
                SortedUsers.Add(users[i].ToString());
            }

            SortedUsers.Sort();


            if (users.Count == 0)
            {
                Console.WriteLine("    No Username Found\n");
            }
            else
            {
                foreach (string user in SortedUsers)
                {
                    Console.WriteLine("username : "+ user);           // To print all usernames
                }
            }
              
        }


        // main function
        static void Main(string[] args)
        {
            // set color
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor= ConsoleColor.DarkCyan;
            Console.WriteLine(" \n\n         ==== Our LogIn System ====\n");

            Console.ForegroundColor = ConsoleColor.White;
            

            char answer;
            int feature;
            do
            {
                Console.WriteLine("1) Register.");
                Console.WriteLine("2) Login.");
                Console.WriteLine("3) Edit.");
                Console.WriteLine("4) Delet ");
                Console.WriteLine("5) view all usernames");

                // To choose number
                Console.Write("\nEnter feature number (1 - 5) : ");
                
                // confirm the correct data type input
                /* !int.TryParse() --> if user doesn't enter number, convert input to int.
                 out features --> after converting ,store number into feature.
                 */
                while (!int.TryParse(Console.ReadLine(),out feature)|| feature < 1 || feature > 5)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("invalid feature . try again : ");
                    
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                switch (feature)
                {
                    case 1:
                        Console.WriteLine();
                        Register();             // call Register function
                        break;
                    case 2:
                        login();                // call ligin function
                        break;
                    case 3:
                        Edit();                 // call edit function
                        break;
                    case 4:
                        delete();            // call delet function
                        break;
                    case 5:
                        ViewUsernames();     // call viewusernames function
                        break;

                }
                 Console.ForegroundColor=ConsoleColor.White;
                Console.Write("Do you want to choose other features ? --> (y|Y) : ");
                answer=char.Parse(Console.ReadLine());

                // confirm if input his data type is char
               if(answer !='Y'|| answer != 'y')
                {
                    continue;
                }

            } while (answer == 'y' || answer == 'Y');

             Console.ForegroundColor= ConsoleColor.DarkYellow;
            Console.WriteLine("     ===== Thank you For Using Our LogIn system ====");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
