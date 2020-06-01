using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZHProducts;

public class MainCamera : MonoBehaviour
{

    private GameObject player;
    private Vector3 cameraPosition;
    private Vector3 mousePosition;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Hero");
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Position.GetMouseWorldPosition();
        cameraPosition = CalculateCameraPosition(player.transform.position, mousePosition);
        gameObject.transform.position = cameraPosition;
    }

    private static Vector3 CalculateCameraPosition(Vector3 playerPosition, Vector3 mouseOffset)
    {
        Vector3 vec;
        vec.x = playerPosition.x + (mouseOffset.x - playerPosition.x) / 4;
        vec.y = playerPosition.y + (mouseOffset.y - playerPosition.y) / 4;
        vec.z = -10f;

        return vec;
    }
    
}
