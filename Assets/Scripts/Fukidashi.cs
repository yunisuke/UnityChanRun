using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Manager;

public class Fukidashi : MonoBehaviour
{
    [SerializeField]
    private Sprite[] numbers;

    [SerializeField]
    private SpriteRenderer num;

    public UnityAction afterCountdownCallback;

    void Awake()
    {
        StartCoroutine(countdown());
    }

    private IEnumerator countdown()
    {
        var count = 3;
        while(count > 0)
        {
            PlayVoice(count);

            num.sprite = numbers[count];
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
