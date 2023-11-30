
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace Ha_Emergency_Room_Priority_Queue
{
    internal class ERQueue
    {
        private PriorityQueue<Patients, int> queue = new PriorityQueue<Patients, int>(); // Start priorty queue


        public void LoadPreRecords(string preRecords) // loads the file into LoadPreRecords 
        {

            if (!File.Exists(preRecords))
            {
                Console.WriteLine("Error: Missing File");
                return;
            }

            try
            {
                var lines = File.ReadAllLines(preRecords).Skip(1);
                foreach (var line in lines)
                {
                    var info = line.Split(',');
                    if (info.Length >= 3)
                    {

                        string Name = info[0].Trim();
                        string SirName = info[1].Trim();
                        DateTime DOB = DateTime.Parse(info[2].Trim());
                        int Priority = int.Parse(info[3].Trim());

                        var patient = new Patients(SirName, Name, DOB, Priority);
                        EnqueuePatients(patient);

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


        }

        public void EnqueuePatients(Patients patient)
        {
            queue.Enqueue(patient, patient._priority);
        }


        public Patients DequeuePatient()
        {
            if(queue.TryDequeue(out Patients patient, out _)) // checks if we can dequeue patient
            {
                return patient;
            }
            return null;
        }

        public void ListPatients()
        {
            // Head of queue
            List<Patients> sortedPatients = new List<Patients>();

            // Dequeue all patients
            while (queue.Count >= 1)
            {
                sortedPatients.Add(queue.Dequeue());
            }

            // Sort the patients
            sortedPatients.Sort((p1, p2) => p1._priority.CompareTo(p2._priority));

            // Requeue
            foreach (var patient in sortedPatients)
            {
                EnqueuePatients(patient);
            }

            // Show result
            foreach (var patient in queue.UnorderedItems)
            {
                Console.WriteLine($"{patient.Element}");
            }
        }
    }
}
