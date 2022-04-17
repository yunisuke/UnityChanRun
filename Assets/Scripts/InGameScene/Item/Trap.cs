using UnityEngine;
using Manager;

namespace InGameScene.Item
{
    public class Trap : BaseItem
    {
        protected override void ItemEffect(Collider2D col)
        {
            InGameManager.Instance.GameOver();
        }
    }
}
