using DO;
using DalApi;


namespace DalTest;


public static class Initialization
{
    private static IDal s_dal;
    
    private static void CreateAnswer()
    {
        // אתחול התשובות (תשובה נכונה ו-3 תשובות שגויות לכל שאלה)

        // שאלה 1
        s_dal.Answer.Create(new Answer(NextAnswerId, 1, "תכנות מונחה עצמים מתמקד באובייקטים המשלבים נתונים ופעולות יחד, בעוד תכנות פרוצדורלי מתמקד בפונקציות וביצוע של משימות שלב אחר שלב.")); // נכונה
        s_dal.Answer.Create(new Answer(NextAnswerId, 1, "תכנות פרוצדורלי משתמש תמיד במחלקות וממשקים, בעוד מונחה עצמים פועל רק עם פונקציות גלובליות."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 1, "אין שום הבדל מעשי בין השניים, מדובר בשמות שונים לאותו תחביר בדיוק."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 1, "תכנות מונחה עצמים מיועד אך ורק לחומרה ולרשתות, ותכנות פרוצדורלי מיועד למסדי נתונים בלבד."));

        // שאלה 2
        s_dal.Answer.Create(new Answer(NextAnswerId, 2, "איתור ושחרור אוטומטי של זיכרון שהוקצה לאובייקטים שאינם נמצאים עוד בשימוש בתוכנה.")); // נכונה
        s_dal.Answer.Create(new Answer(NextAnswerId, 2, "מחיקת קבצים מיותרים מדיסק הקשיח של המשתמש בעת הפעלת התוכנה."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 2, "איסוף הודעות שגיאה מלוג המערכת ורישומן בקבצי גיבוי."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 2, "המרת קוד מקור לשפת מכונה באופן אוטומטי טרם הידור התוכנית."));

        // שאלה 3
        s_dal.Answer.Create(new Answer(NextAnswerId, 3, "O(log n)")); // נכונה
        s_dal.Answer.Create(new Answer(NextAnswerId, 3, "O(n)"));
        s_dal.Answer.Create(new Answer(NextAnswerId, 3, "O(n^2)"));
        s_dal.Answer.Create(new Answer(NextAnswerId, 3, "O(1)"));

        // שאלה 4
        s_dal.Answer.Create(new Answer(NextAnswerId, 4, "עקרון המורה להימנע ככל הניתן משכפול קוד במערכת על ידי יצירת פונקציות או רכיבים הניתנים לשימוש חוזר.")); // נכונה
        s_dal.Answer.Create(new Answer(NextAnswerId, 4, "דרישה לייבש קבצי קוד שנרטבו או נפגמו במהלך העברת נתונים ברשת."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 4, "הימנעות משימוש במשתנים גלובליים בכל מחלקות התוכנה."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 4, "חובה לבצע שמירה אוטומטית של פרויקט התכנות בכל מספר דקות."));

        // שאלה 5
        s_dal.Answer.Create(new Answer(NextAnswerId, 5, "מחסנית פועלת בשיטת LIFO (האחרון שנכנס יוצא ראשון), ותור פועל בשיטת FIFO (הראשון שנכנס יוצא ראשון).")); // נכונה
        s_dal.Answer.Create(new Answer(NextAnswerId, 5, "מחסנית שומרת נתונים בזיכרון ה-RAM ותור שומר נתונים בדיסק הקשיח בלבד."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 5, "אין הבדל מבני, שניהם פועלים אך ורק בשיטת FIFO."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 5, "תור מיועד לנתונים מספריים בלבד, ומחסנית מיועדת למחלקות ולמחרוזות טקסט."));

        // שאלה 6
        s_dal.Answer.Create(new Answer(NextAnswerId, 6, "הבטחת ייחודיות מוחלטת לכל שורה (רשומה) בטבלה.")); // נכונה
        s_dal.Answer.Create(new Answer(NextAnswerId, 6, "הגנה על מסד הנתונים מפני פריצות סייבר וגישה לא מורשית."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 6, "האצת פעולות חישוב מתמטיות של השאילתות בשרת."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 6, "קביעת סדר הצגת הנתונים במסך המשתמש באופן אוטומטי."));

        // שאלה 7
        s_dal.Answer.Create(new Answer(NextAnswerId, 7, "ממשק תכנות יישומים המאפשר לתקשר ולעבד מידע בין מערכות תוכנה שונות.")); // נכונה
        s_dal.Answer.Create(new Answer(NextAnswerId, 7, "פרוטוקול אבטחה מתקדם להצפנת קבצי מערכת הפעלה."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 7, "סביבת פיתוח משולבת (IDE) לבניית יישומי צד-שרת."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 7, "שפת תכנות חדשה המיועדת לפיתוח ממשקי משתמש גרפיים."));

        // שאלה 8
        s_dal.Answer.Create(new Answer(NextAnswerId, 8, "האצת תהליכי שליפת נתונים וחיפוש בטבלאות גדולות על חשבון נפח אחסון וזמן עדכון.")); // נכונה
        s_dal.Answer.Create(new Answer(NextAnswerId, 8, "מחיקת שורות כפולות וישנות מהטבלה באופן אוטומטי."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 8, "יצירת קשרים פיזיים בין טבלאות שונות ללא צורך במפתחות זרים."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 8, "גיבוי יומי של כל נתוני המסד לשרת חיצוני."));

        // שאלה 9
        s_dal.Answer.Create(new Answer(NextAnswerId, 9, "אטומיות, עקביות, בידוד ועמידות המבטיחים אמינות בפעולות טרנזקציה.")); // נכונה
        s_dal.Answer.Create(new Answer(NextAnswerId, 9, "שיטת דחיסת נתונים מתקדמת לחיסכון במקום אחסון בשרת."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 9, "פרוטוקול תקשורת לאבטחת העברת נתונים בין לקוח לשרת ב-SQL."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 9, "מנגנון לזיהוי ותיקון שגיאות חומרה בדיסקים קשיחים."));

        // שאלה 10
        s_dal.Answer.Create(new Answer(NextAnswerId, 10, "INNER JOIN מחזיר רק רשומות בעלות התאמה בשתי הטבלאות, ואילו LEFT JOIN מחזיר את כל הרשומות מהטבלה השמאלית גם אם אין להן התאמה.")); // נכונה
        s_dal.Answer.Create(new Answer(NextAnswerId, 10, "INNER JOIN מיועד לחיפוש טקסט ואילו LEFT JOIN מיועד למספרים בלבד."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 10, "אין הבדל ביניהם והם מריצים את אותה שאילתת בדיוק."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 10, "LEFT JOIN פועל רק בבסיסי נתונים לא-רלציוניים (NoSQL)."));

        // שאלה 11
        s_dal.Answer.Create(new Answer(NextAnswerId, 11, "תהליך תכנון מבנה הטבלאות לצמצום כפילויות מידע ומניעת אנומליות בעדכון.")); // נכונה
        s_dal.Answer.Create(new Answer(NextAnswerId, 11, "תהליך המרת שמות עמודות לאנגלית תקנית ואחידה."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 11, "איפוס סיסמאות המשתמשים במסד הנתונים לברירת המחדל."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 11, "מיון נתוני הטבלה בסדר אלפבתי עולה."));

        // שאלה 12
        s_dal.Answer.Create(new Answer(NextAnswerId, 12, "קיבוץ שורות בעלות מאפיינים משותפים לביצוע חישובים סטטיסטיים או סיכומים עליהן.")); // נכונה
        s_dal.Answer.Create(new Answer(NextAnswerId, 12, "מיזוג שתי טבלאות שונות לטבלה אחת ראשית."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 12, "מחיקת שורות כפולות המכילות ערכים ריקים (NULL)."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 12, "הקמת קבוצות הרשאות חדשות למשתמשי המערכת."));

        // שאלה 13
        s_dal.Answer.Create(new Answer(NextAnswerId, 13, "יומן הטרנזקציות מתעד ברצף כל שינוי שבוצע לצרכי שחזור ובקרה, והנתונים נשמרים בטבלאות הראשיות.")); // נכונה
        s_dal.Answer.Create(new Answer(NextAnswerId, 13, "קובץ הטרנזקציות מיועד לסיסמאות והנתונים הראשיים לתוכן הרגיל."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 13, "אין הבדל, מדובר באותו קובץ בדיוק המשוכפל לגיבוי."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 13, "קובץ הלוג משמש אך ורק לעבודה במצב אופליין."));

        // שאלה 14
        s_dal.Answer.Create(new Answer(NextAnswerId, 14, "תרגום כתובות מתחם (Domain Names) מילים קריאות לכתובות IP מספריות.")); // נכונה
        s_dal.Answer.Create(new Answer(NextAnswerId, 14, "הצפנת נתוני הגלישה מפני האזנה של ספקי האינטרנט."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 14, "ניתוב מהיר של חבילות מידע בין ראוטרים שונים בעולם."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 14, "ניהול חיבורי ה-Wi-Fi במכשירים ניידים."));

        // שאלה 15
        s_dal.Answer.Create(new Answer(NextAnswerId, 15, "TCP מבטיח הגעה אמינה ומסודרת של המידע באמצעות אישורים הדדיים, ואילו UDP מהיר יותר אך אינו מבטיח אמינות או סדר הגעה.")); // נכונה
        s_dal.Answer.Create(new Answer(NextAnswerId, 15, "UDP מאובטח לחלוטין בהצפנה מתקדמת ו-TCP אינו מוצפן כלל."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 15, "TCP מיועד לקבצי טקסט ו-UDP מיועד אך ורק לתמונות."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 15, "אין הבדל ביניהם מבחינת מהירות או אמינות העברת הנתונים."));

        // שאלה 16
        s_dal.Answer.Create(new Answer(NextAnswerId, 16, "סינון תעבורת הרשת הנכנסת והיוצאת על פי חוקי אבטחה מוגדרים מראש.")); // נכונה
        s_dal.Answer.Create(new Answer(NextAnswerId, 16, "מניעת התחממות יתר של רכיבי החומרה בשרתים מרכזיים."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 16, "מחיקת וירוסים וקבצים זדוניים מדיסק הקשיח באופן אוטומטי."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 16, "האצת מהירות הגלישה ברשת המקומית (LAN)."));

        // שאלה 17
        s_dal.Answer.Create(new Answer(NextAnswerId, 17, "IPv4 משתמשת ב-32 סיביות ומאפשרת מרחב כתובות מוגבל, בעוד IPv6 משתמשת ב-128 סיביות לפתרון מחסור הכתובות העולמי.")); // נכונה
        s_dal.Answer.Create(new Answer(NextAnswerId, 17, "IPv4 אינה בשימוש עוד וכל האתרים בעולם עברו ל-IPv6 בלבד."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 17, "IPv6 מהירה פי עשרה מ-IPv4 במהירות הורדת הנתונים."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 17, "אין שום הבדל במספר הסיביות, ההבדל הוא רק בשמות הגרסאות."));

        // שאלה 18
        s_dal.Answer.Create(new Answer(NextAnswerId, 18, "הצפנת המידע המועבר ברשת למניעת האזנה, גניבה או שינוי של נתונים רגישים.")); // נכונה
        s_dal.Answer.Create(new Answer(NextAnswerId, 18, "הפחתת זמן טעינת העמודים בדפדפן האינטרנט."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 18, "חסימת פרסומות קופצות באתרים מסחריים."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 18, "מניעת נפילות שרת בזמן עומס משתמשים גבוה."));

        // שאלה 19
        s_dal.Answer.Create(new Answer(NextAnswerId, 19, "איבוד חבילות נתונים בדרכן מיעד א' ליעד ב' עקב עומס או תקלות רשת.")); // נכונה
        s_dal.Answer.Create(new Answer(NextAnswerId, 19, "גניבת סיסמאות משתמשים על ידי האקרים ברשת הפתוחה."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 19, "תשלום כספי מיותר עבור נפח גלישה חודשי בספק האינטרנט."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 19, "מחיקת קבצי מטמון (Cache) מהדפדפן באופן ידני."));

        // שאלה 20
        s_dal.Answer.Create(new Answer(NextAnswerId, 20, "ניתוב חבילות מידע בין רשתות שונות בדרך היעילה ביותר אל היעד.")); // נכונה
        s_dal.Answer.Create(new Answer(NextAnswerId, 20, "אחסון קבצים ושיתופם בין מחשבים באותה רשת מקומית."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 20, "המרת אותות חשמליים לאותות אופטיים בסיב אופטי."));
        s_dal.Answer.Create(new Answer(NextAnswerId, 20, "הגנה פיזית על ארונות תקשורת מפני נזקי מזג אוויר."));



    }

