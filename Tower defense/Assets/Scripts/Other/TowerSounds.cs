using UnityEngine;

public class TowerSounds : MonoBehaviour
{
    [SerializeField] private AudioSource destroySound;
    [SerializeField] private AudioSource hitSound;

    private void Start()
    {
        GlobalEventManager.OnTowerDamaged.AddListener(PlayHitSound);
    }

    private void PlayDestroySound()
    {
        destroySound.Play();
    }

    private void PlayHitSound()
    {
        hitSound.Play();
    }
}
