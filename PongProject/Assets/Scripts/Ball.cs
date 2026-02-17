using UnityEngine;

public class Ball : MonoBehaviour
{
    public MyVec2 velocity;
    public float speed = 5.0f;

    void Start()
    {
        //Initial launch
        velocity = new MyVec2(1.0f, 0.5f);

        //Normalize direction and scale
        velocity = NativeMath.Vector2Normalize(velocity);
        velocity = NativeMath.Vector2Scale(velocity, speed);
    }

    void Update()
    {
        // Get Current Position 
        MyVec2 currentPos = new MyVec2(transform.position.x, transform.position.y);

        //Calculate new position
        MyVec2 frameVelocity = NativeMath.Vector2Scale(velocity, Time.deltaTime);
        MyVec2 newPos = NativeMath.Vector2Add(currentPos, frameVelocity);

        // Update Position
        transform.position = new UnityEngine.Vector3(newPos.x, newPos.y, 0);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        //Receive normal from Unity collision and convert to MyVec2
        Vector2 unityNormal = collision.contacts[0].normal;
        MyVec2 normal = new MyVec2(unityNormal.x, unityNormal.y);
        velocity = NativeMath.Vector2Reflect(velocity, normal);

        //Increase speed slightly on each bounce
        velocity = NativeMath.Vector2Scale(velocity, 1.02f);
    }
}
