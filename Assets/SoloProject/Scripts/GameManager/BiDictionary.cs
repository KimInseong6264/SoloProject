using System.Collections.Generic;

public class BiDictionary<TKey, TValue>
{
         private Dictionary<TKey, TValue> _keyToValue;
         private Dictionary<TValue, TKey> _valueToValue;

         public void Add(TKey key, TValue value)
         {
             _keyToValue.Add(key, value);
             _valueToValue.Add(value, key);
         }

         public void Remove(TKey key)
         {
             _valueToValue.Remove(_keyToValue[key]);
             _keyToValue.Remove(key);
         }
         
         public void Remove(TValue value)
         {
             _keyToValue.Remove(_valueToValue[value]);
             _valueToValue.Remove(value);
         }
         
         public void Clear()
         {
             _keyToValue.Clear();
             _valueToValue.Clear();
         }
         
         public TValue GetValue(TKey key) => _keyToValue[key];
         public TKey GetKey(TValue value) =>  _valueToValue[value];
}