using API.DataAccess.Info;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace API.DataAccess
{
    public class DataProvider
    {
        MaalDBEntities dbContext = new MaalDBEntities();
        internal List<Ladies> GetAllLadies()
        {
            try
            {
                var maals = dbContext.MM_Maal;
                List<Ladies> ladyList = new List<Ladies>();
                foreach (var item in maals)
                {
                    Ladies lady = new Ladies();
                    lady.Id = item.Id;
                    lady.Name = item.Name;
                    lady.Image = item.Image;
                    lady.Age = item.Age;
                    ladyList.Add(lady);
                }
                return ladyList;
            }
            catch (Exception ex)
            {
                return new List<Ladies>();
                throw;
            }
        }
        internal Ladies GetLadiesById(int id)
        {
            try
            {
                if (dbContext.MM_Maal.FirstOrDefault(x => x.Id == id) != null)
                {
                    var ld = dbContext.MM_Maal.FirstOrDefault(x => x.Id == id);
                    Ladies lady = new Ladies();
                    lady.Age = ld.Age;
                    lady.Id = ld.Id;
                    lady.Image = ld.Image;
                    lady.Name = ld.Name;
                    return lady;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        internal void AddNewLadies(Ladies ld)
        {
            try
            {
                MM_Maal m = new MM_Maal();
                m.Age = ld.Age;
                m.Image = ld.Image;
                m.Name = ld.Name;

                dbContext.MM_Maal.Add(m);
                dbContext.SaveChanges();


            }
            catch (Exception)
            {


                throw;
            }
        }

        internal int UpdateLady(Ladies ladies)
        {
            try
            {
               MM_Maal m = dbContext.MM_Maal.FirstOrDefault(x => x.Id == ladies.Id);
                if (m!=null)
                {
                
                    m.Image = ladies.Image;

                    m.Name = ladies.Name;
                    m.Age = ladies.Age;
                    dbContext.SaveChanges();
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }

    }
}