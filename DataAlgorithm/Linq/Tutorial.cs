using System;
using System.Collections;
using System.Collections.Generic;

class Student
{
    public int StudentID { get; set; }
    public String StudentName { get; set; }
    public int Age { get; set; }
    public int StandardID { get; set; }
}

public class Standard
{
    public int StandardID { get; set; }
    public string StandardName { get; set; }
}

public class LinqTutorial
{
    public void LinqToArray()
    {
        string[] names = { "Bill", "Steve", "James", "Mohan" };

        var myLinqQuery = from name in names
                          where name.Contains('a')
                          select name;

        foreach (var name in myLinqQuery)
        {
            Console.Write(name + " ");
        }
    }

    public void QueryStudents()
    {
        Student[] studentArray = {
                    new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                    new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                    new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                    new Student() { StudentID = 5, StudentName = "Ron" , Age = 31 } ,
                    new Student() { StudentID = 6, StudentName = "Chris",  Age = 17 } ,
                    new Student() { StudentID = 7, StudentName = "Rob",Age = 19  } ,
                };

        // Find teenager students
        // Linq method syntax
        Student[] teenagerStudents = studentArray.Where(s => s.Age > 12 && s.Age < 20).ToArray();

        // OR Func Delegate
        Func<Student, bool> isStudentTeenAger = s => s.Age > 12 && s.Age < 20;
        teenagerStudents = studentArray.Where(s => isStudentTeenAger(s)).ToArray();

        // Use LINQ to find first student whose name is Bill 
        Action<Student> PrintStudentDetail = s => Console.WriteLine($"Name: {s.StudentName}, Age: {s.Age}");
        Student? bill = studentArray.Where(s => s.StudentName == "Bill").FirstOrDefault();

        if (bill != null)
            PrintStudentDetail(bill);

        // Use LINQ to find student whose StudentID is 5
        Student? student5 = studentArray.Where(s => s.StudentID == 5).FirstOrDefault();

        // Use index
        var evenStudents = studentArray.Where((s, i) => i % 2 == 0);
        foreach (var student in evenStudents)
            PrintStudentDetail(student);
    }

    public void FilteringOperator()
    {
        IList mixedList = new ArrayList();
        mixedList.Add(0);
        mixedList.Add("One");
        mixedList.Add("Two");
        mixedList.Add(3);
        mixedList.Add(new Student()
        {
            StudentID = 1,
            StudentName = "Bill",
        });

        var stringResult = from s in mixedList.OfType<string>()
                           select s;

        var intResult = from i in mixedList.OfType<int>()
                        select i;

        foreach (var item in stringResult) Console.WriteLine(item);

        foreach (var item in intResult) Console.WriteLine(item);

        Student[] studentArray = {
                    new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                    new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                    new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                    new Student() { StudentID = 5, StudentName = "Ron" , Age = 31 } ,
                    new Student() { StudentID = 6, StudentName = "Chris",  Age = 17 } ,
                    new Student() { StudentID = 7, StudentName = "Rob",Age = 19  } ,
                };
        var orderbyResult = from s in studentArray
                            orderby s.StudentName, s.Age
                            select new { s.StudentName, s.Age };

        foreach (var s in orderbyResult)
        {
            Console.WriteLine($"Name: {s.StudentName}, Age: {s.Age}");
        }

        /*
        NOTE: the two queries produce the same results. Both expressions will order the 
        studentList first by StudentName and then by Age for students with the same StudentName.

        from s in studentList
        orderby s.StudentName, s.Age
        select s;

        studentList.OrderBy(s => s.StudentName).ThenBy(s => s.Age);
        ----------------------------------------------------------------------
        from s in studentList
        orderby s.StudentName, s.Age descending
        select s;

        studentList.OrderBy(s => s.StudentName).ThenByDescending(s => s.Age);
        */
    }

    public void GroupJoin()
    {
        IList<Student> studentList = new List<Student>() {
                    new Student() { StudentID = 1, StudentName = "John", Age = 13, StandardID =1 },
                    new Student() { StudentID = 2, StudentName = "Moin",  Age = 21, StandardID =1 },
                    new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, StandardID =2 },
                    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID =2 },
                    new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
};

        IList<Standard> standardList = new List<Standard>() {
                    new Standard(){ StandardID = 1, StandardName="Standard 1"},
                    new Standard(){ StandardID = 2, StandardName="Standard 2"},
                    new Standard(){ StandardID = 3, StandardName="Standard 3"}
};
        var groupJoin = standardList.GroupJoin(studentList,
                                                std => std.StandardID,
                                                s => s.StandardID,
                                                (std, studentsGroup) => new
                                                {
                                                    Students = studentsGroup,
                                                    StandardFullName = std.StandardName
                                                });

        foreach (var item in groupJoin)
        {
            Console.WriteLine(item.StandardFullName);

            foreach (var s in item.Students)
            {
                Console.WriteLine(s.StudentName);
            }
        }
    }

    public void Aggregate()
    {
        IList<string> strList = new List<string>() { "One", "Two", "Three", "Four", "Five" };

        var newString = strList.Aggregate((s1, s2) =>
        {
            Console.WriteLine($"s1: {s1}, s2: {s2}");
            return s1 + ", " + s2;
        });

        Console.WriteLine(newString);

        Dictionary<char, int> map = new Dictionary<char, int>();

        string input = "This is a description!";
        foreach (char c in input)
        {
            if (Char.IsLetter(c))
            {
                Char lowercaseChar = Char.ToLower(c);
                if (map.ContainsKey(lowercaseChar))
                {
                    map[lowercaseChar]++;
                }
                else
                {
                    map[lowercaseChar] = 1; // Or map.Add(lowercaseChar, 1);
                }
            }
        }

        KeyValuePair<char, int> mostOccurringItem = map.Aggregate((x, y) =>
        {
            Console.WriteLine($"x: {x}, y: {y}");
            return x.Value > y.Value ? x : y;
        });

        Console.WriteLine($"Most Occuring Item: {mostOccurringItem.Key}, {mostOccurringItem.Value}");
    }

    public void Max()
    {
        IList<int> intList = new List<int>() { 10, 21, 30, 45, 50, 87 };

        var largest = intList.Max();

        Console.WriteLine($"Largest element: {largest}");

        var evenLargest = intList.Max(i => i % 2 == 0 ? i : 0);

        Console.WriteLine($"Largest even element: {evenLargest}");
    }
}
