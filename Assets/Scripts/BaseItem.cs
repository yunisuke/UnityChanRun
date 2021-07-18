using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    [SerializeField]
    private SEType hitSe;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Player") return;
        SoundManager.Instance.PlaySE(hitSe);
        ItemEffect();
    }

    protected abstract void ItemEffect();
}
