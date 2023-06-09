using System;
using System.Collections.Generic;

namespace Memory.Scripts.Utils
{
    public static class ExtensionMethods
    {
        private static Random _random = new Random(); // Create a random number generator

        public static List<T> Shuffle<T>(this List<T> original)
        {
            // The Shuffle extension method shuffles the elements of a list and returns the shuffled list.

            List<T> shallowInputClone = new List<T>(original); // Create a shallow copy of the original list
            List<T> result = new List<T>(shallowInputClone.Count); // Create a new list to store the shuffled elements

            while (shallowInputClone.Count > 0)
            {
                // Randomly select an index from the remaining elements in the shallow copy
                int index = _random.Next(0, shallowInputClone.Count);

                // Add the element at the selected index to the result list
                result.Add(shallowInputClone[index]);

                // Remove the element from the shallow copy at the selected index
                shallowInputClone.RemoveAt(index);
            }

            return result; // Return the shuffled list
        }
    }
}
