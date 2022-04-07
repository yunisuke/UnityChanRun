using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using DG.Tweening;

namespace InGameScene.Enemy
{
    public class StayEnemy : BaseItem
    {
        [SerializeField]
        private Collider2D hitCollider;

        [SerializeField]
        private BoxCollider2D groundCollider;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private Rigidbody2D rb;
        private Tweener tweener;
        
        protected override void Initialize()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        protected override void ItemEffect(Player player)
        {
            if (player.IsOnGround())
            {
                // 地上で接敵するとゲームオーバー
                InGameManager.Instance.GameOver();
            }
            else
            {
                // 空中で接敵すると撃破
                player.DefeatEnemy();
                Dead();
                InGameManager.Instance.AddScore(1000);
            }
        }

        private void Dead()
        {
            rb.velocity = new Vector2(10, 10);
            hitCollider.enabled = false;
            groundCollider.enabled = false;

            DeadAnimation();
            Destroy(gameObject, 3f);
        }

        private void DeadAnimation()
        {
            tweener.Kill();
        }
    }
}
