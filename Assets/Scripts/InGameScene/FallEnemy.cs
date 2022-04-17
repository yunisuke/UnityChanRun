using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using DG.Tweening;

namespace InGameScene.Enemy
{
    public class FallEnemy : BaseEnemy
    {
        [SerializeField]
        private Collider2D hitCollider;

        [SerializeField]
        private BoxCollider2D groundCollider;

        [SerializeField]
        private HitChecker cencer;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        [SerializeField]
        private Sprite fallSprite;

        private Rigidbody2D rb;
        private Tweener tweener;
        private SpriteRenderer sp;
        
        protected override void Initialize()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.isKinematic = true;
            sp = GetComponentInChildren<SpriteRenderer>();
            cencer.OnTriggerEnterEvent += Fall;
        }

        private void Fall(Collider2D col)
        {
            if (col.tag != "Player") return;

            sp.sprite = fallSprite;
            rb.isKinematic = false;
            rb.velocity = new Vector2(0, -20f);
        }

        protected override void Dead()
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
