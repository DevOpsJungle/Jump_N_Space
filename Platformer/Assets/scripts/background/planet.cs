using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet : screenspace
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(screen.x+5,2 , 0);
    }
}
