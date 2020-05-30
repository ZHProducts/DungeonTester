using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private void OnCollisionStay2D(Collision2D collision)
    {
        HiveBasis target = collision.gameObject.GetComponent<HiveBasis>();

        if (target != null)
            target.ChangeHealth(-1);

    }
}
