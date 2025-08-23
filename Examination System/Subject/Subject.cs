using System.ComponentModel.Design;

namespace Examination_System
{
    public class Subject 
    {
        #region class Subject

        #region Attributes
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }
        #endregion

        #region Constructors
        public Subject(int id, string name)
        {
            SubjectId = id;
            SubjectName = name;
        }
        #endregion
        #region Methods

        public void CreateExam(Exam exam)  // تخزين الامتحان 
        {
            Exam = exam;
        }
        #endregion
       
        #region override Methods

        public override string ToString() => $"{SubjectId} - {SubjectName}";
        #endregion

        #endregion
    }
}