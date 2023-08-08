using UnityEngine;

public class SkillsSounds : MonoBehaviour
{
    [SerializeField] private AudioSource[] skillSounds;

    private void Start()
    {
        GlobalEventManager.OnPurchaseSkill.AddListener(PlaySkillSound);
    }

    private void PlaySkillSound(string skillName)
    {
        if (skillName == "AddHealth")
        {
            skillSounds[0].Play();
        }
        else if (skillName == "AddTowerHealth")
        {
            skillSounds[1].Play();
        }
        else if (skillName == "AddDamage")
        {
            skillSounds[2].Play();
        }
        else if (skillName == "AddMoney")
        {
            skillSounds[3].Play();
        }
    }
}
