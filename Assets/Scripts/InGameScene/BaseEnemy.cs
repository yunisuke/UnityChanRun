using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace InGameScene
{
    public abstract class BaseEnemy : BaseItem
    {
        [SerializeField]
        private GameObject hitEffectObj;

        [SerializeField]
        private int Score = 100;

        [SerializeField]
        private float defeatJumpSpeed = 13f;

        protected override void ItemEffect(Collider2D col)
        {
            ContactEnemy(col);
        }

        protected virtual void ContactEnemy(Collider2D col)
        {
            var pl = InGameManager.Instance.GetPlayer();

            if (pl.IsOnGround())
            {
                // 地上で接敵するとゲームオーバー
                InGameManager.Instance.GameOver();
            }
            else
            {
                // 空中で接敵すると撃破
                pl.DefeatEnemy(defeatJumpSpeed);
                AppearHitEffect(col);
                Dead();
                InGameManager.Instance.AddScore(Score);
            }
        }

        protected virtual void AppearHitEffect(Collider2D col)
        {
            var obj = Instantiate(hitEffectObj);
            obj.transform.position = new Vector2(col.transform.position.x + 1f, col.transform.position.y);
            Destroy(obj, 2f);
        }

        protected abstract void Dead();
    }
}
