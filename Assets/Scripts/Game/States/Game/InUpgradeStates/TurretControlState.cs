namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.Component;
	using BaseDefense.HFSM;
	using UnityEngine;

	public class TurretControlState : StateMachine
	{
		private StateEventContainer _stateEventContainer;
		private TestCamera _testCamera;

		public TurretControlState(ComponentContainer compenentContainer)
		{
			_testCamera = compenentContainer.GetComponent("TestCamera") as TestCamera;
			_stateEventContainer = compenentContainer.GetComponent("StateEventContainer") as StateEventContainer;
		}

		protected override void OnEnter()
		{
			Debug.Log("Turret Control State OnEnter!");
			_stateEventContainer.ReturnUpgradeIdleEvent += ReturnUpgradeIdle;
		}

		private void ReturnUpgradeIdle()
		{
			SendTrigger((int)StateTriggers.RETURN_UPGRADE_IDLE_STATE);
		}

		protected override void OnUpdate()
		{
			Debug.Log("Turret Control State OnUpdate!");
		}

		protected override void OnExit()
		{
			Debug.Log("Turret Control State OnExit!");
		}
	}
}
