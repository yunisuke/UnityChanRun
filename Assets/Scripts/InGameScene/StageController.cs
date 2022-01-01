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
            StartCoroutine("SpeedUpCoroutine");
            SetStageSpeed(MapSpeeds[speedLevel]);
        }

        private IEnumerator SpeedUpCoroutine()
        {
            int counter = 0;
            while(true)
            {
                counter++;
                if (counter > 1000 && speedLevel < MaXSpeedLevel)
                {
                    UpSpeedLevel();
                    counter = 0;
                }
                yield return null;
            }
        }

        private IEnumerator GameOverCoroutine()
        {
            int counter = 0;
            const int StopFrameCount = 100;
            while(counter < StopFrameCount)
            {
                counter++;
                SetStageSpeed(MapSpeeds[speedLevel] * (StopFrameCount - counter)/StopFrameCount);
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

        public void GameOver()
        {
            StopCoroutine("SpeedUpCoroutine");
            StartCoroutine("GameOverCoroutine");
        }
    }
}
