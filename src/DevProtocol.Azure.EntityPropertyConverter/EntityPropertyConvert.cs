using System;
using System.Collections.Generic;

namespace DevProtocol.Azure.EntityPropertyConverter
{
    public static class EntityPropertyConvert
    {
        public static void Serialize<TEntity>(TEntity entity, IDictionary<string, EntityProperty> results)
        {
            foreach (var property in typeof(TEntity).GetProperties())
            {
                var attributedProperty = (EntityPropertyConverterAttribute)Attribute.GetCustomAttribute(property, typeof(EntityPropertyConverterAttribute));
                if (attributedProperty != null)
                {
                    var entityProperty = entity.GetType().GetProperty(property.Name)?.GetValue(entity);
                    results.Add(property.Name, new EntityProperty(JsonConvert.SerializeObject(entityProperty)));
                }
            }
        }

        public static void DeSerialize<TEntity>(TEntity entity, IDictionary<string, EntityProperty> properties)
        {
            foreach (var property in typeof(TEntity).GetProperties())
            {
                var attributedProperty = (EntityPropertyConverterAttribute)Attribute.GetCustomAttribute(property, typeof(EntityPropertyConverterAttribute));
                if (attributedProperty != null)
                {
                    Type resultType = null;
                    if (attributedProperty.ConvertToType != null)
                    {
                        resultType = attributedProperty.ConvertToType;
                    }
                    else
                    {
                        resultType = property.GetType();
                    }
                    var objectValue = JsonConvert.DeserializeObject(properties[property.Name].StringValue, resultType);
                    entity.GetType().GetProperty(property.Name)?.SetValue(entity, objectValue);
                }
            }
        }
    }
}