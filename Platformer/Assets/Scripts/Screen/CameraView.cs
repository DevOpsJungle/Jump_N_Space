/*
 * Script: Camera View
 * Author: Felix Schneider
 * Last Change: 10.06.21
 * Sets Camera to the position of the player
 */


using UnityEngine;

public class CameraView : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private static Vector3 cam_pos;

    private void Awake()
    {
        cam = GameObject.Find("CameraPlayer").GetComponent<Camera>();   /* Finds the GameObject CameraPlayer with the Component Camera */
    }

    // Start is called before the first frame update
    void Start()
    {
        SetCamera();
        GetCameraPos();
    }

    // LateUpdate is called after Update
    void Update()
    {
        SetCamera();        /* Has to be set because player moves every frame */
        GetCameraPos();
    }

    private void SetCamera()
    {
        var player_pos = PlayerController.GetPlayerPos();
        var camera_pos = cam.transform;
        camera_pos.position = new Vector3(player_pos.x, player_pos.y, camera_pos.position.z);       /* Camera follows Player exactly */
    }
    
    private void GetCameraPos()
    {
        cam_pos = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, - cam.transform.position.z));
    }
    
    public static Camera GetCamera()
    {
        return Camera.main;
    }
    
    public static Vector3 GetScreenPos()
    {
        return cam_pos;
    }
}
