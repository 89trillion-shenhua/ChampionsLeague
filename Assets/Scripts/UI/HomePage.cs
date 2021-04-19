using UnityEngine;

public class HomePage : MonoBehaviour
{
    [SerializeField] private RewardDialog _rewardDialog;
    [SerializeField] private RewardPanel _rewardPanel;

    private void Awake()
    {
        _rewardPanel.Init();
    }

    public void CheckRankClick()
    {
        _rewardDialog.gameObject.SetActive(true);
    }

    public void AddPointsClick()
    {
        int addPoints = 200;
        PlayerInfo.Instance.AddPoints(addPoints);
        Debug.LogError(PlayerInfo.Instance.Points);
    }

    public void SeasonRefreshClick()
    {
        SeasonInfo.Instance.RefreshSeason();
        PlayerInfo.Instance.OnSeasonChanged(SeasonInfo.Instance.SeasonId);
        _rewardPanel.Refresh();
    }
}
