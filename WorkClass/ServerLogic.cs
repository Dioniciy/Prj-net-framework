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

        public DbSet<DataForBD> Arrays { get; set; }
    }
    public partial class WorkClass
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
                DataForBD data = new DataForBD { Data = arr_str, Height = (int)height, Lng = (int)lng };
                db.Arrays.Add(data);
                db.SaveChanges();
            }
        }
        public DataForBD ReadFromDB()
        {
            using (ArrayContext db = new ArrayContext())
            {
                db.Database.CreateIfNotExists();
                db.Database.Initialize(false);
                DbSet<DataForBD> arrays = db.Arrays;
                foreach (DataForBD u in arrays)
                {
                    return u;
                }
            }
            return null;
        }
    }
}
