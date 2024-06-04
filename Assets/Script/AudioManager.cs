using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource audioVS;
    [SerializeField] private AudioSource audioSelect;
    [SerializeField] private AudioSource audioClick;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayAudioVS()
    {
        audioVS.Play();
    }
    public void PlayAudioSelect()
    {
        audioSelect.Play();
    }
    public void PlayAudioClick()
    {
        audioClick.Play();
    }
}
