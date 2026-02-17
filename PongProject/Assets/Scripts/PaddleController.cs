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
        MyVec2 displacement = NativeMath.Vector2Scale(direction, speed * Time.deltaTime);
        MyVec2 newPos = NativeMath.Vector2Add(currentPos, displacement);
        transform.position = new UnityEngine.Vector3(newPos.x, newPos.y, 0);
    }
}
