using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float money = 0f;
    [SerializeField] private float moneyMultiplier = 1f;

    [SerializeField] private string difficult;


    private void Awake()
    {
        SetUpSingleton();
    }


    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void CalculateMoney()
    { 
        GameSession gameSession = FindObjectOfType<GameSession>();
        money += gameSession.GetScore() * moneyMultiplier;   
    }

    public bool SpendMoney(float money)
    {
        if (money > this.money)
        {
            return false;
        }
        this.money -= money;
        return true;
    }

    public float GetMoney()
    {
        return money;
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    public Player GetPlayer()
    {
        return player;
    }

    public float GetMultiplier()
    {
        return moneyMultiplier;
    }

    public void SetEasy() 
    {
        difficult = "Easy";
        moneyMultiplier = 0.2f;
    }
    public void SetMedium()
    {
        difficult = "Medium";
        moneyMultiplier = 0.4f;
    }
    public void SetHard()
    {
        difficult = "Hard";
        moneyMultiplier = 0.8f;
    }

    public string GetDifficult()
    {
        return difficult;
    }
}
