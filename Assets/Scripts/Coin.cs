using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : BaseItem
{
    public override void ItemEffect()
    {
        Destroy(gameObject);
    }
}
