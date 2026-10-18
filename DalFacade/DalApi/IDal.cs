namespace DalApi
{
    public interface IDal
    {
        IStudent Student { get; }
        IAnswer Answer { get; } 
        IExam Exam { get; } 
        IQuestion Question { get; }
        IStudentQueston Queston { get; }

    }
}
