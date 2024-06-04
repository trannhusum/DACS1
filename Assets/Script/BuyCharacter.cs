using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCharacter : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private GameObject uiLock;
    [SerializeField] private GameObject uiLockPVP1;
    [SerializeField] private GameObject uiLockPVP2;
    public void Unlock()
    {
        int money = DatabaseGame.Instance.GetCoinData() - 1500;
        if (money >= 0)
        {
            DatabaseGame.Instance.SetCoinData(money);
            Destroy(gameObject);
            Destroy(uiLock);
            Destroy(uiLockPVP1);
            Destroy(uiLockPVP2);
            CoinGame.Instance.SetCoinText();
            DatabaseGame.Instance.SetUnlockTrue(id);
        }

    }
}
