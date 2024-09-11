using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slide : MonoBehaviour
{
    new Rigidbody rigidbody;
    public float speed;
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        speed = 1f;
    }
    void Update()
    {
        speed++;
        this.rigidbody.velocity = new Vector3(0, 0, speed);
    }
}
