namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.HFSM;
	using UnityEngine;

	public class SetTrapState : StateMachine
	{
		public SetTrapState(ComponentContainer componentContainer)
		{

		}

		protected override void OnEnter()
		{
			Debug.Log("Set Trap State OnEnter!");
		}

		protected override void OnUpdate()
		{
			Debug.Log("Set Trap State OnUpdate!");
		}

		protected override void OnExit()
		{
			Debug.Log("Set Trap State OnExit!");
		}
	}
}
