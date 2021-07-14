using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] private RectTransform[] stages;

    void Update()
    {
        MoveStage();
    }

    private void MoveStage()
    {
        for(int i=0; i<stages.Length; i++)
        {
            var stage = stages[i];
            stage.position = new Vector2(stage.position.x - 0.1f, stage.position.y);
            if (stage.position.x < -25) {
                stage.position = new Vector2(stage.position.x + 50, stage.position.y);
            }
        }
    }
}
