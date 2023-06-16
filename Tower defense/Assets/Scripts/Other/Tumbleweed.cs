using UnityEngine;

public class Tumbleweed : Decoration
{
    [SerializeField] private float angle;

    private protected override void Move()
    {
        base.Move();
        transform.Rotate(Vector3.forward, angle * Time.deltaTime, Space.Self);
    }

    private void Update()
    {
        Move();
    }
}
