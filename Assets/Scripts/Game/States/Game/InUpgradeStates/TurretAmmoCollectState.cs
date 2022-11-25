namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.Component;
	using BaseDefense.HFSM;
	using UnityEngine;

	public class TurretAmmoCollectState : StateMachine
	{
		private StateEventContainer _stateEventContainer;
		private TurretAmmoFactory _turretAmmoFactory;
		private AmmoStackTest _ammoStackTest;

		public TurretAmmoCollectState(ComponentContainer componentContainer)
		{
			_stateEventContainer = componentContainer.GetComponent("StateEventContainer") as StateEventContainer;
			_ammoStackTest = componentContainer.GetComponent("AmmoStackTest") as AmmoStackTest;
			_turretAmmoFactory = new TurretAmmoFactory();
			_ammoStackTest.InjectAmmoBullet(_turretAmmoFactory);
		}

		protected override void OnEnter()
		{
			Debug.Log("Turret Ammo Collect State OnEnter!");
			_stateEventContainer.ReturnUpgradeIdleEvent += ReturnUpgradeIdle;			
		}

		protected override void OnUpdate()
		{
			Debug.Log("Turret Ammo Collect State OnUpdate!");			
			_ammoStackTest.OnGetAmmo();
		}

		private void ReturnUpgradeIdle()
		{
			SendTrigger((int)StateTriggers.RETURN_UPGRADE_IDLE_STATE);
		}		

		protected override void OnExit()
		{
			Debug.Log("Turret Ammo Collect State OnExit!");
		}
	}
}