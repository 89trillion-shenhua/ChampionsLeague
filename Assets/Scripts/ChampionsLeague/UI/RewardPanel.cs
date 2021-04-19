using System.Collections.Generic;
using UnityEngine;

public class RewardPanel : MonoBehaviour
{
    [SerializeField] private RewardItem _rewardItem;
    [SerializeField] private GameObject content;

    private List<RewardItem> _rewardItems = new List<RewardItem>();
    private List<int> rewardPoints = new List<int>();

    public void Init()
    {
        int start = SeasonInfo.MINRewardPoints;
        int end = SeasonInfo.MAXRewardPoints;
        for (int i = start; i <= end; i += 200)
        {
            _rewardItems.Add(_rewardItem);
            rewardPoints.Add(i);
        }

        for (int i = 0; i < rewardPoints.Count; i ++)
        {
            _rewardItems[i].SetData(rewardPoints[i]);
            RewardItem item = Instantiate(_rewardItems[i], content.transform);
            item.SetEvent();
        }
    }

    public void Refresh()
    {
        int rewardItemCount = content.transform.childCount;
        for (int i = rewardItemCount - 1; i >= 0; i--)
        {
            Destroy(content.transform.GetChild(i).gameObject);
        }
        
        for (int i = 0; i < rewardPoints.Count; i ++)
        {
            _rewardItems[i].SetData(rewardPoints[i]);
            RewardItem item = Instantiate(_rewardItems[i], content.transform);
            item.SetEvent();
        }
    }
}