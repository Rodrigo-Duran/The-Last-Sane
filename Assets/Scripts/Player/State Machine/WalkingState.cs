using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : IStateManager<PlayerController>
{

    public void EnterState(PlayerController controller, IStateManager<PlayerController> lastState)
    {
        Debug.Log("ENTER WALKING STATE");
    }

    public void ExitState(PlayerController controller)
    {
        Debug.Log("EXIT WALKING STATE");
    }

    public void FixedUpdateState(PlayerController controller)
    {
    }

    public void HandleInput(PlayerController controller)
    {
        if (InputManager.GetMovementInput().magnitude == 0) controller.SwitchState(new IdleState());
    }

    public void UpdateState(PlayerController controller)
    {
        HandleInput(controller);
    }
}
