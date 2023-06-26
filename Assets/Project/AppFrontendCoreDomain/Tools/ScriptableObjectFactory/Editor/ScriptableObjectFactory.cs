using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Project.AppFrontendCoreDomain.Tools
{
    /// <summary>
    /// A helper class for instantiating ScriptableObjects in the editor.
    /// </summary>
    public class ScriptableObjectFactory
    {
        private static List<string> _includeAssembliesPrefix = new List<string>()
        {
            "App"
        };

        [MenuItem("Assets/Create/ScriptableObject")]
        public static void CreateScriptableObject()
        {
            var assemblies = GetAssemblies();

            // Get all classes derived from ScriptableObject
            var allScriptableObjects = new List<Type>();

            foreach (var assembly in assemblies)
            {
                allScriptableObjects.AddRange(from t in assembly.GetTypes()
                                              where t.IsSubclassOf(typeof(ScriptableObject))
                                              select t);
            }

            // Show the selection window.
            ScriptableObjectWindow.Init(allScriptableObjects.ToArray());
        }

        private static List<Assembly> GetAssemblies()
        {
            var assemblies = new List<Assembly>();
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var isInclude = false;
                foreach (var includedAssembly in _includeAssembliesPrefix)
                {
                    if (assembly.FullName.Contains(includedAssembly))
                    {
                        isInclude = true;
                        break;
                    }
                }

                if (isInclude)
                {
                    assemblies.Add(assembly);
                }
            }
            return assemblies;
        }
    }
}