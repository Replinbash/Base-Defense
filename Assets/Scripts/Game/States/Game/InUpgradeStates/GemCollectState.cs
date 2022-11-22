namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.HFSM;
	using UnityEngine;

	public class GemCollectState : StateMachine
	{
		public GemCollectState(ComponentContainer componentContainer)
		{

		}

		protected override void OnEnter()
		{
			Debug.Log("Gem Collect State OnEnter!");
		}

		protected override void OnUpdate()
		{
			Debug.Log("Gem Collect State OnUpdate!");
		}

		protected override void OnExit()
		{
			Debug.Log("Gem Collect State OnExit!");
		}

	}
}