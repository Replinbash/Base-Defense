namespace BaseShooter.State
{
	using BaseShooter.Base.Component;
	using BaseShooter.HFSM;
	using UnityEngine;

	public class ReplayGameState : StateMachine
	{
		public ReplayGameState(ComponentContainer componentContainer)
		{

		}

		protected override void OnEnter()
		{
			Debug.Log("ReplayGameState OnEnter");
		}

		protected override void OnExit()
		{
			Debug.Log("ReplayGameState OnEnter");
		}
	}

}