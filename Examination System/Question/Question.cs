using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public abstract class Question : ICloneable
    {
        #region class Question

        #region Attributes 
        public string Header { get; set; }
        public string Body { get; set; }
        public double Mark { get; set; }
        public Answer[] AnswerList { get; set; } = Array.Empty<Answer>();
        public int RightAnswerId { get; set; }
        public int UserAnswerId { get; set; }
        #endregion


        #region Constructors // الهدف منه تحديد شكل السؤال

        protected Question(string header, string body, double mark, Answer[] answers, int rightAnswerId)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answers;
            RightAnswerId = rightAnswerId;
        }
        #endregion


        #region Methods //لهذا الكلاس Attributes لازم اي كلاس يورث من هذا الكلاس انه يعرض الامتحان بنفس  

        //public abstract void ShowQuestion();
        public void ShowQuestion()
        {
            Console.WriteLine($"{Body} ({Mark} Marks)");
            foreach (var ans in AnswerList)
            {
                Console.WriteLine($"{ans.Id}. {ans.Text}");
            }


            // الهدف منها المقارنه بين اجابة الطالبة والاجابة الصحيحة 
            Console.Write("Your Answer Student: ");
            UserAnswerId = int.Parse(Console.ReadLine() ?? "0");
            if (CheckAnswer(UserAnswerId))
            {
                Console.WriteLine("Correct Answer!");
            }
            else
            {
                var correctAnswer = AnswerList.First(a => a.Id == RightAnswerId);
                Console.WriteLine($"Wrong Answer! The correct answer is: {correctAnswer.Text}");
            }
        }
       
            public double GetScore()
            {
            return UserAnswerId == RightAnswerId ? Mark : 0;
            }
       
        #endregion


        #region Check Answer Method //user الهدف هو المقارنه بين الاجابة الصحيحة وإجابة 

        public virtual bool CheckAnswer(int userAnswerId) => userAnswerId == RightAnswerId;
       



        #endregion

        #region Clone Method// Deep الهدف هو نسخ السؤال في كلاس جديد بنفس الخصائص
        public abstract object Clone();
        #endregion


        #region ToString Method // الهدف هو عرض السؤال  بهذا الشكل 
        public override string ToString() => $"{Header}\n{Body} ({Mark} Marks)";

       
        #endregion

        #endregion

    }
}
