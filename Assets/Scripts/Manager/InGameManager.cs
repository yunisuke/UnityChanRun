using InGameScene;

namespace Manager
{
    public class InGameManager
    {
        private static InGameManager _instance;

        private InGameSceneScript scr;

        private InGameManager () {
        }

        public static InGameManager Instance {get {
            if (_instance == null) _instance = new InGameManager ();
            return _instance;
        }}

        public void Initialize (InGameSceneScript scr) {
            this.scr = scr;
        }

        public void GameOver()
        {
            scr.GameOver();
        }

        public void AddScore(int score)
        {
            scr.AddScore(score);
        }

        public void UpdateSpeedLevel(int speedLevel)
        {
            scr.UpdateSpeedLevelText(speedLevel);
        }

        public Player GetPlayer()
        {
            return scr.Player;
        }
    }
}
