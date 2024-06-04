using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Count3seconds : MonoBehaviour
{
    public static Count3seconds Instance;
    [SerializeField] private TextMeshProUGUI m_TextMeshPro;
    [SerializeField] private GameObject coin_Canvas;
    [SerializeField] private AudioSource audioFight;
    [SerializeField] private Player player;
    [SerializeField] private NPC npc;
    private void Start()
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
    public IEnumerator Count(GameObject gameObject,GameObject setTrue)
    {
        m_TextMeshPro.SetText("3");
        yield return new WaitForSeconds(1);
        m_TextMeshPro.SetText("2");
        yield return new WaitForSeconds(1);
        m_TextMeshPro.SetText("1");
        yield return new WaitForSeconds(1);
        m_TextMeshPro.SetText("");
        player.PlayerName.Play();
        yield return new WaitForSeconds(1);
        AudioManager.Instance.PlayAudioVS();
        yield return new WaitForSeconds(1);
        npc.NPCNAME.Play();
        yield return new WaitForSeconds(1);
        setTrue.SetActive(true);
        gameObject.SetActive(false);
        coin_Canvas.SetActive(false);
        audioFight.Play();

    }
}
