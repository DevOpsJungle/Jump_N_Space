/*
 * Script: PlayerSpwan
 * Author: Felix Schneider
 * Last Change: 01.08.21
 * Handles Spawn and Death of the player
 */


using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject death;
    private GameObject player_instance;
    
    public float falldeath;             /* 0 is bottom of start chunk */
    
    public EdgeCollider2D deathwall;    /* just to visualize */
    
    [SerializeField] private float diff;
    public static float edge_death;
    private float last_edge_death;

    [SerializeField] private float linear_speed;
    private static float lerp_speed = 1f;


    private void Awake()
    { 
        GameController.TimeStart();
        player_instance = Instantiate(player,GameController.GetStartPos(), Quaternion.identity, transform);
        deathwall = GetComponentInChildren<EdgeCollider2D>();

        
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        edge_death = 0.1f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!GameController.game_is_paused)
        {
            if (player_instance.transform.position.y < falldeath || player_instance.transform.position.x < edge_death)
            {
                GameController.TimeStop();
                death.SetActive(true);
            }
        }
        
        
        //Deathwall
        linear_speed = 3f * Time.deltaTime;
        FunktionDeathwall();
        SetDeathwall();
    }

    private void SetDeathwall()
    {
        Vector2 point_1 = new Vector2(edge_death, 100);
        Vector2 point_2 = new Vector2(edge_death, -100);
                
        Vector2 [] pointArray = new Vector2[] {point_1,point_2,point_1};
        
        deathwall.points = pointArray;
    }

    private void FunktionDeathwall()
    {
        edge_death = edge_death + linear_speed;
        
        if (PlayerController.GetPlayerPos().x - edge_death > 24f)       /* Deathwall has a rubberband effect stays tries to not let the player advance more than 24f before the Dathwall */
        {
            edge_death = Lerp(edge_death, PlayerController.GetPlayerPos().x - 24f);
            Debug.Log("Lerp");
        }
        
    }

    public static float Lerp(float last_pos, float pos)        /* lets the octopus trail behind the player on one axis */
    {
        float value;
        value = Mathf.Lerp(last_pos, pos, Time.deltaTime * lerp_speed);
        return value;
    }
}
