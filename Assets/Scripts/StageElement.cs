using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageElement : MonoBehaviour
{
    [SerializeField] private RectTransform enemyContainer;

    private RectTransform rectTransform;

    public Vector3 LocalPosition 
    {
        get {return rectTransform.localPosition;}
        set {rectTransform.localPosition = value;}
    }

    public RectTransform EnemyContainer
    {
        get {return enemyContainer;}
    }

    public void SetSpeed(float speed)
    {
        // rb.velocity = new Vector2(-speed, 0);
        // Debug.Log("set speed!" + speed);
    }
    
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        // rb = GetComponent<Rigidbody2D>();
    }

    public void ClearEnemys()
    {
        foreach (Transform tr in enemyContainer.transform)
        {
            Destroy(tr.gameObject);
        }
    }
}
