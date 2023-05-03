using UnityEngine;

public class ThrowerController : UnitController
{
    [SerializeField] private GameObject spell;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spellSpeed;

    private bool useSpell;

    public void UseSpell()
    {

        useSpell = true;
    }

    private void Update()
    {
        if (target != null)
        {
            if (target.position.x > transform.position.x && useSpell)
            {
                GameObject newSpell = Instantiate(spell, spawnPoint.position, spawnPoint.rotation, gameObject.transform);
                newSpell.GetComponent<Rigidbody2D>().velocity = Vector2.right * spellSpeed * Time.deltaTime;
                useSpell = false;
            }
            else if (target.position.x < transform.position.x && useSpell && target != null)
            {
                GameObject newSpell = Instantiate(spell, spawnPoint.position, spawnPoint.rotation, gameObject.transform);
                newSpell.GetComponent<Rigidbody2D>().velocity = Vector2.left * spellSpeed * Time.deltaTime;
                useSpell = false;
            }
        }
    }
}
