using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float jumpSpeed = 20f;
    public float maxSpeed = 10f;
    public GameObject canvas;
    public bool HardMode = false;

    public bool isGround;
    public Vector3 startPos = new Vector3(-8.12f, -1.56f, 0);

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos;
        canvas = GameObject.Find("Canvas");
        canvas.GetComponent<TouchController>().player = this.gameObject;
        canvas.GetComponent<TouchController>().pc = this;
    }

    // Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR || UNITY_WEBGL
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Idle();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            
            MoveLeft();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {

            Idle();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

#elif UNITY_ANDROID
        //rb.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * maxSpeed, rb.velocity.y);
        rb.AddForce(new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * maxSpeed, 0));
#endif

        //rb.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * maxSpeed, rb.velocity.y);
        rb.AddForce(new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * maxSpeed, 0));

        if (rb.velocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            float limit = Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed);
            rb.velocity = new Vector2(limit, rb.velocity.y);
        }



    }

    public void MoveRight()
    {
        if (HardMode)
            rb.AddForce(Vector2.right * maxSpeed);
        else
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, maxSpeed, .8f), rb.velocity.y);
           

    }
    public void MoveLeft()
    {
        if (HardMode)
            rb.AddForce(Vector2.left * maxSpeed);
        else
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, -maxSpeed, .8f), rb.velocity.y);
    }

    public void Jump()
    {
        if (isGround)
        {

            rb.velocity += (Vector2.up * jumpSpeed);
            isGround = false;
            
        }
    }
    public void Idle()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }


    public void Die()
    {
        Starter.Health -= 1;
        if (SceneManager.GetActiveScene().buildIndex > 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            transform.position = startPos;

        }
        if (Starter.Health == 0)
        {
            Starter.Health = 3;
            Destroy(canvas);
            SceneManager.LoadScene(1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGround = true;
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Spike")
        {
            Die();
        }

        if(collision.tag == "Finish")
        {
            Debug.Log("OKE");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}
