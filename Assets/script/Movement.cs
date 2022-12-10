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
    private bool dashBool;
    [Header("MovementSettings")]
    [SerializeField] float speedX;
    [SerializeField] float jumpY;
    [SerializeField] float xRaw;
    private float hookafterMovement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hookground = true;
        axisanim = true;
    }

    // Update is called once per frame
   
    private void FixedUpdate()
    {
        //exenKontroller;
        xRaw = Input.GetAxisRaw("Horizontal");
        horizontal = Input.GetAxis("Horizontal");
        
        //afterHook
        if (hookground && hookjumped && !ground)
            rb.velocity = new Vector2(5 * hookafterMovement, rb.velocity.y);
        
        //normal kontroller

        else if (hookground && !hookjumped)
            rb.velocity = new Vector2(speedX * horizontal, rb.velocity.y);

        Jump();
        hookExens();
        Dash(xRaw);
        Sallanma();
      
    }
    
    void Update()
    {
        charExens();
        //Sallanma();
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zemin")
            ground = true; hookjumped = false; dashBool = true;
        axisanim = true;
    }
    public void Dash(float x)
    {
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (!ground && dashBool)
            {
                rb.velocity = Vector2.zero;
                rb.velocity = new Vector2(x, rb.velocity.y).normalized * 300;
                dashBool = false;
            }
        }

       
    }
    void Jump()
    {
        if (Input.GetKey(KeyCode.W) && ground)
        {
            ground = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpY);
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

    void Sallanma()
    {
        if (!axisanim)
        {
            if (rb.velocity.x < 0 )
            {
                this.gameObject.transform.localScale = new Vector2(-0.341f, this.gameObject.transform.localScale.y);
            }
            else if(rb.velocity.x> 0)
            {
                this.gameObject.transform.localScale = new Vector2(0.341f, this.gameObject.transform.localScale.y);
            }
        }


    }
}
