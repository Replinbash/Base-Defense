namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.HFSM;
	using UnityEngine;

	public class SoldierUpgradesState : StateMachine
	{
		public SoldierUpgradesState(ComponentContainer componentContainer)
		{

		}

		protected override void OnEnter()
		{
			Debug.Log("Soldier Upgrades State OnEnter!");
		}

		protected override void OnUpdate()
		{
			Debug.Log("Soldier Upgrades State OnUpdate!");
		}

		protected override void OnExit()
		{
			Debug.Log("Soldier Upgrades State OnExit!");
		}

	}
}