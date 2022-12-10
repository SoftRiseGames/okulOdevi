using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kancaSistemi : MonoBehaviour
{
    [SerializeField] private Transform hedefPozisyon;
    [SerializeField] private LineRenderer lr;
    [SerializeField] private DistanceJoint2D dj;
    
    private Node selectednode;
    public static kancaSistemi instance;
    public Movement moveCont;
    
    bool asilikalma;
    public LayerMask layercontrol;
    void Start()
    {
        lr.enabled = false;
        dj.enabled = false;
        selectednode = null;
        moveCont = GameObject.Find("karakter").GetComponent<Movement>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(selectednode == null)
        {
            lr.enabled = false;
            dj.enabled = false;
            return;
        }

        lr.enabled = true;
        dj.enabled = true;

        dj.connectedBody = selectednode.GetComponent<Rigidbody2D>();
        if(selectednode != null)
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, selectednode.transform.position);
        }
    }
    public void SelectNode(Node node)
    {
        selectednode = node;
        moveCont.axisanim = false;
        moveCont.hookground = false;
        moveCont.hookjumped = false;
        this.gameObject.transform.parent = selectednode.transform;
        Debug.Log(this.gameObject.transform.position.x);
      
    }
    public void Deselect()
    {
        moveCont.axisanim = true;
        selectednode = null;
        this.gameObject.transform.parent = null;
        moveCont.hookground = true;
        moveCont.hookjumped = true;
    }
   
}
