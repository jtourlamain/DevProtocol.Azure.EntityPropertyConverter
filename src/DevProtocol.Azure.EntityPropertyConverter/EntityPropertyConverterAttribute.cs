using System;

namespace DevProtocol.Azure.EntityPropertyConverter
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EntityPropertyConverterAttribute: Attribute
    {
        public Type ConvertToType;

        public EntityPropertyConverterAttribute()
        {

        }
        public EntityPropertyConverterAttribute(Type convertToType)
        {
            ConvertToType = convertToType;
        }
    }
}