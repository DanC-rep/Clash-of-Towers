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
    [SerializeField] private int timeToWaitMoney;

    private float moneyPerTime;
    private float moneyPerSec;

    private int diamonds;

    private void Start()
    {
        moneyPerSec = moneyPerTime / timeToWaitMoney;

        GlobalEventManager.OnTimerEnded.AddListener(AddMoneyPerTimeCall);

        diamonds = PlayerPrefs.GetInt("diamonds", 0);
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
        PlayerPrefs.SetInt("diamonds", diamonds);
    }

    public int GetDiamonds()
    {
        return PlayerPrefs.GetInt("diamonds", 0);
    }

    public float GetMoneyPerSec()
    {
        return moneyPerSec;
    }

    public void SetMoneyPerTime(float _moneyPerTime)
    {
        moneyPerTime = _moneyPerTime;
    }

    public void DecreaseDiamonds(int decreaseDiamonds)
    {
        if (diamonds - decreaseDiamonds >= 0)
        {
            diamonds -= decreaseDiamonds;
            PlayerPrefs.SetInt("diamonds", diamonds);
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

    public void AddMoneyPerTimeCall()
    {
        InvokeRepeating("AddMoneyPerTime", 0, timeToWaitMoney);
    }

    public float GetMoneyPerTime()
    {
        return moneyPerTime;
    }
}
