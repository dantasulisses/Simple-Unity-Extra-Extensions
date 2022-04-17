using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Uli.UI.Components
{
    /// <summary>
    /// Groups a Text with a Icon/Image related
    /// </summary>
    public class UITextImagePairComponent : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI text;
        [SerializeField] private TMPro.TextMeshProUGUI subText;
        [SerializeField] private Image image;
        [SerializeField] private Sprite[] imageStates; //TODO - Maybe change to addressableReference?

        public void Set(string text, string subText, int image) 
        {
            this.text.text = text;
            if(this.subText != null)
                this.subText.text = subText;
            if(this.image != null)
                this.image.sprite = this.imageStates[image];
        }
    }
}
