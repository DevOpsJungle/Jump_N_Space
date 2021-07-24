/*
 * Script: ScreenViewport
 * Author: Felix Schneider
 * Last Change: 10.06.21
 * ...I am a description...
 */

using UnityEngine;

public class ScreenViewport : MonoBehaviour
{
    private EdgeCollider2D edge;
    [SerializeField] private Camera cam;     //show private attribute in inspector
    private Vector3 pos;                        //Player Position
    private static Vector3 screen_pos;            //screenpos => x, y - middle of every Viewport Axis to Worldspace
    
    
    public static float width;       
    public static float height;

    private static float edgeleft;
    private static float edgeright;
    private static float edgetop;
    private static float edgebottom;
    
    void Awake()
    {
        edge = GetComponent<EdgeCollider2D>();
        cam = CameraView.GetCamera();
        pos = PlayerController.GetPlayerPos();
        
        FindDimensions();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        FindScreenpos();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        pos = PlayerController.GetPlayerPos();
        FindScreenpos();

        FindDimensions();
        SetEdges();
        SetBoundary();

        Debug.Log(width);
        Debug.Log(height);
    }

    private void FindScreenpos()
    {
        screen_pos = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, - cam.transform.position.z));
    }

    private void FindDimensions()
    {
        width = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0) + pos).x - 0.5f);        //Viewport Transformation
        height = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0) + pos).y - 0.5f);
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

    public static Vector3 GetScreenPos()
    {
        return screen_pos;
    }
}

