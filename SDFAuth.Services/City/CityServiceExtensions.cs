
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DB.SDFAuth;

namespace Nop.Services.Blogs
{

    public static class CityExtensions
    {

        public static IList<SelectListItem> ToSelectListItem(this IList<S_Province> source ,SelectListItem firstItem = null)
        {
            var q = from i in source
                    select new SelectListItem
                        {
                            Text = i.ProvinceName,
                            Value = i.ProvinceID.ToString(),
                            Selected = false
                        };
            
            var list = q.ToList();
            if (firstItem != null)
            {
                list.Insert(0, firstItem);
            }
            
            return list;
        }

        public static IList<SelectListItem> ToSelectListItem(this IList<S_City> source, SelectListItem firstItem = null)
        {
            var q = from i in source
                    select new SelectListItem
                    {
                        Text = i.CityName,
                        Value = i.CityID.ToString(),
                        Selected = false
                    };

            var list = q.ToList();
            if (firstItem != null)
            {
                list.Insert(0, firstItem);
            }
            
            return list;
        }

        public static IList<SelectListItem> ToSelectListItem(this IList<S_District> source, SelectListItem firstItem = null)
        {
            var q = from i in source
                    select new SelectListItem
                    {
                        Text = i.DistrictName,
                        Value = i.DistrictID.ToString(),
                        Selected = false
                    };

            var list = q.ToList();
            if (firstItem != null)
            {
                list.Insert(0, firstItem);
            }
            
            return list;
        }

    }
}
