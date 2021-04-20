using System;
using ChampionsLeague.Data;
using UnityEngine;
using UnityEngine.UI;

namespace ChampionsLeague.UI
{
    public class RewardItem : MonoBehaviour
    {
        [SerializeField] private Text rewardPoints;
        [SerializeField] private Text coinsReward;
        [SerializeField] private Text rankReward;
        [SerializeField] private Button claimBtn;
        [SerializeField] private Image claimedImg;

        private Action _onClaimEvent;

        public void SetData(RewardData rewardData)
        {
            rewardPoints.text = rewardData.Point.ToString();
            if (rewardData.Point % 1000 == 0)
            {
                rankReward.text = rewardData.RewardType;
                coinsReward.gameObject.SetActive(false);
                rankReward.gameObject.SetActive(true);
                claimBtn.gameObject.SetActive(false);
                claimedImg.gameObject.SetActive(false);
            }
            else
            {
                coinsReward.text = rewardData.RewardType;
                coinsReward.gameObject.SetActive(true);
                rankReward.gameObject.SetActive(false);
                claimBtn.gameObject.SetActive(true);
                claimedImg.gameObject.SetActive(false);
            }
        }

        public void SetClaimedStatus(RewardData rewardData)
        {
            if (PlayerInfo.Instance.RewardAlreadyClaimed(rewardData.Point)  && rewardData.Point % 1000 != 0)
            {
                claimBtn.gameObject.SetActive(false);
                claimedImg.gameObject.SetActive(true);
            }
            else if (rewardData.Point % 1000 == 0)
            {
                claimBtn.gameObject.SetActive(false);
                claimedImg.gameObject.SetActive(false);
            }
            else
            {
                claimBtn.gameObject.SetActive(true);
                claimedImg.gameObject.SetActive(false);
            }
        }

        public void SetEvent()
        {
            _onClaimEvent = () =>
            {
                if (PlayerInfo.Instance.GetPoints() >= Convert.ToInt32(rewardPoints.text) 
                    && PlayerInfo.Instance.RewardAlreadyClaimed(Convert.ToInt32(rewardPoints.text)) == false)
                {
                    claimBtn.gameObject.SetActive(false);
                    claimedImg.gameObject.SetActive(true);
                    PlayerInfo.Instance.ClaimedStatusChanged(Convert.ToInt32(rewardPoints.text));
                }
            };
        }
    
        public void OnCliamClick()
        {
            _onClaimEvent?.Invoke();
        }
    }
}