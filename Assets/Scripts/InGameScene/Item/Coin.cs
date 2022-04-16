using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace InGameScene.Item
{
    public class Coin : BaseItem
    {
        protected override void ItemEffect(Player player)
        {
            Destroy(gameObject);
            InGameManager.Instance.AddScore(100);
            player.AppearGetItemEffect();
        }
    }
}
