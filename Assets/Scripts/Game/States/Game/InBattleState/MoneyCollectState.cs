namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.HFSM;
	using UnityEngine;

	public class MoneyCollectState : StateMachine
	{
		public MoneyCollectState(ComponentContainer componentContainer)
		{

		}

		protected override void OnEnter()
		{
			Debug.Log("Money Collect State OnEnter!");
		}

		protected override void OnUpdate()
		{
			Debug.Log("Money Collect State OnUpdate!");
		}

		protected override void OnExit()
		{
			Debug.Log("Money Collect State OnExit!");
		}
	}
}
