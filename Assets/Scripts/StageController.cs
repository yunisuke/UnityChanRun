using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] private Stage[] stages;
    [SerializeField] private Transform pos;

    [SerializeField] private GameObject coins;
    [SerializeField] private GameObject enemys;
    private int count = 0;

    void Update()
    {
        MoveStage();
    }

    private void MoveStage()
    {
        for(int i=0; i<stages.Length; i++)
        {
            var stage = stages[i];
            stage.LocalPosition = new Vector2(stage.LocalPosition.x - 0.15f, stage.LocalPosition.y);
            if (stage.LocalPosition.x < -60) {
                stage.LocalPosition = new Vector2(stage.LocalPosition.x + 75, stage.LocalPosition.y);
                InstantiateObject(stage);
            }
        }
    }

    private void InstantiateObject(Stage stage)
    {
        stage.ClearEnemys();

        Instantiate(enemys, stage.EnemyContainer);
    }
}
