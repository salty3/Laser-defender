using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float money = 0f;
    [SerializeField] private float moneyMultiplier = 1f;


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
}
