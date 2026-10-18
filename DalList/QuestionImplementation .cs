using Dal;
using DalApi;
using DO;

namespace DalApi;

internal class QuestionImplementation : IQuestion
{
    public int Create(Question item)
    {
        if (item == null) throw new ArgumentNullException("item");
        Question question= item with { Id = DataSource.Config.NextQuestionId };
        DataSource.questions.Add(question);
        return question.Id;
    }

    public void Delete(int id)
    {
        foreach (Question item in DataSource.questions)
        {
            if (item.Id == id)
                DataSource.Answers.Remove(item);
        }
        throw new NotImplementedException();
    }

    public Question? Read(int id)
    {
        foreach (var item in DataSource.questions)
        {
            if (item.Id.Equals(id))
            {
                return item;
            }
        }
        return null;
    }


    public List<Question> ReadAll()
    {
        return new List<Question>(DataSource.questions);
    }

    public void Update(Question item)
    {
        foreach (Question item1 in DataSource.questions)
        {
            if (item1.Id == item.Id) {
                Delete(item1.Id);
                DataSource.questions.Add(item);
            }
            throw new Exception("השאלה לא קיימת");

        }
    }
}
