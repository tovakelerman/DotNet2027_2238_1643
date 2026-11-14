

namespace DO;

/// <summary>
///מייצג את הנושאים שעליהם ניתן להיבחן
/// </summary>
public enum SubjectType
{
    Programming,
    CSharp,
    Java,
    C,
    Python,
    Core,
    React,
    Node,
    Databases, //I changed this here: added - Initialization uses SubjectType.Databases and it did not exist (adding at the END so existing values keep their numbers)
    Networks //I changed this here: added - Initialization uses SubjectType.Networks and it did not exist
}