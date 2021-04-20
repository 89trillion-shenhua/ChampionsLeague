using System.Data;
using UnityEngine;

namespace ChampionsLeague.UI
{
    public class RewardDialog : MonoBehaviour
    {
        [SerializeField] private RewardDialog rewardDialog;
        [SerializeField] private RewardPanel rewardPanel;

        private DataTable _dt;

        public void Init(DataTable dt)
        {
            _dt = dt;
            rewardPanel.Init(_dt);
            rewardPanel.CreateItems();
        }

        public void OnCloseClick()
        {
            rewardDialog.gameObject.SetActive(false);
            rewardPanel.DestroyItems();
            Destroy(gameObject);
        }
    }
}