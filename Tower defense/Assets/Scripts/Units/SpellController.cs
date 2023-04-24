using UnityEngine;

public class SpellController : MonoBehaviour
{
    [SerializeField] UnitController unitController;

    [SerializeField] private GameObject spell;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    public void UseSpell()
    {
        Instantiate(spell, spawnPoint);

        if (unitController.target.position.x > transform.position.x)
        {
            rb.velocity = Vector3.right * speed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            rb.velocity = Vector3.left * speed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
