using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Load UI Canvas On Start")]
    public GameObject UI;
    public TMP_Text MoneyUI;

    private int money = 0;
    
    void Awake() 
    {
        UI.SetActive(true);
    }

    private void Start() {
        MoneyUI.text = "$:" + money;
        ScrapSelling.OnMoneyAdded += AddMoney;
    }

    private void AddMoney(int amountToAdd)
    {
        money += amountToAdd;
        MoneyUI.text = "$:" + money;
    }
}
