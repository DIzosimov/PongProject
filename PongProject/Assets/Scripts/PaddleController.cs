using UnityEngine;
public class PaddleController : MonoBehaviour
{
    public string inputAxis;
    public float speed = 10f;
    void Update()
    {
        float input = Input.GetAxisRaw(inputAxis);
        MyVec2 currentPos = new MyVec2(transform.position.x, transform.position.y);
        MyVec2 direction = new MyVec2(0, input);

        // Scale Displacement
        MyVec2 displacement = NativeMath.Vector2Scale(direction, speed * Time.deltaTime);

        //Add Displacement to Current Position
        MyVec2 newPos = NativeMath.Vector2Add(currentPos, displacement);

        // Clamp Y to Play Area
        float clampedY = NativeMath.MathClamp(newPos.y, -4.4f, 4.4f);

        // Update Position
        transform.position = new UnityEngine.Vector3(newPos.x, clampedY, 0);
    }
}
