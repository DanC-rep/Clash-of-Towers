using UnityEngine;

public class Decoration : MonoBehaviour
{
    [SerializeField] private protected Transform startPoint;
    [SerializeField] private protected Transform endPoint;
    [SerializeField] private protected float speed;

    private protected virtual void Move()
    {
        if (transform.position.x >= endPoint.position.x)
        {
            transform.position = new Vector3(startPoint.position.x, transform.position.y, 0f);
        }

        transform.position += Vector3.right * speed / 2 * Time.deltaTime;
    }

}
