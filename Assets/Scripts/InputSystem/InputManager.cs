using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    #region Variables

    #region Player

    // INPUT VALUES
    private Vector2 movementInput;          // Receives the value of the movement input
    #endregion

    #endregion

    #region Singleton

    public static InputManager inputManagerInstance;

    private void Awake()
    {
        if(inputManagerInstance != null && inputManagerInstance != this) Destroy(gameObject);
        else inputManagerInstance = this;
    }

    #endregion

    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region Input Actions - Methods

    #region Player Map

    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();   
    }

    public static Vector2 GetMovementInput()
    {
        return inputManagerInstance.movementInput;
    }

    #endregion

    #endregion
}
