namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.HFSM;
	using UnityEngine;

	public class UpgradeToSoldierState : StateMachine
	{
		public UpgradeToSoldierState(ComponentContainer componentContainer)
		{

		}

		protected override void OnEnter()
		{
			Debug.Log("Upgrade To Soldier State OnEnter!");
		}

		protected override void OnUpdate()
		{
			Debug.Log("Upgrade To Soldier State OnUpdate!");
		}

		protected override void OnExit()
		{
			Debug.Log("Upgrade To Soldier State OnExit!");
		}
	}
}