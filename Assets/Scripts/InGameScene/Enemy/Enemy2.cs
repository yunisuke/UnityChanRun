using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using DG.Tweening;

namespace InGameScene.Enemy
{
    public class Enemy2 : BaseItem
    {
        [SerializeField]
        private Sprite damageSprite;

        [SerializeField]
        private BoxCollider2D hitCollider;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private Rigidbody2D rb;
        
        protected override void Initialize()
        {
            rb = GetComponent<Rigidbody2D>();
            transform.DOMoveY(transform.position.y + 3f, 1f).SetLoops(-1, LoopType.Yoyo).SetLink(gameObject);
        }

        private bool front;
        private bool back;
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
            //rb.velocity = new Vector2(10, 10);
            //spriteRenderer.sprite = damageSprite;
            //hitCollider.enabled = false;

            //GetComponent<Animator>().SetTrigger("DamageTrigger"); 
            Destroy(gameObject);
        }
    }
}
