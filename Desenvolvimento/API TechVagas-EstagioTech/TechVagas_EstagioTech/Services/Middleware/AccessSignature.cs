using System;

namespace TechVagas_EstagioTech.Services.Middleware
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AccessAttribute : Attribute
    {
        public int[] Values { get; }

        public AccessAttribute(params int[] values)
        {
            Values = values ?? Array.Empty<int>();
        }
    }
}
