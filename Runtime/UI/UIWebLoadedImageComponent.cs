using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Uli.UI.Components
{
    /// <summary>
    /// Fills an raw image with a image loaded from web based on a URL
    /// </summary>
    public class UIWebLoadedImageComponent : MonoBehaviour
    {
        [SerializeField] private RawImage image;
        [HideInInspector] public Texture2D loadedImage;

        private void Awake()
        {
            image.enabled = false;
        }
        public void LoadImage(string url) 
        {
            StartCoroutine(Routine_LoadImage(url));
        }
        public void FillImage(Texture2D texture) 
        {
            //TODO - Maybe set aspect ratio controls?
            image.texture = texture;
            image.enabled = true;
        }
        IEnumerator Routine_LoadImage(string url)
        {
            using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url))
            {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();

                switch (webRequest.result)
                {
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.DataProcessingError:
                    case UnityWebRequest.Result.ProtocolError:
                        Debug.LogError(url + ": Error: " + webRequest.error);
                        break;
                    case UnityWebRequest.Result.Success:
                        loadedImage = DownloadHandlerTexture.GetContent(webRequest);
                        break;
                }
            }

            if (loadedImage != null) 
            {
                FillImage(loadedImage);
            }
        }
        private void OnDestroy()
        {
            //Releases the texture
            if (loadedImage != null) 
            {
                Destroy(loadedImage);
            }
        }
    }
}
