using DO;
using DalApi;
using Dal;

namespace DalApi;

internal class StudentQuestionImplementation : IStudentQueston
{
     if (item == null) throw new ArgumentNullException("item");

    public int Create(StudentQuestion item)
    {
        foreach (StudentQuestion item1 in DataSource.studentQuestions)
        {
            if(item1.StudentId==item.StudentId && item1.ExamId==item.ExamId && item1.QuestionId==item.QuestionId) {
                throw new ArgumentNullException("השאלה כבר קיימת לתלמיד זה");
        }
            DataSource.studentQuestions.Add(item);
        }

    public void Delete(int StudentId,int ExamId, int QuestionId)
    {
        foreach (StudentQuestion item in DataSource.StudentQuestion)
        {
            if (item1.StudentId == item.StudentId && item1.ExamId == item.ExamId && item1.QuestionId == item.QuestionId)
                DataSource.StudentQuestion.Remove(item);
        }
        throw new NotImplementedException();
    }

    public StudentQuestion? Read(int StudentId, int ExamId, int QuestionId)
    {
        foreach (StudentQuestion item in DataSource.StudentQuestion)
        {
            if (item1.StudentId == item.StudentId && item1.ExamId == item.ExamId && item1.QuestionId == item.QuestionId)
                return item;       
        }
        return null;
    }

    public List<StudentQuestion> ReadAll()
    {
        return new List<StudentQuestion>(DataSource.studentQuestions);
    }

    public void Update(StudentQuestion item)
    {
        foreach (StudentQuestion item in DataSource.StudentQuestion)
        {
            if (item1.StudentId == item.StudentId && item1.ExamId == item.ExamId && item1.QuestionId == item.QuestionId)
            {
                Delete(item1.Id);
                DataSource.Exams.Add(item);
            }
            throw new Exception("שאלה לא קיימת במבחן לתלמיד זה");

        }
    }
}
