using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMoneyState : State
{
    bool IsHoldingPlant;
    bool hasMoneyForPlant;
    public override State RunCurrentState()
    {
        if (IsHoldingPlant)
        {
            //Find place to put plant
        }
        else if(hasMoneyForPlant)
        {
            //Go buy a plant
        }

        return this;
    }
}
