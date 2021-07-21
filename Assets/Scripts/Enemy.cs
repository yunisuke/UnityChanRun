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

    private bool front;
    private bool back;
    protected override void ItemEffect()
    {
        rb.velocity = new Vector2(10, 20);
        sr.sprite = damageSprite;
        GetComponent<BoxCollider2D>().enabled = false;
        int rnd = Random.Range(0, 3);
        if (rnd == 0) front = true;
        if (rnd == 1) back = true; 
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        if (front)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.15f);
        }

        if (back)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.15f);
            sr.sortingOrder = -1;
        }
    }
}
