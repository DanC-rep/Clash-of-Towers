using UnityEngine;

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
}
