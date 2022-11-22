namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.HFSM;
	using UnityEngine;

	public class TurretAmmoCollectState : StateMachine
	{
		public TurretAmmoCollectState(ComponentContainer componentContainer)
		{

		}

		protected override void OnEnter()
		{
			Debug.Log("Turret Ammo Collect State OnEnter!");
		}

		protected override void OnUpdate()
		{
			Debug.Log("Turret Ammo Collect State OnUpdate!");
		}

		protected override void OnExit()
		{
			Debug.Log("Turret Ammo Collect State OnExit!");
		}
	}
}