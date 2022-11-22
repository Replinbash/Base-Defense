namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.HFSM;
	using UnityEngine;

	public class EnemyAreaUpgradeState : StateMachine
	{
		public EnemyAreaUpgradeState(ComponentContainer componentContainer)
		{

		}

		protected override void OnEnter()
		{
			Debug.Log("Enemy Area Upgrade State OnEnter!");
		}

		protected override void OnUpdate()
		{
			Debug.Log("Enemy Area Upgrade State OnUpdate!");
		}

		protected override void OnExit()
		{
			Debug.Log("Enemy Area Upgrade State OnExit!");
		}
	}
}
