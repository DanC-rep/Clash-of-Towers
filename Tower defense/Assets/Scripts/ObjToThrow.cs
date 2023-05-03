using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjToThrow : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject parent = transform.parent.gameObject;

        if (parent.tag == "FirstTeam" && collision.gameObject.tag == "SecondTeam")
        {
            Destroy(gameObject);
            parent.GetComponent<UnitController>().DecreaseEnemyHP();
        }
        if (parent.tag == "SecondTeam" && collision.gameObject.tag == "FirstTeam")
        {
            Destroy(gameObject);
            parent.GetComponent<UnitController>().DecreaseEnemyHP();
        }
    }
}
