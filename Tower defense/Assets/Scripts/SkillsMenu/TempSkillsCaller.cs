using UnityEngine;
using UnityEngine.UI;

public class TempSkillsCaller : MonoBehaviour
{

    public void CallAddDamage(UnitStats unit, int value, int duration)
    {
        StartCoroutine(unit.AddTemporarilyDamage(value, duration));
    }

    public void CallAddMoney(int value, int duration)
    {
        StartCoroutine(PlayerSettings.instance.AddTempMoney(value, duration));
    }

    public void CallBuyCooldown(SkillsMenuEl skillEl, Button button)
    {
        StartCoroutine(skillEl.BuyCooldown(button));
    }
}
