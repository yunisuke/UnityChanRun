using Manager;

namespace InGameScene.Item
{
    public class Trap : BaseItem
    {
        protected override void ItemEffect(Player player)
        {
            InGameManager.Instance.GameOver();
        }
    }
}
