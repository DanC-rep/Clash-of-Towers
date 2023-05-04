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

    [SerializeField] private int money;

    public void AddMoney(int addMoney)
    {
        money += addMoney;
    }

    public int GetMoney()
    {
        return money;
    }


    public void DecreaseMoney(int decreaseMoney)
    {
        if (money - decreaseMoney >= 0)
        {
            money -= decreaseMoney;
        }
    }
}
