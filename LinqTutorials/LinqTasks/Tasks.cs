using LinqTasks.Extensions;
using LinqTasks.Models;

namespace LinqTasks;

public static partial class Tasks
{
    public static IEnumerable<Emp> Emps { get; set; }
    public static IEnumerable<Dept> Depts { get; set; }

    static Tasks()
    {
        Depts = LoadDepts();
        Emps = LoadEmps();
    }

    /// <summary>
    ///     SELECT * FROM Emps WHERE Job = "Backend programmer";
    /// </summary>
    public static IEnumerable<Emp> Task1()
    {

        var results1 =
            from st in Emps
            where st.Job.Equals("Backend programmer")
            select st;

        // OR
        var results2 = Emps.Where(emp => emp.Job.Equals("Backend programmer"));


        return results1;
    }

    /// <summary>
    ///     SELECT * FROM Emps Job = "Frontend programmer" AND Salary>1000 ORDER BY Ename DESC;
    /// </summary>
    public static IEnumerable<Emp> Task2()
    {
        var results1 =
            from st in Emps
            where st.Job.Equals("Frontend programmer") && st.Salary > 1000
            orderby st.Ename descending
            select st;

        // OR
        var results2 = Emps.Where(emp => emp.Job.Equals("Frontend programmer") && emp.Salary > 1000)
            .OrderBy(emp => emp.Empno);


        return results1;
    }


    /// <summary>
    ///     SELECT MAX(Salary) FROM Emps;
    /// </summary>
    public static int Task3()
    {
        var results2 = Emps.Max(emp => emp.Salary);

        return results2;
    }

    /// <summary>
    ///     SELECT * FROM Emps WHERE Salary=(SELECT MAX(Salary) FROM Emps);
    /// </summary>
    public static IEnumerable<Emp> Task4()
    {

        var results2 = Emps.Where(emp => emp.Salary.Equals(
            Emps.Max(emp => emp.Salary)));

        return results2;
    }

    /// <summary>
    ///    SELECT ename AS Nazwisko, job AS Praca FROM Emps;
    /// </summary>
    public static IEnumerable<object> Task5()
    {
        var results2 = Emps.Select(emp => new
        {
            Nazwisko = emp.Ename,
            Praca = emp.Job
        });
        return results2;
    }

    /// <summary>
    ///     SELECT Emps.Ename, Emps.Job, Depts.Dname FROM Emps
    ///     INNER JOIN Depts ON Emps.Deptno=Depts.Deptno
    ///     Rezultat: Złączenie kolekcji Emps i Depts.
    /// </summary>
    public static IEnumerable<object> Task6()
    {
        var results2 = Emps.Join(Depts,
                emp => emp.Deptno,
                dep => dep.Deptno,
                (emp, dep) => new { Emps = emp, Depts = dep })
            .Select(emp_dep => new
            {
                emp_dep.Emps.Ename,
                emp_dep.Emps.Job,
                emp_dep.Depts.Dname
            });

        return results2;
    }

    /// <summary>
    ///     SELECT Job AS Praca, COUNT(1) LiczbaPracownikow FROM Emps GROUP BY Job;
    /// </summary>
    public static IEnumerable<object> Task7()
    {
        var results2 = Emps.GroupBy(emp1 => emp1.Job)
            .Select(grouped => new
            {
                Praca = grouped.Key,
                LiczbaPracownikow = grouped.Count()
            });


        return results2;
    }

    /// <summary>
    ///     Zwróć wartość "true" jeśli choć jeden
    ///     z elementów kolekcji pracuje jako "Backend programmer".
    /// </summary>
    public static bool Task8()
    {
        var results2 = Emps.Where(emp => emp.Job.Equals("Backend programmer")).Any();


        return results2;
    }

    /// <summary>
    ///     SELECT TOP 1 * FROM Emp WHERE Job="Frontend programmer"
    ///     ORDER BY HireDate DESC;
    /// </summary>
    public static Emp Task9()
    {
        var results2 = Emps.Where(emp => emp.Job.Equals("Frontend programmer"))
            .OrderByDescending(emp => emp.HireDate)
            .FirstOrDefault();


        return results2;
    }

