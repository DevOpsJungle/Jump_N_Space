/*
 * Script: GameController
 * Author: Felix Schneider
 * Last Change: 24.07.21
 * Global variable for instantiating a Game Session
 */

using UnityEngine;

namespace Global
{
    public class GameController : MonoBehaviour
    {
        public static bool game_is_paused;

        [SerializeField] private Vector3 start_pos;
        private static Vector3 start_pos_s;

        private void Awake()
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");
            if (objs.Length > 1)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject); 
        
            game_is_paused = false;
        
            start_pos_s = start_pos;
        }
    
        // Start is called before the first frame update
        private void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
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
}
