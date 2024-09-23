﻿namespace Dictionary_Task
{
    internal class Program
    {

        Dictionary<string, HashSet<string>> Courses = new Dictionary<string, HashSet<string>>();
        List<(string CourseCode, string StudenName)> WaitList = new List<(string CourseCode, string StudentName)> ();

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
    }
}
