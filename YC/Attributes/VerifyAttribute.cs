using System;

namespace YC.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class VerifyAttribute : Attribute
    {
        public bool Required;
        public int Length;
    }
}