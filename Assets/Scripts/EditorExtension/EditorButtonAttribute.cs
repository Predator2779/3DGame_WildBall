using System;

namespace EditorExtension
{
    [AttributeUsage(AttributeTargets.Method)]
    public class EditorButtonAttribute : Attribute
    {
        public string Name;

        public EditorButtonAttribute(string name)
        {
            Name = name;
        }
    }
}
