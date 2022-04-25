using UnityEngine;
using Manager;

namespace InGameScene.Item
{
    public class PullItem : BaseItem
    {
        protected override void ItemEffect(Collider2D col)
        {
            InGameManager.Instance.EnablePullItemEffect();
            Destroy(gameObject);
        }
    }
}
