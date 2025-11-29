// Fig. 10.16: TimeExtensionsTest.cs
// Demonstrating extension methods.
using System;

class TimeExtensionsTest
{
    static void Main()
    {
        var myTime = new Time2();
        myTime.SetTime(11, 34, 15);

        // test DisplayTime
        Console.Write("Use the DisplayTime extension method: ");
        myTime.DisplayTime();

        // test AddHours — add 5 hours
        Console.Write("Add 5 hours with the AddHours extension method: ");
        var newTime1 = myTime.AddHours(5);
        newTime1.DisplayTime();

        // add 15 hours in one statement
        Console.Write("Add 15 hours with the AddHours extension method: ");
        myTime.AddHours(15).DisplayTime();

        // use fully qualified extension-method name
        Console.Write("Use fully qualified extension-method name: ");
        TimeExtensions.DisplayTime(myTime);
    }
}


public static class TimeExtensions
{
    // display the Time2 object
    public static void DisplayTime(this Time2 aTime)
    {
        Console.WriteLine(aTime.ToString());
    }

    // add the specified number of hours and return new Time2
    public static Time2 AddHours(this Time2 aTime, int hours)
    {
        var newTime = new Time2()
        {
            Hour = aTime.Hour,
            Minute = aTime.Minute,
            Second = aTime.Second
        };

        newTime.Hour = (aTime.Hour + hours) % 24;
        return newTime;
    }
}




public class Time2
{
    public int Hour { get; set; }
    public int Minute { get; set; }
    public int Second { get; set; }

    public void SetTime(int h, int m, int s)
    {
        Hour = h;
        Minute = m;
        Second = s;
    }

    public override string ToString()
    {
        return $"{Hour:D2}:{Minute:D2}:{Second:D2}";
    }
}
