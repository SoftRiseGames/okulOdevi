using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private GameObject player;
    private kancaSistemi kancasistemi;
    private Node node;
    public bool mesafe;
    [SerializeField] float DistanceVeriable;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("boulder");
        node = null;
        kancasistemi = player.GetComponent<kancaSistemi>();
    }

    // Update is called once per frame
    void Update()
    {
        DistanceVeriable = Mathf.Abs(DistanceVeriable);
        
        if (Mathf.Abs(this.gameObject.transform.position.y-player.gameObject.transform.position.y) < DistanceVeriable)
            mesafe = true;
        else
            mesafe = false;
        
    }
    public void OnMouseDown()
    {
        if (mesafe == true)
        {
            node = this;
            kancasistemi.SelectNode(node);
        }
    }
    public void OnMouseUp()
    {
        node = null;
        kancasistemi.Deselect();
    }
}
