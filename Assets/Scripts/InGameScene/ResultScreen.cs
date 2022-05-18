using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;
using Manager;
using UnityEngine.SceneManagement;

public class ResultScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button okButton;

    void Update()
    {
        if (isMoveScene) SceneManager.LoadScene("InGameScene");
    }

    public void GameOver(int score)
    {
        gameObject.SetActive(true);
        StartCoroutine(Effect(score));
    }

    private IEnumerator Effect(int score)
    {
        int digit = (int)Math.Floor(Math.Log10(score) + 1);
        var total = "";
        for (int i=1; i<=digit; i++)
        {
            yield return EffectNum(total, digit);

            var val = GetPointDigit(score, i);
            total = val + total;
            Debug.Log(total);
        }
        scoreText.text = score.ToString("N0");
        Debug.Log(score);
    }

    private IEnumerator EffectNum(string value, int digit)
    {
        for(int i=0; i<4; i++)
        {
            for(int j=1; j<=9; j++)
            {
                var tmp = j + value;
                Debug.Log(int.Parse(tmp).ToString("N0"));
                scoreText.text = int.Parse(tmp).ToString("N0");
                yield return null;
            }
        }
    }

    private int GetPointDigit(int num, int digit)
    {
        return (int)(num / Math.Pow(10, digit - 1)) % 10;
    }

    public void OnClickOkButton()
    {
        AdManager.Instance.HideAds();
        AdManager.Instance.ShowIntersitialAd(NextGame);
    }

    private bool isMoveScene = false;
    private void NextGame(object sender, EventArgs args)
    {
        isMoveScene = true;
    }

    public void OnClickTweetButton()
    {
        Application.OpenURL("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL("テキスト #hashtag"));
    }
}
