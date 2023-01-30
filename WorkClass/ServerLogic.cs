using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WorkClassNS.WorkClass;

namespace WorkClassNS
{
    class ArrayContext : DbContext
    {
        public ArrayContext()
            : base("DbConnection")
        { }

        public DbSet<ArrayTwoDimensional> Arrays { get; set; }
    }
    internal class ServerLogic
    {
        public void SaveToDB(string arr_str, int height, int lng)
        {
            using (ArrayContext db = new ArrayContext())
            {
                ArrayTwoDimensional data = new ArrayTwoDimensional { Data = arr_str, Height = (int)height, Lng = (int)lng };
                db.Arrays.Add(data);
                db.SaveChanges();
            }
        }
        public ArrayTwoDimensional ReadFromDB()
        {
            using (ArrayContext db = new ArrayContext())
            {
                db.Database.CreateIfNotExists();
                db.Database.Initialize(false);
                DbSet<ArrayTwoDimensional> arrays = db.Arrays;
                foreach (ArrayTwoDimensional u in arrays)
                {
                    return u;
                }
            }
            return null;
        }
    }
}
