using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    Transform bar;
    private void Awake()
    {
       bar = transform.Find("Bar");
    }

   
    public void SetSize (float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

}
