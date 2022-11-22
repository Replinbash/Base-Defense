namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.HFSM;
	using UnityEngine;

	public class SoldierAttackOrderState : StateMachine
	{
		public SoldierAttackOrderState(ComponentContainer componentContainer)
		{
				
		}

		protected override void OnEnter()
		{
			Debug.Log("Soldier Attack Order State OnEnter!");
		}

		protected override void OnUpdate()
		{
			Debug.Log("Soldier Attack Order State OnUpdate!");
		}

		protected override void OnExit()
		{
			Debug.Log("Soldier Attack Order State OnExit!");
		}
	}
}