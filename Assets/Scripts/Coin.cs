using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : BaseItem
{
    protected override void ItemEffect()
    {
        Destroy(gameObject);
    }
}
