using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Rocket : MonoBehaviour
{
    private Vector3 direction;
    private Vector3 startposition;
    float movingspeed = 10.0f;
    Rigidbody r_rigidbody;
    private int currentstate,direction_dec;
    public Sprite[] rocket=new Sprite[4];  /*array with all used images*/
    public Camera cam;

    void Awake()
    {
        cam = CameraView.GetCamera();
        r_rigidbody = GetComponent<Rigidbody>(); /*assign rigitbody*/
        Time.timeScale = 1.0f;
    }
    // Start is called before the first frame update
    void Start()
    { 
        r_rigidbody = GetComponent<Rigidbody>(); /*assign rigitbody*/
        reset_values();
        direction_dec = 0;
    }
    
    // Update is called once per frame
 
    void FixedUpdate()
    {
        //Debug.Log(cam.WorldToScreenPoint(r_rigidbody.position));
        
        r_rigidbody.velocity = direction * movingspeed; /*set velocity*/
        if (currentstate != 0 && currentstate%20==0) /*animation change every 20 frames*/
        {
            gameObject.GetComponent<Image>().sprite = rocket[currentstate/20];
            currentstate++;
            if ((currentstate-1) / 20 == 3) /*if the last image is shown, begin with the first*/
            {
                currentstate = 0;
            }
        }
        else
        {
            currentstate++;
        }
        
        if (r_rigidbody.position.y > cam.ScreenToWorldPoint(new Vector3(0,1080,0)).y)
        {
            reset_values();
            
            if (direction_dec == 0)
            {
                direction.x = -direction.x;
                startposition.x = -startposition.x;
                
                direction_dec++;
            }
            else if (direction_dec!=0)
            {
                direction_dec = 0;
            }
            Debug.Log(startposition);
            
            gameObject.GetComponent<Image>().rectTransform.anchoredPosition3D = startposition; /*reset image*/
            //Debug.Log(cam.WorldToScreenPoint(r_rigidbody.position));
        }
    }

    void reset_values()
    {
        startposition = (new Vector3(960f, -460f, 0));
        
        direction = new Vector3(-1.0f, 1.0f, 0.0f); /*set direction*/
    }
}