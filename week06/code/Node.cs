using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    // Creates a set to prevent duplicate values
    HashSet<int> values = new HashSet<int> ();

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Problem 1 - Complete

        // Checks for duplicate values
        if (!values.Contains(value))
        {
            values.Add(value);
            if (value < Data)
            {
                // Insert to the left
                if (Left is null)
                    Left = new Node(value);
                else
                    Left.Insert(value);
            }
            else
            {
                // Insert to the right
                if (Right is null)
                    Right = new Node(value);
                else
                    Right.Insert(value);
            }
        }

        
    }

    public bool Contains(int value)
    {
        // Problem 2 - Complete
        bool results; // Store results

        if (value == Data) // Check current node
        {
            return true;
        }
        else if (value < Data) // Check left
        {
            if (Left != null) // If left is not null
            {
                results = Left.Contains(value);
            }
            else // Otherwise it is not in the list
            {
                return false;
            }
        }
        else // Check right
        {
            if (Right != null) // If right is not null
            {
                results = Right.Contains(value);
            }
            else // Otherwuse it is not in the list
            {
                return false;
            }
        }
        return results; // Return the results
    }

    public int GetHeight(int currHeight, HashSet<int>? heights = null)
    {
        // Problem 4 - Complete
        int maxHeight = 1;
        if (heights == null)
        {
            heights = new HashSet<int>(); //Store all the end heights that are unique
        }

        int currentHeight = currHeight;

        if (Left == null && Right == null)
        {
            // Add max height of current path to heights
            heights.Add(currHeight);
        }
        if (Left is not null)
        {
            // Move to left
            currentHeight += 1;
            Left.GetHeight(currentHeight, heights);
            currentHeight -= 1;
        }
        if (Right is not null)
        {
            // Move to right
            currentHeight += 1;
            Right.GetHeight(currentHeight, heights);
            currentHeight -= 1;
        }
        //return the largest height
        foreach (var height in heights)
        {
            if (height > maxHeight)
            {
                maxHeight = height;
            }
        }
        return maxHeight;
    }
}