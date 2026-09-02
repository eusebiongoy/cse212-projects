public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan:
        // 1. Create a new double array with the requested length.
        // 2. Use a loop to go through each position in the array, starting at index 0.
        // 3. For each position, calculate the multiple of the given number by multiplying
        //    the number by the index plus 1.
        // 4. Store the calculated multiple in the current position of the array.
        // 5. Continue the loop until all positions in the array have been filled.
        // 6. Return the completed array.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan:
        // 1. Calculate the index where the portion that needs to move to the
        //    beginning of the list starts by subtracting amount from data.Count.
        // 2. Use GetRange to copy the last amount of items into a separate list.
        // 3. Use GetRange to copy the items from the beginning of the original
        //    list up to the starting index into another list.
        // 4. Clear the original data list so that the same list is modified.
        // 5. Add the items from the end portion to the original list first.
        // 6. Add the beginning portion after the end portion.
        // 7. The original list is now rotated to the right by the requested amount.

        int startIndex = data.Count - amount;

        List<int> endPart = data.GetRange(startIndex, amount);
        List<int> beginningPart = data.GetRange(0, startIndex);

        data.Clear();
        data.AddRange(endPart);
        data.AddRange(beginningPart);
    }
}
