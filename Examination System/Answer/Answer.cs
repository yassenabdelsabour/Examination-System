using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
   public class Answer : ICloneable
    {
        #region class Answer


        #region Attributes => الهدف هو تحديد شكل الاجابة
        public int Id { get; set; }
        public string Text { get; set; }
        
       
        public Answer(int id, string text)
        {
            Id = id;
            Text = text;
        }
        #endregion

        #region override Methods =>  تحديد شكل الاجابة عند عرضها
        public override string ToString()
        {
            return $"{Id}: {Text} ";
        }
        #endregion

        #region Clone Method => الهدف هو نسخ الاجابة في كلاس جديد بنفس الخصائص
        public object Clone() => new Answer(Id, Text );

        #endregion
       


        #endregion


    }
}
