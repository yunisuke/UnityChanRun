using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] private StageElement[] stageElements;
    [SerializeField] private Transform pos;

    [SerializeField] private GameObject coins;
    [SerializeField] private GameObject enemys;
    [SerializeField] private float stageSpeed;
    private float stageOffset;

    [SerializeField] private bool isBackground = false;

    void Awake()
    {
        var tmp = stageElements[0];
        stageOffset = stageElements.Length * tmp.gameObject.GetComponent<RectTransform>().sizeDelta.x;
    }

    void Start()
    {
        foreach(var el in stageElements) el.SetSpeed(stageSpeed);
    }

    void Update()
    {
        MoveStage();
    }

    public void SetStageSpeed(float stageSpeed)
    {
        this.stageSpeed = stageSpeed;
        foreach(var stage in stageElements) stage.SetSpeed(stageSpeed);
    }

    private void MoveStage()
    {
        for(int i=0; i<stageElements.Length; i++)
        {
            var el = stageElements[i];
            el.LocalPosition = new Vector2(el.LocalPosition.x - stageSpeed, el.LocalPosition.y);
            if (el.LocalPosition.x < -40) {
                el.LocalPosition = new Vector2(el.LocalPosition.x + stageOffset, el.LocalPosition.y);
                el.SetSpeed(stageSpeed);
                if (isBackground == false) InstantiateObject(el);
            }
        }
    }

    private void InstantiateObject(StageElement el)
    {
        el.ClearEnemys();

        Instantiate(enemys, el.EnemyContainer);
    }
}
