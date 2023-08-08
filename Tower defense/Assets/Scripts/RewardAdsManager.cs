using YG;
using UnityEngine;

public class RewardAdsManager : MonoBehaviour
{
    [SerializeField] private YandexGame sdk;
    [SerializeField] private int diamonds;

    public void AdButton()
    {
        sdk._RewardedShow(1);
    }

    public void AddDiamonds()
    {
        PlayerSettings.instance.AddDiamonds(diamonds);
        GlobalEventManager.SendAdRewarded();
    }
}
