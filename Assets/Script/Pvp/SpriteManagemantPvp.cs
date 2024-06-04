using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class SpriteManagementPvp : MonoBehaviour
{
    public static SpriteManagementPvp Instance;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private Image imagePlayer1;
    [SerializeField] private Image imagePlayer2;
    [SerializeField] private PlayerPvp player1;
    [SerializeField] private PlayerPvp player2;
    private Player player;
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
    public void changeAttackSpritePlayer(int index,int player)
    {
        if (player==1)
            imagePlayer1.sprite = sprites[index];
        else if (player==2)
            imagePlayer2.sprite = sprites[index];
    }
    public void ChangeAnimationPlayer(int indexPlayer1, int indexPlayer2)
    {
        StartCoroutine(player1.ChangeandresetAnimation(indexPlayer1));
        StartCoroutine(player2.ChangeandresetAnimation(indexPlayer2));
    }
}

