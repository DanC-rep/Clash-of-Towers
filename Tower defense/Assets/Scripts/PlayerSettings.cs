using System;
using System.Collections;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    #region Singleton
    public static PlayerSettings instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    #endregion

    [SerializeField] private float money;
    [SerializeField] private int diamonds;

    [SerializeField] private float moneyPerTime;
    [SerializeField] private int timeToWaitMoney;
    [SerializeField] private int startTimeToGetMoneySpawn;

    private float moneyPerSec;

    private void Start()
    {
        InvokeRepeating("AddMoneyPerTime", startTimeToGetMoneySpawn, timeToWaitMoney);

        moneyPerSec = moneyPerTime / timeToWaitMoney;
    }

    public void AddMoney(float addMoney)
    {
        money = (float)Math.Round(money + addMoney, 2);
    }

    public float GetMoney()
    {
        return money;
    }

    public void AddDiamonds(int _diamonds)
    {
        diamonds += _diamonds;
    }

    public int GetDiamonds()
    {
        return diamonds;
    }

    public float GetMoneyPerSec()
    {
        return moneyPerSec;
    }

    public void DecreaseDiamonds(int decreaseDiamonds)
    {
        if (diamonds - decreaseDiamonds >= 0)
        {
            diamonds -= decreaseDiamonds;
        }
    }


    public void DecreaseMoney(int decreaseMoney)
    {
        if (money - decreaseMoney >= 0)
        {
            money -= decreaseMoney;
        }
    }

    private void AddMoneyPerTime()
    {
        AddMoney(moneyPerTime);

        GlobalEventManager.SendMoneyAddedPerTime();
    }

    public IEnumerator AddTempMoney(int value, int duration)
    {
        moneyPerTime += value;
        moneyPerSec = moneyPerTime / timeToWaitMoney;

        yield return new WaitForSeconds(duration);

        moneyPerTime -= value;
        moneyPerSec = moneyPerTime / timeToWaitMoney;
    }
}
