using UnityEngine;
using UnityEngine.UI;
using InterfaceModification;

public class ViewStateGlove : MonoBehaviour, IViewStateGlove
{   
    [SerializeField] private Image _imageStateGlove;    

    public void ChangeImageStateGlove(Sprite image)
    {
        _imageStateGlove.sprite = image;
    }
}
