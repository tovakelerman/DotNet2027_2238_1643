using Dal;
using DalApi;
using DO;

namespace DalApi;

internal class ExamImplementation : IExam
{
    public int Create(Exam item)
    {
        if (item == null) throw new ArgumentNullException("item");
        Exam exam = item with { Id = DataSource.Config.NextExamId };
        DataSource.Exams.Add(exam);
        return exam.Id;
    }

    public void Delete(int id)
    {
        foreach (Exam item in DataSource.Exam)
        {
            if (item.Id == id)
                DataSource.Exams.Remove(item);
        }
        throw new NotImplementedException();
    }

    public Exam? Read(int id)
    {
        foreach (var item in DataSource.Exams)
        {
            if (item.Id.Equals(id))
            {
                return item;
            }
        }
        return null;
    }


    public List<Exam> ReadAll()
    {
        return new List<Exam>(DataSource.Exams);
    }

    public void Update(Exam item)
    {
        foreach (Exam item1 in DataSource.Exams)
        {
            if (item1.Id == item.Id) {
                Delete(item1.Id);
                DataSource.Exams.Add(item);
            }
            throw new Exception("הבחינה לא קיימת");
        }
    }
}
