using System.Data;
using ChampionsLeague.Data;
using ChampionsLeague.UI;
using UnityEngine;
using Utils;

namespace UI
{
    public class HomePage : MonoBehaviour
    {
        [SerializeField] private RewardDialog rewardDialog;

        private int _seasonId;
        private DataTable _dt;

        private void Awake()
        {
            _dt = CSVHelper.CsvToDataTable("Assets/CSV/SeasonRewardData.csv", 1);
            PlayerPrefs.HasKey("seasonId");
            _seasonId = PlayerPrefs.GetInt("seasonId", 0);
            PlayerPrefs.HasKey("playerPoints");
            PlayerInfo.Instance.InitPoints();
        }

        private void OnDestroy()
        {
            PlayerPrefs.Save();
        }

        public void CheckRankClick()
        {
            RewardDialog newDialog = Instantiate(rewardDialog, transform);
            newDialog.Init(_dt);
            newDialog.gameObject.SetActive(true);
        }

        public void AddPointsClick()
        {
            int addPoints = 200;
            PlayerInfo.Instance.AddPoints(addPoints);
            PlayerInfo.Instance.ShowPoints();
        }

        public void SeasonRefreshClick()
        {
            _seasonId += 1;
            PlayerPrefs.SetInt("seasonId",_seasonId);
            PlayerInfo.Instance.OnSeasonChanged();
        }
    }
}
