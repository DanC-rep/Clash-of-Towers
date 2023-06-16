using UnityEngine;

public class UnitSounds : MonoBehaviour
{
    [SerializeField] private AudioSource hitSound;

    private void Start()
    {
        GlobalEventManager.OnUnitDamaged.AddListener(PlayHitSound);
    }

    private void PlayHitSound()
    {
        hitSound.Play();
    }
}
