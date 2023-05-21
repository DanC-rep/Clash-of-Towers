using System;
using UnityEngine.Events;

public class GlobalEventManager
{
    public static UnityEvent OnEnemyKilled = new UnityEvent();
    public static UnityEvent OnPurchaseUnit = new UnityEvent();
    public static UnityEvent OnMoneyAddedPerTime = new UnityEvent();
    public static UnityEvent<string> OnTowerDestroy = new UnityEvent<string>();
    public static UnityEvent OnStatUpgraded = new UnityEvent();
    public static UnityEvent OnPurchaseUnitDiamonds = new UnityEvent();


    public static void SendEnemyKilled()
    {
        OnEnemyKilled.Invoke();
    }

    public static void SendPurchaseUnit()
    {
        OnPurchaseUnit.Invoke();
    }

    public static void SendMoneyAddedPerTime()
    {
        OnMoneyAddedPerTime.Invoke();
    }

    public static void SendTowerDestroy(string towerName)
    {
        OnTowerDestroy.Invoke(towerName);
    }

    public static void SendStatUpgraded()
    {
        OnStatUpgraded.Invoke();
    }

    public static void SendUnitPurchaseDiamonds()
    {
        OnPurchaseUnitDiamonds.Invoke();
    }
}
