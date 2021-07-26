
using UnityEngine;



public class AsteroidMovement : MonoBehaviour
{
    public Animator animatior;
    private float anim_rotation_speed = 0.5f;
    
    
    public Vector3 pos;
    public float velocity;
    private float max_velocity = 3f;

    

    // Start is called before the first frame update
    void Start()
    {
        animatior = gameObject.GetComponent<Animator>();
        pos = gameObject.GetComponent<Transform>().position;

        velocity = Random.Range(-max_velocity,max_velocity);

        if (velocity > 0)
        {
            animatior.speed = velocity * anim_rotation_speed;
            animatior.SetFloat("rotation",-1);
        }
        else
        {
            animatior.speed = velocity * -anim_rotation_speed;
            animatior.SetFloat("rotation",1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = pos + CameraView.GetScreenPos() - GameController.GetStartPos();
        transform.position = transform.position + new Vector3(velocity * Time.fixedDeltaTime,0,0) ;
    }
}