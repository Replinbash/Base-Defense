namespace BaseShooter.State
{
	using BaseShooter.Base.Component;
	using BaseShooter.HFSM;
	using UnityEngine;

	public class BattleState : StateMachine
	{
		public BattleState(ComponentContainer componentContainer)
		{

		}

		// TODO : Enter the fight anim state
		protected override void OnEnter()
		{
			Debug.Log("BattleState OnEnter");
		}		

		protected override void OnExit()
		{
			Debug.Log("BattleState OnExit");
		}
	}

}
