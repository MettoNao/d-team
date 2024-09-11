using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpPower;
    private bool jumpTF = true;
    public int health;
    private Rigidbody rb;
    private TansuProject ip;
    [SerializeField] float xLimit;
    private float x;
    private float y;
    void Start()
    {
        health = 3;
        rb = gameObject.GetComponent<Rigidbody>();
        ip = new TansuProject();
        ip.Player.Jamp.performed += OnJump;
        ip.Enable();
    }
    public void RemoveHP()
    {
        health--;
        if(health==0)
        {
            //SceneManager.LoadScene("Result");
        }
    }
    private void Update()
    {
        Vector3 currentPos = transform.position;
        currentPos.x = Mathf.Clamp(currentPos.x, -xLimit, xLimit);
        transform.position = currentPos;
    }
    private void OnMove(InputValue inputvalue)
    {
        Vector2 movementVector = inputvalue.Get<Vector2>();
        x = movementVector.x;
        y = movementVector.y;
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(-x, 0, -y);
        rb.AddForce(movement * speed);
    }
    public void OnCollisionEnter(Collision other)
    {
        if(jumpTF==true)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                jumpTF = false;
            }
        }
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        if (jumpTF == false)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            jumpTF = true;
        }
    }
}
