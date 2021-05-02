using System;

namespace Game.Model
{
    public class DataItem<T> where T : IEquatable<T>
    {
        public event Action<T> Changed;
        
        private T itemValue;
        
        public T Value
        {
            get => itemValue;
            set
            {
                if (itemValue.Equals(value)) 
                    return;
                
                itemValue = value;
                Changed?.Invoke(itemValue);
            }
        }
    }
}