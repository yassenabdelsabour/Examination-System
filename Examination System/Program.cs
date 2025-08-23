using System.ComponentModel.Design;
using System.Diagnostics;

namespace Examination_System
{
    internal class Program
    {
        private static int userAnswerId;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Examination System");
            Console.WriteLine("=================================");
            // Collect student information
            Console.WriteLine("Please Enter Your Name and ID :");
            // Read input from the user
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 2)
                {
                    string studentName = parts[0];
                    int studentId = int.Parse(parts[1]);

                    Console.WriteLine($"Name: {studentName}      ID: {studentId}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter in the format: Name ID");
                    return;
                }
            }

            // Determine the nature of the test
            Console.WriteLine("Please Enter the type of Exam :(1 - Practical | 2 - Final)");
            int choice = int.Parse(Console.ReadLine());
            // Validate the choice input
            if (choice < 1 || choice >2 )
            {
                Console.WriteLine("Invalid choice. Please enter 1 for Practical Exam or 2 for Final Exam.");
                return;
            }


            //Time of Exam
            Console.WriteLine("Please Enter the Time of Exam From (30 min to 100 min)");
            int time = int.Parse(Console.ReadLine());
            // Validate the time input
            if (time < 30 || time > 100)
            {
                Console.WriteLine("Invalid time. Please enter a time between 30 and 100 minutes.");
                return;
            }

            //the Number of Questions
            Console.WriteLine("Please Enter the Number of Questions in Exam From (1 to 10)");
            int numberOfQuestions = int.Parse(Console.ReadLine());
          
            // Validate the number of questions
            if (numberOfQuestions < 1 || numberOfQuestions > 10)
            {
                Console.WriteLine("Invalid number of questions. Please enter a number between 1 and 10.");
                return;
            }

            Console.Clear();

            //choose between 
            Console.WriteLine("Please Enter the Type of Question (1- MCQ | 2- True | False)");
            int questionType = int.Parse(Console.ReadLine());

            // Validate the question type input
            if (questionType < 1 || questionType > 2)
            {
                Console.WriteLine("Invalid question type. Please enter 1 for MCQ or 2 for True/False.");
                return;
            }
             
            if (questionType == 1)
            Console.WriteLine("MCQ Question");
            else
            Console.WriteLine("True/False Question");
            Console.WriteLine("Please Enter Question Body");
            string?body= Console.ReadLine();
            // Validate the body input
            if (string.IsNullOrWhiteSpace(body))
            {
                Console.WriteLine("Invalid body. Please enter a valid question body.");
                return;
            }

            Console.WriteLine("Please Enter Question Mark");
            double mark = double.Parse(Console.ReadLine());
            // Validate the mark input
            if (mark <= 0)
            {
                Console.WriteLine("Invalid mark. Please Enter A Number More Than 0 For The Mark.");
                return;
            }
            Console.WriteLine("choices of Question");
            List<Answer> answers = new List<Answer>();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Please Enter Choice {i + 1}");
                string? choiceText = Console.ReadLine();
                answers.Add(new Answer(i + 1, choiceText));
            }

            Console.WriteLine("Please Enter The Right Answer Id");
            int rightAnswerId = int.Parse(Console.ReadLine());

            // Validate the right answer ID input
            if (rightAnswerId < 1 || rightAnswerId > answers.Count)
            {
                Console.WriteLine("Invalid right answer ID. Please enter a valid ID corresponding to the choices.");
                return;
            }
            Console.Clear();

            Console.WriteLine("Please Enter the Type of Question (1- MCQ | 2- True | False)");
            int trueFalseQuestionType = int.Parse(Console.ReadLine());
            if (trueFalseQuestionType == 1)
                Console.WriteLine("MCQ Question");
            else
                Console.WriteLine("True/False Question");

            Console.WriteLine("Please Enter Question Body");
            string? trueFalseBody = Console.ReadLine();
            // Validate the body input
            if (string.IsNullOrWhiteSpace(trueFalseBody))
            {
                Console.WriteLine("Invalid body. Please enter a valid question body.");
                return;
            }

            Console.WriteLine("Please Enter Question Mark");
            double trueFalseMark = double.Parse(Console.ReadLine());
            // Validate the mark input
            if (trueFalseMark <= 0)
            {
                Console.WriteLine("Invalid mark. Please Enter A Number More Than 0 For The Mark.");
                return;
            }

            Console.WriteLine("Please Enter The Right Answer Id (1 for True, 2 for False)");
            int trueFalseRightAnswerId = int.Parse(Console.ReadLine());
            // Validate the right answer ID input for True/False question
            if (trueFalseRightAnswerId < 1 || trueFalseRightAnswerId > 2)
            {
                Console.WriteLine("Invalid right answer ID. Please enter 1 for True or 2 for False.");
                return;
            }

            Console.Clear();

            Console.WriteLine("Do You To Start Exam (Y|N)");
            string? startExam = Console.ReadLine();
            if (startExam?.ToUpper() != "Y")
            {
                Console.WriteLine("Exam not started.");
                return;
            }
            Console.Clear();
            Exam exam;
            // Create a subject for the exam

            Subject subject = new Subject(1, "Computer Science");

            if (choice == 1)
            {
                exam = new PracticalExam(time, numberOfQuestions, subject);
            }
            else
            {
                exam = new FinalExam(time, numberOfQuestions, subject);
            }
            Question question;
            Console.Clear();
            Console.WriteLine($"MCQ Header       Mark");

            if (questionType == 2)

            question = new MCQQuestion("MCQ Header", body, mark, answers.ToArray(), rightAnswerId);
            question = new TrueFalseQuestion("True/False Header", trueFalseBody, trueFalseMark, trueFalseRightAnswerId);

            exam.Questions.Add(new MCQQuestion("MCQ Header", body, mark, answers.ToArray(), rightAnswerId));
            exam.Questions.Add(new TrueFalseQuestion("True/False Header", trueFalseBody, trueFalseMark, trueFalseRightAnswerId));

            exam.ShowExamDetails();
            Console.Clear();

            //Exam Details
            Console.WriteLine("Exam Details:");
            Console.WriteLine("=================================");

            Console.WriteLine($"Number of Questions: {exam.NumberOfQuestions}");
            Console.WriteLine("=================================");

            Console.WriteLine("Exam Questions:");
            foreach (var q in exam.Questions)
            {
                Answer[] answersArray = q.AnswerList.ToArray();
                Console.WriteLine($"Question: {q.Header}    ({q.Mark} Marks)\n  {q.Body} ? \n(Answer : {q.RightAnswerId})");

            }

            Console.WriteLine("=================================");

            // Final Grade
            Console.WriteLine("Final Grade Calculation:");
            Console.WriteLine("=================================");
            double totalMarks = exam.Questions.Sum(q => q.Mark);

            double earnedMarks = exam.Questions.Sum(q =>
            {
                return q.GetScore(); // Assuming GetScore() returns the score for each question

            });

            double finalGrade = (earnedMarks / totalMarks) * 100;

            Console.WriteLine($"Total Marks: {totalMarks}");
            Console.WriteLine($"Earned Marks: {earnedMarks}");
            Console.WriteLine($"Final Grade: {finalGrade}%");

            Console.WriteLine("=================================");

            //Time
            TimeOnly examStartTime = TimeOnly.FromDateTime(DateTime.Now);
            Console.WriteLine($"Exam started at: {examStartTime}");
            Console.WriteLine($"Exam Duration: {exam.Time} minutes");
          
            


        }
    }
}





