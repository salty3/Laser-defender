using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayMoney : MonoBehaviour
{
    private TextMeshProUGUI moneyText;
    private UserInfo userInfo;

    // Start is called before the first frame update
    void Start()
    {
        moneyText = GetComponent<TextMeshProUGUI>();
        userInfo = FindObjectOfType<UserInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = userInfo.GetMoney().ToString() + "$";
    }
}
