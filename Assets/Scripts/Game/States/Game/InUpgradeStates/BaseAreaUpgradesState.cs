namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.HFSM;
	using UnityEngine;
	public class BaseAreaUpgradesState : StateMachine
	{
		public BaseAreaUpgradesState(ComponentContainer componentContainer)
		{

		}

		protected override void OnEnter()
		{
			Debug.Log("Base Area Upgrades OnEnter!");
		}

		protected override void OnUpdate()
		{
			Debug.Log("Base Area Upgrades OnUpdate!");
		}

		protected override void OnExit()
		{
			Debug.Log("Base Area Upgrades OnExit!");
		}

	}
}