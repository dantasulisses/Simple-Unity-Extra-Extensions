using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Uli.UI.Components
{
    /// <summary>
    /// Holds a list of spawned game objects, with simple methods to clear, spawn, add, or retrieve them
    /// </summary>
    public class UIListHolderComponent : MonoBehaviour
    {
        private List<GameObject> objects = new List<GameObject>();

        public GameObject Spawn(GameObject prefab) 
        {
            //TODO - Maybe use some pooling?
            GameObject newEntry = (GameObject)Instantiate(prefab, this.transform);
            Add(newEntry);
            return newEntry;
        }
        private void Add(GameObject newObject) 
        {
            objects.Add(newObject);
        }
        public void Clear() 
        {
            for (int x = 0; x < this.objects.Count; x++)
            {
                if(objects[x] != null)
                    Destroy(objects[x]);
            }
            objects = new List<GameObject>();
        }
        public List<GameObject> GetList() 
        {
            return objects;
        }
    }
}
