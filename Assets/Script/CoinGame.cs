using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CoinGame : MonoBehaviour
{
    public static CoinGame Instance;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private DatabaseGame databaseGame;
    private void Awake()
    {
        SetCoinText();
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
        SetCoinText();
    }
    public void SetCoinText()
    {
        textMeshProUGUI.SetText("" + databaseGame.GetCoinData());
    }
}
