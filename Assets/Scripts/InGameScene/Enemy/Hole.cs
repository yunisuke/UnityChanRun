using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace InGameScene.Enemy
{
    public class Hole : BaseItem
    {
        protected override void ItemEffect(Collider2D col)
        {
            // 穴に落ちるとゲームオーバー
            InGameManager.Instance.GameOver();
        }
    }
}
