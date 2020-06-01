using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    EnemyController target;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("I hit " + collision.gameObject);

        if (collision.gameObject.tag == "Enemy")
        {
            target = collision.gameObject.GetComponent<EnemyController>();

            target.ChangeHealth(-1);
        }
            

        Destroy(gameObject);

        
    }
}