    /// <summary>
    ///     SELECT Ename, Job, Hiredate FROM Emps    /// Powinno być HireDate !!!!
    ///     UNION
    ///     SELECT "Brak wartości", null, null;
    /// </summary>
    public static IEnumerable<object> Task10()
    {
        var results2 = Emps.Select(emp => new
        {
            Ename = emp.Ename,
            Job = emp.Job,
            HireDate = emp.HireDate
        });

        var query = (new[]
        {
            new
            {
                Ename = "Brak wartości",
                Job = (string)null,
                HireDate = (DateTime?)null
            }
        }.AsQueryable());


        return results2.Union(query);
        ;
    }

    /// <summary>
    ///     Wykorzystując LINQ pobierz pracowników podzielony na departamenty pamiętając, że:
    ///     1. Interesują nas tylko departamenty z liczbą pracowników powyżej 1
    ///     2. Chcemy zwrócić listę obiektów o następującej srukturze:
    ///     [
    ///     {name: "RESEARCH", numOfEmployees: 3},
    ///     {name: "SALES", numOfEmployees: 5},
    ///     ...
    ///     ]
    ///     3. Wykorzystaj typy anonimowe
    /// </summary>
    public static IEnumerable<object> Task11()
    {
        var results2 =
            Emps.Join(Depts,
                    emp => emp.Deptno,
                    dep => dep.Deptno,
                    (emp, dep) => new { Emps = emp, Depts = dep })
                .GroupBy(emp1 => emp1.Depts.Dname)
                .Select(grouped => new
                {
                    name = grouped.Key,
                    numOfEmployees = grouped.Count()
                });


        return results2;
    }

    /// <summary>
    ///     Napisz własną metodę rozszerzeń, która pozwoli skompilować się poniższemu fragmentowi kodu.
    ///     Metodę dodaj do klasy CustomExtensionMethods, która zdefiniowana jest poniżej.
    ///     Metoda powinna zwrócić tylko tych pracowników, którzy mają min. 1 bezpośredniego podwładnego.
    ///     Pracownicy powinny w ramach kolekcji być posortowani po nazwisku (rosnąco) i pensji (malejąco).
    /// </summary>
    public static IEnumerable<Emp> Task12()
    {
        IEnumerable<Emp> result = Emps.GetEmpsWithSubordinates();

        return result;
    }

    /// <summary>
    ///     Poniższa metoda powinna zwracać pojedyczną liczbę int.
    ///     Na wejściu przyjmujemy listę liczb całkowitych.
    ///     Spróbuj z pomocą LINQ'a odnaleźć tę liczbę, które występuja w tablicy int'ów nieparzystą liczbę razy.
    ///     Zakładamy, że zawsze będzie jedna taka liczba.
    ///     Np: {1,1,1,1,1,1,10,1,1,1,1} => 10
    /// </summary>
    public static int Task13(int[] arr)
    {
        return -1;
    }

    /// <summary>
    ///     Zwróć tylko te departamenty, które mają 5 pracowników lub nie mają pracowników w ogóle.
    ///     Posortuj rezultat po nazwie departament rosnąco.
    /// </summary>
    public static IEnumerable<Dept> Task14()
    {
        var results2 =
            Emps.Join(Depts,
                    emp => emp.Deptno,
                    dep => dep.Deptno,
                    (emp, dep) => new { Emps = emp, Depts = dep })
                .OrderBy(d => d.Depts.Dname)
                .GroupBy(emp1 => new { emp1.Depts.Dname, emp1.Depts.Deptno ,emp1.Depts.Loc })
                .Where(g => g.Count() == 5)
                .Select(g => new Dept
                {
                    Deptno = g.Key.Deptno,
                    Dname=g.Key.Dname,
                    Loc =g.Key.Loc 
                });
        
        var results3 =
            Emps.Join(Depts,
                    emp => emp.Deptno,
                    dep => dep.Deptno,
                    (emp, dep) => new { Emps = emp, Depts = dep })
                .GroupBy(emp1 => new{ emp1.Depts.Dname})
                .Select(grouped => new Dept
                {
                    Dname = grouped.Key.Dname
                });
        
        Console.WriteLine(results2.Count());
        
        return results3;
    }
}