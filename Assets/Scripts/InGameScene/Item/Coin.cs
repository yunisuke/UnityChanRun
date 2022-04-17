using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace InGameScene.Item
{
    public class Coin : BaseItem
    {
        protected override void ItemEffect(Collider2D col)
        {
            var player = InGameManager.Instance.GetPlayer();

            Destroy(gameObject);
            InGameManager.Instance.AddScore(100);
            player.AppearGetItemEffect();
        }
    }
}
