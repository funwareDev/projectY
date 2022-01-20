using System.Collections;
using UnityEngine;

public abstract class StateMachineMB : MonoBehaviour
{
	public BaseState CurrentState { get; private set; }
	public BaseState _previousState;

	bool _inTransition = false;

	public void ChangeState(BaseState newState)
	{
		if (CurrentState == newState || _inTransition)
			return;

		ChangeStateRoutine(newState);
	}

	public void RevertState()
	{
		if (_previousState != null)
			ChangeState(_previousState);
	}

	void ChangeStateRoutine(BaseState newState)
	{
		_inTransition = true;

		if (CurrentState != null)
			CurrentState.Exit();

		if (_previousState != null)
			_previousState = CurrentState;

		CurrentState = newState;

		if (CurrentState != null)
			CurrentState.Enter();

		_inTransition = false;
	}

	public void Update()
	{
		if (CurrentState != null && !_inTransition)
			CurrentState.Tick();
	}

    public void FixedUpdate()
    {
		if (CurrentState != null && !_inTransition)
			CurrentState.FixedTick();
    }
}
