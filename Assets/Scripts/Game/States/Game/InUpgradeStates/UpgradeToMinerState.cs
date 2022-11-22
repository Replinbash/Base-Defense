namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.HFSM;
	using UnityEngine;

	public class UpgradeToMinerState : StateMachine
	{
		public UpgradeToMinerState(ComponentContainer componentContainer)
		{

		}

		protected override void OnEnter()
		{
			Debug.Log("Upgrade To Miner State OnEnter!");
		}

		protected override void OnUpdate()
		{
			Debug.Log("Upgrade To Miner State OnUpdate!");
		}

		protected override void OnExit()
		{
			Debug.Log("Upgrade To Miner State OnExit!");
		}
	}
}