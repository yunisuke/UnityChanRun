using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

public class Coin : BaseItem
{
    protected override void ItemEffect(Player player)
    {
        Destroy(gameObject);
        InGameManager.Instance.AddScore(100);
    }
}
