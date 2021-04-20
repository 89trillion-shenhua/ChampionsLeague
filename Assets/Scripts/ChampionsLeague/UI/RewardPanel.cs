using System;
using System.Collections.Generic;
using System.Data;
using ChampionsLeague.Data;
using UnityEngine;

namespace ChampionsLeague.UI
{
    public class RewardPanel : MonoBehaviour
    {
        [SerializeField] private RewardItem rewardItem;
        [SerializeField] private GameObject content;

        private readonly List<RewardData> _rewardDatas = new List<RewardData>();

        public void Init(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i ++)
            {
                var datarow = dt.Rows[i];
                RewardData rewardData = new RewardData();
                rewardData.Point = Convert.ToInt32(datarow["points"]);
                rewardData.RewardType = datarow["rewardType"].ToString();
                _rewardDatas.Add(rewardData);
            }
        }
    
        public void CreateItems()
        {
            for (int i = 0; i < _rewardDatas.Count; i ++)
            {
                RewardItem item = Instantiate(rewardItem, content.transform);
                item.SetData(_rewardDatas[i]);
                item.SetClaimedStatus(_rewardDatas[i]);
                item.SetEvent();
            }
        }

        public void DestroyItems()
        {
            for (int i = content.gameObject.transform.childCount - 1; i >= 0; i--)
            {
                Destroy(content.gameObject.transform.GetChild(i).gameObject);
            }
        }
    }
}