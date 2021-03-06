using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using DG.Tweening;

namespace InGameScene.Enemy
{
    public class StayEnemy : BaseEnemy
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

        protected override void Dead()
        {
            hitCollider.enabled = false;
            groundCollider.enabled = false;

            DeadAnimation();
            Destroy(gameObject, 3f);
        }

        private void DeadAnimation()
        {
            rb.velocity = new Vector2(10, 10);
        }
    }
}
