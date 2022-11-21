namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.Component;
	using BaseDefense.Enum;
	using BaseDefense.HFSM;
	using System;
	using UnityEngine;

	public class UpgradeState : StateMachine
	{
		[Header("States")]
		private UpgradeIdleState _upgradeIdleState;
		private TurretControlState _turretControlState;

		[Header("Components")]
		private PlayerAnimationHandler _playerAnimationHandler;
		private PlayerColliderComponent _playerColliderComponent;

		public UpgradeState(ComponentContainer componentContainer)
		{
			_upgradeIdleState = new UpgradeIdleState(componentContainer);
			_turretControlState = new TurretControlState(componentContainer);

			this.AddSubState(_upgradeIdleState);
			this.AddSubState(_turretControlState);

			SetupTurretControlTransitions();

			_playerAnimationHandler = componentContainer.GetComponent("PlayerAnimationHandler") as PlayerAnimationHandler;
			_playerColliderComponent = componentContainer.GetComponent("PlayerColliderComponent") as PlayerColliderComponent;

			// Base Idle State
			// Base Area Upgrades State
			// Weapon Shop State
			// Player Upgrades State
			// Turret Control State
			// Turret Ammo Collect State
			// Turret Ammo Area State
			// Turret Soldier state
			// Upgrade To Miner State
			// Gem Collect State
			// Money Worker State
			// Ammo Worker State
			// Upgrade To Soldier State
			// Soldier Upgrades State
			// Soldier Attack Order State
		}

		private void SetupTurretControlTransitions()
		{
			this.AddTransition(_upgradeIdleState, _turretControlState, (int)StateTriggers.TURRET_CONTROL_REQUEST);
			this.AddTransition(_turretControlState, _upgradeIdleState, (int)StateTriggers.RETURN_UPGRADE_IDLE_STATE);
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
