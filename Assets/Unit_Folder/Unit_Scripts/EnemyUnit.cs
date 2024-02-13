using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : UnitBase
{
    public Transform StopPosition;

    protected override void UpdatePassive()
    {
        base.UpdatePassive();

        if (foundEnemy)
        {
            SetState(UnitState.Attacking);
        }
        else
        {
            if (transform.position.x > StageManager.instance.EnemyStopPosition.position.x)
            {
                SetState(UnitState.Walking);
            }
        }
    }

    protected override void UpdateWalking()
    {
        base.UpdateWalking();

        if (foundEnemy)
        {
            SetState(UnitState.Attacking);
        }
        else
        {
            if (transform.position.x <= StageManager.instance.EnemyStopPosition.position.x)
            {
                SetState(UnitState.Idle);
            }
            else
            {
                Move_Unit();
            }
        }
    }

}
