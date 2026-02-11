using System;
using System.Collections.Generic;
using System.Linq;

namespace CAP2025.Day_39_M1Practice
{
    // ===============================
    // 1. Base Interfaces & Enums
    // ===============================
    public interface IPatient
    {
        int PatientId { get; }
        string Name { get; }
        DateTime DateOfBirth { get; }
        BloodType BloodType { get; }
    }

    public enum BloodType { A, B, AB, O }
    public enum Condition { Stable, Critical, Recovering }

    // ===============================
    // 2. Generic Priority Queue
    // ===============================
    public class PriorityQueue<T> where T : IPatient
    {
        private readonly SortedDictionary<int, Queue<T>> _queues = new();

        public void Enqueue(T patient, int priority)
        {
            if (priority < 1 || priority > 5)
                throw new ArgumentException("Priority must be between 1 (highest) and 5 (lowest)");

            if (!_queues.ContainsKey(priority))
                _queues[priority] = new Queue<T>();

            _queues[priority].Enqueue(patient);
        }

        public T Dequeue()
        {
            foreach (var queue in _queues.OrderBy(q => q.Key))
            {
                if (queue.Value.Count > 0)
                    return queue.Value.Dequeue();
            }

            throw new InvalidOperationException("Queue is empty.");
        }

        public T Peek()
        {
            foreach (var queue in _queues.OrderBy(q => q.Key))
            {
                if (queue.Value.Count > 0)
                    return queue.Value.Peek();
            }

            throw new InvalidOperationException("Queue is empty.");
        }

        public int GetCountByPriority(int priority)
        {
            if (_queues.ContainsKey(priority))
                return _queues[priority].Count;

            return 0;
        }
    }

    // ===============================
    // 3. Generic Medical Record
    // ===============================
    public class MedicalRecord<T> where T : IPatient
    {
        private readonly T _patient;
        private readonly List<(DateTime date, string diagnosis)> _diagnoses = new();
        private readonly Dictionary<DateTime, string> _treatments = new();

        public MedicalRecord(T patient)
        {
            _patient = patient;
        }

        public void AddDiagnosis(string diagnosis, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(diagnosis))
                throw new ArgumentException("Diagnosis cannot be empty.");

            _diagnoses.Add((date, diagnosis));
        }

        public void AddTreatment(string treatment, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(treatment))
                throw new ArgumentException("Treatment cannot be empty.");

            _treatments[date] = treatment;
        }

        public IEnumerable<KeyValuePair<DateTime, string>> GetTreatmentHistory()
        {
            return _treatments
                .OrderBy(t => t.Key)
                .ToList();
        }
    }

    // ===============================
    // 4. Specialized Patients
    // ===============================
    public class PediatricPatient : IPatient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public BloodType BloodType { get; set; }
        public string GuardianName { get; set; }
        public double Weight { get; set; }

        public override string ToString() => $"{Name} (Pediatric)";
    }

    public class GeriatricPatient : IPatient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public BloodType BloodType { get; set; }
        public List<string> ChronicConditions { get; } = new();
        public int MobilityScore { get; set; }

        public override string ToString() => $"{Name} (Geriatric)";
    }

    // ===============================
    // 5. Generic Medication System
    // ===============================
    public class MedicationSystem<T> where T : IPatient
    {
        private readonly Dictionary<T, List<(string medication, DateTime time)>> _medications = new();

        private readonly Dictionary<string, List<string>> _interactionMap = new()
        {
            { "Aspirin", new List<string> { "Warfarin" } },
            { "Warfarin", new List<string> { "Aspirin" } }
        };

        public void PrescribeMedication(
            T patient,
            string medication,
            Func<T, bool> dosageValidator)
        {
            if (!dosageValidator(patient))
                throw new InvalidOperationException("Dosage validation failed for patient.");

            if (!_medications.ContainsKey(patient))
                _medications[patient] = new List<(string, DateTime)>();

            if (CheckInteractions(patient, medication))
                throw new InvalidOperationException("Drug interaction detected.");

            _medications[patient].Add((medication, DateTime.Now));
        }

        public bool CheckInteractions(T patient, string newMedication)
        {
            if (!_medications.ContainsKey(patient))
                return false;

            var currentMeds = _medications[patient].Select(m => m.medication);

            foreach (var med in currentMeds)
            {
                if (_interactionMap.ContainsKey(med) &&
                    _interactionMap[med].Contains(newMedication))
                    return true;
            }

            return false;
        }
    }

    // ===============================
    // 6. TEST SCENARIO
    // ===============================
    public class HospitalPatientManagement
    {
        public static void Main()
        {
            var queue = new PriorityQueue<IPatient>();

            // Patients
            var p1 = new PediatricPatient
            {
                PatientId = 1,
                Name = "Aarav",
                DateOfBirth = new DateTime(2018, 5, 1),
                BloodType = BloodType.O,
                Weight = 18
            };

            var p2 = new PediatricPatient
            {
                PatientId = 2,
                Name = "Diya",
                DateOfBirth = new DateTime(2016, 8, 10),
                BloodType = BloodType.A,
                Weight = 22
            };

            var g1 = new GeriatricPatient
            {
                PatientId = 3,
                Name = "Mr. Rao",
                DateOfBirth = new DateTime(1945, 3, 15),
                BloodType = BloodType.B,
                MobilityScore = 4
            };

            var g2 = new GeriatricPatient
            {
                PatientId = 4,
                Name = "Mrs. Sharma",
                DateOfBirth = new DateTime(1940, 11, 22),
                BloodType = BloodType.AB,
                MobilityScore = 6
            };

            // Enqueue with priorities
            queue.Enqueue(g1, 1); // critical
            queue.Enqueue(p1, 2);
            queue.Enqueue(g2, 3);
            queue.Enqueue(p2, 2);

            Console.WriteLine("Next patient: " + queue.Peek());
            Console.WriteLine("Processing: " + queue.Dequeue());

            // Medical Records
            var record = new MedicalRecord<PediatricPatient>(p1);
            record.AddDiagnosis("Flu", DateTime.Now.AddDays(-2));
            record.AddTreatment("Antiviral Syrup", DateTime.Now.AddDays(-1));

            Console.WriteLine("\nTreatment History:");
            foreach (var t in record.GetTreatmentHistory())
                Console.WriteLine($"{t.Key}: {t.Value}");

            // Medication System
            var pediatricMedSystem = new MedicationSystem<PediatricPatient>();
            var geriatricMedSystem = new MedicationSystem<GeriatricPatient>();

            // Pediatric weight-based validation (min weight 15kg)
            pediatricMedSystem.PrescribeMedication(
                p1,
                "Paracetamol",
                patient => patient.Weight >= 15);

            Console.WriteLine("\nMedication prescribed to pediatric patient.");

            // Geriatric mobility-based validation
            geriatricMedSystem.PrescribeMedication(
                g1,
                "Aspirin",
                patient => patient.MobilityScore >= 3);

            Console.WriteLine("Medication prescribed to geriatric patient.");

            // Interaction check
            try
            {
                geriatricMedSystem.PrescribeMedication(
                    g1,
                    "Warfarin",
                    patient => true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Interaction detected: " + ex.Message);
            }
        }
    }
}
