namespace BaseDefense.State
{
	using BaseDefense.HFSM;
	using UnityEngine;
	using BaseDefense.Base.Component;
	using BaseDefense.Component;

	public class UpgradeIdleState : StateMachine
	{
		private GameEventContainer _gameEventContainer;
		public UpgradeIdleState(ComponentContainer componentContainer)
		{
			_gameEventContainer = componentContainer.GetComponent("GameEventContainer") as GameEventContainer;
		}

		protected override void OnEnter()
		{
			Debug.Log("Base Idle State OnEnter!");
			_gameEventContainer.TurretControlRequest += OnTurretControlRequest;
		}

		private void OnTurretControlRequest()
		{
			SendTrigger((int)StateTriggers.TURRET_CONTROL_REQUEST);
		}

		protected override void OnExit()
		{
			Debug.Log("Base Idle State OnExit!");
			_gameEventContainer.TurretControlRequest -= OnTurretControlRequest;
		}
	}
}
