namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.HFSM;
	using UnityEngine;

	public class HelpToSurvivorState : StateMachine
	{
		public HelpToSurvivorState(ComponentContainer componentContainer)
		{

		}

		protected override void OnEnter()
		{
			Debug.Log("Help To Survivor State OnEnter!");
		}

		protected override void OnUpdate()
		{
			Debug.Log("Help To Survivor State OnUpdate!");
		}

		protected override void OnExit()
		{
			Debug.Log("Help To Survivor State OnExit!");
		}
	}
}
