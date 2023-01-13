using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float horizontal;
    public Rigidbody2D rb;
    public bool ground;
    public bool hookground;
    public bool hookjumped;
    public bool afterMoveCont;
    public bool axisanim;
<<<<<<< HEAD
    public Animator anim;
=======
    private bool dashBool;
>>>>>>> parent of 315986d (lightsEnd)
    [Header("MovementSettings")]
    private float speedX;
    public float jumpY;
    [SerializeField] float xRaw;
    [SerializeField] float walkinSpeed;
    public bool dashCont;
    private float hookafterMovement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hookground = true;
        axisanim = true;
<<<<<<< HEAD
        anim = GetComponent<Animator>();
        
=======
        speedX = walkinSpeed;
>>>>>>> parent of 315986d (lightsEnd)
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        //exenKontroller;
        xRaw = Input.GetAxisRaw("Horizontal");
        horizontal = Input.GetAxis("Horizontal");

        //afterHook
        if (hookground && hookjumped && !ground && !dashCont)
            rb.velocity = new Vector2(5 * hookafterMovement, rb.velocity.y);

        //normal kontroller
        
        else if (hookground && !hookjumped && !dashCont)
            rb.velocity = new Vector2(walkinSpeed * horizontal*Time.deltaTime, rb.velocity.y);

        if (ground)
            Jump();
      

        hookExens();
        Sallanma();

    }

    void Update()
    {
        charwalkanim();
        charExens();
    }
    void charwalkanim()
    {
        if (horizontal > 0 || horizontal < 0)
        {
            anim.SetBool("isWalk", true);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }

        if (rb.velocity.y > 0)
        {
            anim.SetBool("isJump", true);
        }
        else
        {
            anim.SetBool("isJump", false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zemin")
            hookjumped = false; dashBool = true;
        axisanim = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "zemin")
        {
            
        }
    }

    void hookExens()
    {
        if (this.gameObject.transform.localScale.x >= 0)
            hookafterMovement = 1;
        else
            hookafterMovement = -1;
    }
    void charExens()
    {
        if (axisanim)
        {
            if (horizontal < 0 && this.gameObject.transform.localScale.x >= 0)
                this.gameObject.transform.localScale = new Vector2(this.gameObject.transform.localScale.x * -1, this.gameObject.transform.localScale.y);
            else if (horizontal > 0 && this.gameObject.transform.localScale.x < 0)
                this.gameObject.transform.localScale = new Vector2(this.gameObject.transform.localScale.x * -1, this.gameObject.transform.localScale.y);
        }
    }
    void Jump()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.up * jumpY * Time.deltaTime;
        }
    }
    void Sallanma()
    {
        if (!axisanim)
        {
            if (rb.velocity.x < 0)
            {
                this.gameObject.transform.localScale = new Vector2(-1.5f, this.gameObject.transform.localScale.y);
                Debug.Log("left");

            }
            else if (rb.velocity.x >= 0)
            {
                this.gameObject.transform.localScale = new Vector2(1.5f, this.gameObject.transform.localScale.y);
            }
        }
    }
}
