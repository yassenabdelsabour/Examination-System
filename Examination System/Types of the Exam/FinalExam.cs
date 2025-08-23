using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class FinalExam : Exam
    {
        #region class FinalExam
        #region Constructors =>  Exam اعتمادة عل كلاس الاب  
        public FinalExam(int time, int numberOfQuestions, Subject subject)
         : base(time, numberOfQuestions, subject) { }

        #endregion
        #region display Final Grade  q => Questions
        public override void ShowExamDetails()
        {
            //حساب درجات الامتحان النهائي
            double total = 0, earned = 0;
            foreach (var q in Questions)
            {
                q.ShowQuestion();
                Console.Write("Your Answer Id: ");
                int ans = int.Parse(Console.ReadLine());

                total += q.Mark;
                if (q.CheckAnswer(ans)) earned += q.Mark;
                
            }
            Console.WriteLine($"Final Grade: {earned}/{total} ({(earned / total) * 100}%)");
        }
        #endregion
        #endregion

    }
}
