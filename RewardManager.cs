using UnityEngine;
using UnityEngine.UI;

public class RewardManager : MonoBehaviour
{
    [Header("Daily Reward")]
    public static int rewardCoins = 5; 
    public Button rewardButton;
    public Text rewardamount;
    public Text rewardText; 
    private string lastRewardTimeKey = "LastRewardTime";
    private int rewardInterval = 24 * 60 * 60;

    [Header("First Reward")]
    public static bool firstClaim = false;
    public GameObject firstReward;

    private void Start()
    {
        MetaMaskManager.Getvalue("reward_time");
        MetaMaskManager.Getvalue("reward");
        MetaMaskManager.Getvalue("firstclaim");
        UpdateRewardStatus();
    }

    private void Update()
    {
        UpdateRewardStatus();
        if(firstClaim == true)
        {
            firstReward.SetActive(false);
        }
        rewardamount.text = $"+{rewardCoins}";
    }

    private void UpdateRewardStatus()
    {
        if (PlayerPrefs.HasKey(lastRewardTimeKey))
        {
            long lastRewardTime = PlayerPrefs.GetInt(lastRewardTimeKey);
            long currentTime = GetCurrentUnixTimestamp();

            long timeSinceLastReward = currentTime - lastRewardTime;

            if (timeSinceLastReward >= rewardInterval)
            {
                // Можно получить награду
                rewardButton.interactable = true;
                rewardText.text = "get reward";
            }
            else
            {
                // Время до следующей награды
                long timeRemaining = rewardInterval - timeSinceLastReward;
                UpdateRewardText(timeRemaining);

                // Устанавливаем кнопку неактивной
                rewardButton.interactable = false;
            }
        }
        else
        {
            // Первый запуск игры или время награды не установлено
            rewardButton.interactable = true;
            rewardText.text = "get reward";
        }
    }

    public async void OnRewardButtonClicked()
    {
        var success = await MetaMaskManager.dailyclaim();
        if (success)
        {
            rewardButton.interactable = false;
            long currentTime = GetCurrentUnixTimestamp();
            PlayerPrefs.SetInt(lastRewardTimeKey, (int)currentTime);
            PlayerPrefs.Save();
        }
    }

    public void Getfirstreward()
    {
        MetaMaskManager.firstclaim();
        //firstClaim = true;
    }
    private void UpdateRewardText(long timeRemaining)
    {
        if (timeRemaining <= 0)
        {
            rewardText.text = "Get Daily Reward";
        }
        else
        {
            int hours = Mathf.FloorToInt(timeRemaining / 3600);
            int minutes = Mathf.FloorToInt((timeRemaining % 3600) / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);

            rewardText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        }
    }

    private long GetCurrentUnixTimestamp()
    {
        return (long)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalSeconds;
    }
}