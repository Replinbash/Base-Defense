namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.Component;
	using BaseDefense.HFSM;
	using UnityEngine;
	public class TurretAmmoAreaState : StateMachine
	{
		private StateEventContainer _stateEventContainer;
		private AmmoStackTest _ammoStackTest;

		public TurretAmmoAreaState(ComponentContainer componentContainer)
		{
			_stateEventContainer = componentContainer.GetComponent("StateEventContainer") as StateEventContainer;
			_ammoStackTest = componentContainer.GetComponent("AmmoStackTest") as AmmoStackTest;
		}

		protected override void OnEnter()
		{
			Debug.Log("Turret Ammo Area State OnEnter!");
			_stateEventContainer.ReturnUpgradeIdleEvent += ReturnUpgradeIdle;
		}

		private void ReturnUpgradeIdle()
		{
			SendTrigger((int)StateTriggers.RETURN_UPGRADE_IDLE_STATE);
		}

		protected override void OnUpdate()
		{
			Debug.Log("Turret Ammo Area State OnUpdate!");
			_ammoStackTest.SendAmmoArea();
		}

		protected override void OnExit()
		{
			Debug.Log("Turret Ammo Area State OnExit!");
		}
	}
}