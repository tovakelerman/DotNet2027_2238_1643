using DO;

namespace DalApi;

//I changed this here: now inherits ICrud<StudentQuestion> again - the key is int, so it matches ICrud exactly,
//and crudMenu<T>(ICrud<T> ...) accepts s_dal.StudentQuestion (this removes error CS1503 in Program.cs line 40)
public interface IStudentQueston : ICrud<StudentQuestion>
{
}
