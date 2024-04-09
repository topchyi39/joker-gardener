using System;
using System.Collections.Generic;

namespace Reactivity
{
    public interface IReactProperty<T>
    {
        T Value { get; }
        event Action<T> ValueChanged;
    }
    
    public class ReactProperty<T> : IReactProperty<T>
    {
        public T Value
        {
            get => _value;
            set
            {
                if (Comparer<T>.Default.Compare(_value, value) == 0) return;

                _value = value;
                ValueChanged?.Invoke(_value);
            }
            
        }

        public event Action<T> ValueChanged;

        private T _value;

        public ReactProperty(T value)
        {
            _value = value;
        }

        public ReactProperty()
        {
            
        }
    }
}