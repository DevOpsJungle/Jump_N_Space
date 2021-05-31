using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class ScreenBoundary : MonoBehaviour
{
    [SerializeField] private float width;       //show private attribute in inspector
    [SerializeField] private float height;
    
    public static float edgeleft;
    public static float edgeright;
    public static float edgetop;
    public static float edgebottom;
    
    public EdgeCollider2D edge;
    public Camera default_Camera;
    [SerializeField] private Vector3 pos;
   
    void Awake()
    {
        default_Camera = Camera.main.GetComponent<CameraView>().camera;
        edge = GetComponent<EdgeCollider2D>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        pos = CameraView.player_pos;
    }

    // Update is called once per frame
    void Update()
    {
        pos = CameraView.player_pos;
        
        FindBoundary();
        SetEdges();
        SetBoundary();
    }
    
    
    private void FindBoundary()
    {
        width = 1 / (default_Camera.WorldToViewportPoint(new Vector3(1, 1, 0) + pos).x - 0.5f);        //Viewport Transformation
        height = 1 / (default_Camera.WorldToViewportPoint(new Vector3(1, 1, 0) + pos).y - 0.5f);
    }

    private void SetEdges()                         //set edges with camera pos --> Camera Viewport defines edges
    {
        edgeleft = (-width/ 2) + pos.x;
        edgeright = (width/ 2) + pos.x;
        
        edgetop = (height / 2) + pos.y;
        edgebottom = (-height / 2) + pos.y;
    }
    
    private void SetBoundary()                      //with edgepoints boundary can be set
    {
        Vector2 point_1 = new Vector2(edgeright, edgetop);
        Vector2 point_2 = new Vector2(edgeright, edgebottom);
        Vector2 point_3 = new Vector2(edgeleft , edgebottom);
        Vector2 point_4 = new Vector2(edgeleft, edgetop);
        Vector2 [] pointArray = new Vector2[] {point_1,point_2,point_3,point_4,point_1};

        edge.points = pointArray;
    }
}

