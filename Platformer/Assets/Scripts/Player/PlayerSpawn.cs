/*
 * Script: PlayerSpwan
 * Author: Felix Schneider
 * Last Change: 24.07.21
 * Handles Spawn and Death of the player
 */



using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private GameObject player_instance;
    
    public float falldeath;     //0 is bottom of start chunk
    
    public EdgeCollider2D deathwall;    //just to visualize
    [SerializeField] private float diff;
    public static float edgedeath;
    private float last_edgedeath;
    
    private float linear_speed = 0.0125f;


    void Awake()
    { 
        player_instance = Instantiate(player,GameController.GetStartPos(), Quaternion.identity, transform);
        deathwall = GetComponentInChildren<EdgeCollider2D>();
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        edgedeath = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (player_instance.transform.position.y < falldeath || player_instance.transform.position.x < edgedeath)
        {
            Destroy(player_instance);
            SceneManager.LoadScene("game.scene");
        }
        
        //Deathwall
        FunktionDeathwall();
        SetDeathwall();
    }

    private void SetDeathwall()
    {
        Vector2 point_1 = new Vector2(edgedeath, 100);
        Vector2 point_2 = new Vector2(edgedeath, -100);
                
        Vector2 [] pointArray = new Vector2[] {point_1,point_2,point_1};
        
        deathwall.points = pointArray;
    }

    private void FunktionDeathwall()
    {
        if (diff < linear_speed)
        {
            last_edgedeath = edgedeath;
            edgedeath = Exponential(edgedeath);
            diff = edgedeath - last_edgedeath;
        }
        else
        {
            edgedeath = edgedeath + linear_speed;
            diff = linear_speed;
        }
    }
    private float Exponential(float i)
    {
        {
            if (GameController.game_is_paused)
            {
                return i;
            }
            else
            {
               i = i + Time.fixedDeltaTime * 0.05f * i;
               return i;
            }
        }
    }
}
