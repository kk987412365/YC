using System;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;

namespace YC.Utilities
{
    public class Utility
    {
        public static Collection<T> GetAttributes<T>(object ob)
        {
            Contract.Requires(ob != null);
            Contract.Requires(ob is Assembly || ob is Type || ob is MemberInfo);

            object[] attributes = null;
            if (ob is Assembly)
            {
                var assembly = ob as Assembly;
                attributes = assembly.GetCustomAttributes(typeof(T), true).ToArray();
            }
            else if (ob is Type)
            {
                var type = ob as Type;
                attributes = type.GetCustomAttributes(typeof(T), true).ToArray();
            }
            else if (ob is MemberInfo)
            {
                var mInfo = ob as MemberInfo;
                attributes = mInfo.GetCustomAttributes(typeof(T), true).ToArray();
            }
            else if (ob is PropertyInfo)
            {
                var mpInfo = ob as PropertyInfo;
                attributes = mpInfo.GetCustomAttributes(typeof(T), true).ToArray();
            }
            else
            {
                throw new NotImplementedException();
            }
            Collection<T> results = new Collection<T>();
            foreach (object attribute in attributes)
            {
                results.Add((T)attribute);
            }
            return results;
        }
    }
}