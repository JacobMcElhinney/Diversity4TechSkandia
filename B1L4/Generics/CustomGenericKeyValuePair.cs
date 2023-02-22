namespace Generics
{
    // Syntax: Classname<T>
    // The Type Parameter TValue represents the type of a value in the key:value pair.
    // 
    internal class CustomGenericKeyValuePair<TValue>
    {
        public string Key { get; set; }
        public TValue Value { get; set; } // cannot be initialised e.g. = "";

        public CustomGenericKeyValuePair(string key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public string ExtractStringFromKeyValuePair(CustomGenericKeyValuePair<TValue> keyValuePair)
            => $"\"{keyValuePair.Key}\":\"{keyValuePair.Value.ToString()}\"";
    }
}
