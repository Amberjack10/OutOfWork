using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : UnitBase
{

    protected override void UpdatePassive()
    {
        base.UpdatePassive();

        if (foundEnemy)
        {
            SetState(UnitState.Attacking);
        }
        else
        {
            SetState(UnitState.Walking);
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
            Move_Unit();
        }
    }
}
