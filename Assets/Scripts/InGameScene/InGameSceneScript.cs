using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Manager;

namespace InGameScene
{
    public class InGameSceneScript : MonoBehaviour
    {
        [SerializeField] private Player pl;
        [SerializeField] private GameObject gameOverObj;
        [SerializeField] private ImageNo scoreText;
        [SerializeField] private Text speedLevelText;
        [SerializeField] private StageController stgCntrl;

        [SerializeField] private GameObject pauseScreenObj;
        [SerializeField] private GameObject filterScreenObj;

        [SerializeField] private Fukidashi fkPrefab;

        private enum GameState
        {
            BeforeGame,
            InGame,
            GameOver,
        }
        private GameState state;

        // Start is called before the first frame update
        void Start()
        {
            state = GameState.InGame;

            FPSManager.Instance.Initialize ();
            SoundManager.Instance.Initialize ();
            InGameManager.Instance.Initialize (this);
            //SoundManager.Instance.PlayBGM(BGMType.Main);
        }

        // Update is called once per frame
        void Update()
        {
            //if (IsTapScreen()) TapScreenEvent();
        }

        public void GameOver()
        {
            state = GameState.GameOver;
            pl.GameOver();
            gameOverObj.SetActive(true);
            stgCntrl.GameOver();
        }

        int score = 0;
        public void AddScore(int score)
        {
            this.score += score;
            scoreText.SetNo(this.score);
        }

        public void UpdateSpeedLevelText(int speedLevel)
        {
            speedLevelText.text = speedLevel.ToString();
        }

        public bool IsTapScreen()
        {
            // キーボード操作
            if (Input.GetMouseButtonDown(0)) return true;

            return false;
        }

        public void OnClickScreen()
        {
            TapScreenEvent();
        }

        private void TapScreenEvent()
        {
            switch(state)
            {
                case GameState.BeforeGame:
                    break;
                case GameState.InGame:
                    pl.Jump();
                    break;
                case GameState.GameOver:
                    SceneManager.LoadScene("InGameScene");
                    break;
            }
        }

        void OnApplicationFocus(bool isFocus)
        {
            if (isFocus == false)
            {
                OnClickPauseButton();
            }
        }

        public void OnClickPauseButton()
        {
            //SoundManager.Instance.PlayVoice(VoiceType.Pause);

            Time.timeScale = 0f;
            pauseScreenObj.SetActive(true);
        }

        public void OnClickStartButton()
        {
            pauseScreenObj.SetActive(false);
            filterScreenObj.SetActive(true);

            var fk = Instantiate(fkPrefab);
            fk.transform.position = new Vector3(pl.transform.position.x + 2.1f, pl.transform.position.y + 1f);
            fk.afterCountdownCallback = RestartGame;
        }

        private void RestartGame()
        {
            Time.timeScale = 1;
            filterScreenObj.SetActive(false);
        }
    }
}
