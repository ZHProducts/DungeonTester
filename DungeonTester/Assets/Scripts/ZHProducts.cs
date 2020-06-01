using System.Collections;
using UnityEngine;


namespace ZHProducts
{
    public class Position
    {
        public static Vector3 GetMouseWorldPosition()
        {
            Camera worldCamera = Camera.main;
            Vector3 vec = worldCamera.ScreenToWorldPoint(Input.mousePosition);
            vec.z = 0f;
            return vec;
        }
    }
}