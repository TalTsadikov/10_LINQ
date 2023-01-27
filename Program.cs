//----- C# II (Dor Ben Dor) ------
//          Tal Tsadikov
//--------------------------------

//1
List<int> list = new() { 1,5,8,9,21,35,56,43,78,54,34,12,99,52,65,23,88,45,32};

var dlist = list.Distinct().OrderBy(x => x);

foreach (var item in dlist)
{
    Console.WriteLine(item);
}

//2
string sent = "hi my name is Metushelah and i am going to the market";

var avg = sent.Split(' ').Average((s) => s.Length);
    
Console.WriteLine(avg);

//3
List<string> clist = new() {"Avram", "Avi", "Banana", "Armani" };

var charlist = clist.Where((s) => s.StartsWith("A") && s.EndsWith("i"));

foreach (var item in charlist)
{
    Console.WriteLine(item);
}

//4
List<Students> students = new List<Students>
{
    new Students { Name = "Aviv", studentID = 0 },
    new Students { Name = "Sigal", studentID = 1 },
    new Students { Name = "Yoel", studentID = 2 },
    new Students { Name = "Haim",   studentID = 3 },
    new Students { Name = "Noa", studentID = 4 },
};

List<Grades> grades = new List<Grades>
{
    new Grades{ Id = 0, Grade = 88 },
    new Grades{ Id = 1, Grade = 95 },
    new Grades{ Id = 2, Grade = 77 },
    new Grades{ Id = 3, Grade = 65 },
    new Grades{ Id = 4, Grade = 71 }
};

var collection = students.Join(grades, (s) => s.studentID, (g) => g.Id,
(s, g) => new { Name = s.Name, Grade = g.Grade });

foreach (var item in collection)
{
    Console.WriteLine(item);
}

//Extending method 1
grades.PrintAllItems();

//Extending method 2
Console.WriteLine(collection.GetHighest((s) => s.Grade));

//Extending method3
Console.WriteLine(list.CompareToHighest()); 

class Students
{
    public int studentID { get; set; }
    public string Name { get; set; }
}

class Grades
{
    public int Id { get; set; }
    public int Grade { get; set; }
}

static class ExtentionMethods
{
    public static void PrintAllItems<T>(this IEnumerable<T> collection)
    {
        foreach (T item in collection)
        {
            Console.WriteLine(item);
        }
    }

    public static T GetHighest<T>(this IEnumerable<T> collection, Func<T, int> predicate)
    {
        int currectHighestScore = 0;
        T currentHighest = default;

        foreach (T item in collection)
        {
            if (predicate.Invoke(item) > currectHighestScore)
            {
                currectHighestScore = predicate.Invoke(item);
                currentHighest = item;
            }
        }

        return currentHighest;
    }

    public static T CompareToHighest<T>(this IEnumerable<T> collection) where T : IComparable
    {
        T currentHighest = default;

        foreach (T item in collection)
        {
            if (item.CompareTo(currentHighest) > 0)
            {
                currentHighest = item;
            }
        }

        return currentHighest;
    }
}