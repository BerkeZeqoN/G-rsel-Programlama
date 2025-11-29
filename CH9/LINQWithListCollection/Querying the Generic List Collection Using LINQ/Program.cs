// Fig. 9.7: LINQWithListCollection.cs
// LINQ to Objects using a List<string>.
using System;
using System.Linq;
using System.Collections.Generic;

class LINQWithListCollection
{
    static void Main()
    {
        // populate a List of strings 
        var items = new List<string>();
        items.Add("aQua");
        items.Add("RusT");
        items.Add("yElLow");
        items.Add("rEd");

        // display initial List
        Console.Write("items contains:");
        foreach (var item in items)
        {
            Console.Write($" {item}");
        }
        Console.WriteLine();

        // convert to uppercase, select those starting with "R" and sort
        var startsWithR =
            from item in items
            let uppercaseString = item.ToUpper()
            where uppercaseString.StartsWith("R")
            orderby uppercaseString
            select uppercaseString;

        // display query results
        Console.Write("results of query startsWithR:");
        foreach (var item in startsWithR)
        {
            Console.Write($" {item}");
        }
        Console.WriteLine();

        // display initial List again
        Console.Write("items contains:");
        foreach (var item in items)
        {
            Console.Write($" {item}");
        }
        Console.WriteLine();

        // display updated query results
        Console.Write("results of query startsWithR:");
        foreach (var item in startsWithR)
        {
            Console.Write($" {item}");
        }
        Console.WriteLine();
    }
}
