using System;
using Common.Interfaces;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class InputManager: IInitializable, IDisposable, IMoveProvider
{
    public IObservable<Vector2> Move => _move;
    private readonly ReactiveCommand<Vector2> _move;
        
    private readonly InputMap _inputMap;

    public InputManager(InputMap inputMap)
    {
        _inputMap = inputMap;
        
        _move = new();
    }

    public void Initialize()
    {
        _inputMap.PlayerMove.Move.performed += ProcessMoveInput;
    }

    public void Dispose()
    {
        _inputMap.PlayerMove.Move.performed -= ProcessMoveInput;
    }

    private void ProcessMoveInput(InputAction.CallbackContext ctx)
    {
        _move.Execute(ctx.ReadValue<Vector2>());
    }
}