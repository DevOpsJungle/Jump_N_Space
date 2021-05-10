using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{

    public GameObject player;

    public float speed = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float interpolation = speed * Time.deltaTime;
        
        Vector3 position = this.transform.position;
        position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x, interpolation);
        
        this.transform.position = position;
    }
}
