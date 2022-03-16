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

        [Header("障害物")]
        [SerializeField] private GameObject[] enemysLevel_0;
        [SerializeField] private GameObject[] enemysLevel_1;
        [SerializeField] private GameObject[] enemysLevel_2;
        [SerializeField] private GameObject[] enemysLevel_3;
        [SerializeField] private GameObject[] enemysLevel_4;
        [SerializeField] private GameObject[] enemysLevel_5;

        [SerializeField] private int speedLevel;
        [SerializeField ]private float[] MapSpeeds = {0.1f, 0.15f, 0.2f, 0.25f, 0.3f, 0.35f};
        private readonly int MaXSpeedLevel = 5;

        [Header("デバッグ")]
        [SerializeField] private bool isLevelFixed = false;
        [SerializeField] private int initSpeedLevel = 0;

        void Awake()
        {
            mainStage.LotteryEnemy = LotteryEnemy;

            speedLevel = initSpeedLevel;
            StartCoroutine("SpeedUpCoroutine");
            SetStageSpeed(MapSpeeds[speedLevel]);
        }

        private GameObject LotteryEnemy()
        {
            var enemys = GetEnemys();
            int rand = Random.Range(0, enemys.Length);
            return enemys[rand];
        }

        private GameObject[] GetEnemys()
        {
            switch(speedLevel)
            {
                case 0:
                    return enemysLevel_0;
                case 1:
                    return enemysLevel_1;
                case 2:
                    return enemysLevel_2;
                case 3:
                    return enemysLevel_3;
                case 4:
                    return enemysLevel_4;
                case 5:
                    return enemysLevel_5;
                default:
                    return null;
            }
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
            if (isLevelFixed) return;
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
