using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public Animator animatior;


    public Vector3 pos;
    public float velocity;
    private readonly float anim_rotation_speed = 0.5f;
    private readonly float max_velocity = 3f;


    // Start is called before the first frame update
    private void Start()
    {
        animatior = gameObject.GetComponent<Animator>();
        pos = gameObject.GetComponent<Transform>().position;

        velocity = Random.Range(-max_velocity, max_velocity);

        if (velocity > 0)
        {
            animatior.speed = velocity * anim_rotation_speed;
            animatior.SetFloat("rotation", -1);
        }
        else
        {
            animatior.speed = velocity * -anim_rotation_speed;
            animatior.SetFloat("rotation", 1);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //transform.position = pos + CameraView.GetScreenPos() - GameController.GetStartPos();
        transform.position = transform.position + new Vector3(velocity * Time.fixedDeltaTime, 0, 0);
    }
}