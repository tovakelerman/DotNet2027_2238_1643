
using DalApi;
using System.Reflection;

namespace Dal
{
    public class DalList: IDal
    {
        public IStudent Student => new StudentImplementation();

        public IAnswer Answer => new AnswerImplementation();

        public IExam Exam => new ExamImplementation();

        public IQuestion Question => new QuestionImplementation();

        public IStudentQueston StudentQuestion => new StudentQuestionImplementation(); //I changed this here: Queston -> StudentQuestion, to match the renamed member in IDal
    }
}

