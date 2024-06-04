using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPvp : MonoBehaviour
{
    [SerializeField] private List<AudioSource> playerfights;
    [SerializeField] private PlayerPvp otherPlayer;
    [SerializeField] int player;
    [SerializeField] private List<Sprite> animationPlayer;
    [SerializeField] private List<KeyCode> keyCode;
    [SerializeField] private float hp;
    [SerializeField] private float dame;
    [SerializeField] private Slider slider;
    [SerializeField] private Slider countdown;
    [SerializeField] private float keyPressCooldown; // Thời gian chờ giữa các lần bấm phím
    private float lastKeyPressTime = 0f; // Thời gian của lần bấm phím cuối cùng
    private SpriteRenderer spriteRenderer;
    private State state;
    private float fullHP;
    public List<AudioSource> Playerfights => playerfights;
    public float KeyPressCooldown
    {
        set { keyPressCooldown = value; }
    }


    public State statee => state;
    public float Damage
    {
        get { return dame; }
        set { dame = value; }
    }
    public float Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public List<Sprite> AnimationPlayer => animationPlayer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        state = State.Keo;
        
    }
    private void OnEnable()
    {
        fullHP = hp;
        countdown.maxValue = keyPressCooldown;
    }
    void Update()
    {
        if (Time.time - lastKeyPressTime >= keyPressCooldown && hp > 0)
        {
            if (Input.GetKeyDown(keyCode[0]))
            {
                lastKeyPressTime = Time.time;
                state = State.Keo;
                SpriteManagementPvp.Instance.changeAttackSpritePlayer(0,player);
                countdown.value = 0;
            }
            else if (Input.GetKeyDown(keyCode[1]))
            {
                lastKeyPressTime = Time.time;
                state = State.Bua;
                SpriteManagementPvp.Instance.changeAttackSpritePlayer(1, player);
                countdown.value = 0;
            }
            else if (Input.GetKeyDown(keyCode[2]))
            {
                lastKeyPressTime = Time.time;
                state = State.Bao;
                SpriteManagementPvp.Instance.changeAttackSpritePlayer(2, player);
                countdown.value = 0;
            }

        }
        countdown.value += Time.deltaTime;
        slider.value = hp / fullHP;

    }
    public enum State
    {
        Keo, Bua, Bao
    }

    public void TakeDamage(float damageOther)
    {
        hp -= damageOther;
        if (hp <= 0)
        {
            BarTimePVP.Instance.CanRun = OTT_Pvp.Instance.Canrun = false;
        }

    }
    public IEnumerator ChangeandresetAnimation(int index)
    {
        spriteRenderer.sprite = animationPlayer[index];
        yield return new WaitForSeconds(1);
        if (hp <= 0)
        {
            spriteRenderer.sprite = animationPlayer[5];
        }
        else if (hp > 0 && otherPlayer.Hp <= 0)
            spriteRenderer.sprite = animationPlayer[6];
        else
            spriteRenderer.sprite = animationPlayer[3];
    }


}
