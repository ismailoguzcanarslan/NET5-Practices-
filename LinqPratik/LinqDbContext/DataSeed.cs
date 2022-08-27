using LinqPratik.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPratik.LinqDbContext
{
    public class DataSeed
    {
        public static void Initial()
        {
            using (var context = new DataContext())
            {
                if (!context.Students.Any())
                {
                    context.Students.AddRange(
                        new Student()
                        {
                            LastName = "Arslan",
                            Name = "İsmail",
                            MiddleName = "Oğuzcan",
                            ClassId = 1
                        },
                        new Student()
                        {
                            LastName = "Kaya",
                            Name = "Melis",
                            ClassId=1
                        },
                        new Student()
                        {
                            LastName = "Nisa",
                            Name = "Akgül",
                            MiddleName = "Nur",
                            ClassId = 2
                        },
                        new Student()
                        {
                            LastName = "Kaya",
                            Name = "Can",
                            ClassId = 3
                        }
                    );

                    context.SaveChanges();
                }
                return;
            }
        }
    }
}
