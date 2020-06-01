using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopLeave : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameMaster GM = GameObject.Find("GameMaster").GetComponent<GameMaster>();

        GM.enterLevel(1);
    }
}
