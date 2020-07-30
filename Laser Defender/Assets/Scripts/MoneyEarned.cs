using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyEarned : MonoBehaviour
{
    private TextMeshProUGUI moneyText;
    private GameSession gameSession;
    private UserInfo userInfo;
    private float moneyEarned = 0f;

    // Start is called before the first frame update
    void Start()
    {
        moneyText = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();
        userInfo = FindObjectOfType<UserInfo>();

        moneyEarned = gameSession.GetScore() * userInfo.GetMultiplier();

        moneyText.text = moneyEarned.ToString();
    }

}
