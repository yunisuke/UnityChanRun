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
        [SerializeField] private Text scoreText;

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
            if (IsTapScreen()) TapScreenEvent();
        }

        public void GameOver()
        {
            state = GameState.GameOver;
            pl.GameOver();
            gameOverObj.SetActive(true);
        }

        int score = 0;
        public void AddScore(int score)
        {
            this.score += score;
            scoreText.text = this.score.ToString();
        }

        public bool IsTapScreen()
        {
            // キーボード操作
            if (Input.GetMouseButtonDown(0)) return true;

            return false;
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
    }
}