    private static void CreateExam()
    {
        s_dal.Exam.Create(new Exam(NextExamId, SubjectType.Programming, new DateTime(2026, 1, 15), 5));
        s_dal.Exam.Create(new Exam(NextExamId, SubjectType.Databases, new DateTime(2026, 2, 10), 5));
        s_dal.Exam.Create(new Exam(NextExamId, SubjectType.Networks, new DateTime(2026, 3, 5), 5));
        s_dal.Exam.Create(new Exam(NextExamId, SubjectType.Programming, new DateTime(2026, 4, 20), 5));
        s_dal.Exam.Create(new Exam(NextExamId, SubjectType.Databases, new DateTime(2026, 5, 12), 5));
    }

    private static void CreateQuestion()
    {
        // אתחול השאלות
        s_dal.Question.Create(new Question(NextQuestionId, SubjectType.Programming, "מהו ההבדל המרכזי בין עקרונות תכנות מונחה עצמים (OOP) לתכנות פרוצדורלי?", 1));
        s_dal.Question.Create(new Question(NextQuestionId, SubjectType.Programming, "מה תפקידו של מנגנון ה-Garbage Collection בשפות ניהול זיכרון אוטומטיות?", 5));
        s_dal.Question.Create(new Question(NextQuestionId, SubjectType.Programming, "מהי מורכבות הזמן (Time Complexity) של אלגוריתם חיפוש בינארי (Binary Search)?", 9));
        s_dal.Question.Create(new Question(NextQuestionId, SubjectType.Programming, "מה המשמעות של עקרון ה-DRY (Don't Repeat Yourself) בפיתוח תוכנה?", 13));
        s_dal.Question.Create(new Question(NextQuestionId, SubjectType.Programming, "מה ההבדל בין מבנה נתונים מסוג Stack (מחסנית) לבין Queue (תור)?", 17));
        s_dal.Question.Create(new Question(NextQuestionId, SubjectType.Programming, "מהו תפקידו של מפתח ראשי (Primary Key) במסד נתונים רלציוני?", 21));
        s_dal.Question.Create(new Question(NextQuestionId, SubjectType.Programming, "מה פירוש המושג API בפיתוח תוכנה?", 25));

        s_dal.Question.Create(new Question(NextQuestionId, SubjectType.Databases, "מהו תפקידו של מדד (Index) במסד נתונים?", 29));
        s_dal.Question.Create(new Question(NextQuestionId, SubjectType.Databases, "מה משמעות המונח ACID בניהול מסדי נתונים רלציוניים?", 33));
        s_dal.Question.Create(new Question(NextQuestionId, SubjectType.Databases, "מה ההבדל בין פעולת INNER JOIN לפעולת LEFT JOIN בשפת SQL?", 37));
        s_dal.Question.Create(new Question(NextQuestionId, SubjectType.Databases, "מהי נורמליזציה (Normalization) במסדי נתונים?", 41));
        s_dal.Question.Create(new Question(NextQuestionId, SubjectType.Databases, "מהי מטרתה של שאילתת Aggregation כגון GROUP BY?", 45));
        s_dal.Question.Create(new Question(NextQuestionId, SubjectType.Databases, "מה ההבדל בין קובץ Transaction Log לבין קובץ הנתונים הראשי במסד נתונים?", 49));

        s_dal.Question.Create(new Question(NextQuestionId, SubjectType.Networks, "מה תפקידו של פרוטוקול ה-DNS ברשת האינטרנט?", 53));
        s_dal.Question.Create(new Question(NextQuestionId, SubjectType.Networks, "מה ההבדל העיקרי בין פרוטוקול TCP לבין פרוטוקול UDP?", 57));
        s_dal.Question.Create(new Question(NextQuestionId, SubjectType.Networks, "מהו תפקידו של פיירוול (Firewall) באבטחת מידע?", 61));
        s_dal.Question.Create(new Question(NextQuestionId, SubjectType.Networks, "מה ההבדל בין כתובת IP גרסה 4 (IPv4) לכתובת IP גרסה 6 (IPv6)?", 65));
        s_dal.Question.Create(new Question(NextQuestionId, SubjectType.Networks, "מהי מטרת פרוטוקול ההצפנה HTTPS בתקשורת דפדפן ושרת?", 69));
        s_dal.Question.Create(new Question(NextQuestionId, SubjectType.Networks, "מה משמעות המושג Packet Loss בתקשורת נתונים?", 73));
        s_dal.Question.Create(new Question(NextQuestionId, SubjectType.Networks, "מהו תפקידו של מנתב (Router) ברשת תקשורת מחשבים?", 77));

    }

