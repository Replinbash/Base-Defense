namespace BaseShooter.State
{
	using BaseShooter.Base.Component;
	using BaseShooter.HFSM;
	using UnityEngine;
	
	public class LoadingState : StateMachine
	{
		public LoadingState(ComponentContainer componentContainer)
		{
			
		}

		protected override void OnEnter()
		{
			Debug.Log("Loading State OnEnter");
		}

		//TODO: LOADING SCREEN
		protected override void OnUpdate()
		{
			Debug.Log("Loading State OnUpdate");			
			SendTrigger((int)StateTriggers.LOADING_COMPLETED);
		}

		protected override void OnExit()
		{
			Debug.Log("Loading State OnExit");
		}
	}

}