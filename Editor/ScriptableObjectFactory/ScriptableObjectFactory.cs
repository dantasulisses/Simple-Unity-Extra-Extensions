using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Uli.Extensions
{
	/// <summary>
	/// A helper class for instantiating ScriptableObjects in the editor.
	/// </summary>
	public class ScriptableObjectFactory
	{
		[MenuItem("Assets/Create/ScriptableObject")]
		public static void CreateScriptableObject()
		{
			var assemblies = GetAssembly();

			List<Type> allScriptableObjects = new List<Type>();
			foreach (var assembly in assemblies)
			{
				//Excludes Unity and Common Assemblies
				if (assembly.FullName.Contains("Unity") || assembly.FullName.Contains("Sirenix") || assembly.FullName.Contains("DOTween"))
					continue;

				// Get all classes derived from ScriptableObject
				var types = (from t in assembly.GetTypes()
							 where t.IsSubclassOf(typeof(ScriptableObject))
							 select t).ToList();
				allScriptableObjects.AddRange(types);
			}

			// Show the selection window.
			ScriptableObjectWindow.Init(allScriptableObjects);
		}

		/// <summary>
		/// Returns the assemblies that contains the script code for this project
		/// </summary>
		private static Assembly[] GetAssembly()
		{
			return System.AppDomain.CurrentDomain.GetAssemblies();
		}
	}
}