using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscore : MonoBehaviour
{
    public Vector3 start_pos;
    public Vector3 player_pos;
    public float highscore;
    public float distance;
    public float last_distance;
    
    
    // Start is called before the first frame update
    void Start()
    {
        start_pos = GameController.GetStartPos();
        player_pos = PlayerController.GetPlayerPos();
    }

    // Update is called once per frame
    void Update()
    {
        player_pos = PlayerController.GetPlayerPos();
        
        if (highscore <= distance)
        {
            last_distance = distance;
        }
        
        distance = Vector3.Distance(new Vector3(0, player_pos.x, 0), new Vector3(0, start_pos.x, 0));
        
        if (distance > last_distance)
        {
            highscore = distance;
        }

    }
}
