using LinqTasks.Models;

namespace LinqTasks.Extensions;

public static class CustomExtensionMethods
{
    //Put your extension methods here
    public static IEnumerable<Emp> GetEmpsWithSubordinates(this IEnumerable<Emp> emps)
    {
        var results1 = emps
            .Where(em => em.Mgr != null)
            .OrderBy(em => em.Ename)
            .OrderByDescending(em => em.Salary)
            .Select(emp => new Emp
            {
                Empno = emp.Mgr.Empno,
                Deptno = emp.Mgr.Deptno,
                Ename = emp.Mgr.Ename,
                HireDate = emp.Mgr.HireDate,
                Job = emp.Mgr.Job,
                Mgr = emp.Mgr.Mgr,
                Salary = emp.Mgr.Salary
            });

        return results1;
    }

}