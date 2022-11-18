namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.Component;
	using BaseDefense.Enum;
	using BaseDefense.HFSM;
	using UnityEngine;

	public class UpgradeState : StateMachine
	{
		private PlayerAnimationHandler _playerAnimationHandler;
		private PlayerColliderComponent _playerColliderComponent;

		public UpgradeState(ComponentContainer componentContainer)
		{
			_playerAnimationHandler = componentContainer.GetComponent("PlayerAnimationHandler") as PlayerAnimationHandler;
			_playerColliderComponent = componentContainer.GetComponent("PlayerColliderComponent") as PlayerColliderComponent;

			// Gun Shop State
			// Turret State
			// Booster State
			// Mine State
			// Military state
		}

		// TODO: Enable healthbar and gun
		// TODO: Set enemy aggro 
		protected override void OnEnter()
		{
			Debug.Log("<color=cyan>UpgradeState Enter</color>");
			_playerAnimationHandler.SetPlayerState(PlayerStateTriggers.Run);
			_playerColliderComponent.OnFightState += GoToBattleState;
		}
		
		public void GoToBattleState()
		{
			SendTrigger((int)StateTriggers.GO_TO_BATTLE_REQUEST);
		}

		protected override void OnExit()
		{
			Debug.Log("<color=cyan>UpgradeState OnExit</color>");
			_playerAnimationHandler.HandleAnimation(false);
			_playerColliderComponent.OnFightState -= GoToBattleState;
		}
	}

}
