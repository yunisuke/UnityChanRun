using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Manager;
using TMPro;

public class Fukidashi : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro tmp;

    public UnityAction afterCountdownCallback;

    void Awake()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        var count = 3;
        while(count > 0)
        {
            PlayVoice(count);

            tmp.text = count.ToString();
            count--;
            yield return new WaitForSecondsRealtime(1.0f);
        }
        afterCountdownCallback.Invoke();
        GameObject.Destroy(this.gameObject);
    }

    private void PlayVoice(int count)
    {
        switch (count)
        {
            case 1:
                SoundManager.Instance.PlayVoice(VoiceType.One);
                break;
            case 2:
                SoundManager.Instance.PlayVoice(VoiceType.Two);
                break;
            case 3:
                SoundManager.Instance.PlayVoice(VoiceType.Three);
                break;
        }

    }
}
