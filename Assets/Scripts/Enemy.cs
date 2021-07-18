using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseItem
{
    protected override void ItemEffect()
    {
        Destroy(gameObject);
    }
}
