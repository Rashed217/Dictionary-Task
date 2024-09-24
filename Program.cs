namespace Dictionary_Task
{
    internal class Program
    {

        static Dictionary<string, HashSet<string>> Courses = new Dictionary<string, HashSet<string>>();
        static Dictionary<string, int> CourseCapacity = new Dictionary<string, int>();
        static List<(string CourseCode, string StudenName)> WaitList = new List<(string CourseCode, string StudentName)> ();

        static string CoursesFile = "C:\\Users\\Codeline User\\Documents\\Codeline Projects\\Files\\CoursesFile.txt";
        static string WaitingListFile = "C:\\Users\\Codeline User\\Documents\\Codeline Projects\\Files\\WaitingListFile.txt";

        static void Main(string[] args)
        {
            MainMenu();
            SaveCoursesToFile();
            SaveStudentToWaitList();
        }

        static void MainMenu()
        {
            Console.WriteLine("\nPlease select one of the following options:");
            Console.WriteLine("\n1. Add a new course:");
            Console.WriteLine("\n2. Remove Course :");
            Console.WriteLine("\n3. Enroll a student in a course:");
            Console.WriteLine("\n4. Remove a student from a course:");
            Console.WriteLine("\n5. Display all students in a course:");
            Console.WriteLine("\n6. Display all courses and their students:");
            Console.WriteLine("\n7. Find courses with common students:");
            Console.WriteLine("\n8. Withdraw a Student from All Courses:");
            Console.WriteLine("\n9. View waiting list:");

            int Choice;
            Choice = int.Parse(Console.ReadLine());

            switch( Choice )
            {
                case 0:
                    AddNewCourse();
                    break;

                case 1:
                    RemoveCourse();
                    break;

                case 2:
                    EnrollStudentInCourse();
                    break;

                case 3:
                    RemoveStudentFromCourse();
                    break;

                case 4:
                    DisplayStudentsInCourse();
                    break;

                case 5:
                    DisplayAllCoursesAndStudents();
                    break;

                case 6:
                    FindCoursesWithCommonStudent();
                    break;

                case 7:
                    WithdrawStudentFromALlCourses();
                    break;

                case 8:
                    ViewWaitingList();
                    break;

                default:
                    Console.WriteLine("Please enter a valid number.");
                    break;

            }
        }

        static void AddNewCourse()
        {
            Console.Clear();
            Console.Write("Enter the course code (e.g., CS101): ");
            string courseCode = Console.ReadLine(); // Takes Course code input from user

            if (Courses.ContainsKey(courseCode)) // Checks if Course Code exist in the Dictionary
            {
                Console.WriteLine($"Course {courseCode} already exists."); // Validation Message
                return;
            }

            Console.Write("Enter the course capacity: ");
            if (int.TryParse(Console.ReadLine(), out int capacity)) // Takes Course capacity input from user
            {
                Courses[courseCode] = new HashSet<string>(); // Holds student registrations for the course
                CourseCapacity[courseCode] = capacity; // Stores the capacity associated with the Course Code
                Console.WriteLine($"Course {courseCode} added with capacity {capacity}."); // Confirmation Message
            }
            else
            {
                Console.WriteLine("Invalid capacity. Please enter a number.");
            }
        }

        static void RemoveCourse()
        {
            Console.Clear();
            Console.Write("Enter the course code to remove (e.g., CS101): ");
            string courseCode = Console.ReadLine(); // Takes input from user

            if (!Courses.ContainsKey(courseCode)) // Checks if Course Code exist in the Dictionary
            {
                Console.WriteLine($"Course {courseCode} does not exist."); // Validation Message
                return;
            }

            Courses.Remove(courseCode); //Delete the Course Code
            CourseCapacity.Remove(courseCode); // Delete the Course Capacity
            Console.WriteLine($"Course {courseCode} has been removed."); // Confirmation Message
        }


        static void EnrollStudentInCourse()
        {
            Console.Clear();
            Console.Write("Enter the course code (e.g., CS101): ");
            string courseCode = Console.ReadLine();

            if (!Courses.ContainsKey(courseCode)) // Check if the course exists
            {
                Console.WriteLine($"Course {courseCode} does not exist.");
                return;
            }

            Console.Write("Enter the student's name: ");
            string studentName = Console.ReadLine();

            // Check if the course capacity is full
            if (Courses[courseCode].Count >= CourseCapacity[courseCode])
            {
                // Add student to waiting list
                WaitList.Add((courseCode, studentName));
                Console.WriteLine($"Course {courseCode} is full. {studentName} has been added to the waiting list.");
            }
            else
            {
                // Enroll the student to the course
                Courses[courseCode].Add(studentName);
                Console.WriteLine($"{studentName} has been enrolled in {courseCode}.");
            }
        }

        static void RemoveStudentFromCourse()
        {
            Console.Clear();
            Console.Write("Enter the course code (e.g., CS101): ");
            string courseCode = Console.ReadLine(); // Takes Course code input from user

            if (!Courses.ContainsKey(courseCode)) // Check if the course exists
            {
                Console.WriteLine($"Course {courseCode} does not exist.");
                return;
            }

            Console.Write("Enter the student's name: ");
            string studentName = Console.ReadLine();

            if (Courses.ContainsKey(studentName)) // Checks if students name exist in the course
            {
                Courses[courseCode].Remove(studentName); // Remove student from teh course
                Console.WriteLine($"{studentName} has been removed from {courseCode}.");
            }
        }

        static void DisplayStudentsInCourse()
        {

        }

        static void DisplayAllCoursesAndStudents()
        {

        }

        static void FindCoursesWithCommonStudent()
        {

        }

        static void WithdrawStudentFromALlCourses()
        {

        }

        static void ViewWaitingList()
        {

        }

        static void SaveCoursesToFile()
        {
            // Save courses and their students to the CoursesFile
            using (StreamWriter writer = new StreamWriter(CoursesFile))
            {
                foreach (var course in Courses)
                {
                    string courseCode = course.Key;
                    HashSet<string> students = course.Value;
                    writer.WriteLine($"{courseCode}:{string.Join(",", students)}");
                }
            }

        }

        static void SaveStudentToWaitList()
        {
            // Save waitlist to the WaitingListFile
            using (StreamWriter writer = new StreamWriter(WaitingListFile))
            {
                foreach (var Student in WaitList)
                {
                    writer.WriteLine($"{Student.CourseCode}:{Student.StudenName}");
                }
            }

            Console.WriteLine("Courses and waitlist have been saved to files.");
        }

    }
}
