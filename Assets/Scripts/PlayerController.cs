using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpForce = 5f;
    Rigidbody2D rb;
    public Animator animator;
    public float runningSpeed = 1.5f;
    
    
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        animator.SetBool("isAlive", true);
        animator.SetBool("isGrounded", true);
    }

       
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            
        }
        animator.SetBool("isGrounded", IsTouchingTheGround());//IsTouchingTheGround es un booleano, por lo cual hacemos depender la animación de esta variable


    }

    //En fuerzas constantes se utiliza FixedUpdate, dado que al haber una baja de frames no perjudicará la experiencia
    private void FixedUpdate()
    {
        if(rb.velocity.x < runningSpeed)
        {
            rb.velocity = new Vector2(runningSpeed, rb.velocity.y);
        }
    }

    void Jump()
    {
        if (IsTouchingTheGround())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
            
        }
    }

    //Variable para detectar el suelo
    public LayerMask groundLayer;

    bool IsTouchingTheGround()
    {
        if(Physics2D.Raycast(this.transform.position, Vector2.down, 0.2f, groundLayer))
        {
            return true;            
        }
        else
        {
            return false;
        }
        

    }
}
