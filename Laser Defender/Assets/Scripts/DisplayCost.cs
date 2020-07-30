using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayCost : MonoBehaviour
{
  
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = transform.parent.gameObject.GetComponent<PlayerUpgrade>().GetCost().ToString() + "$";
    }
}

