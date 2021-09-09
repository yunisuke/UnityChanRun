using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleSceneScript : MonoBehaviour
{
    void Start()
    {
        FPSManager.Instance.Initialize ();
        SoundManager.Instance.Initialize ();
    }

    public void OnClickStartButton()
    {
        SoundManager.Instance.PlayVoice(VoiceType.GameStart);
        SceneManager.LoadScene("SampleScene");
    }
}
