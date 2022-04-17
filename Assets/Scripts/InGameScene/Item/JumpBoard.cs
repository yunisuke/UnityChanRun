using UnityEngine;
using Manager;

namespace InGameScene.Item
{
    public class JumpBoard : BaseItem
    {
        protected override void ItemEffect(Collider2D col)
        {
            var player = InGameManager.Instance.GetPlayer();
            player.Up();
        }
    }
}
