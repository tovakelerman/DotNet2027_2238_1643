using Dal;
using DalApi;
using DO;
using System.Reflection;
using Tools;

namespace Dal; //I changed this here (was: namespace DalApi;)

internal class StudentQuestionImplementation : IStudentQueston
{

    public int Create(StudentQuestion item) //I changed this here: long -> int (matches IStudentQueston)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");

        if (item == null) throw new ArgumentNullException(nameof(item)); //I changed this here: added the null check that every other Create has (otherwise the next line throws a NullReferenceException)
        foreach (StudentQuestion item1 in DataSource.studentQuestions)
        {
            if (item1.StudentId == item.StudentId && item1.ExamId == item.ExamId && item1.QuestionId == item.QuestionId) //I changed this here: compare the real key (student+exam+question) instead of the generated id, so duplicates are actually blocked
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "שגיאת AlreadyExists");
                throw new InvalidOperationException("השאלה כבר קיימת לתלמיד זה"); //I changed this here: the throw is now INSIDE the if - it runs only for a real duplicate, not on the first loop iteration
            }
        } //I changed this here: the loop ends normally when there is no duplicate
        //I changed this here: throw ArgumentNullException -> InvalidOperationException - the item is not null, the problem is that the record already exists
        StudentQuestion studentQuestion = item with { StudentQuestionId = DataSource.Config.NextStudentQuestionId }; //I changed this here: ComposeId -> running number - one unique id for every record, so Delete/Read find the right row
        DataSource.studentQuestions.Add(studentQuestion); //I changed this here: Add is now OUTSIDE the foreach (was throwing InvalidOperationException) and stores the record with the new id
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הסתיימה בהצלחה");

        return studentQuestion.StudentQuestionId; //I changed this here: return int - the composed id of the stored record
    }

    public void Delete(int id) //I changed this here: long -> int (matches IStudentQueston)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");

        foreach (StudentQuestion item1 in DataSource.studentQuestions)
        {
            if (item1.StudentQuestionId == id) //I changed this here: item1.id/item.id -> item1.StudentQuestionId/id (StudentQuestion has no "id" property, and "item" did not exist in Delete)
            {
                DataSource.studentQuestions.Remove(item1);
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הסתיימה בהצלחה");

                return; //I changed this here: return after a successful delete, so the "not found" throw below is skipped
            }
        }
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "שגיאת notExsist");

        throw new Exception("השאלה לא קיימת לתלמיד זה במבחן"); //I changed this here: throw only if the loop ended without finding the record
    }

    public StudentQuestion? Read(int id) //I changed this here: long -> int; ICrud-style lookup by the unique id (was Read(int,int,int), which did not implement the interface)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");

        foreach (StudentQuestion item1 in DataSource.studentQuestions)
        {
            if (item1.StudentQuestionId == id) //I changed this here: compare with the id parameter, and return item1 (was comparing item with itself and returning a variable that does not exist)
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הסתיימה בהצלחה");
                return item1; //I changed this here: the return moved INSIDE the if - before, it returned the first row even when the id did not match
            }
        }
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "שגיאת notExsist");

        return null;
    }

    public List<StudentQuestion> ReadAll()
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הסתיימה בהצלחה");

        return new List<StudentQuestion>(DataSource.studentQuestions);
    }

    public void Update(StudentQuestion item)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");

        foreach (StudentQuestion item1 in DataSource.studentQuestions)
        {
            if (item1.StudentId == item.StudentId && item1.ExamId == item.ExamId && item1.QuestionId == item.QuestionId) //I changed this here: match the record by its real key
            {
                int newId = item1.StudentQuestionId; //I changed this here: the id no longer follows the key - keep the old unique id
                if (item.StudentQuestionId != item1.StudentQuestionId) //I changed this here: the caller changed the record itself (another student/exam/question)
                    newId = DataSource.Config.NextStudentQuestionId; //I changed this here: give it a new unique id, like a new record
                Delete(item1.StudentQuestionId); //I changed this here: no cast needed
                StudentQuestion studentQuestion = item with { StudentQuestionId = newId }; //I changed this here: store the updated record with its id
                DataSource.studentQuestions.Add(studentQuestion); //I changed this here: add the updated record (was adding item as-is, with whatever id the caller sent)
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הסתיימה בהצלחה");

                return; //I changed this here: return after a successful update, so the "not found" throw is skipped
            }
        }
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "שגיאת notExsist");

        throw new Exception("שאלה לא קיימת במבחן לתלמיד זה"); //I changed this here: moved the throw OUT of the loop - it now runs only if no record with this Id was found
    }
}
