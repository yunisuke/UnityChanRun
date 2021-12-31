using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace InGameScene
{
    public class StageController : MonoBehaviour
    {
        [SerializeField] private Stage mainStage;
        [SerializeField] private Stage backgroundStage;

        [SerializeField] private int speedLevel;
        [SerializeField ]private float[] MapSpeeds = {0.1f, 0.15f, 0.2f, 0.25f, 0.3f, 0.35f};
        private readonly int MaXSpeedLevel = 5;

        void Awake()
        {
            StartCoroutine(SpeedUpCoroutine());
            SetStageSpeed(MapSpeeds[speedLevel]);
        }

        int count = 0;
        private IEnumerator SpeedUpCoroutine()
        {
            while(true)
            {
                count++;
                if (count > 1000 && speedLevel < MaXSpeedLevel)
                {
                    UpSpeedLevel();
                    count = 0;
                }
                yield return null;
            }
        }

        private void UpSpeedLevel()
        {
            speedLevel++;
            SetStageSpeed(MapSpeeds[speedLevel]);
            InGameManager.Instance.UpdateSpeedLevel(speedLevel);
            Debug.Log("スピードアップ！");
        }

        private void SetStageSpeed(float speed)
        {
            mainStage.SetSpeed(speed);
            backgroundStage.SetSpeed(speed / 5f);
        }
    }
}
