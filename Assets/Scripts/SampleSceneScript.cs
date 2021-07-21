using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FPSManager.Instance.Initialize ();
        SoundManager.Instance.Initialize ();
        //SoundManager.Instance.PlayBGM(BGMType.Main);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
