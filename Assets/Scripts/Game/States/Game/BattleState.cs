namespace BaseShooter.State
{
	using BaseShooter.Base.Component;
	using BaseShooter.Component;
	using BaseShooter.Enum;
	using BaseShooter.HFSM;
	using UnityEngine;

	public class BattleState : StateMachine
	{
		private PlayerAnimationHandler _playerAnimationHandler;
		private PlayerColliderComponent _playerColliderComponent;

		public BattleState(ComponentContainer componentContainer)
		{
			_playerAnimationHandler = componentContainer.GetComponent("PlayerAnimationHandler") as PlayerAnimationHandler;
			_playerColliderComponent = componentContainer.GetComponent("PlayerColliderComponent") as PlayerColliderComponent;
		}

		// TODO: Disable health bar and gun
		// TODO: Set enemy agroo
		protected override void OnEnter()
		{
			Debug.Log("<color=red>BattleState OnEnter</color>");
			_playerAnimationHandler.SetPlayerState(PlayerStateTriggers.Fight);
			_playerColliderComponent.OnUpgradeState += GoToUpgradeState;
		}

		public void GoToUpgradeState()
		{
			SendTrigger((int)StateTriggers.GO_TO_UPGRADE_REQUEST);
		}

		protected override void OnExit()
		{
			Debug.Log("<color=red>BattleState OnExit</color>");
			_playerAnimationHandler.HandleAnimation(false);
			_playerColliderComponent.OnUpgradeState -= GoToUpgradeState;
		}
	}

}
