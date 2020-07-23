using System;

public class Solution {

    public static int[] GetProductsOfAllIntsExceptAtIndex(int[] intArray)
    {
        // Make an array with the products
        //our new array
        int[] arrayFromStart = new int[intArray.Length];
        
        //if array is too short, throw an exception
        if (intArray.Length < 2) {
            throw new ArgumentException ("Input array too short", nameof(intArray));
        }
        
        int productSoFar = 1;
        //loop through all the elements of the array to get the value of every item on the LEFT side
        //from the current index
        
        for (int i = 0; i < intArray.Length; i++) {
            arrayFromStart[i] = productSoFar;
            productSoFar *= intArray[i];
        }
        
        //then iterate again from the back to the front of the array
        //to get remaining item
        productSoFar = 1;
        
        for(int i = intArray.Length - 1; i >= 0 ; i--) {
            arrayFromStart[i] *= productSoFar;
            productSoFar *= intArray[i];
        }
        
        return arrayFromStart;
    }


















    // Tests

    [Fact]
    public void SmallArrayInputTest()
    {
        var expected = new int[] { 6, 3, 2 };
        var actual = GetProductsOfAllIntsExceptAtIndex(new int[] { 1, 2, 3 });
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LongArrayInputTest()
    {
        var expected = new int[] { 120, 480, 240, 320, 960, 192 };
        var actual = GetProductsOfAllIntsExceptAtIndex(new int[] { 8, 2, 4, 3, 1, 5 });
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void InputHasOneZeroTest()
    {
        var expected = new int[] { 0, 0, 36, 0 };
        var actual = GetProductsOfAllIntsExceptAtIndex(new int[] { 6, 2, 0, 3 });
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void InputHasTwoZerosTest()
    {
        var expected = new int[] { 0, 0, 0, 0, 0 };
        var actual = GetProductsOfAllIntsExceptAtIndex(new int[] { 4, 0, 9, 1, 0 });
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void InputHasOneNegativeNumberTest()
    {
        var expected = new int[] {32, -12, -24};
        var actual = GetProductsOfAllIntsExceptAtIndex(new int[] { -3, 8, 4 });
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AllNegativesInputTest()
    {
        var expected = new int[] { -8, -56, -14, -28 };
        var actual = GetProductsOfAllIntsExceptAtIndex(new int[] { -7, -1, -4, -2 });
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ExceptionWithEmptyInputTest()
    {
        Assert.Throws<ArgumentException>(() => GetProductsOfAllIntsExceptAtIndex(new int[] { }));
    }

    [Fact]
    public void ExceptionWithOneNumberInputTest()
    {
        Assert.Throws<ArgumentException>(() => GetProductsOfAllIntsExceptAtIndex(new int[] { 1 }));
    }

    public static void Main(string[] args)
    {
        TestRunner.RunTests(typeof(Solution));
    }
}
