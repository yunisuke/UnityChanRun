using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseItem
{
    [SerializeField]
    private Sprite damageSprite;

    [SerializeField]
    private BoxCollider2D hitCollider;

    [SerializeField]
    private BoxCollider2D groundCollider;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private bool front;
    private bool back;
    public override void ItemEffect()
    {
        rb.velocity = new Vector2(10, 10);
        spriteRenderer.sprite = damageSprite;
        hitCollider.enabled = false;
        groundCollider.enabled = false;

        GetComponent<Animator>().SetTrigger("DamageTrigger"); 
        Destroy(gameObject, 3f);
    }

}
