using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FlyAsteroid : MonoBehaviour
{
    private Camera cam;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        cam = CameraView.GetCamera();
        pos = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = ScreenViewport.GetScreenPos();
        transform.position = pos + cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, -cam.transform.position.z));
    }
}
