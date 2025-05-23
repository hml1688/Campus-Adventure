using UnityEngine;

public class ARUIManager : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject LeaderboardPanel;
    public GameObject BadgePanel;
    public GameObject HotAreaPanel;

    // 确保开始时全部关闭
    void Start()
    {
        SettingsPanel.SetActive(false);
        LeaderboardPanel.SetActive(false);
        BadgePanel.SetActive(false);
        HotAreaPanel.SetActive(false);
    }

    // 关闭全部面板
    private void HideAllPanels()
    {
        SettingsPanel.SetActive(false);
        LeaderboardPanel.SetActive(false);
        BadgePanel.SetActive(false);
        HotAreaPanel.SetActive(false);
    }

    // 每个按钮绑定的公开函数
    public void OnSettingsButtonClicked()
    {
        HideAllPanels();
        SettingsPanel.SetActive(true);
    }

    public void OnLeaderboardButtonClicked()
    {
        HideAllPanels();
        LeaderboardPanel.SetActive(true);
    }

    public void OnBadgeButtonClicked()
    {
        HideAllPanels();
        BadgePanel.SetActive(true);
    }

    public void OnHotAreaButtonClicked()
    {
        HideAllPanels();
        HotAreaPanel.SetActive(true);
    }

    public void OnBackButtonClicked()
    {
        HideAllPanels();
    }
}
