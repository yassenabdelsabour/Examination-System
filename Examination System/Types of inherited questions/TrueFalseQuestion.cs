using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class TrueFalseQuestion : Question
    {
        #region class TrueFalseQuestion

        #region Constructors //  Question اعتمادة عل كلاس الاب
        public TrueFalseQuestion(string header, string body, double mark, int rightAnswerId)
         : base(header, body, mark,
               [new Answer(1, "True"), new Answer(2, "False")],
               rightAnswerId)
        {
        }
        #endregion

        #region Methods //  الهدف منها عرض نوع ونص السؤال والدرجة

        public virtual void ShowQuestion()
        {
            Console.WriteLine($"{Header}: {Body} ({Mark} Marks)");
            foreach (var answer in AnswerList)
            {
                Console.WriteLine($"{answer.Id}. {answer.Text}");
            }
        }
        #endregion

        #region clone method

        public override object Clone()//  Deep الهدف هو نسح السؤال في
        {
            var clonedAnswers = AnswerList.Select(a => (Answer)a.Clone()).ToArray();
            return new TrueFalseQuestion(Header, Body, Mark, RightAnswerId)
            {
                AnswerList = clonedAnswers
            };

        }
        #endregion
        #endregion
    }
}

    
