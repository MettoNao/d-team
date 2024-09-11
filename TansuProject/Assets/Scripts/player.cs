using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpPower;
    [SerializeField] float xLimit;
    [SerializeField] private ResultDisplayScore resultDisplayScore;
    private bool jumpTF = true;
    public int health;
    private Rigidbody rb;
    private TansuProject ip;
    private Animator anim;
    private float x;
    private float y;
    void Start()
    {
        health = 3;
        rb = gameObject.GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();
        anim.SetBool("walk", true);

        ip = new TansuProject();
        ip.Player.Jump.performed += Jump;
        ip.Enable();
    }

    public void RemoveHP()
    {
        health--;
        if (health == 0)
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

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(-x, 0, -y);
        rb.AddForce(movement * speed);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (jumpTF == true)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                jumpTF = false;
            }
        }


        if (other.gameObject.CompareTag("Enemy"))
        {
            resultDisplayScore.ShowResult();
        }
    }

    private void OnMove(InputValue inputvalue)
    {
        Vector2 movementVector = inputvalue.Get<Vector2>();
        x = movementVector.x;
        y = movementVector.y;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump!!");
        if (jumpTF == false)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            jumpTF = true;
        }
    }
}