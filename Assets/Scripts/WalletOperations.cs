using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WalletOperations : SingletonBase<WalletOperations>
{
    /// <summary>
    /// ����� ���������� �����
    /// </summary>
    [SerializeField] private int walletMoney;
    /// <summary>
    /// ������
    /// </summary>
    [SerializeField] private int bet;
    public int Bet => bet;
    /// <summary>
    /// ����� ������ ���������� �����
    /// </summary>
    [SerializeField] private Text walletMoneyTxt;
    /// <summary>
    /// ����� ������
    /// </summary>
    [SerializeField] private Text betTxt;
    [Header("Set In Dinamycally")]
    /// <summary>
    /// ���������� ����� �� ������
    /// </summary>
    [SerializeField] private static int walletMoneyStart;
   
    public static bool win;

    private void Start()
    {
        win = Result();
      if(win)
        {
            walletMoney = PlayerPrefs.GetInt("General wallet") + PlayerPrefs.GetInt("BetBonus") * 2;
        }
        else
        {
            walletMoney = PlayerPrefs.GetInt("General wallet") - PlayerPrefs.GetInt("BetBonus");

        }
      if(walletMoney < 50)
        {
            walletMoney = 50;
        }
        walletMoneyStart = walletMoney;

        bet = 50;
        betTxt.text = "Distance " + bet;

        walletMoneyTxt.text = "$ " + walletMoney.ToString();
    }
    public void MinusBet()
    {
        if (bet > 0)
        {
            bet -= 25;
            walletMoney += 25;
        }
        betTxt.text = "Distance " + bet;
        walletMoneyTxt.text = "$ " + walletMoney.ToString();
        AudioManager.Instance.AudioPlay("UI");
    }
    public void PlusBet()
    {
        if (bet < walletMoney || walletMoney > 0)
        {
            bet += 25;
            walletMoney -= 25;
        }
        betTxt.text = "Distance " + bet;
        walletMoneyTxt.text = "$ " + walletMoney.ToString();
        AudioManager.Instance.AudioPlay("UI");
    }
    public void BetScore()
    {
        if (bet > 26)
        {
            PlayerPrefs.SetInt("BetBonus", bet);

            PlayerPrefs.SetInt("General wallet", walletMoney);
            SceneController.Instance.SceneLoading("Game");
        }
        else
        {
            betTxt.text = "Increase the distance!";
        }
        AudioManager.Instance.AudioPlay("UI");
    }
    public bool Result()
    {
        if(PlayerPrefs.GetInt("BetBonus") <= PlayerPrefs.GetInt("Distance"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}