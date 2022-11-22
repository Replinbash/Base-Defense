namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.HFSM;
	using UnityEngine;

	public class BattleIdleState : StateMachine
	{
		public BattleIdleState(ComponentContainer componentContainer)
		{

		}

		protected override void OnEnter()
		{
			Debug.Log("Battle Idle State OnEnter!");
		}

		protected override void OnUpdate()
		{
			Debug.Log("Battle Idle State OnUpdate!");
		}

		protected override void OnExit()
		{
			Debug.Log("Battle Idle State OnExit!");
		}
	}
}
