using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCont : MonoBehaviour
{
    public Movement character;
    public Rigidbody2D rbchar;
    public Dash dashcode;
    void Start()
    {
        dashcode = GameObject.Find("karakter").GetComponent<Dash>();
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "zemin")
        {
            dashcode.hasDashed = true;
            character.ground = true;
        }
        
          
       

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "zemin")
            character.ground = false;
    }

    

}
