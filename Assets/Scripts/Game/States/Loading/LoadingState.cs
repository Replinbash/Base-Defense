namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.HFSM;
	using UnityEngine;
	
	public class LoadingState : StateMachine
	{
		public LoadingState(ComponentContainer componentContainer)
		{
			
		}

		protected override void OnEnter()
		{
			Debug.Log("<color=cyan>Loading State OnEnter</color>");
		}

		//TODO: LOADING SCREEN
		protected override void OnUpdate()
		{
			Debug.Log("<color=cyan>Loading State OnUpdate</color>");			
			SendTrigger((int)StateTriggers.LOADING_COMPLETED);
		}

		protected override void OnExit()
		{
			Debug.Log("<color=cyan>Loading State OnExit</color>");
		}
	}

}