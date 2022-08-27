using LinqPratik.LinqDbContext;
using System;
using System.Linq;

namespace LinqPratik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataSeed.Initial();
            DataContext _context = new DataContext();
            var students = _context.Students.ToList();

            var student = _context.Students.Where(a => a.Name == "Can").FirstOrDefault();

            var student2 = _context.Students.Find(1);

            var student3 = _context.Students.Where(a=>a.LastName.Contains("Kaya")).ToList();

            var ordered = _context.Students.OrderBy(a => a.Id).ToList();

            foreach (var item in ordered)
            {
                Console.WriteLine(item.Name);
            }

            var anonymous = _context.Students
                            .Where(a => a.ClassId == 1)
                            .Select(a => new
                            {
                                studentId = a.Id,
                                studentName = a.Name,
                                studentLastName = a.LastName,
                            }).ToList();

            foreach (var item in anonymous)
            {
                Console.WriteLine(item.studentId + " " + item.studentName + " " + item.studentLastName);
            }
            
        }
    }
}
