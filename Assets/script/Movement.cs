using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    private float horizontal;
    public Rigidbody2D rb;
    public bool ground;
    public bool hookground;
    public bool hookjumped;
    public bool afterMoveCont;
    public bool axisanim;
    
    [Header("MovementSettings")]
    
    public float jumpY;
    
    [SerializeField] float walkinSpeed;
    public bool dashCont;
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
        charExens();
    }
    void charwalkanim()
    {
        if (horizontal > 0 || horizontal < 0)
        {

        }
        else
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TriggerNextLevel")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zemin")
            hookjumped = false; 
        axisanim = true;
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
