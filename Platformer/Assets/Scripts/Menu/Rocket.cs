using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Rocket : MonoBehaviour
{
    Vector3 vector,position;
    float movingspeed = 100.0f;
    Rigidbody r_rigidbody;
    private int currentstate;
    public Sprite[] rocket=new Sprite[4];
    
    // Start is called before the first frame update
    void Start()
    {
        vector = new Vector3(-1.0f, 1.0f, 0.0f);
        position = new Vector3(-300.0f, 300.0f, 0.0f);
        r_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        r_rigidbody.velocity = vector * movingspeed;
        if (currentstate != 0 && currentstate%60==0)
        {
            gameObject.GetComponent<Image>().sprite = rocket[currentstate/60];
            currentstate++;
            if ((currentstate-1) / 60 == 3)
            {
                currentstate = 0;
            }
        }
        else
        {
            currentstate++;
        }
        Debug.Log(Vector3.Distance(r_rigidbody.position,position));
        if (r_rigidbody.position.y>600)
        {
            //r_rigidbody.position = Vector3.zero;
            gameObject.GetComponent<Image>().rectTransform.anchoredPosition3D = new Vector3(300,-290,0);
        }
    }
}