    private static void CreateStudent()
    {
        // מבחן ראשון
        s_dal.Student.Create(new Student(216258954, "תמר כהן", 1000, 88));
        s_dal.Student.Create(new Student(313145698, "יצחק שמיר", 1000, 92));
        s_dal.Student.Create(new Student(217852963, "לאה רוט", 1000, 79));
        s_dal.Student.Create(new Student(215874965, "רבקה שיק", 1000, 95));
        s_dal.Student.Create(new Student(220458987, "מרים לוי", 1000, 84));

        // מבחן שני
        s_dal.Student.Create(new Student(216258954, "תמר כהן", 1001, 91));
        s_dal.Student.Create(new Student(313145698, "יצחק שמיר", 1001, 87));
        s_dal.Student.Create(new Student(217852963, "לאה רוט", 1001, 90));
        s_dal.Student.Create(new Student(215874965, "רבקה שיק", 1001, 78));
        s_dal.Student.Create(new Student(220458987, "מרים לוי", 1001, 85));

        // מבחן שלישי
        s_dal.Student.Create(new Student(216258954, "תמר כהן", 1002, 94));
        s_dal.Student.Create(new Student(313145698, "יצחק שמיר", 1002, 89));
        s_dal.Student.Create(new Student(217852963, "לאה רוט", 1002, 92));
        s_dal.Student.Create(new Student(215874965, "רבקה שיק", 1002, 83));
        s_dal.Student.Create(new Student(220458987, "מרים לוי", 1002, 90));

        // מבחן רביעי
        s_dal.Student.Create(new Student(216258954, "תמר כהן", 1003, 82));
        s_dal.Student.Create(new Student(313145698, "יצחק שמיר", 1003, 96));
        s_dal.Student.Create(new Student(217852963, "לאה רוט", 1003, 88));
        s_dal.Student.Create(new Student(215874965, "רבקה שיק", 1003, 91));
        s_dal.Student.Create(new Student(220458987, "מרים לוי", 1003, 77));

        // מבחן חמישי
        s_dal.Student.Create(new Student(216258954, "תמר כהן", 1004, 89));
        s_dal.Student.Create(new Student(313145698, "יצחק שמיר", 1004, 93));
        s_dal.Student.Create(new Student(217852963, "לאה רוט", 1004, 85));
        s_dal.Student.Create(new Student(215874965, "רבקה שיק", 1004, 90));
        s_dal.Student.Create(new (220458987, "מרים לוי", 1004, 86));
    }Student

