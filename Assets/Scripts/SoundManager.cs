using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoundManager
{
    private static SoundManager _instance;

    // BGM
    private List<AudioClip> bgmList = new List<AudioClip>();

    // SE
    private List<AudioClip> seList = new List<AudioClip>();

    // Voice
    private List<AudioClip> voiceList = new List<AudioClip>();

    private AudioSource bgmAudio = new AudioSource ();
    private AudioSource seAudio = new AudioSource ();
    private AudioSource voiceAudio = new AudioSource ();

    private SoundManager () {

    }

    public static SoundManager Instance {get {
        if (_instance == null) _instance = new SoundManager ();
        return _instance;
    }}

    public void Initialize () {
        if (bgmAudio == null) {
            var obj = new GameObject("Sound");
            GameObject.DontDestroyOnLoad(obj);
            bgmAudio = obj.AddComponent<AudioSource>();
            bgmAudio.loop = true;

            seAudio = obj.AddComponent<AudioSource>();
            voiceAudio = obj.AddComponent<AudioSource>();
            //obj.AddComponent<AudioListener>();
        }

        bgmList = Resources.LoadAll<AudioClip> ("BGM").ToList();
        seList = Resources.LoadAll<AudioClip> ("SE").ToList ();
        voiceList = Resources.LoadAll<AudioClip> ("Voice").ToList ();
    }

    public void PlayBGM (BGMType bgm_type)
    {
        var bgm = bgmList.Find (x => x.name == BGM_Names[(int)bgm_type]);
        if (bgm == null) return;

        bgmAudio.clip = bgm;
        bgmAudio.Play();
    }

    public void SetBGMVolume (float volume)
    {
        bgmAudio.volume = volume;
    }

    public void PlaySE (SEType se_type) {
        var se = seList.Find (x => x.name == SE_Names[(int)se_type]);
        if (se == null) return;

        seAudio.PlayOneShot (se);
    }

    public void PlayVoice (VoiceType voice_type) {
        var voice = voiceList.Find (x => x.name == Voice_Names[(int)voice_type]);
        if (voice == null) return;

        voiceAudio.PlayOneShot(voice);
    }

    private readonly string[] BGM_Names = {
        "Main"
    };

    private readonly string[] SE_Names = {
        "Jump",
        "Coin",
        "Attack",
        "laser2",
    };

    private readonly string[] Voice_Names = {
        "univ0001",
        "univ0002",
        "univ1254",
        "univ1094",
        "univ1016",
        "univ1256"
    };
}

public enum BGMType {
    Main = 0,
}

public enum SEType {
    Jump,
    Coin,
    Attack,
    Shot,
}

public enum VoiceType {
    Jump,
    JumpOneMore,
    Attack,
    Damage,
    GameStart,
    HighJump,
}
