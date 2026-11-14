using Dal;
using DalApi;
using DO;
using System.Reflection;
using System.IO;
using Tools;
using static Dal.DataSource;


namespace Dal;//I changed this here (was: namespace DalApi;)
internal class AnswerImplementation : IAnswer
{
    public int Create(Answer item)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");
        if (item == null)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "שגיאת nullreference ");
            throw new ArgumentNullException("item");
        }
        Answer answer = item with { Id = DataSource.Config.NextAnswerId };
        DataSource.Answers.Add(answer);
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הסתיימה בהצלחה");
        return answer.Id;
    }

    public void Delete(int id)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");

        foreach (Answer item in DataSource.Answers)
        {
            if (item.Id == id)
            {
                DataSource.Answers.Remove(item);
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הסתיימה בהצלחה");

                return; //I changed this here: return after a successful delete, so the "not found" throw below is skipped
            }
        }
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "שגיאת notExsist");

        throw new Exception("התשובה לא קיימת"); //I changed this here: throw only if the loop ended without finding the answer
    }

    public Answer? Read(int id)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");

        foreach (var item in DataSource.Answers)
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
    public List<Answer> ReadAll()
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");

        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הסתיימה בהצלחה");

        return new List<Answer>(DataSource.Answers);
    }

    public void Update(Answer item)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");

        foreach (Answer item1 in DataSource.Answers)
        {
            if (item1.Id == item.Id)
            {
                Delete(item1.Id);
                DataSource.Answers.Add(item);
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הסתיימה בהצלחה");

                return; //I changed this here: return after a successful update, so the "answer not found" throw is skipped
            }
        }
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "שגיאת notExsist");

        throw new Exception("התשובה לא קיימת"); //I changed this here: moved the throw OUT of the loop - it now runs only if no answer with this Id was found

    }
}
