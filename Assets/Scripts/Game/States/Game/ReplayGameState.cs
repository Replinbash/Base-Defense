namespace BaseShooter.State
{
	using BaseShooter.Base.Component;
	using BaseShooter.HFSM;
	using UnityEngine;

	//TODO: Player stack and tracer will be empty then spawn to base.
	public class ReplayGameState : StateMachine
	{
		public ReplayGameState(ComponentContainer componentContainer)
		{

		}

		protected override void OnEnter()
		{
			Debug.Log("<color=red>ReplayGameState OnEnter</color>");
		}

		protected override void OnExit()
		{
			Debug.Log("<color=red>ReplayGameState OnEnter</color>");
		}
	}

}