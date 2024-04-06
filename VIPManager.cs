using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class VIPManager : MonoBehaviour
{
    public Button VIP1Button;
    public Button VIP2Button;
    public Button VIP3Button;
    public Text VIP1Text;
    public Text VIP2Text;
    public Text VIP3Text;
    private string buyvipTimeKey = "VIPTime";
    private int buyInterval = 30 * 24 * 60 * 60;
    public static int user_viplevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        MetaMaskManager.Getvalue("viplevel");
        MetaMaskManager.Getvalue("vip_time"); 
    }

    // Update is called once per frame
    void Update()
    {
        UpdateVIPStatus();
        
    }

    public async void OnVIP1ButtonClicked()
    {
        var success = await MetaMaskManager.buyvip(1, 30000000000000000);
        if (success == true)
        {
            MetaMaskManager.Getvalue("viplevel");
            VIP1Button.interactable = false;
            long currentTime = GetCurrentUnixTimestamp();
            PlayerPrefs.SetInt(buyvipTimeKey, (int)currentTime);
            PlayerPrefs.Save();

        }
    }

    public async void OnVIP2ButtonClicked()
    {
        var success = await MetaMaskManager.buyvip(2, 60000000000000000);
        if(success == true)
        {
            MetaMaskManager.Getvalue("viplevel");
            VIP2Button.interactable = false;
            long currentTime = GetCurrentUnixTimestamp();
            PlayerPrefs.SetInt(buyvipTimeKey, (int)currentTime);
            PlayerPrefs.Save();

        }
    }

    public async void OnVIP3ButtonClicked()
    {
        var success = await MetaMaskManager.buyvip(3, 90000000000000000);
        if(success==true)
        {
            MetaMaskManager.Getvalue("viplevel");
            VIP3Button.interactable = false;
            long currentTime = GetCurrentUnixTimestamp();
            PlayerPrefs.SetInt(buyvipTimeKey, (int)currentTime);
            PlayerPrefs.Save();

        }
    }

    private void UpdateVIPStatus()
    {
        if (user_viplevel == 1)
        {
            long lastbuy1Time = PlayerPrefs.GetInt(buyvipTimeKey);
            long currentTime = GetCurrentUnixTimestamp();

            long timeSinceLast1 = currentTime - lastbuy1Time;
            long timeRemaining = buyInterval - timeSinceLast1;

            VIP1Button.interactable = false;

            if (timeRemaining <= 0)
            {
                VIP1Text.text = "Get VIP1";
                VIP1Button.interactable = true;
            }
            else
            {
                int days = Mathf.FloorToInt(timeRemaining / 86400);
                int hours = Mathf.FloorToInt((timeRemaining % 86400)/3600);
                int minutes = Mathf.FloorToInt((timeRemaining % 3600) / 60);
                int seconds = Mathf.FloorToInt(timeRemaining % 60);

                VIP1Text.text = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", days, hours, minutes, seconds);
            }
        }
        else
        {
            VIP1Button.interactable = true;
            VIP1Text.text = "Get VIP1";
        }
        if (user_viplevel == 2)
        {
            long lastbuy2Time = PlayerPrefs.GetInt(buyvipTimeKey);
            long currentTime = GetCurrentUnixTimestamp();

            long timeSinceLast2 = currentTime - lastbuy2Time;
            long timeRemaining = buyInterval - timeSinceLast2;

            VIP2Button.interactable = false;

            if (timeRemaining <= 0)
            {
                VIP2Text.text = "Get VIP2";
                VIP2Button.interactable = true;
            }
            else
            {
                int days = Mathf.FloorToInt(timeRemaining / 86400);
                int hours = Mathf.FloorToInt((timeRemaining % 86400) / 3600);
                int minutes = Mathf.FloorToInt((timeRemaining % 3600) / 60);
                int seconds = Mathf.FloorToInt(timeRemaining % 60);

                VIP2Text.text = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", days, hours, minutes, seconds);
            }
        }
        else
        {
            VIP2Button.interactable = true;
            VIP2Text.text = "Get VIP2";
        }
        if (user_viplevel == 3)
        {
            long lastbuy3Time = PlayerPrefs.GetInt(buyvipTimeKey);
            long currentTime = GetCurrentUnixTimestamp();

            long timeSinceLast3 = currentTime - lastbuy3Time;
            long timeRemaining = buyInterval - timeSinceLast3;

            VIP3Button.interactable = false;

            if (timeRemaining <= 0)
            {
                VIP3Text.text = "Get VIP3";
                VIP3Button.interactable = true;
            }
            else
            {
                int days = Mathf.FloorToInt(timeRemaining / 86400);
                int hours = Mathf.FloorToInt((timeRemaining % 86400) / 3600);
                int minutes = Mathf.FloorToInt((timeRemaining % 3600) / 60);
                int seconds = Mathf.FloorToInt(timeRemaining % 60);

                VIP3Text.text = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", days, hours, minutes, seconds);
            }
        }
        else
        {
            VIP3Button.interactable = true;
            VIP3Text.text = "Get VIP3";
        }


    }

    private long GetCurrentUnixTimestamp()
    {
        return (long)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalSeconds;
    }

}
