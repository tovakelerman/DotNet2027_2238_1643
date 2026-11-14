namespace DO; //I changed this here (was: namespace DalFacade.DO;)

///// <summary>
////// מייצג את הקשר בין תלמיד, בחינה, שאלה והתשובה שהנבחן בחר בפועל.
///// </summary>

public record StudentQuestion(
    int StudentQuestionId,     //I changed this here: long -> int (the question number is no longer part of the id, so int is enough)
    int StudentId,             // מזהה תלמיד
    int ExamId,                // מזהה בחינה
    int QuestionId,            // מזהה שאלה
    int? SelectedAnswerId      // מזהה תשובה שנבחרה
)
{
    // בנאי ריק
    public StudentQuestion() : this(0, 0, 0, 0, 0)
    {
    }

    // בנאי המקבל את שאר המשתנים
    public StudentQuestion(int studentId, int examId, int questionId, int? selectedAnswerId)
        : this(0, studentId, examId, questionId, selectedAnswerId) //I changed this here: id = 0 -> the DAL gives the real id in Create (running number)
    {
    }

    //I changed this here: ComposeId was DELETED - an id built from student+exam is the same for every question,
    //so Delete/Read could not tell two records apart. The id is now a unique running number in DataSource.Config.
}