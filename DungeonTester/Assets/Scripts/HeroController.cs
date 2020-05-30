using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class HeroController : MonoBehaviour
{

    Rigidbody2D rbBody;
    Vector2 inputMovement, currentRbPosition;

    private float inputHoriz, inputVert;
    [SerializeField] private float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        rbBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHoriz = Input.GetAxis("Horizontal");
        inputVert = Input.GetAxis("Vertical");

        inputMovement = new Vector2(inputHoriz, inputVert) * Time.deltaTime * speed;
    }

    private void FixedUpdate()
    {
        currentRbPosition = rbBody.position;
        currentRbPosition += inputMovement * Time.deltaTime * speed;

        rbBody.MovePosition(currentRbPosition);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        HiveBasis target = other.gameObject.GetComponent<HiveBasis>();

        Debug.Log("Player collidet with: " + target);

        if (target != null)
            target.ChangeHealth(-1);
    }
}
