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

    [HideInInspector] public Rigidbody rb;

    #endregion

    #region Movement

    [Header("Movement")]
    public float speed;
    public float rotationSpeed;
    [HideInInspector] public float actualSpeed;
     public Vector2 direction;

    #endregion

    [HideInInspector] public Transform cameraObject;
    #endregion

    #region Unity Methods

    private void Start()
    {
        cameraObject = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        SwitchState(new IdleState());

    }

    void Update()
    {
        direction = InputManager.GetMovementInput().normalized;
        currentState?.UpdateState(this);

        #region Rotation
        if (direction.magnitude != 0)
        {
            Vector3 input = new Vector3(direction.x, 0, direction.y);
            var relative = (transform.position + input) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, rotationSpeed * Time.deltaTime);
        }
        #endregion
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
