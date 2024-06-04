using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{

    private Player player;
    public static NPC Instance;
    [SerializeField] private List<GameObject> uiLocks;
    [SerializeField] private AudioSource NPCName;
    [SerializeField] private List<AudioSource> NPCFights;
    [SerializeField] private float hp;
    [SerializeField] private float dame;
    [SerializeField] private float time;
    [SerializeField] private Slider slider;
    [SerializeField] private List<Sprite> animationNPC;
    private int levelOfNPC = 0;
    private SpriteRenderer spriteRenderer;
    private float fullHP;
    public int LevelOfNPC
    {
        set { levelOfNPC = value; }
    }
    public AudioSource NPCNAME
    {
        get { return NPCName; }
        set { NPCName = value; }
    }
    public List<AudioSource> NPCFIGHTs => NPCFights;
    public float Time => time;

    public float Damage
    {
        get { return dame; }
        set { dame = value; }
    }
    public float HP
    {
        get { return hp; }
        set { hp = value; }
    }
    public List<Sprite> AnimationNPC => animationNPC;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

        spriteRenderer = GetComponent<SpriteRenderer>();
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
        fullHP = hp;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = hp / fullHP;
    }
    public void TakeDamage(float damageOther)
    {
        hp -= damageOther;
        if (hp <= 0)
        {
            if (levelOfNPC < 7)
                uiLocks[levelOfNPC].SetActive(false);
            NPCFIGHTs[2].Play();
            BarTime.Instance.CanRun = OneTwoThreeManagement.Instance.Canrun = false;
            if ((levelOfNPC + 1) < 8)
                DatabaseGame.Instance.SetLevelTrue(levelOfNPC + 1);

        }
    }
    public IEnumerator ChangeandresetAnimation(int index, float second)
    {
        spriteRenderer.sprite = animationNPC[index];
        yield return new WaitForSeconds(second);
        if (hp <= 0)
        {
            spriteRenderer.sprite = animationNPC[5];
        }
        else if (hp > 0 && player.Hp <= 0)
            spriteRenderer.sprite = animationNPC[6];
        else
            spriteRenderer.sprite = animationNPC[3];
    }
}
