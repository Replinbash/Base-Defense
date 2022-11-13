namespace BaseShooter.State
{
	using BaseShooter.Base.Component;
	using BaseShooter.HFSM;
	using UnityEngine;

	// TODO: PAUSE GAME AND SETTÝNGS SCREEN
	public class PauseGameState : StateMachine
	{
		public PauseGameState(ComponentContainer componentContainer)
		{

		}

		protected override void OnEnter()
		{
			Debug.Log("PauseGameState State OnEnter");
		}
		
		protected override void OnExit()
		{
			Debug.Log("PauseGameState State OnExit");
		}
	}

}
