using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenspace : MonoBehaviour
{
    public static Vector3 ScreenReference()
    {
        Vector3 vec = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,Camera.main.transform.position.z));
        return vec;
    }
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
