using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoldPickup : MonoBehaviour
{
    HeroController player;
    GameMaster GM;

    [SerializeField] private int moneyWorth = 1;

    private void Start()
    {
        GM = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.gameObject.GetComponent<HeroController>();
        if (player != null)
        {
            GM.changeMoney(moneyWorth);
            Destroy(gameObject);
        }
    }
}
