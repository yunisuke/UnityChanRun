using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoard : BaseItem
{
    protected override void ItemEffect(Player player)
    {
        player.Up();
    }
}
