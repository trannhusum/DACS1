using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class SpriteManagement : MonoBehaviour
{
    public static SpriteManagement Instance;
    [SerializeField] private List<Sprite> sprites;   
    [SerializeField] private Image imagePlayer;
    [SerializeField] private Image imageNPC;
    private Player player;
    private void Awake()
    {
        player=GameObject.Find("Player").GetComponent<Player>();       
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
    public void addSprite(int randomNumber)
    {
        switch (randomNumber)
        {
            case 1:
                imageNPC.sprite = sprites[0];
                break;
            case 2:
                imageNPC.sprite = sprites[1];
                break;
            case 3:
                imageNPC.sprite = sprites[2];
                break;
        }
    }
    public void addSpritePlayer(int randomNumber)
    {
        switch (randomNumber)
        {
            case 1:
                imageNPC.sprite = sprites[0];
                break;
            case 2:
                imageNPC.sprite = sprites[1];
                break;
            case 3:
                imageNPC.sprite = sprites[2];
                break;
        }
    }

    public void changeAttackSprite(int index)
    {
        imagePlayer.sprite = sprites[index];
    }
    public void WhoWin(int indexPlayer, int indexNPC, float secondPlayer, float secondNPC)
    {
        StartCoroutine(player.ChangeandresetAnimation(indexPlayer, secondPlayer));
        StartCoroutine(NPC.Instance.ChangeandresetAnimation(indexNPC, secondNPC));
    }

}

