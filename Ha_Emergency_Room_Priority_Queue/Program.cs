// Khai Ha
// IT113
// NOTES: My first thought to sort was to put the by making list for each priority, and then filter and put them into each list. That's how I was going to sort but we did not went that way.

using System;
using System.IO;

namespace Ha_Emergency_Room_Priority_Queue
{
    internal class Program
    {
        static ERQueue eRQueue = new ERQueue();

        static void Main(string[] args)
        {

            string PreRecords = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Patients-1.csv"); // Find the file that's in the bin

            eRQueue.LoadPreRecords(PreRecords); // Shoves the PreRecords into the LoadPreRecords

            string choice = string.Empty; //Choices to navigate the program

            do
            {
                Console.WriteLine("Main Menu" + '\n' + "(A)dd Patient" + '\n' + "(P)rocess Current Patient" + '\n' + "(L)ist All in Queue" + '\n' + "(Q)uit");
                choice = Console.ReadLine().ToUpper();
                if (choice == "A")
                {
                    Console.Clear();
                    AddPatient();
                }
                if(choice == "P")
                {
                    Console.Clear();
                    ProcessPatient();
                }
                if(choice == "L")
                {
                    Console.Clear();
                    eRQueue.ListPatients();
                }

            }while(choice != "Q");


            Console.WriteLine('\n' + "End Reached");
        }

        static void AddPatient()
        {
            Console.WriteLine("Enter First Name: ");
            string Name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter Last Name: ");
            string SirName = Console.ReadLine();
            Console.WriteLine("Enter Date of Birth: ");
            Console.Clear();
            DateTime DOB;
            while (true)
            {
                Console.Write("Enter Date of Birth as (MM/DD/YYYY): ");
                if (DateTime.TryParse(Console.ReadLine(), out DOB))
                {
                    break;
                }
                Console.WriteLine("Invalid date."); // checks to see if format is valid or not to loop backl
            }
            Console.Clear();
            int Priority; 
            while (true)
            {
                Console.Write("Enter Priority (1-5): ");
                if (int.TryParse(Console.ReadLine(), out Priority) && Priority >= 1 && Priority <= 5) // check parse for priority
                {
                    break;
                }
                Console.WriteLine("Invalid entry, enter a number between 1 and 5.");
            }
            Console.Clear();
            var patient = new Patients(SirName, Name, DOB, Priority);
            eRQueue.EnqueuePatients(patient); // insert patient into Enqueue to queue it up
            Console.WriteLine("Patient Added.");
        }

        static void ProcessPatient()
        {
            Patients patient = eRQueue.DequeuePatient(); // process and then dequeue the patient
            if (patient != null)
            {
                Console.WriteLine($"Processing patient: {patient}");
            }
            else
            {
                Console.WriteLine("No patients in the queue.");
            }
        }

    }
}