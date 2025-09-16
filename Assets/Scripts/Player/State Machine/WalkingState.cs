using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : IStateManager<PlayerController>
{

    public void EnterState(PlayerController controller, IStateManager<PlayerController> lastState)
    {
        Debug.Log("ENTER WALKING STATE");
        controller.actualSpeed = controller.speed;
    }

    public void ExitState(PlayerController controller)
    {
        Debug.Log("EXIT WALKING STATE");
    }

    public void FixedUpdateState(PlayerController controller)
    {
        #region Movement

        /*Vector3 movement = (controller.cameraObject.right * controller.direction.x + controller.cameraObject.forward * controller.direction.y).normalized;
        movement.y = 0;

        controller.rb.velocity = movement * controller.actualSpeed;*/
        Vector3 movement = new Vector3(controller.direction.x, 0, controller.direction.y);
        controller.rb.MovePosition(controller.transform.position + (controller.transform.forward * movement.magnitude) * controller.actualSpeed * Time.fixedDeltaTime);
        #endregion
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
