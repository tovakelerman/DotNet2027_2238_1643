using Dal;
using DalApi;
using DO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Tools;
using static System.Net.Mime.MediaTypeNames;


namespace DalTest
{
    internal class Program
    {
        private static readonly IDal s_dal = new Dal.DalList();

        static void Main(string[] args)
        {
            try
            {
                Initialization.Initialize(s_dal);
                bool exit = false;
                while (!exit)
                {
                Console.WriteLine("hello and welcome to our platform.\nto students press 1\n" + //I changed this here: g - "to student" -> "to students" (English)
                    "to tests press 2\nto question press 3\nto answer press 4\nto answer per student press 5\n" + //I changed this here: g - added the missing newline so this line does not join the next one
                    "to reset logs press 6\n" + //I changed this here: g - double-backslash n printed a backslash and an "n" - now it is a real new line
                    "\nto exit press 0\n"); //I changed this here: g - removed the duplicate newline at the end
int chice = ReadInt(); //I changed this here: int.Parse -> ReadInt (no crash on letters)
                    switch (chice)
                    {
                        case 1:
                            crudMenu(s_dal.Student, "student",AskStudent); break;
                        case 2:
                            crudMenu(s_dal.Exam, "Test", AskTest); break;
                        case 3:
                            crudMenu(s_dal.Question, "Question", AskQuestion); break;
                        case 4:
                            crudMenu(s_dal.Answer, "Answer", AskAnswer); break;
                        case 5:
                            crudMenu(s_dal.StudentQuestion, "question to student", AskStudentQuestion); break;
                        case 6:
                            LogManager.CleanLog(); break;
                        case 0:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("no valid input, try again");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        private static int ReadInt(string prompt = "") //I changed this here: new helper - int.Parse throws on bad input, TryParse does not
        {
            while (true) //I changed this here: ask again until the input is a real number
            {
                if (!string.IsNullOrEmpty(prompt)) //I changed this here: print the question only when there is one
                    Console.WriteLine(prompt);
                string? input = Console.ReadLine(); //I changed this here: string? - ReadLine can return null
                if (int.TryParse(input, out int value)) //I changed this here: TryParse returns false instead of throwing
                    return value;
                Console.WriteLine("no valid number, try again"); //I changed this here: tell the user and ask again
            }
        }


        private static void crudMenu<T>(ICrud<T> crud, String entityName, Func<T> AskFanc)
        {
            Console.WriteLine("to crete a new student press 1 to delete press 2 to read press 3 to readAll press 4 and to update press 5 ");
                int choise = ReadInt(); //I changed this here: int.Parse -> ReadInt (no crash on letters)
            switch (choise)
            {
                case 1:
                    T obj = AskFanc();
                    int newId = crud.Create(obj); //I changed this here: keep the id that the DAL returned instead of throwing it away
                    Console.WriteLine($"created successed, id = {newId}"); //I changed this here: show the new id to the user (the DAL generates it, so the user cannot know it)
                    break;
                case 2:
                    int id = ReadInt("insert id"); //I changed this here: int.Parse -> ReadInt
                    crud.Delete(id);
                    Console.WriteLine("deleted successed");
                    break;
                case 3:
                    int Id = ReadInt("insert id"); //I changed this here: int.Parse -> ReadInt
                    Console.WriteLine(crud.Read(Id));
                    break;
                case 4:
                    {
                        foreach (var item in crud.ReadAll())
                            Console.WriteLine(item);
                    }
                    break;
                case 5:
                    T Obj = AskFanc();
                    crud.Update(Obj);
                    Console.WriteLine("update successed");
                    break;
                default: //I changed this here: added - a wrong number used to close the CRUD menu silently
                    //I changed this here: show an explanation before going back to the main menu
                    Console.WriteLine($"no valid input for {entityName}"); //I changed this here: say which menu the input was wrong in (entityName was passed but never used)
                    Console.WriteLine($"please press a number between 1 and 5, or continue in the main menu"); //I changed this here: explain the valid range
                    Console.WriteLine("going back to the main menu...\n"); //I changed this here: tell the user what happens next
                    break; //I changed this here: break -> the function ends, so control returns to the main menu loop (line 22)
            }
        }

        public static Student AskStudent()
        {
            int id = ReadInt("insert id"); //I changed this here: int.Parse -> ReadInt
            Console.WriteLine("insert name");
            string name= Console.ReadLine();
            int examId = ReadInt("insert exam id"); //I changed this here: int.Parse -> ReadInt
            int grade = ReadInt("insert grade"); //I changed this here: int.Parse -> ReadInt
            Student student = new Student(id,name,examId,grade);
            return student;
        }
        public static Answer AskAnswer()
        {
            int question_id = ReadInt("insert question id"); //I changed this here: int.Parse -> ReadInt
            Console.WriteLine("insert content");
            string content = Console.ReadLine();

            Answer ans = new Answer(0, question_id, content);
            return ans;
        }
        public static Question AskQuestion()
        {
            int id = ReadInt("insert id"); //I changed this here: int.Parse -> ReadInt
            Console.WriteLine("subject: \n");
            foreach (SubjectType entity in Enum.GetValues(typeof(SubjectType)))
            {
                Console.WriteLine($"{(int)entity}. {entity}");
            }
            Console.Write("press the num of the subject ");
            bool valid = false;
            SubjectType sub = default;
            while (!valid)
            {
                string input = Console.ReadLine();
                sub = new SubjectType();
                if (Enum.TryParse(input, true, out SubjectType selectedEntity) && Enum.IsDefined(typeof(SubjectType), selectedEntity))
                {
                    sub = selectedEntity;
                    valid = true;
                }
                else Console.Write("no valid input");
            }

            Console.WriteLine("insert content");
            string content = Console.ReadLine();

            int correct = ReadInt("insert correct answer id"); //I changed this here: int.Parse -> ReadInt
            Question question = new Question(id, sub, content, correct);
            return question;
        }

        public static Exam AskTest()
        {

            Console.WriteLine("subject: \n");
            foreach (SubjectType entity in Enum.GetValues(typeof(SubjectType)))
            {
                Console.WriteLine($"{(int)entity}. {entity}");
            }
            Console.Write("press the num of the subject ");
            bool valid = false;
            SubjectType sub = default;
            while (!valid)
            {
                string input = Console.ReadLine();
                sub = new SubjectType();
                if (Enum.TryParse(input, true, out SubjectType selectedEntity) && Enum.IsDefined(typeof(SubjectType), selectedEntity))
                {
                    sub = selectedEntity;
                    valid = true;
                }
                else Console.Write("no valid input\n");
            }

            Console.WriteLine("insert Date\n");
            DateTime date = DateTime.Parse(Console.ReadLine());
            int quest = ReadInt("insert question number"); //I changed this here: int.Parse -> ReadInt (the prompt moved into ReadInt)

            Exam exam = new Exam(0, sub, date, quest);
            return exam;
        }

        public static StudentQuestion AskStudentQuestion()
        {
            int student_id = ReadInt("insert student id"); //I changed this here: int.Parse -> ReadInt
            int test_id = ReadInt("insert test id"); //I changed this here: int.Parse -> ReadInt
            int answer_id = ReadInt("insert qestion id"); //I changed this here: int.Parse -> ReadInt
            int selected_answer_id = ReadInt("insert selected answer id"); //I changed this here: int.Parse -> ReadInt
            StudentQuestion studentQuestion = new StudentQuestion(0, student_id, test_id, answer_id, selected_answer_id);
            return studentQuestion;
        }
    }
}
