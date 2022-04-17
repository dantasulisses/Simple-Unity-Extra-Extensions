using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Uli.UI.Components
{
    /// <summary>
    /// Dynamically loads an image and assigns to a Raw Image component
    /// </summary>
    public class UIRawImageHolderComponent : MonoBehaviour
    {
        [SerializeField] private RawImage image;
        [HideInInspector] public Texture2D loadedImage;

        private void Awake()
        {
            //image.enabled = false;
        }
        public void LoadImage(string address) 
        {
            image.enabled = true;
            //TODO - Use addressables?
            loadedImage = Resources.Load(address) as Texture2D;
            image.texture = loadedImage;
        }
    }
}
