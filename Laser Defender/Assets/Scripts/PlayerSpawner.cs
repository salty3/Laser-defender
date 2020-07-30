using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private void Awake()
    {
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);
        Instantiate(FindObjectOfType<UserInfo>().GetPlayer(), playerPos, Quaternion.identity);
    }

}
