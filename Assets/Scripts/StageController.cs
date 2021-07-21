using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] private RectTransform[] stages;
    [SerializeField] private Transform pos;

    [SerializeField] private GameObject coins;
    [SerializeField] private GameObject enemys;
    private int count = 0;

    void Update()
    {
        MoveStage();
        InstantiateObject();
    }

    private void MoveStage()
    {
        for(int i=0; i<stages.Length; i++)
        {
            var stage = stages[i];
            stage.localPosition = new Vector2(stage.localPosition.x - 0.1f, stage.localPosition.y);
            if (stage.localPosition.x < -60) {
                stage.localPosition = new Vector2(stage.localPosition.x + 75, stage.localPosition.y);
            }
        }
    }

    private void InstantiateObject()
    {
        count++;
        if (count >= 180)
        {
            float x = 0;
            RectTransform target = null;
            for (int i = 0; i < stages.Length; i++)
            {
                if (x < stages[i].transform.position.x)
                {
                    x = stages[i].transform.position.x;
                    target = stages[i];
                }
            }

            int rnd = Random.Range(0, 4);
            if (rnd == 0)
            {
                Instantiate(coins, target);
            }
            else 
            {
                Instantiate(enemys, target);
            }
            count = 0;
        }
    }
}
