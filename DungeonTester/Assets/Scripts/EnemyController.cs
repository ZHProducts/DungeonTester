using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private float atkcooldown =0f;

    private float health;
    [SerializeField] private float maxHealth = 10f;

     private HealthBarController healthbar;

    public GameObject MoneyDrop;
   

    private void Start()
    {

        healthbar = GameObject.FindObjectOfType<HealthBarController>();
        health = maxHealth;
        
    }

    private void Awake()
    {
        health = maxHealth;
        
        
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        atkcooldown -= Time.deltaTime;
        GameMaster target = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        
        if (collision.gameObject.GetComponent<HiveBasis>() != null && atkcooldown < 0)
        {
            target.changeBasisHealth(-3);
            atkcooldown = 5f;

            Debug.Log("Enemy hit the Base!");
        }
    }


    public void ChangeHealth(int amount)
    {
        health = Mathf.Clamp(health + amount, 0, maxHealth);

        if(health == 0)
        {
            Destroy(gameObject);
            
            if(MoneyDrop != null)
            Instantiate( MoneyDrop , transform.position, Quaternion.identity);
        }

        healthbar.SetSize( health / maxHealth);
    }
}
