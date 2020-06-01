using UnityEngine;
using ZHProducts;

public class PlayerAimWeapon : MonoBehaviour
{
    
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    Vector3 mousePosition;

   

    private void Update()
    {
        HandleAiming();
        HandleShooting();
    }


    private void HandleAiming()
    {
        mousePosition = Position.GetMouseWorldPosition();
        Vector2 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right  * bulletForce, ForceMode2D.Impulse);
                     
        }
    }

    
}
