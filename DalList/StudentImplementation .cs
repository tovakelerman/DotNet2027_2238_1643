using Dal;
using DalApi;
using DO;
using System.Reflection;
using Tools;

namespace Dal;

internal class StudentImplementation : IStudent
{
    public int Create(Student item)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");

        if (item == null) throw new ArgumentNullException("item");

        foreach (Student student in DataSource.Students)
        {
            if (student.Id == item.Id && student.ExamId == item.ExamId) //I changed this here: duplicate = same student IN THE SAME EXAM - one student may sit more than one exam (option B)
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "שגיאת AlredyExsist");
                throw new Exception("התלמיד כבר קיים"); //I changed this here: moved the throw INSIDE the if - before, it ran on the first row, so a new student could never be added
            }
        } //I changed this here: close the loop (the closing brace used to sit in the wrong place)
        DataSource.Students.Add(item);

        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הסתיימה בהצלחה");

        return item.Id;
    }

    public void Delete(int id)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");

        foreach (Student item in DataSource.Students)
        {
            if (item.Id == id)
            {
                DataSource.Students.Remove(item);
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הסתיימה בהצלחה");

                return; //I changed this here: return after a successful delete, so the "not found" throw below is skipped
            }
        }
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "שגיאת notExsist");

        throw new Exception("התלמיד לא קיים"); //I changed this here: throw only if the loop ended without finding the student
        //I changed this here: deleted throw new NotImplementedException(); (Delete already removes the item)
    }

    public Student? Read(int id)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");

        foreach (var item in DataSource.Students)
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


    public List<Student> ReadAll()
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הסתיימה בהצלחה");

        return new List<Student>(DataSource.Students);
    }

    public void Update(Student item)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הופעלה");

        foreach (Student item1 in DataSource.Students)
        {
            if (item1.Id == item.Id && item1.ExamId == item.ExamId) //I changed this here: same key as Create (student + exam), otherwise Update could replace the row of another exam
            {
                Delete(item1.Id); //I changed this here: still to check - Delete removes EVERY row of this student (all exams), not only this one
                DataSource.Students.Add(item);
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הפונקציה הסתיימה בהצלחה");

                return; //I changed this here: return after a successful update, so the "student not found" throw is skipped
            }
        }
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "שגיאת notExsist");

        throw new Exception("התלמיד לא קיים"); //I changed this here: moved the throw OUT of the loop - it now runs only if no student with this Id was found

}
}
