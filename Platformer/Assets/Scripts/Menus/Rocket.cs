/*
* Script: Rocket
* Author: Philipp Scheffler
* Last Change: 21.06.21
* Controls the rocket in menu.scene
*/

using UnityEngine;
using UnityEngine.UI;
using Viewport;

namespace Menus
{
    public class Rocket : MonoBehaviour
    {
        private Vector3 direction;
        private Vector3 startposition;
    
        private Rigidbody r_rigidbody;
        public Camera cam;
        public Sprite[] rocket = new Sprite[4];  /*array with all used images*/
    
        private float movingspeed = 10.0f;
        private float border;
        private int currentstate,direction_dec;
    
    

        void Awake()
        {
            cam = CameraView.GetCamera();
            r_rigidbody = GetComponent<Rigidbody>(); /*assign rigidbody*/
            Time.timeScale = 1.0f;
        }
        // Start is called before the first frame update
        void Start()
        { 
            r_rigidbody = GetComponent<Rigidbody>(); /*assign rigidbody*/
            ResetValues();
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
            /*if (r_rigidbody.position.y > border direction_dec == 2 ^ direction_dec == 0)
        {
          Debug.Log(true);  
        }*/
        
            if (r_rigidbody.position.y > border & direction_dec < 2 ^ r_rigidbody.position.y < border & direction_dec >=2)
            {
                ResetValues();
            
                if (direction_dec == 0)
                {
                    direction.x = -direction.x;
                    startposition.x = -startposition.x;
                    gameObject.GetComponent<Image>().rectTransform.rotation = Quaternion.Euler(0, 0, -90);
                    direction_dec++;
                }
            
                else if (direction_dec == 1)
                {
                    direction = new Vector3(-direction.x, -direction.y, 0);
                    startposition = new Vector3(-startposition.x, -startposition.y, 0);
                    gameObject.GetComponent<Image>().rectTransform.rotation = Quaternion.Euler(0, 0, -180);
                    border = -border;
                    direction_dec++;
                }
            
                else if (direction_dec == 2)
                {
                    direction.y = -direction.y;
                    startposition.y = -startposition.y;
                    gameObject.GetComponent<Image>().rectTransform.rotation = Quaternion.Euler(0, 0, 90);
                    border = -border;
                    direction_dec++;
                }

                else
                {
                    direction_dec = 0;
                    gameObject.GetComponent<Image>().rectTransform.rotation = Quaternion.Euler(0, 0, 0);
                }

                gameObject.GetComponent<Image>().rectTransform.anchoredPosition3D = startposition; /*reset image*/
            }
        }

        void ResetValues()
        {
            startposition = (new Vector3(1440f, -1080f, 0));
            direction = new Vector3(-1.0f, 1.0f, 0.0f); /*set direction*/
            border=cam.ScreenToWorldPoint(new Vector3(0,2160,0)).y;
        }
    }
}