using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Manager;

public class TitleSceneScript : MonoBehaviour
{
    void Start()
    {
        FPSManager.Instance.Initialize ();
        SoundManager.Instance.Initialize ();
        AdManager.Instance.Initialize();
    }

    public void OnClickStartButton()
    {
        SoundManager.Instance.PlayVoice(VoiceType.GameStart);
        SceneManager.LoadScene("InGameScene");
    }
}
