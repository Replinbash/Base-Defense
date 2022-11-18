namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.HFSM;
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