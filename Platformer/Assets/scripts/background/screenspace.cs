using UnityEngine;

public class ScreenSpace : MonoBehaviour
{/*
    public Vector3 screen_ref;
    public Vector3 screen_upd;

    public static Vector3 screen;
    public Vector3 ins_screen;
    

    public static Vector3 edge_left;
    public Vector3 ins_edge_left;
    public static Vector3 edge_right;
    public Vector3 ins_edge_right;

    public Camera cam;
    
    public static Vector3 ScreenReference()
    {
        Vector3 vec = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        return vec;
    }

    public static Vector3 ScreenUpdate()
    {
        Vector3 vec = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        return vec;
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        screen_ref = ScreenReference();
    }

    // Update is called once per frame
    void Update()
    {
        screen_upd = ScreenUpdate();

        screen.x = (screen_upd.x - screen_ref.x);
        
        edge_left.x = (screen.x + screen_ref.x);
        edge_right.x = (screen.x - screen_ref.x);

        ins_edge_left = edge_left;
        ins_edge_right = edge_right;
        ins_screen = screen;

    }*/
}
