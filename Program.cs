﻿namespace Dictionary_Task
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

                default:
                    Console.WriteLine("Please enter a valid number.");
                    break;

            }
        }

        static void AddNewCourse()
        {
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

        }

        static void RemoveStudentFromCourse()
        {

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
    }
}
