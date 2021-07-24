/*
 * Script: GameController
 * Author: Felix Schneider
 * Last Change: 24.07.21
 * Global variable for instantiating a Game Session
 */

using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool game_is_paused;
    
    public Vector3 start_pos;
    private static Vector3 start_pos_s;

    public Vector3 player_pos;

    public float highscore;
    
    
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");
        if (objs.Length > 1)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject); 
        
        game_is_paused = false;
        
        start_pos_s = start_pos;
        player_pos = PlayerController.GetPlayerPos();
    }
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player_pos = PlayerController.GetPlayerPos();
        highscore = Vector3.Distance(new Vector3(0, player_pos.x, 0), new Vector3(0, start_pos.x, 0));
    }

    public static void TimeStop()
    {
        Time.timeScale = 0f;
        game_is_paused = true;
    } 
    public static void TimeStart()
    {
        Time.timeScale = 1f;
        game_is_paused = false;
    }
    
    public static Vector3 GetStartPos()
    {
        return start_pos_s;
    }
}
