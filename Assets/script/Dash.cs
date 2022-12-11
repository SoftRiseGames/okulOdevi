using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    bool hasDashed;
    public Rigidbody2D rb;
    public float dashSpeed;
    public Movement moveCodes;
    float xRaw;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveCodes = GameObject.Find("karakter").GetComponent<Movement>();
        hasDashed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && hasDashed && moveCodes.hookground)
            StartCoroutine(Dashwait());
    }
    
    IEnumerator Dashwait()
    {
        Debug.Log("girdi");
        hasDashed = false;
        moveCodes.dashCont = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * 30, 0);
        yield return new WaitForSeconds(.1f);
        rb.gravityScale = 1f;
        moveCodes.dashCont = false;
        hasDashed = true;
    }
   
}
