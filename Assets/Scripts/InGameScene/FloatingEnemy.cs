using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using DG.Tweening;

namespace InGameScene.Enemy
{
    public class FloatingEnemy : BaseEnemy
    {
        [SerializeField]
        private Collider2D hitCollider;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private Rigidbody2D rb;

        protected override void Initialize()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.isKinematic = true;
        }

        protected override void Dead()
        {
            hitCollider.enabled = false;

            DeadAnimation();
            Destroy(gameObject, 3f);
        }

        private void DeadAnimation()
        {
            rb.isKinematic = false;
            rb.velocity = new Vector2(10, 10);
        }
    }
}
