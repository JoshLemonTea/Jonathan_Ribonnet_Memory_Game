using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Memory.Data
{
    // Define a generic abstract class Singleton<T> that inherits from MonoBehaviour
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        // Create a Lazy<T> instance that will hold the singleton instance
        private static readonly Lazy<T> LazyInstance = new Lazy<T>(CreateSingleton);

        // Define a public static property 'Instance' that returns the singleton instance
        public static T Instance => LazyInstance.Value;

        // Define a private static method 'CreateSingleton' that creates and returns the singleton instance
        private static T CreateSingleton()
        {
            // Create a new GameObject to hold the singleton instance, with a name based on the type of T
            var ownerObject = new GameObject($"{typeof(T).Name} (singleton)");

            // Add an instance of T as a component to the ownerObject
            var instance = ownerObject.AddComponent<T>();

            // Prevent the ownerObject from being destroyed when a new scene is loaded
            DontDestroyOnLoad(ownerObject);

            // Return the created instance
            return instance;
        }
    }
}
