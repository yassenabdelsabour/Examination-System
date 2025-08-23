using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public abstract class Exam 
    {

        #region abstract class Exam 
        #region Attributes

        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public Subject Subject { get; set; }
        public List<Question> Questions { get; set; } = new();
      

        #endregion
        #region Constructors

        protected Exam(int time, int numberOfQuestions, Subject subject)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Subject = subject;
        }
        #endregion
        #region ShowExamDetails => لهذا الكلاس Attributes لازم اي كلاس يورث من هذا الكلاس انه يعرض الامتحان بنفس 

        public abstract void ShowExamDetails();
        #endregion
        #region override Methods
        public override string ToString()
        {
            return $"Exam for {Subject.SubjectName}, Time: {Time} min, Questions: {NumberOfQuestions}";
        }
       

        #endregion

        #endregion


    }
}
