using UnityEngine;

public class Mover : MonoBehaviour
{

    bool isMoving = true;

    public void StopMoving() => isMoving = false;

    public void StartMoving() => isMoving = true;

    public void Move(Vector3 direction, float speed)
    {
        if (!isMoving) return;

        transform.Translate(direction * speed * Time.deltaTime);

    }


    public void MoveTowards(Vector2 target, float speed)
    {
        if (!isMoving) return;
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
