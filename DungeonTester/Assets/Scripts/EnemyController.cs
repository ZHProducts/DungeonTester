using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private float atkcooldown = 0f; 
    [SerializeField] private float atkcooldownmax = 5f;
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
        
        if (collision.gameObject.tag == "Basis" && atkcooldown < 0)
        {
            target.changeBasisHealth(-3);
            atkcooldown = 5f;
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
