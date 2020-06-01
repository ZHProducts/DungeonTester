using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    private GameObject player;
    private Vector3 playerPosition;

    private Vector3 cameraposition;
    private Vector3 mousePosition;

    private void Start()
    {
        player = GameObject.Find("Hero");
       
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = GetMouseWorldPosition();
        playerPosition = player.transform.position;
        cameraposition.x = playerPosition.x + (mousePosition.x - playerPosition.x)/4;
        cameraposition.y = playerPosition.y + (mousePosition.y - playerPosition.y)/4;
        cameraposition.z = -10f;
        gameObject.transform.position = cameraposition;
    }


    static Vector3 GetMouseWorldPosition()
    {
        Camera worldCamera = Camera.main;
        Vector3 vec = worldCamera.ScreenToWorldPoint(Input.mousePosition);
        vec.z = 0f;
        return vec;
    }
}
