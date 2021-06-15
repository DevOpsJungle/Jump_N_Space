using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Rocket : MonoBehaviour
{
    Vector3 vector;
    float movingspeed = 100.0f;
    Rigidbody r_rigidbody;
    private int currentstate;
    public Sprite[] rocket=new Sprite[4];  /*array with all used images*/
    
    // Start is called before the first frame update
    void Start()
    {
        vector = new Vector3(-1.0f, 1.0f, 0.0f); /*set direction*/
        r_rigidbody = GetComponent<Rigidbody>(); /*assign rigitbody*/
    }

    // Update is called once per frame
    void Update()
    {
        r_rigidbody.velocity = vector * movingspeed; /*set velocity*/
        if (currentstate != 0 && currentstate%60==0) /*animation change every 60 frames*/
        {
            gameObject.GetComponent<Image>().sprite = rocket[currentstate/60];
            currentstate++;
            if ((currentstate-1) / 60 == 3) /*if the last image is shown, begin with the first*/
            {
                currentstate = 0;
            }
        }
        else
        {
            currentstate++;
        }
        
        if (r_rigidbody.position.y>600)
        {
            gameObject.GetComponent<Image>().rectTransform.anchoredPosition3D = new Vector3(600,-450,0); /*reset image*/
        }
    }
}
