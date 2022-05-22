using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Manager;
using TMPro;

namespace InGameScene
{
    public class InGameSceneScript : MonoBehaviour
    {
        [SerializeField] private Player pl;
        [SerializeField] private GameObject gameOverObj;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private Text speedLevelText;
        [SerializeField] private StageController stgCntrl;

        [SerializeField] private GameObject pauseScreenObj;
        [SerializeField] private GameObject filterScreenObj;
        [SerializeField] private ResultScreen resultScreenScr;

        [SerializeField] private Fukidashi fkPrefab;

        private enum GameState
        {
            BeforeGame,
            InGame,
            GameOver,
            Pause,
        }
        private GameState state;

        public Player Player
        {
            get {
                return pl;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            state = GameState.InGame;

            FPSManager.Instance.Initialize ();
            SoundManager.Instance.Initialize ();
            InGameManager.Instance.Initialize (this);
            SoundManager.Instance.PlayBGM(BGMType.InGame);
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
            stgCntrl.GameOver();

            StartCoroutine(GameOverWait());
        }

        private IEnumerator GameOverWait()
        {
            yield return new WaitForSeconds(1.0f);
            resultScreenScr.GameOver(score);
            AdManager.Instance.ShowAds();
        }

        int score = 0;
        public void AddScore(int score)
        {
            this.score += score;
            scoreText.text = this.score.ToString("N0");
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
            if (state == GameState.GameOver || state == GameState.Pause) return;
            //SoundManager.Instance.PlayVoice(VoiceType.Pause);

            Time.timeScale = 0f;
            pauseScreenObj.SetActive(true);

            state = GameState.Pause;
        }

        public void OnClickStartButton()
        {
            pauseScreenObj.SetActive(false);
            filterScreenObj.SetActive(true);

            var fk = Instantiate(fkPrefab);
            fk.transform.position = new Vector3(pl.transform.position.x + 2.1f, pl.transform.position.y + 1f);
            fk.afterCountdownCallback = RestartGame;
        }

        public void OnClickStopGameButton()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("TitleScene");
        }

        private void RestartGame()
        {
            Time.timeScale = 1;
            filterScreenObj.SetActive(false);

            state = GameState.InGame;
        }

        public void EnablePullItemEffect()
        {
            StartCoroutine(PullItemEffect());
        }

        private IEnumerator PullItemEffect()
        {
            pl.SetActivePullItemCollider(true);
            yield return new WaitForSeconds(5);
            pl.SetActivePullItemCollider(false);
        }
    }
}
