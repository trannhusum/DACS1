using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;


public class OTT_Pvp : MonoBehaviour
{
    public static OTT_Pvp Instance;
    [SerializeField] private AudioSource audioBell;
    [SerializeField] private AudioSource audioAttack;
    [SerializeField] private PlayerPvp player1;
    [SerializeField] private PlayerPvp player2;
    private SpriteManagement spriteManagement;
    private bool canRun = true;
    [SerializeField] private GameObject gamePlaypvp;
    [SerializeField] private GameObject pvp_Popup;
    [SerializeField] private GameObject coin_Canvas;
    public bool Canrun
    {
        set { canRun = value; }
    }
    private void Awake()
    {
     
    }
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
    private void OnEnable()
    {
        StartCoroutine(DoSomethingSeconds());
    }
    // Update is called once per frame
    void Update()
    {
        if (player1.Hp <= 0 || player2.Hp <= 0)
        {
            StartCoroutine(EndGame());
        }
    }
    public void checkState()
    {
        if (player1.statee==PlayerPvp.State.Bao)
        {
            if (player2.statee == PlayerPvp.State.Bao)
            {
                player1.TakeDamage(player2.Damage/2);
                player2.TakeDamage(player1.Damage/2);
                audioAttack.Play();
                player1.Playerfights[0].Play();
                player2.Playerfights[0].Play();
                SpriteManagementPvp.Instance.ChangeAnimationPlayer(2,2);
            }
            else if (player2.statee == PlayerPvp.State.Keo)
            {
                player1.TakeDamage(player2.Damage);
                audioAttack.Play();
                player1.Playerfights[1].Play();
                player2.Playerfights[0].Play();
                SpriteManagementPvp.Instance.ChangeAnimationPlayer(4, 0);
            }
            else if (player2.statee == PlayerPvp.State.Bua)
            {
                player2.TakeDamage(player1.Damage);
                audioAttack.Play();
                player1.Playerfights[0].Play();
                player2.Playerfights[1].Play();
                SpriteManagementPvp.Instance.ChangeAnimationPlayer(2, 4);
            }
        }
        else if (player1.statee == PlayerPvp.State.Keo)
        {
            if (player2.statee == PlayerPvp.State.Bao)
            {
                player2.TakeDamage(player1.Damage);
                audioAttack.Play();
                player1.Playerfights[0].Play();
                player2.Playerfights[1].Play();
                SpriteManagementPvp.Instance.ChangeAnimationPlayer(0, 4);
            }
            else if (player2.statee == PlayerPvp.State.Keo)
            {
                player1.TakeDamage(player2.Damage/2);
                player2.TakeDamage(player1.Damage/2);
                audioAttack.Play();
                player1.Playerfights[0].Play();
                player2.Playerfights[0].Play();
                SpriteManagementPvp.Instance.ChangeAnimationPlayer(0, 0);
            }
            else if (player2.statee == PlayerPvp.State.Bua)
            {
                player1.TakeDamage(player2.Damage);
                audioAttack.Play();
                player1.Playerfights[1].Play();
                player2.Playerfights[0].Play();
                SpriteManagementPvp.Instance.ChangeAnimationPlayer(4, 1);
            }
        }
        else if (player1.statee == PlayerPvp.State.Bua)
        {
            if (player2.statee == PlayerPvp.State.Bao)
            {
                player1.TakeDamage(player2.Damage);
                audioAttack.Play();
                player1.Playerfights[1].Play();
                player2.Playerfights[0].Play();
                SpriteManagementPvp.Instance.ChangeAnimationPlayer(4, 2);
            }
            else if (player2.statee == PlayerPvp.State.Keo)
            {
                player2.TakeDamage(player1.Damage);
                audioAttack.Play();
                player1.Playerfights[0].Play();
                player2.Playerfights[1].Play();
                SpriteManagementPvp.Instance.ChangeAnimationPlayer(1, 4);
            }
            else if (player2.statee == PlayerPvp.State.Bua)
            {
                player1.TakeDamage(player2.Damage/2);
                player2.TakeDamage(player1.Damage/2);
                audioAttack.Play();
                player1.Playerfights[0].Play();
                player2.Playerfights[0].Play();
                SpriteManagementPvp.Instance.ChangeAnimationPlayer(1, 1);
            }
        }
        if (player1.Hp <= 0 || player2.Hp <= 0)
                audioBell.Play();
    }
    IEnumerator DoSomethingSeconds()
    {
        canRun = true;
        while (canRun)
        {
            yield return new WaitForSeconds(2);
            checkState();
            yield return new WaitForSeconds(1);
        }
    }
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3);
        gamePlaypvp.SetActive(false);
        pvp_Popup.SetActive(true);
        coin_Canvas.SetActive(true);
    }
}
