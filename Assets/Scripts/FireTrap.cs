using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    Collider2D fireCol;
    void Start()
    {
        fireCol = GetComponent<Collider2D>();
    }

    void Update()
    {

    }

    public void fireOn()
    {
        fireCol.enabled = true;
    }

    public void fireOff()
    {
        fireCol.enabled = false;
    }
}