/*
 * Script: Highscore
 * Author: Felix Schneider
 * Last Change: 29.07.21
 * highscore calculation
 */


using UnityEngine;

public class Highscore : MonoBehaviour
{
    private Vector3 start_pos;
    private Vector3 player_pos;
    
    private static float highscore;
    private float distance;
    private float last_distance;

    private void Awake()
    {
        start_pos = GameController.GetStartPos();
        player_pos = PlayerController.GetPlayerPos();
    }

    // Start is called before the first frame update
    private void Start()
    {
        player_pos = PlayerController.GetPlayerPos();
    }

    // Update is called once per frame
    private void Update()
    {
        player_pos = PlayerController.GetPlayerPos();
        
        if (highscore <= distance)
        {
            last_distance = distance;
        }
        
        //distance = Vector3.Distance(new Vector3(player_pos.x,0 ,0), Vector3.zero);
        distance = PlayerController.GetPlayerPos().x;

        if (distance > last_distance)
        {
            highscore = distance;
        }
    }
    
    public static float GetHighscore()
    {
        return highscore;
    }
}
