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
    [SerializeField] private GameObject death;
    private GameObject player_instance;
    
    
    public float falldeath;     //0 is bottom of start chunk
    
    public EdgeCollider2D deathwall;    //just to visualize
    public float edgedeath;
    private float last_edgedeath;
    private float diff;


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
        if (!GameController.game_is_paused)
        {
            if (player_instance.transform.position.y < falldeath || player_instance.transform.position.x < edgedeath)
            {
                GameController.TimeStop();
                Destroy(player_instance);
                death.SetActive(true);
            }
        }
        
        
        //Deathwall
        FunktionDeathwall();
        SetDeathwall();
    }

    private void SetDeathwall()
    {
        Vector2 point_1 = new Vector2(edgedeath, 10);
        Vector2 point_2 = new Vector2(edgedeath, -10);
                
        Vector2 [] pointArray = new Vector2[] {point_1,point_2,point_1};
        
        deathwall.points = pointArray;
    }

    private void FunktionDeathwall()
    {
        diff = edgedeath - last_edgedeath;
        last_edgedeath = edgedeath;
        if (diff < 0.025f)
        {
            edgedeath = Exponential(edgedeath);
            
        }
        else
        {
            edgedeath = edgedeath + 0.025f;
        }
    }
    private float Exponential(float i)
    {
        {
            i = i + 1.0f + Time.deltaTime * 0.05f * i;
            return i - 1.0f;
        }
    }
}
