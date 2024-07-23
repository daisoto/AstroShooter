using System;
using Common;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager: ISetupable
{
    public Vector2 MoveDirection { get; private set; }

    private readonly InputMap _inputMap;

    public InputManager(InputMap inputMap)
    {
        _inputMap = inputMap;
    }

    public IDisposable Setup()
    {
        _inputMap.Enable();
        _inputMap.PlayerMove.Move.performed += ProcessMoveInput;
        _inputMap.PlayerMove.Move.canceled += ProcessMoveInput;

        return Disposable.Create(() => 
        { 
            _inputMap.PlayerMove.Move.performed -= ProcessMoveInput;
            _inputMap.PlayerMove.Move.canceled -= ProcessMoveInput;
            _inputMap.Disable();
        });
    }

    private void ProcessMoveInput(InputAction.CallbackContext ctx)
    {
        MoveDirection = ctx.ReadValue<Vector2>();
    }
}