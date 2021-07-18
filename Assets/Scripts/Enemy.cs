using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseItem
{
    [SerializeField]
    private Sprite damageSprite;


    private SpriteRenderer sr;
    private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }


    protected override void ItemEffect()
    {
        rb.velocity = new Vector2(10, 20);
        sr.sprite = damageSprite;
    }
}
