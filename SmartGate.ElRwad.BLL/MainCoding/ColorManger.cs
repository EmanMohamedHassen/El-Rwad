using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.ViewModel;




namespace SmartGate.ElRwad.BLL
{
    public class ColorManger
    {
        private elRwadEntities db = new elRwadEntities();
        private static ColorManger instance;
        public static ColorManger Instance { get { return instance; } }


        static ColorManger()
        {
            instance = new ColorManger();
        }


        public List<ColorVM> GetAllColors()
        {
            List<ColorVM> colors = db.Colors.Select(s => new ColorVM
            {
                id = s.Id,
                NameAr = s.NameAr,
                NameEn = s.NameEn
            }).ToList();
            return colors;
        }



        public ColorByIdVM GetColorById(int colorId)
        {
            try
            {
               var  color = db.Colors.Where(e => e.Id == colorId).FirstOrDefault();
                if (color != null)
                {
                    return new ColorByIdVM
                    {
                        NameAr = color.NameAr,
                        NameEn = color.NameEn
                    };
                }
                else
                {
                    return new ColorByIdVM
                    {
                        NameAr = null,
                        NameEn = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new ColorByIdVM
                {
                    NameAr = null,
                    NameEn = null
                };
                // return ex.Message();
            }
        }




        public dynamic PostColor(string colorNameAr, string colorNAmeEn)
        {
            var x = db.Colors.Add(new Color
            {
                NameAr = colorNameAr,
                NameEn = colorNAmeEn

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                id = x.Id
            };
        }




        public dynamic PutColor(int colorId, string colorNameAr, string colorNAmeEn)
        {
            var color = db.Colors.Find(colorId);

            color.NameAr = colorNameAr;
            color.NameEn = colorNAmeEn;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }



        public dynamic DeleteColor(int colorId)
        {
            var color = db.Colors.Where(s => s.Id == colorId).FirstOrDefault();
            db.Colors.Remove(color);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
    }
}
