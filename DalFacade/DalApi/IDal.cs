namespace DalApi
{
    public interface IDal
    {
        IStudent Student { get; }
        IAnswer Answer { get; } 
        IExam Exam { get; } 
        IQuestion Question { get; }
        IStudentQueston StudentQuestion { get; } //I changed this here: Queston -> StudentQuestion (typo in the name; the interface IStudentQueston itself is left as-is)

    }
}
