using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class ColorsController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        /// <summary>
        /// get all colors
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetAllColors()
        {
            var colors = db.Colors.Select(s => new
            {
                colorId = s.Id,
                colorNameAr = s.NameAr,
                colorNameEn = s.NameEn
            }).ToList();
            return colors;
        }

        /// <summary>
        /// get color by id
        /// </summary>
        /// <param name="colorId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetColorById(int colorId)
        {
            try
            {
                var color = db.Colors.Where(e => e.Id == colorId).FirstOrDefault();
                if (color != null)
                {
                    return new
                    {
                        colorNameAr = color.NameAr,
                        colorNAmeEn = color.NameEn
                    };
                }
                else
                {
                    return new
                    {
                        Id = 0
                    };
                }
            }
            catch (Exception ex)
            {
                return new
                {
                    result = new
                    {
                        Id = 0
                    }
                };
            }
        }

        /// <summary>
        /// add new color
        /// </summary>
        /// <param name="colorNameAr"></param>
        /// <param name="colorNAmeEn"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostColor(string colorNameAr, string colorNAmeEn)
        {
            db.Colors.Add(new Color
            {
                NameAr = colorNameAr,
                NameEn = colorNAmeEn

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        /// <summary>
        /// update color data
        /// </summary>
        /// <param name="colorId"></param>
        /// <param name="colorNameAr"></param>
        /// <param name="colorNAmeEn"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
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

        /// <summary>
        /// delete color
        /// </summary>
        /// <param name="colorId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
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
