using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PopupCharacter : MonoBehaviour
{
    [SerializeField] private Sprite newImage;
    [SerializeField] private Image image;
    public void Select()
    {
        AudioManager.Instance.PlayAudioClick();
        image.sprite= newImage;
    }
}
