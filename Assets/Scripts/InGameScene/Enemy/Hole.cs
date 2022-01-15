using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace InGameScene.Enemy
{
    public class Hole : BaseItem
    {
        protected override void ItemEffect(Player player)
        {
            // 穴に落ちるとゲームオーバー
            InGameManager.Instance.GameOver();
        }
    }
}
