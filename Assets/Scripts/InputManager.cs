using System;
using Common;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager: ISetupable
{
    public IObservable<Vector2> MoveDirection => _moveDirection;
    private readonly ReactiveCommand<Vector2> _moveDirection;
        
    private readonly InputMap _inputMap;

    public InputManager(InputMap inputMap)
    {
        _inputMap = inputMap;
        
        _moveDirection = new();
    }

    public IDisposable Setup()
    {
        _inputMap.PlayerMove.Move.performed += ProcessMoveInput;

        return Disposable.Create(() => 
            _inputMap.PlayerMove.Move.performed -= ProcessMoveInput);
    }

    private void ProcessMoveInput(InputAction.CallbackContext ctx)
    {
        _moveDirection.Execute(ctx.ReadValue<Vector2>());
    }
}