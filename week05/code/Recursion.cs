using System.Collections;
using System.ComponentModel.DataAnnotations;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Problem 1 - Complete
        if (n <= 0)
        // base case: check if n is less than or equal to 0, return if so
        {
            return 0;
        }
        else
        {   // return N squared plus the recursive function, all the way to zero
            return (n * n) + SumSquaresRecursive(n - 1);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Problem 2 - Complete
        if (results == null) // Create the result list if it doesnt exist already
        {
            results = new List<string>();
        }
        if (word.Length == size) // If the word is the correct size already, add it and dont loop
        {
            results.Add(word);
            return;
        }
        else
        {
            for (int i = 0; i < letters.Length; i++) // Loop a number of times equal to the number of letters
            {
                var lettersLeft = letters.Remove(i, 1); // Remove the current letter from the available options
                PermutationsChoose(results, lettersLeft, size, word + letters[i]); // Recurse with the letters left, and add the current letter to the word
            }
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null) // Create dictionary if it doesnt exist
        {
            remember = new Dictionary<int, decimal>();
        }
        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // Problem 3 - Complete
        if (remember.ContainsKey(s)) // Check if dictionary has solution already, return if so
        {
            return remember[s];
        }
        // Solve using recursion
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember); // Pass on Remember to the other recursions
        remember[s] = ways; // Remember this solution for future reference
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results) // 111011**111
    {
        if (results == null) // Create results if it doesnt exist
        {
            results = new List<string>();
        }
        if (pattern == null || !pattern.Contains('*'))
        { //If there is no pattern, or the pattern doesnt have a wildcard, end early after adding it
            results.Add(pattern);
            return;
        }
        else
        {
            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern.IndexOf('*') != -1)// Check for wildcard, recurse with both pattern options
                {
                    i = pattern.IndexOf('*');
                    var option1 = $"{pattern.Substring(0, i)}1{pattern.Substring(i + 1)}";
                    var option2 = $"{pattern.Substring(0, i)}0{pattern.Substring(i + 1)}";
                    WildcardBinary(option1, results);
                    WildcardBinary(option2, results);
                    return;
                }
            }
        }
        // Problem 4 - Complete
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    //     public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    //     {
    //         // If this is the first time running the function, then we need
    //         // to initialize the currPath list.
    //         if (currPath == null)
    //         {
    //             currPath = new List<ValueTuple<int, int>>();
    //         }
    //         if (results == null)
    //         {
    //             results = new List<string>();
    //         }
    //         if (maze.IsEnd(x, y))
    //         {
    //             currPath.Add((x, y));
    //             Console.WriteLine($"{x}, {y}");
    //             Console.WriteLine(currPath.AsString());
    //             results.Add(currPath.AsString());

    //             return;
    //         }

    //         // currPath.Add((1,2)); // Use this syntax to add to the current path

    //         // TODO Start Problem 5 - INCOMPLETE
    //         // ADD CODE HERE
    //         currPath.Add((x, y));
    //         Console.WriteLine($"{x}, {y}");
    //         Console.WriteLine(currPath.AsString());
    //         if (maze.IsValidMove(currPath, x + 1, y)) // Right 
    //         {
    //             ///
    //             var newCP = currPath;
    //             var newX = x;
    //             var newY = y;
    //             SolveMaze(results, maze, x + 1, y, currPath);
    //             currPath = newCP; ///
    //             x = newX;
    //             y = newY;
    //         }
    //         if (maze.IsValidMove(currPath, x, y + 1)) // Down
    //         {
    //             SolveMaze(results, maze, x, y + 1, currPath);
    //             currPath = new List<ValueTuple<int, int>> { (0, 0) };
    //             x = 0;
    //             y = 0;
    //         }
    //         if (maze.IsValidMove(currPath, x - 1, y)) // Left
    //         {
    //             SolveMaze(results, maze, x - 1, y, currPath);
    //             currPath = new List<ValueTuple<int, int>> { (0, 0) };
    //             x = 0;
    //             y = 0;
    //         }
    //         if (maze.IsValidMove(currPath, x, y - 1)) // Up
    //         {
    //             SolveMaze(results, maze, x, y - 1, currPath);
    //             currPath = new List<ValueTuple<int, int>> { (0, 0) };
    //             x = 0;
    //             y = 0;
    //         }
    //         else
    //         {
    //             currPath.RemoveAt(currPath.Count - 1);
    //             return;
    //         }
    //         // Console.WriteLine(currPath.AsString());
    //         // results.Add(currPath.AsString()); // Use this to add your path to the results array keeping track of complete maze solutions when you find the solution.
    //     }
    // }


    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }
        if (results == null) // initialize results if null
        {
            results = new List<string>();
        }
        if (maze.IsEnd(x, y)) // Check for end case, add to results and return if so
        {
            currPath.Add((x, y));
            results.Add(currPath.AsString());
            return;
        }

        // currPath.Add((1,2)); // Use this syntax to add to the current path

        // TODO Start Problem 5 - COMPLETE
        
        currPath.Add((x, y)); // Add current space

        if (maze.IsValidMove(currPath, x + 1, y)) // Right 
        {
            SolveMaze(results, maze, x + 1, y, new List<ValueTuple<int, int>>(currPath));
        }
        if (maze.IsValidMove(currPath, x - 1, y)) // Left
        {
            SolveMaze(results, maze, x - 1, y, new List<ValueTuple<int, int>>(currPath));
        }
        if (maze.IsValidMove(currPath, x, y + 1)) // Down
        {
            SolveMaze(results, maze, x, y + 1, new List<ValueTuple<int, int>>(currPath));
        }
        if (maze.IsValidMove(currPath, x, y - 1)) // Up
        {
            SolveMaze(results, maze, x, y - 1, new List<ValueTuple<int, int>>(currPath));
        }
        // results.Add(currPath.AsString()); // Use this to add your path to the results array keeping track of complete maze solutions when you find the solution.
    }
}