    private static void CreateStudentQuestion()
    {
        // תלמיד 1: 216258954
        // מבחן 1000 (שאלות 1-4)
        s_dal.StudentQuestion.Create(new StudentQuestion(216258954, 1000, 1, 1));
        s_dal.StudentQuestion.Create(new StudentQuestion(216258954, 1000, 2, 5));
        s_dal.StudentQuestion.Create(new StudentQuestion(216258954, 1000, 3, 9));
        s_dal.StudentQuestion.Create(new StudentQuestion(216258954, 1000, 4, 13));
        // מבחן 1001 (שאלות 5-8)
        s_dal.StudentQuestion.Create(new StudentQuestion(216258954, 1001, 5, 17));
        s_dal.StudentQuestion.Create(new StudentQuestion(216258954, 1001, 6, 21));
        s_dal.StudentQuestion.Create(new StudentQuestion(216258954, 1001, 7, 25));
        s_dal.StudentQuestion.Create(new StudentQuestion(216258954, 1001, 8, 29));
        // מבחן 1002 (שאלות 9-12)
        s_dal.StudentQuestion.Create(new StudentQuestion(216258954, 1002, 9, 33));
        s_dal.StudentQuestion.Create(new StudentQuestion(216258954, 1002, 10, 37));
        s_dal.StudentQuestion.Create(new StudentQuestion(216258954, 1002, 11, 41));
        s_dal.StudentQuestion.Create(new StudentQuestion(216258954, 1002, 12, 45));
        // מבחן 1003 (שאלות 13-16)
        s_dal.StudentQuestion.Create(new StudentQuestion(216258954, 1003, 13, 49));
        s_dal.StudentQuestion.Create(new StudentQuestion(216258954, 1003, 14, 53));
        s_dal.StudentQuestion.Create(new StudentQuestion(216258954, 1003, 15, 57));
        s_dal.StudentQuestion.Create(new StudentQuestion(216258954, 1003, 16, 61));
        // מבחן 1004 (שאלות 17-20)
        s_dal.StudentQuestion.Create(new StudentQuestion(216258954, 1004, 17, 65));
        s_dal.StudentQuestion.Create(new StudentQuestion(216258954, 1004, 18, 69));
        s_dal.StudentQuestion.Create(new StudentQuestion(216258954, 1004, 19, 73));
        s_dal.StudentQuestion.Create(new StudentQuestion(216258954, 1004, 20, 77));

        // תלמיד 2: 313145698
        // מבחן 1000 (שאלות 1-4)
        s_dal.StudentQuestion.Create(new StudentQuestion(313145698, 1000, 1, 2));
        s_dal.StudentQuestion.Create(new StudentQuestion(313145698, 1000, 2, 6));
        s_dal.StudentQuestion.Create(new StudentQuestion(313145698, 1000, 3, 10));
        s_dal.StudentQuestion.Create(new StudentQuestion(313145698, 1000, 4, 14));
        // מבחן 1001 (שאלות 5-8)
        s_dal.StudentQuestion.Create(new StudentQuestion(313145698, 1001, 5, 18));
        s_dal.StudentQuestion.Create(new StudentQuestion(313145698, 1001, 6, 22));
        s_dal.StudentQuestion.Create(new StudentQuestion(313145698, 1001, 7, 26));
        s_dal.StudentQuestion.Create(new StudentQuestion(313145698, 1001, 8, 30));
        // מבחן 1002 (שאלות 9-12)
        s_dal.StudentQuestion.Create(new StudentQuestion(313145698, 1002, 9, 34));
        s_dal.StudentQuestion.Create(new StudentQuestion(313145698, 1002, 10, 38));
        s_dal.StudentQuestion.Create(new StudentQuestion(313145698, 1002, 11, 42));
        s_dal.StudentQuestion.Create(new StudentQuestion(313145698, 1002, 12, 46));
        // מבחן 1003 (שאלות 13-16)
        s_dal.StudentQuestion.Create(new StudentQuestion(313145698, 1003, 13, 50));
        s_dal.StudentQuestion.Create(new StudentQuestion(313145698, 1003, 14, 54));
        s_dal.StudentQuestion.Create(new StudentQuestion(313145698, 1003, 15, 58));
        s_dal.StudentQuestion.Create(new StudentQuestion(313145698, 1003, 16, 62));
        // מבחן 1004 (שאלות 17-20)
        s_dal.StudentQuestion.Create(new StudentQuestion(313145698, 1004, 17, 66));
        s_dal.StudentQuestion.Create(new StudentQuestion(313145698, 1004, 18, 70));
        s_dal.StudentQuestion.Create(new StudentQuestion(313145698, 1004, 19, 74));
        s_dal.StudentQuestion.Create(new StudentQuestion(313145698, 1004, 20, 78));

        // תלמיד 3: 217852963
        // מבחן 1000 (שאלות 1-4)
        s_dal.StudentQuestion.Create(new StudentQuestion(217852963, 1000, 1, 3));
        s_dal.StudentQuestion.Create(new StudentQuestion(217852963, 1000, 2, 7));
        s_dal.StudentQuestion.Create(new StudentQuestion(217852963, 1000, 3, 11));
        s_dal.StudentQuestion.Create(new StudentQuestion(217852963, 1000, 4, 15));
        // מבחן 1001 (שאלות 5-8)
        s_dal.StudentQuestion.Create(new StudentQuestion(217852963, 1001, 5, 19));
        s_dal.StudentQuestion.Create(new StudentQuestion(217852963, 1001, 6, 23));
        s_dal.StudentQuestion.Create(new StudentQuestion(217852963, 1001, 7, 27));
        s_dal.StudentQuestion.Create(new StudentQuestion(217852963, 1001, 8, 31));
        // מבחן 1002 (שאלות 9-12)
        s_dal.StudentQuestion.Create(new StudentQuestion(217852963, 1002, 9, 35));
        s_dal.StudentQuestion.Create(new StudentQuestion(217852963, 1002, 10, 39));
        s_dal.StudentQuestion.Create(new StudentQuestion(217852963, 1002, 11, 43));
        s_dal.StudentQuestion.Create(new StudentQuestion(217852963, 1002, 12, 47));
        // מבחן 1003 (שאלות 13-16)
        s_dal.StudentQuestion.Create(new StudentQuestion(217852963, 1003, 13, 51));
        s_dal.StudentQuestion.Create(new StudentQuestion(217852963, 1003, 14, 55));
        s_dal.StudentQuestion.Create(new StudentQuestion(217852963, 1003, 15, 59));
        s_dal.StudentQuestion.Create(new StudentQuestion(217852963, 1003, 16, 63));
        // מבחן 1004 (שאלות 17-20)
        s_dal.StudentQuestion.Create(new StudentQuestion(217852963, 1004, 17, 67));
        s_dal.StudentQuestion.Create(new StudentQuestion(217852963, 1004, 18, 71));
        s_dal.StudentQuestion.Create(new StudentQuestion(217852963, 1004, 19, 75));
        s_dal.StudentQuestion.Create(new StudentQuestion(217852963, 1004, 20, 79));

        // תלמיד 4: 215874965
        // מבחן 1000 (שאלות 1-4)
        s_dal.StudentQuestion.Create(new StudentQuestion(215874965, 1000, 1, 4));
        s_dal.StudentQuestion.Create(new StudentQuestion(215874965, 1000, 2, 8));
        s_dal.StudentQuestion.Create(new StudentQuestion(215874965, 1000, 3, 12));
        s_dal.StudentQuestion.Create(new StudentQuestion(215874965, 1000, 4, 16));
        // מבחן 1001 (שאלות 5-8)
        s_dal.StudentQuestion.Create(new StudentQuestion(215874965, 1001, 5, 20));
        s_dal.StudentQuestion.Create(new StudentQuestion(215874965, 1001, 6, 24));
        s_dal.StudentQuestion.Create(new StudentQuestion(215874965, 1001, 7, 28));
        s_dal.StudentQuestion.Create(new StudentQuestion(215874965, 1001, 8, 32));
        // מבחן 1002 (שאלות 9-12)
        s_dal.StudentQuestion.Create(new StudentQuestion(215874965, 1002, 9, 36));
        s_dal.StudentQuestion.Create(new StudentQuestion(215874965, 1002, 10, 40));
        s_dal.StudentQuestion.Create(new StudentQuestion(215874965, 1002, 11, 44));
        s_dal.StudentQuestion.Create(new StudentQuestion(215874965, 1002, 12, 48));
        // מבחן 1003 (שאלות 13-16)
        s_dal.StudentQuestion.Create(new StudentQuestion(215874965, 1003, 13, 52));
        s_dal.StudentQuestion.Create(new StudentQuestion(215874965, 1003, 14, 56));
        s_dal.StudentQuestion.Create(new StudentQuestion(215874965, 1003, 15, 60));
        s_dal.StudentQuestion.Create(new StudentQuestion(215874965, 1003, 16, 64));
        // מבחן 1004 (שאלות 17-20)
        s_dal.StudentQuestion.Create(new StudentQuestion(215874965, 1004, 17, 68));
        s_dal.StudentQuestion.Create(new StudentQuestion(215874965, 1004, 18, 72));
        s_dal.StudentQuestion.Create(new StudentQuestion(215874965, 1004, 19, 76));
        s_dal.StudentQuestion.Create(new StudentQuestion(215874965, 1004, 20, 80));

        // תלמיד 5: 220458987
        // מבחן 1000 (שאלות 1-4)
        s_dal.StudentQuestion.Create(new StudentQuestion(220458987, 1000, 1, 1));
        s_dal.StudentQuestion.Create(new StudentQuestion(220458987, 1000, 2, 5));
        s_dal.StudentQuestion.Create(new StudentQuestion(220458987, 1000, 3, 9));
        s_dal.StudentQuestion.Create(new StudentQuestion(220458987, 1000, 4, 13));
        // מבחן 1001 (שאלות 5-8)
        s_dal.StudentQuestion.Create(new StudentQuestion(220458987, 1001, 5, 17));
        s_dal.StudentQuestion.Create(new StudentQuestion(220458987, 1001, 6, 21));
        s_dal.StudentQuestion.Create(new StudentQuestion(220458987, 1001, 7, 25));
        s_dal.StudentQuestion.Create(new StudentQuestion(220458987, 1001, 8, 29));
        // מבחן 1002 (שאלות 9-12)
        s_dal.StudentQuestion.Create(new StudentQuestion(220458987, 1002, 9, 33));
        s_dal.StudentQuestion.Create(new StudentQuestion(220458987, 1002, 10, 37));
        s_dal.StudentQuestion.Create(new StudentQuestion(220458987, 1002, 11, 41));
        s_dal.StudentQuestion.Create(new StudentQuestion(220458987, 1002, 12, 45));
        // מבחן 1003 (שאלות 13-16)
        s_dal.StudentQuestion.Create(new StudentQuestion(220458987, 1003, 13, 49));
        s_dal.StudentQuestion.Create(new StudentQuestion(220458987, 1003, 14, 53));
        s_dal.StudentQuestion.Create(new StudentQuestion(220458987, 1003, 15, 57));
        s_dal.StudentQuestion.Create(new StudentQuestion(220458987, 1003, 16, 61));
        // מבחן 1004 (שאלות 17-20)
        s_dal.StudentQuestion.Create(new StudentQuestion(220458987, 1004, 17, 65));
        s_dal.StudentQuestion.Create(new StudentQuestion(220458987, 1004, 18, 69));
        s_dal.StudentQuestion.Create(new StudentQuestion(220458987, 1004, 19, 73));
        s_dal.StudentQuestion.Create(new StudentQuestion(220458987, 1004, 20, 77));


    }

    public Initialize()
    {
        CreateAnswer();
        CreateExam();
        CreateQuestion();
        CreateStudent();
        CreateStudentQuestion();
    }
}
