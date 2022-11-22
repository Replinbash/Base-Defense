namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.HFSM;
	using UnityEngine;

	public class TurretSoldierState : StateMachine
	{
		public TurretSoldierState(ComponentContainer componentContainer)
		{
				
		}

		protected override void OnEnter()
		{
			Debug.Log("Turret Soldier State OnEnter!");
		}

		protected override void OnUpdate()
		{
			Debug.Log("Turret Soldier State OnUpdate!");
		}

		protected override void OnExit()
		{
			Debug.Log("Turret Soldier State OnExit!");
		}
	}
}