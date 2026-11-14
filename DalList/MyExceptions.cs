using System;
using System.Collections.Generic;
using System.Text;


namespace Dal
{

    public class MyExceptions : Exception
    {
        public MyExceptions(String message) : base(message) { }
        public MyExceptions(String message,Exception innerExp):base(message, innerExp) { }
    }
   
    public class DalDoesNotExistException : MyExceptions
    {
        public DalDoesNotExistException() : base("Dal Does Not Exist") { }
    }
    public class DalAlreadyExistsException : MyExceptions
    {
        public DalAlreadyExistsException() : base("Dal Already Exists") { }
    }
}