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
            stage.localPosition = new Vector2(stage.localPosition.x - 0.1f, stage.localPosition.y);
            if (stage.localPosition.x < -40) {
                stage.localPosition = new Vector2(stage.localPosition.x + 60, stage.localPosition.y);
            }
        }
    }
}
