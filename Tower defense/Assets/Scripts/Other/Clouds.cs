using UnityEngine;

public class Clouds : MonoBehaviour
{
    [SerializeField] private Transform startPos;
    [SerializeField] private Transform endPos;
    [SerializeField] private int speed;

    private void Update()
    {
        if (transform.position.x >= endPos.position.x)
        {
            transform.position = startPos.position;
        }

        transform.position += Vector3.right * speed / 2 * Time.deltaTime;
    }
}

