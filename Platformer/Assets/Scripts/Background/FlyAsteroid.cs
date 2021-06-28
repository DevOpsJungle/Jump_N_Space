using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FlyAsteroid : MonoBehaviour
{
    private Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = CameraView.GetCamera();
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = ScreenViewport.GetScreenPos();
        transform.position = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, -cam.transform.position.z));
    }
}
