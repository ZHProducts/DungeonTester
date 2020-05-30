using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveBasis : MonoBehaviour
{
    [SerializeField] private int ihealthBasisMax = 5;
    private int icurrhealth;

    private void Start()
    {
        icurrhealth = ihealthBasisMax;
    }

    public void ChangeHealth(int amount)
    {
        icurrhealth = Mathf.Clamp(icurrhealth + amount, 0, ihealthBasisMax);
        Debug.Log("Basis is at " + icurrhealth + " health");
    }

}
