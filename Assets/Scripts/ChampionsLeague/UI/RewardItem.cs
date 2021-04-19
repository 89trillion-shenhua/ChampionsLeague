using UnityEngine;
using UnityEngine.UI;
using System;

public class RewardItem : MonoBehaviour
{
    [SerializeField] private Text rewardPoints;
    [SerializeField] private Text coinsReward;
    [SerializeField] private Text rankReward;
    [SerializeField] private Button claimBtn;
    [SerializeField] private Image claimedImg;

    private Action OnClaimEvent;

    public void SetData(int points)
    {
        rewardPoints.text = points.ToString();
        if (points % 1000 == 0)
        {
            rankReward.text = points + "Rank";
            coinsReward.gameObject.SetActive(false);
            rankReward.gameObject.SetActive(true);
            claimBtn.gameObject.SetActive(false);
        }
        else
        {
            coinsReward.gameObject.SetActive(true);
            rankReward.gameObject.SetActive(false);
            claimBtn.gameObject.SetActive(true);
        }
    }

    public void SetEvent()
    {
        this.OnClaimEvent = () =>
        {
            if (PlayerInfo.Instance.Points >= Convert.ToInt32(this.rewardPoints.text))
            {
                this.claimBtn.gameObject.SetActive(false);
                this.claimedImg.gameObject.SetActive(true);
            }
        };
    }
    
    public void OnCliamClick()
    {
        OnClaimEvent?.Invoke();
    }
}