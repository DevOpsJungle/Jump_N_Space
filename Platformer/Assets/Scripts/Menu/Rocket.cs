using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Rocket : MonoBehaviour
{
    private Vector3 direction;
    private Vector3 startposition;
    float movingspeed = 100.0f;
    Rigidbody r_rigidbody;
    private int currentstate,direction_dec;
    public Sprite[] rocket=new Sprite[4];  /*array with all used images*/
    // public Camera camera;

    void Awake()
    {
        r_rigidbody = GetComponent<Rigidbody>(); /*assign rigitbody*/
        //camera = GetComponent<Camera>();
    }
    // Start is called before the first frame update
    void Start()
    { 
        reset_values();
        direction_dec = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
        
        if (r_rigidbody.position.y>600)
        {
            reset_values();
            Debug.Log(direction_dec);
            if (direction_dec == 0)
            {
                direction.x = -direction.x;
                startposition.x = -startposition.x;
                Debug.Log(direction_dec);
                direction_dec++;
            }
            else if (direction_dec!=0)
            {
                direction_dec = 0;
            }
            gameObject.GetComponent<Image>().rectTransform.anchoredPosition3D = startposition; /*reset image*/
        }
    }

    void reset_values()
    {
        var vector = new Vector3(0, 0, 0);
        // startposition = camera.ViewportToWorldPoint(new Vector3(0.75f, -0.1f, 0));
        startposition = new Vector3(600, -450, 0);
        direction = new Vector3(-1.0f, 1.0f, 0.0f); /*set direction*/
    }
}
