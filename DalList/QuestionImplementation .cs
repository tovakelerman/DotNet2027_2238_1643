using Dal;
using DalApi;
using DO;
using System.Reflection;
using Tools;


namespace Dal; //I changed this here (was: namespace DalApi;)

internal class QuestionImplementation : IQuestion
{
    public int Create(Question item)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");

        if (item == null)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "שגיאת NullReference");

            throw new ArgumentNullException("item");
        }
        Question question= item with { Id = DataSource.Config.NextQuestionId };
        DataSource.questions.Add(question);
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הסתיימה בהצלחה");

        return question.Id;
    }

    public void Delete(int id)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");

        foreach (Question item in DataSource.questions)
        {
            if (item.Id == id)
            {
                DataSource.questions.Remove(item);
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הסתיימה בהצלחה");

                return; //I changed this here: return after a successful delete, so the "not found" throw below is skipped
            }
        }
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "שגיאת notExsist");

        throw new Exception("השאלה לא קיימת"); //I changed this here: throw only if the loop ended without finding the question
    }

    public Question? Read(int id)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");

        foreach (var item in DataSource.questions)
        {
            if (item.Id.Equals(id))
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הסתיימה בהצלחה");

                return item;
            }
        }
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "שגיאת notExsist");

        return null;
    }


    public List<Question> ReadAll()
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הסתיימה בהצלחה");

        return new List<Question>(DataSource.questions);
    }

    public void Update(Question item)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");

        foreach (Question item1 in DataSource.questions)
        {
            if (item1.Id == item.Id)
            {
                Delete(item1.Id);
                DataSource.questions.Add(item);
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הסתיימה בהצלחה");

                return; //I changed this here: return after a successful update, so the "question not found" throw is skipped
            }
        }
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "שגיאת notExsist");

        throw new Exception("השאלה לא קיימת"); //I changed this here: moved the throw OUT of the loop - it now runs only if no question with this Id was found

}
}
