using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class PracticalExam : Exam
    {
        #region class PracticalExam
        #region Constructors =>  Exam اعتمادة عل كلاس الاب
        public PracticalExam(int time, int numberOfQuestions, Subject subject)
         : base(time, numberOfQuestions, subject) { }

        #endregion
        #region display Practical Grade + display Answer  q => Questions
        public override void ShowExamDetails()
        {
            double total = 0, earned = 0;
            foreach (var q in Questions)
            {
                q.ShowQuestion();
                //حساب درجات الامتحان النهائي
                Console.Write("Your Answer Id: ");
                int ans = int.Parse(Console.ReadLine());

                total += q.Mark;
                if (q.CheckAnswer(ans)) earned += q.Mark;

                //الهدف البحث عن الاجابة وعرضها 
                var rightAnswer = q.AnswerList.First(a => a.Id == q.RightAnswerId);
                if (rightAnswer != null)
                {
                    Console.WriteLine($" Correct Answer: {rightAnswer.Text}");
                }

                // الهدف وضع خط فاصل
                Console.WriteLine(new string('-', 40));
            }

            // Display the total grade
            Console.WriteLine($"Grade: {earned}/{total}");
        }
        #endregion
        #endregion

    }

}
