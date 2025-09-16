using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using static UnityEditorInternal.VersionControl.ListControl;

public class PlayerController : MonoBehaviour
{

    #region Variables

    #region State Machine

    private IStateManager<PlayerController> currentState;      // Player's current state
    private IStateManager<PlayerController> lastState;         // Player's last state

    #endregion

    #region Components

    [field: Header("Components")]
    public CharacterController characterController { get; private set; }

    #endregion

    #endregion

    #region Unity Methods

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        SwitchState(new IdleState());
    }

    void Update()
    {
        currentState?.UpdateState(this);
    }

    private void FixedUpdate()
    {
        currentState?.FixedUpdateState(this);    
    }

    #endregion

    #region State Machine Methods

    public void SwitchState(IStateManager<PlayerController> newState)
    {
        // Calling the ExitState method of the current State
        currentState?.ExitState(this);
        // The current state is now the last state
        lastState = currentState;
        // The new state is now the current state
        currentState = newState;
        // Calling the EnterState method of the new current state
        currentState?.EnterState(this, lastState);
    }

    #endregion
}
