using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IStateManager<PlayerController>
{
    public void EnterState(PlayerController controller, IStateManager<PlayerController> lastState)
    {
        Debug.Log("ENTER IDLE STATE");
        controller.actualSpeed = 0;
        controller.rb.linearVelocity = Vector3.zero;
    }

    public void ExitState(PlayerController controller)
    {
        Debug.Log("EXIT IDLE STATE");
    }

    public void FixedUpdateState(PlayerController controller)
    {
    }

    public void HandleInput(PlayerController controller)
    {
        if (InputManager.GetMovementInput().magnitude != 0) controller.SwitchState(new WalkingState());
    }

    public void UpdateState(PlayerController controller)
    {
        HandleInput(controller);
    }
}
