using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupCaller : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private GameObject butoons;
    public void Open()
    {
        AudioManager.Instance.PlayAudioSelect();
        container.SetActive(true);
        butoons.SetActive(false);
    }

    public void Close()
    {
        AudioManager.Instance.PlayAudioSelect();
        container.SetActive(false);
        butoons.SetActive(true);
    }
}
