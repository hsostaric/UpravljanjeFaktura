﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZadatakFaktureMVC5.Enums.Helpers
{
    public static class EnumHelpers
    {
        public static IEnumerable<SelectListItem> GetItems(this Type enumType)
        {
            if (!typeof(Enum).IsAssignableFrom(enumType))
            {
                throw new ArgumentException("Type must be a enum");
            }
            var names = Enum.GetNames(enumType);
            var values = Enum.GetValues(enumType).Cast<int>();

            var items = names.Zip(values, (name, value) =>
                new SelectListItem
                {
                    Text = GetName(enumType, name),
                    Value = value.ToString()
                });
            return items;
        }

        static string GetName(Type enumType, string name)
        {
            var result = name;
            var attribute = enumType
                .GetField(name)
                .GetCustomAttributes(inherit: false)
                .OfType<DisplayAttribute>()
                .FirstOrDefault();

            if (attribute != null)
            {
                result = attribute.GetName();
            }
            return result;
        }
    }
}