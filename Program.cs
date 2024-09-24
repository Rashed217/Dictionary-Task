namespace Dictionary_Task
{
    internal class Program
    {

        static Dictionary<string, HashSet<string>> Courses = new Dictionary<string, HashSet<string>>();
        static Dictionary<string, int> CoursesCapacities = new Dictionary<string, int>();
        static List<(string CourseCode, string StudentName)> WaitList = new List<(string CourseCode, string StudentName)> ();

        static string CoursesFile = "C:\\Users\\Codeline User\\Documents\\Codeline Projects\\Files\\CoursesFile.txt";
        static string WaitingListFile = "C:\\Users\\Codeline User\\Documents\\Codeline Projects\\Files\\WaitingListFile.txt";


        static void InitializeStartupData()
        {
            // Example data: Courses and their enrolled students (cross-over students)
            Courses["CS101"] = new HashSet<string> { "Alice", "Bob", "Charlie" };   // CS101 has Alice, Bob, Charlie
            Courses["MATH202"] = new HashSet<string> { "David", "Eva", "Bob" };     // MATH202 has David, Eva, and Bob (cross-over with CS101)
            Courses["ENG303"] = new HashSet<string> { "Frank", "Grace", "Charlie" };// ENG303 has Frank, Grace, and Charlie (cross-over with CS101)
            Courses["BIO404"] = new HashSet<string> { "Ivy", "Jack", "David" };     // BIO404 has Ivy, Jack, and David (cross-over with MATH202)


            // Set course capacities (varying)
            CoursesCapacities["CS101"] = 3;   // CS101 capacity of 3 (currently full)
            CoursesCapacities["MATH202"] = 5; // MATH202 capacity of 5 (can accept more students)
            CoursesCapacities["ENG303"] = 3;  // ENG303 capacity of 3 (currently full)
            CoursesCapacities["BIO404"] = 4;  // BIO404 capacity of 4 (can accept more students)


            // Waitlist for courses (students waiting to enroll in full courses)
            WaitList.Add(("Helen", "CS101"));   // Helen waiting for CS101
            WaitList.Add(("Jack", "ENG303"));   // Jack waiting for ENG303
            WaitList.Add(("Alice", "BIO404"));  // Alice waiting for BIO404
            WaitList.Add(("Eva", "ENG303"));    // Eva waiting for ENG303
            Console.WriteLine("Startup data initialized.");
        }

        static void Main(string[] args)
        {
            InitializeStartupData();
            MainMenu();
            SaveCoursesToFile();
            SaveStudentToWaitList();
        }

        static void MainMenu()
        {
            bool ExitFlag = false;

        do
            {
                Console.WriteLine("\nPlease select one of the following options:");
                Console.WriteLine("\n1. Add a new course");
                Console.WriteLine("\n2. Remove Course");
                Console.WriteLine("\n3. Enroll a student in a course");
                Console.WriteLine("\n4. Remove a student from a course");
                Console.WriteLine("\n5. Display all students in a course");
                Console.WriteLine("\n6. Display all courses and their students");
                Console.WriteLine("\n7. Find courses with common students");
                Console.WriteLine("\n8. Withdraw a Student from All Courses");
                Console.WriteLine("\n9. View waiting list");
                Console.WriteLine("\n10. Exit the program");

                int Choice;
                Choice = int.Parse(Console.ReadLine());

                switch (Choice)
                {
                    case 1:
                        AddNewCourse();
                        break;

                    case 2:
                        RemoveCourse();
                        break;

                    case 3:
                        EnrollStudentInCourse();
                        break;

                    case 4:
                        RemoveStudentFromCourse();
                        break;

                    case 5:
                        DisplayStudentsInCourse();
                        break;

                    case 6:
                        DisplayAllCoursesAndStudents();
                        break;

                    case 7:
                        FindCoursesWithCommonStudent();
                        break;

                    case 8:
                        WithdrawStudentFromALlCourses();
                        break;

                    case 9:
                        ViewWaitingList();
                        break;

                    case 10:
                        SaveCoursesToFile();
                        ExitFlag = true;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;

                }
            } while (!ExitFlag);
            
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
                CoursesCapacities[courseCode] = capacity; // Stores the capacity associated with the Course Code
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
            CoursesCapacities.Remove(courseCode); // Delete the Course Capacity
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
            if (Courses[courseCode].Count >= CoursesCapacities[courseCode])
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
                Courses[courseCode].Remove(studentName); // Remove student from the course
                Console.WriteLine($"{studentName} has been removed from {courseCode}.");
            }
        }

        static void DisplayStudentsInCourse()
        {
            Console.Clear();
            Console.Write("Enter the course code (e.g., CS101): ");
            string courseCode = Console.ReadLine(); // Takes Course code input from user

            if (!Courses.ContainsKey(courseCode)) // Check if the course exists
            {
                Console.WriteLine($"Course {courseCode} does not exist.");
                return;
            }

            Console.WriteLine($"Students enrolled in {courseCode}:");
            foreach (var student in Courses[courseCode])
            {
                Console.WriteLine(student); // Display each student's name
            }
        }

        static void DisplayAllCoursesAndStudents()
        {
            Console.Clear();
            Console.WriteLine("Here's All Students and Courses");
            
            foreach (var course in Courses)
            {
                Console.WriteLine($"{course.Key}: {string.Join(", ", course.Value)}");
            }
        }

        static void FindCoursesWithCommonStudent()
        {
            Console.Clear();
            Console.Write("Enter the first course code (e.g., CS101): ");
            string courseCode1 = Console.ReadLine();

            if (!Courses.ContainsKey(courseCode1))
            {
                Console.WriteLine($"Course {courseCode1} does not exist.");
                return;
            }

            Console.Write("Enter the second course code (e.g., CS101): ");
            string courseCode2 = Console.ReadLine();

            if (!Courses.ContainsKey(courseCode2))
            {
                Console.WriteLine($"Course {courseCode2} does not exist.");
                return;
            }

            var commonStudents = new HashSet<string>(Courses[courseCode1]);
            commonStudents.IntersectWith(Courses[courseCode2]);

            Console.WriteLine($"Common students in {courseCode1} and {courseCode2}:");
            if (commonStudents.Count > 0)
            {
                foreach (var student in commonStudents)
                {
                    Console.WriteLine(student);
                }
            }
            else
            {
                Console.WriteLine("No common students found.");
            }
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
                    writer.WriteLine($"{Student.CourseCode}:{Student.StudentName}");
                }
            }

        }

    }
}
