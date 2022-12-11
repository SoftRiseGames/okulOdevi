using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    bool hasDashed;
    public Rigidbody2D rb;
    public float dashSpeed;
    float xRaw;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xRaw = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift) )
            Dashfunc(xRaw);
    }
    private void Dashfunc(float x)
    {
        hasDashed = true;
        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2(x,rb.velocity.y);
        Debug.Log(xRaw);
        Debug.Log("dash");
        rb.velocity += dir.normalized * dashSpeed;
        StartCoroutine(Dashwait());
    }
    IEnumerator Dashwait()
    {
        yield return new WaitForSeconds(.3f);
        hasDashed = false;
        
    }
}
