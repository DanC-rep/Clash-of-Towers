using System.Collections;
using UnityEngine;

public class Effects : MonoBehaviour
{
    [SerializeField] private GameObject damageEffect;
    [SerializeField] private Transform instancePoint;
    [SerializeField] private float timeToDestroyEffect;
    private void DamageEffect()
    {
        StartCoroutine(EffectCoroutine());
    }

    IEnumerator EffectCoroutine()
    {
        GameObject effect = Instantiate(damageEffect, instancePoint);
        yield return new WaitForSeconds(timeToDestroyEffect);
        Destroy(effect);
    }
}
