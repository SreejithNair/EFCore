using cl_efcore_first;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Text;

namespace cl_efcore_first_test
{
#nullable enable

    /// <summary>
    /// This is a console application and doesn't have a host like asp.net core or .net core generic host. So we need to create a point at which we could obtain the context.
    /// </summary>
    /// 
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection();
            serviceProvider.AddDbContext<BloggingContext>();
        }
    }


    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        ValueCannotBeNull(null); // warning CS8625: Cannot convert null literal to non-nullable reference type

    //        string? value1 = null;
    //        ValueCannotBeNull(value1); // warning CS8625: Cannot convert null literal to non-nullable reference type

    //        string? value2 = "test";
    //        ValueCannotBeNull(value2); // ok, while the type of value2 is string?, the compiler understands the value cannot be null here

    //        string value3 = "test";
    //        ValueCannotBeNull(value3); // ok
    //    }
    //    void Sample()
    //    {
    //        string str1 = null; // warning CS8625: Cannot convert null literal to non-nullable reference type.
    //        string? str2 = null; // ok
    //    }

    //    // value cannot be null
    //    public static void ValueCannotBeNull(string value)
    //    {
    //        _ = value.Length; // ok
    //    }

    //    // value can be null
    //    public static void ValueMayBeNull(string? value)
    //    {
    //        _ = value.Length; // warning CS8602: Dereference of a possibly null reference
    //    }
    //}
}
