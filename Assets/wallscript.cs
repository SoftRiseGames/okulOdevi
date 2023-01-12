using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.Universal;
public class wallscript : MonoBehaviour
{
    public Image TextBackgroundImage;
    public string textler;
    private wallscript node;
    public TextMeshProUGUI textFont;
    public bool isOpen;
    public Light2D wallight;
    float mesafekontrol;
    float yukseklikkontrol;
    void Start()
    {
        //TextBackgroundImage.gameObject.SetActive(false);
        node = null;

    }
    
    // Update is called once per frame
    void Update()
    {
         mesafekontrol = this.gameObject.transform.position.x - GameObject.Find("karakter").transform.position.x;
         yukseklikkontrol = this.gameObject.transform.position.y - GameObject.Find("karakter").transform.position.y;


        if (Mathf.Abs(mesafekontrol) < 2 && Mathf.Abs(yukseklikkontrol) < 4)
        {
            node = this;
            node.textFont.gameObject.SetActive(true);
            Distance(node);
        }
        else
        {
            if (node != null)
            {
                node.textFont.gameObject.SetActive(false);
                node = null;
            }

        }


    }
    void Distance(wallscript node)
    {
        isOpen = true;
        wallight.gameObject.SetActive(true);
        textFont.text = textler;
           
    }

  

}
