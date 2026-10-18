using Dal;
using DalApi;
using DO;

namespace DalApi;

internal class StudentImplementation : IStudent
{
    public int Create(Student item)
    {
        if (item == null) throw new ArgumentNullException("item");

        foreach (Student student in DataSource.Students)
        {
            if (student.Id == item.Id)

                    }
        DataSource.Students.Add(item);

        return item.Id;
    }

    public void Delete(int id)
    {
        foreach (Student item in DataSource.Students)
        {
            if (item.Id == id)
                DataSource.Students.Remove(item);
        }
        throw new NotImplementedException();
    }

    public Student? Read(int id)
    {
        foreach (var item in DataSource.Students)
        {
            if (item.Id.Equals(id))
            {
                return item;
            }
        }
        return null;
    }


    public List<Student> ReadAll()
    {
        return new List<Student>(DataSource.Students);
    }

    public void Update(Student item)
    {
        foreach (Student item1 in DataSource.Students)
        {
            if (item1.Id == item.Id)
            {
                Delete(item1.Id);
                DataSource.Students.Add(item);
            }
            throw new Exception("התלמיד לא קיים");

        }
    }
}
