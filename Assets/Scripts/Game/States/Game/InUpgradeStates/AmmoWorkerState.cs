namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.HFSM;
	using UnityEngine;

	public class AmmoWorkerState : StateMachine
	{
		public AmmoWorkerState(ComponentContainer componentContainer)
		{

		}

		protected override void OnEnter()
		{
			Debug.Log("Ammo Worker State OnEnter!");
		}

		protected override void OnUpdate()
		{
			Debug.Log("Ammo Worker State OnUpdate!");
		}

		protected override void OnExit()
		{
			Debug.Log("Ammo Worker State OnExit!");
		}
	}
}