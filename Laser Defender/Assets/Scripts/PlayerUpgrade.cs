using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgrade : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float cost = 20f;

    private UserInfo userInfo;

    private void Start()
    {
        userInfo = FindObjectOfType<UserInfo>();
        if (userInfo.GetPlayer() == player)
        {
            GetComponent<Button>().interactable = false;
        }
    }

    public void Upgrade()
    {
        if (userInfo.SpendMoney(cost))
        {
            userInfo.SetPlayer(player);
            GetComponent<Button>().interactable = false;
        }
    }

    public float GetCost() { return cost; }
}
