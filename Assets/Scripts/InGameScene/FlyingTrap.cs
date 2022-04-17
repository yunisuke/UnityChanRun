using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using DG.Tweening;

namespace InGameScene.Enemy
{
    public class FlyingTrap : BaseItem
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
        private GameObject alertArrowObj;

        private Rigidbody2D rb;
        private Tweener tweener;
        
        protected override void Initialize()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.isKinematic = true;
            rb.velocity = new Vector2(-2f, 0);

            cencer.OnTriggerEnterEvent += InstantiateAlertObj;
        }

        private void InstantiateAlertObj(Collider2D col)
        {
            if (col.tag != "Player") return;
            var obj = Instantiate(alertArrowObj, new Vector3(9, transform.position.y, 0f), Quaternion.identity);
            Destroy(obj, 1.5f);
        }

        protected override void ItemEffect(Collider2D col)
        {
            // 地上で接敵するとゲームオーバー
            InGameManager.Instance.GameOver();
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
