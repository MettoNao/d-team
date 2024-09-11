using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    player p;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            p = other.GetComponent<player>();
            p.RemoveHP();
            Debug.Log(p.health);
        }
    }
}
