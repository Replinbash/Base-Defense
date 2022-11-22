namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.HFSM;
	using UnityEngine;

	public class PlayerUpgradesState : StateMachine
	{
		public PlayerUpgradesState(ComponentContainer componentContainer)
		{

		}

		protected override void OnEnter()
		{
			Debug.Log("Player Upgrades State OnEnter!");
		}

		protected override void OnUpdate()
		{
			Debug.Log("Player Upgrades State OnUpdate!");
		}

		protected override void OnExit()
		{
			Debug.Log("Player Upgrades State OnExit!");
		}
	}
}