using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    EnemyController target;

    private int bulletDamage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            target = collision.gameObject.GetComponent<EnemyController>();
            target.ChangeHealth(-bulletDamage);
        }
        Destroy(gameObject);     
    }
}
