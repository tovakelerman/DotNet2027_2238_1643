using Dal;
using DalApi;
using DO;
using static Dal.DataSource;

namespace DalApi;

internal class AnswerImplementation : IAnswer
{
    public int Create(Answer item)
    {
        if (item == null) throw new ArgumentNullException("item");
        Answer answer = item with { Id = DataSource.Config.NextAnswerId };
        DataSource.Answers.Add(answer);
        return answer.Id;
        }

    public void Delete(int id)
    {
        foreach (Answer item in DataSource.Answers)
        {
            if(item.Id==id)
                DataSource.Answers.Remove(item);
        }
        throw new NotImplementedException();
    }

    public Answer? Read(int id)
    {
        foreach (var item in DataSource.Answers)
        {
            if (item.Id.Equals(id))
            {
                return item;
            }
        }
        return null;
    }
;
    public List<Answer> ReadAll()
    {
        return new List<Answer>(DataSource.Answers);
    }

    public void Update(Exam item)
    {
        foreach (Exam item1 in DataSource.Exams)
        {
            if (item1.Id == item.Id)
            {
                Delete(item1.Id);
                DataSource.Exams.Add(item);
            }
            throw new Exception("התשובה לא קיימת");

        }
    }
}
