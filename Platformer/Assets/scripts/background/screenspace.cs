using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenspace : MonoBehaviour
{
    private Vector3 screenref;
    private Vector3 screenupd;
    
    public static Vector3 screen;

    public static Vector3 edgeleft;
    public static Vector3 edgeright;
    

    public static Vector3 ScreenReference()
    {
        Vector3 vec = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        return vec;
    }

    public static Vector3 ScreenUpdate()
    {
        Vector3 vec = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        return vec;
    }

    // Start is called before the first frame update
    void Start()
    {
        screenref = ScreenReference();
    }

    // Update is called once per frame
    void Update()
    {
        screenupd = ScreenUpdate();

        screen.x = (screenupd.x - screenref.x);
        
        edgeleft.x = (screen.x + screenref.x);
        edgeright.x = (screen.x - screenref.x);
        
        
    }
}
