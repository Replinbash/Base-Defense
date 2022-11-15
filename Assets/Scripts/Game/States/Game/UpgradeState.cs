namespace BaseShooter.State
{
	using BaseShooter.Base.Component;
	using BaseShooter.Component;
	using BaseShooter.Enum;
	using BaseShooter.HFSM;
	using UnityEngine;

	public class UpgradeState : StateMachine
	{
		private PlayerAnimationHandler _playerAnimationHandler;

		public UpgradeState(ComponentContainer componentContainer)
		{
			_playerAnimationHandler = componentContainer.GetComponent("PlayerAnimationHandler") as PlayerAnimationHandler;
		}

		// TODO : Enter the run anim state, 
		protected override void OnEnter()
		{
			Debug.Log("UpgradeState Enter");
			_playerAnimationHandler.SetPlayerState(PlayerStateTriggers.Run);
		}
		
		public void GoToBattle()
		{
			SendTrigger((int)StateTriggers.GO_TO_BATTLE_REQUEST);
		}

		protected override void OnExit()
		{
			Debug.Log("UpgradeState OnExit");
		}
	}

}
