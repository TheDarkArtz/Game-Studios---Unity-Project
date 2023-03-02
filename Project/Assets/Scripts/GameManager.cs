using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Load UI Canvas On Start")]
    public GameObject UI;
    public TMP_Text MoneyUI;

    private static int money = 0;
    
    void Awake() 
    {
        UI.SetActive(true);
        int currentScene =  SceneManager.GetActiveScene().buildIndex;
        
        // Put's money back to zero if you restart the game or play again.
        if (currentScene == 1)
        {
            money = 0;
        }
        
    }

    private void Start() {
        MoneyUI.text = "$:" + money;
    }

    private void OnEnable() {
        ScrapSelling.OnMoneyAdded += AddMoney;
    }

    private void OnDisable() {
        ScrapSelling.OnMoneyAdded -= AddMoney;
    }

    private void AddMoney(int amountToAdd)
    {
        money += amountToAdd;
        MoneyUI.text = "$:" + money;
    }
}
