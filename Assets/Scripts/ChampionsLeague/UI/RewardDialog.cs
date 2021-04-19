using UnityEngine;

public class RewardDialog : MonoBehaviour
{
    [SerializeField] private RewardDialog _rewardDialog;
    [SerializeField] private RewardPanel _rewardPanel;

    private void Awake()
    {
        _rewardPanel.Refresh();
    }

    public void OnCloseClick()
    {
        _rewardDialog.gameObject.SetActive(false);
    }
}
