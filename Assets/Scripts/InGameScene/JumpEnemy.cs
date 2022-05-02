using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using DG.Tweening;

namespace InGameScene.Enemy
{
    public class JumpEnemy : BaseEnemy
    {
        [SerializeField]
        private GroundChecker grChk;

        [SerializeField]
        private Collider2D hitCollider;

        [SerializeField]
        private BoxCollider2D groundCollider;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        //[SerializeField] private float jumpVelocity = 13f;
        [SerializeField] private float gravityScale = 3f;

        // 設置判定許容値。プレイヤーと地面までの距離は完全に0にならない。大きすぎると明らかに地面に接地していないのに接地判定されるので注意
        [SerializeField] private float onGroundOffset = 0.01f;

        private Rigidbody2D rb;
        
        protected override void Initialize()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = gravityScale;
        }

        void Update()
        {
            if (IsOnGround())
            {
                rb.velocity = new Vector2(0, 20f);
            }
        }

        private bool IsOnGround()
        {
            if (grChk.distanceFromGround <= onGroundOffset && rb.velocity.y <= 0) 
            {
                return true;
            }

            return false;
        }

        protected override void Dead()
        {
            hitCollider.enabled = false;
            groundCollider.enabled = false;
            grChk.enabled = false;

            DeadAnimation();
            Destroy(gameObject, 3f);
        }

        private void DeadAnimation()
        {
            rb.velocity = new Vector2(10, 10);
        }
    }
}
