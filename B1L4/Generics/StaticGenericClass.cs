namespace Generics
{
    internal static class StaticGenericClass<T>
    {
        public static T MyProperty { get; set; }

        public static T ReturnMyProperty()
        { return MyProperty; }

    }
}
