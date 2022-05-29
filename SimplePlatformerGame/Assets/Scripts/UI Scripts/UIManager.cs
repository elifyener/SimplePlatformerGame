using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Image HealthImage;
    public TextMeshProUGUI CoinText;

    public GameObject WinScreen;
    public GameObject LoseScreen;

    private void Start()
    {
        SetGameSpeed(1f);
    }

    public void SetGameSpeed(float gameSpeed)
    {
        Time.timeScale = gameSpeed;
    }

    public void UpdateHealthImage(float FillAmount)
    {
        HealthImage.fillAmount = FillAmount;
    }

    public void UpdateCoinText(int CoinAmount)
    {
        CoinText.text = CoinAmount.ToString();
    }

    public void OpenWinScreen()
    {
        WinScreen.SetActive(true);
        SetGameSpeed(0f);
    }

    public void OpenLoseScreen()
    {
        LoseScreen.SetActive(true);
        SetGameSpeed(0f);
    }
}
