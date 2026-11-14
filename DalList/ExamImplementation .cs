using Dal;
using DalApi;
using DO;
using System.Reflection;
using Tools;


namespace Dal; //I changed this here (was: namespace DalApi;)

internal class ExamImplementation : IExam
{
    public int Create(Exam item)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");

        if (item == null)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "שגיאת nullreference ");
            throw new ArgumentNullException("item");
        }
        Exam exam = item with { Id = DataSource.Config.NextExamId };
        DataSource.Exams.Add(exam);
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הסתיימה בהצלחה");
        return exam.Id;
    }

    public void Delete(int id)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");

        foreach (Exam item in DataSource.Exams) //I changed this here: DataSource.Exam -> DataSource.Exams (Exam was not a member of DataSource)
        {
            if (item.Id == id)
            {
                DataSource.Exams.Remove(item);
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הסתיימה בהצלחה");

                return; //I changed this here: return after a successful delete, so the "not found" throw below is skipped
            }
        }
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "שגיאת notExsist");
        throw new Exception("הבחינה לא קיימת"); //I changed this here: throw only if the loop ended without finding the exam
    }

    public Exam? Read(int id)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");

        foreach (var item in DataSource.Exams)
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


    public List<Exam> ReadAll()
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הסתיימה בהצלחה");

        return new List<Exam>(DataSource.Exams);
    }

    public void Update(Exam item)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");

        foreach (Exam item1 in DataSource.Exams)
        {
            if (item1.Id == item.Id)
            {
                Delete(item1.Id);
                DataSource.Exams.Add(item);
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הסתיימה בהצלחה");
                return; //I changed this here: return after a successful update, so the "exam not found" throw is skipped
            }
        }
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "שגיאת notExsist");

        throw new Exception("הבחינה לא קיימת"); //I changed this here: moved the throw OUT of the loop - it now runs only if no exam with this Id was found

    }
}
