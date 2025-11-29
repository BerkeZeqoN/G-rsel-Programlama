// Fig. 7.20: ReferenceAndOutputParameters.cs
// Reference, output and value parameters.
using System;

class ReferenceAndOutputParameters
{
    // call methods with reference, output and value parameters
    static void Main()
    {
        int y = 5; // initialize y to 5
        int z;     // declares z, but does not initialize it

        // display original values of y and z
        Console.WriteLine($"Original value of y: {y}");
        Console.WriteLine("Original value of z: uninitialized\n");

        // pass y and z by reference 
        SquareRef(ref y);   // must use keyword ref
        SquareOut(out z);   // must use keyword out

        // display values of y and z after they are modified 
        Console.WriteLine($"Value of y after SquareRef: {y}");
        Console.WriteLine($"Value of z after SquareOut: {z}\n");

        // pass y and z by value
        Square(y);
        Square(z);

        // display values of y and z after passing by value
        Console.WriteLine($"Value of y after Square: {y}");
        Console.WriteLine($"Value of z after Square: {z}");
    }

    // uses reference parameter x to modify caller's variable
    static void SquareRef(ref int x)
    {
        x = x * x; // squares value of caller's variable
    }

    // uses output parameter x to assign a value 
    static void SquareOut(out int x)
    {
        x = 6;     // assigns a value
        x = x * x; // squares value
    }

    // value parameter, does not modify caller's variable
    static void Square(int x)
    {
        x = x * x;
    }
}
