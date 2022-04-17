using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using DG.Tweening;

namespace InGameScene.Enemy
{
    public class RunEnemy : BaseItem
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
            //tweener = spriteRenderer.transform.DOLocalRotate(new Vector3(0, 0, 360f), 3f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        }

        void Update()
        {
            rb.velocity = new Vector2(-3f, rb.velocity.y);
        }

        protected override void ItemEffect(Collider2D col)
        {
            var player = InGameManager.Instance.GetPlayer();

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
