using GameDB;
using Microsoft.EntityFrameworkCore;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create
            //using (GameDbContext db = new GameDbContext())
            //{
            //    TestDb testDb = new TestDb();
            //    testDb.Name = "Rookiss";

            //    db.Tests.Add(testDb);

            //    db.SaveChanges();
            //}


            // Read
            //using (GameDbContext db = new GameDbContext())
            //{
            //    TestDb? findDb = db.Tests.FirstOrDefault(t => t.Name == "Rookiss");
            //    if (findDb != null)
            //    {
            //        int check = findDb.TestDbId;
            //    }
            //}

            // Update
            //using (GameDbContext db = new GameDbContext())
            //{
            //    TestDb? findDb = db.Tests.FirstOrDefault(t => t.Name == "Rookiss");
            //    if (findDb != null)
            //    {
            //        findDb.Name = "Handsome Rookiss";
            //    }
            //    db.SaveChanges();
            //}

            // Delete
            using (GameDbContext db = new GameDbContext())
            {
                TestDb? findDb = db.Tests.FirstOrDefault(t => t.Name == "Rookiss");
                if (findDb != null)
                {
                    db.Tests.Remove(findDb);
                    db.SaveChanges();
                }

                // Entity Tracking
                {
                    TestDb testDb = new TestDb()
                    {
                        TestDbId = 1
                    };

                    var entry = db.Tests.Entry(testDb);
                    entry.State = EntityState.Deleted;
                    db.SaveChanges();
                }

                // EF Core 7
                {
                    db.Tests.Where(a => a.Name.Contains("Rookiss")).ExecuteDelete();
                }
            }
        }
    }
}
