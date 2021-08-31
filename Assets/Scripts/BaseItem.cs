using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    [SerializeField]
    private SEType hitSe;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Bullet") return;
        SoundManager.Instance.PlaySE(hitSe);
        ItemEffect();
    }

    public abstract void ItemEffect();
}
