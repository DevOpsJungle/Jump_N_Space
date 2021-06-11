using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunks : MonoBehaviour
{
    public GameObject chunk_start;
    public GameObject chunk_01;
    public GameObject chunk_02;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(chunk_start, new Vector3(-16, -8, 0), Quaternion.identity);
        Instantiate(chunk_02, new Vector3(16, -8, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
