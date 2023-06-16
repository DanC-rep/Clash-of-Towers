using UnityEngine;

public class UISounds : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;

    private void Start()
    {
        GlobalEventManager.OnUIClicked.AddListener(PlayClickSound);
    }

    private void PlayClickSound()
    {
        clickSound.Play();
    }
}
