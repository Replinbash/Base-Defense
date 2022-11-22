namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.HFSM;
	using UnityEngine;

	public class MoneyWorkerState : StateMachine
	{
		public MoneyWorkerState(ComponentContainer componentContainer)
		{

		}

		protected override void OnEnter()
		{
			Debug.Log("Money Worker State OnEnter!");
		}

		protected override void OnUpdate()
		{
			Debug.Log("Money Worker State OnUpdate!");
		}

		protected override void OnExit()
		{
			Debug.Log("Money Worker State OnExit!");
		}

	}
}