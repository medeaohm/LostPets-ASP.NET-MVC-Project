namespace LostPets.Web.Infrastructure.HtmlHelpers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    public static class EnumHelpers
    {
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var values = from TEnum e in Enum.GetValues(typeof(TEnum))
                         select new { Id = e, Name = e.ToString() };
            return new SelectList(values, "Id", "Name", 0);
        }
    }
}
