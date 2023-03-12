using System.Linq;
using YC.Attributes;
using YC.Utilities;

namespace YC.Extension
{
    public static class ModelExtension
    {
        public static string Verify<T>(this T data)
        {
            var result = "";
            data.GetType().GetProperties().ToList().ForEach(s =>
            {
                var attr = Utility.GetAttributes<VerifyAttribute>(s).SingleOrDefault();
                if (attr == null) return;

                var intType = new string[] { "long", "int32", "int64", "float" };
                var value = (s.GetValue(data) ?? "").ToString();
                if (attr.Required && string.IsNullOrWhiteSpace(value))
                    result += string.Format(" {0}:無值||", s.Name);
                if (!intType.Contains(s.PropertyType.Name.ToLower()) && value.ToString().Length > attr.Length)
                    result += string.Format(" {0}:長度過長||", s.Name);
            });
            return result == "" ? "success" : result;
        }
    }
}