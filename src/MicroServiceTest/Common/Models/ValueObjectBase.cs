using System;
using System.Collections.Generic;
using System.Reflection;

namespace Mmu.MicroServiceTest.Common.Models
{
    public abstract class ValueObjectBase<T> : IEquatable<T>
        where T : ValueObjectBase<T>
    {
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var other = obj as T;
            return Equals(other);
        }

        public virtual bool Equals(T other)
        {
            if (other == null)
            {
                return false;
            }

            var t = GetType();
            var otherType = other.GetType();

            if (t != otherType)
            {
                return false;
            }

            var fields = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (var field in fields)
            {
                var value1 = field.GetValue(other);
                var value2 = field.GetValue(this);

                if (value1 == null)
                {
                    if (value2 != null)
                    {
                        return false;
                    }
                }
                else if (!value1.Equals(value2))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            const int HASH_START_VALUE = 17;
            const int HASH_MULTIPLIER = 59;

            var fields = GetFields();
            var hashCode = HASH_START_VALUE;

            foreach (var field in fields)
            {
                var value = field.GetValue(this);

                if (value != null)
                {
                    hashCode = hashCode * HASH_MULTIPLIER + value.GetHashCode();
                }
            }

            return hashCode;
        }

        public static bool operator ==(ValueObjectBase<T> x, ValueObjectBase<T> y)
        {
            return x?.Equals(y) ?? false;
        }

        public static bool operator !=(ValueObjectBase<T> x, ValueObjectBase<T> y)
        {
            return !(x == y);
        }

        private IEnumerable<FieldInfo> GetFields()
        {
            var currentType = GetType();

            var fields = new List<FieldInfo>();

            while (currentType != typeof(object))
            {
                fields.AddRange(currentType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
                currentType = currentType.GetTypeInfo().BaseType;
            }

            return fields;
        }
    }
}