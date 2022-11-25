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
			Debug.Log("Upgrade Idle State OnEnter!");
			_stateEventContainer.TurretControlEvent += OnTurretControlRequest;
			_stateEventContainer.AmmoCollectEvent += OnAmmoCollectRequest;
			_stateEventContainer.AmmoAreaEvent += OnAmmoAreaRequest;	
		}

		private void OnTurretControlRequest()
		{
			SendTrigger((int)StateTriggers.TURRET_CONTROL_REQUEST);
		}

		private void OnAmmoCollectRequest()
		{
			SendTrigger((int)StateTriggers.TURRET_AMMO_COLLECT_REQUEST);
		}

		private void OnAmmoAreaRequest()
		{
			SendTrigger((int)StateTriggers.TURRET_AMMO_AREA_REQUEST);
		}

		protected override void OnExit()
		{
			Debug.Log("Upgrade Idle State OnExit!");
			_stateEventContainer.TurretControlEvent -= OnTurretControlRequest;
			_stateEventContainer.AmmoCollectEvent -= OnAmmoCollectRequest;
			_stateEventContainer.AmmoAreaEvent -= OnAmmoAreaRequest;
		}
	}
}
