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
        public void SaveToDB(int[,] array, int height, int lng)
        {
            string arr_str = "";
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < lng; i++)
                {
                    arr_str = string.Concat(arr_str, array[j, i].ToString());
                    arr_str = string.Concat(arr_str, ' ');                    
                }
            }
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
