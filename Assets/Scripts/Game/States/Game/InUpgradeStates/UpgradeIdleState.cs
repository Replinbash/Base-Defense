namespace BaseDefense.State
{
	using BaseDefense.HFSM;
	using UnityEngine;
	using BaseDefense.Base.Component;
	using BaseDefense.Component;

	public class UpgradeIdleState : StateMachine
	{
		private StateEventContainer _stateEventContainer;
		public UpgradeIdleState(ComponentContainer componentContainer)
		{
			_stateEventContainer = componentContainer.GetComponent("StateEventContainer") as StateEventContainer;
		}

		protected override void OnEnter()
		{
			Debug.Log("Base Idle State OnEnter!");
			_stateEventContainer.TurretControlRequest += OnTurretControlRequest;
		}

		private void OnTurretControlRequest()
		{
			SendTrigger((int)StateTriggers.TURRET_CONTROL_REQUEST);
		}

		protected override void OnExit()
		{
			Debug.Log("Base Idle State OnExit!");
			_stateEventContainer.TurretControlRequest -= OnTurretControlRequest;
		}
	}
}
