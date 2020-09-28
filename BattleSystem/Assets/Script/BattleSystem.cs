﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState
{
    Start,
    PlayerAction,
    PlayerMove,
    EnemyMove,
    Busy
}

public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    BattleDialogBox dialogBox;

    BattleState state;
    int currentAction;

    void Start()
    {
        StartCoroutine(SetupBattle());
    }

    public IEnumerator SetupBattle()
    {
        yield return dialogBox.TypeDialog("A new foe has appeared!");
        yield return new WaitForSeconds(1f);

        PlayerAction();
    }

    void PlayerAction()
    {
        state = BattleState.PlayerAction;
        StartCoroutine(dialogBox.TypeDialog("Choose an action."));
        dialogBox.EnableActionSelector(true);
    }

    private void Update()
    {
        if (state == BattleState.PlayerAction)
        {
            HandleActionSelection();
        }
    }

    void HandleActionSelection()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentAction < 1)
            {
                ++currentAction;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentAction > 0)
            {
                --currentAction;
            }
        }

        dialogBox.UpdateActionSelection(currentAction);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentAction == 0)
            {
                //Fight
            }
            else if (currentAction == 0)
            {
                //Run
            }
        }
    }
}
