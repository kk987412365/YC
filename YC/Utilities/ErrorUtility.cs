using System;
using System.Text;
namespace YC.Utilities
{
    public class ErrorUtility
    {
        public static string GetTrail(Exception ex)
        {
            var sb = new StringBuilder().Append(string.Format("{0}{0}{0}", "**請將此段複製給系統管理員**\n"));
            var currentEx = ex;
            int exlevel = 0;
            while (currentEx != null)
            {
                string space = "".PadLeft(exlevel * 4, ' ');
                sb.Append(String.Format("{0}[錯誤訊息]\n", space));
                sb.Append(String.Format("{0}{1}\n", space, currentEx.Message));
                if (currentEx.StackTrace != null)
                {
                    sb.Append(String.Format("{0}[呼叫堆疊]:\n", space));
                    sb.Append(String.Format("{0}{1}\n", space, currentEx.StackTrace.ToString()));
                    sb.Append(String.Format("{0}\n", space));
                }
                currentEx = currentEx.InnerException;
                exlevel++;
            }
            return sb.ToString();
        }
    }
}
