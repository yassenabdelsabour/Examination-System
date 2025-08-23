using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class MCQQuestion : Question
    {
        #region class MCQQuestion

        #region Constructors =>  Question اعتمادة عل كلاس الاب
        public MCQQuestion(string header, string body, double mark, Answer[] answers, int rightAnswerId)
        : base(header, body, mark, answers, rightAnswerId)
        {
        }

        #endregion

        #region Methods =>الهدف منها عرض نوع ونص السؤال والدرجة
        public virtual void ShowQuestion()
        {
            Console.WriteLine($"{Header}: {Body} ({Mark} Marks)");
            // Display the answers
            foreach (var answer in AnswerList)
            {
                Console.WriteLine($"{answer.Id}. {answer.Text}");

            }
        }
        #endregion


        #region Clone Method
        public override object Clone() //  Deep الهدف هو نسح السؤال في  
        {
            var clonedAnswers = AnswerList.Select(a => (Answer)a.Clone()).ToArray();
            return new MCQQuestion(Header, Body, Mark, clonedAnswers, RightAnswerId);
        }
        #endregion
     

        #endregion

    }

}

  
