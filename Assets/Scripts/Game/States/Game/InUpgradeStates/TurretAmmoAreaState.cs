namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.HFSM;
	using UnityEngine;
	public class TurretAmmoAreaState : StateMachine
	{
		public TurretAmmoAreaState(ComponentContainer componentContainer)
		{

		}

		protected override void OnEnter()
		{
			Debug.Log("Turret Ammo Area State OnEnter!");
		}

		protected override void OnUpdate()
		{
			Debug.Log("Turret Ammo Area State OnUpdate!");
		}

		protected override void OnExit()
		{
			Debug.Log("Turret Ammo Area State OnExit!");
		}
	}
}