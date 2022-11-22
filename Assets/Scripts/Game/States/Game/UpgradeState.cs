namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.Component;
	using BaseDefense.Enum;
	using BaseDefense.HFSM;
	using UnityEngine;

	public class UpgradeState : StateMachine
	{
		[Header("States")]
		private UpgradeIdleState _upgradeIdleState;
		private BaseAreaUpgradesState _baseAreaUpgradesState;
		private WeaponShopState _weaponShopState;
		private PlayerUpgradesState _playerUpgradesState;
		private TurretControlState _turretControlState;
		private TurretAmmoAreaState _turretAmmoAreaState;
		private TurretAmmoCollectState _turretAmmoCollectState;
		private TurretSoldierState _turretSoldierState;
		private UpgradeToMinerState _upgradeToMinerState;
		private UpgradeToSoldierState _upgradeToSoldierState;
		private GemCollectState _gemCollectState;
		private MoneyWorkerState _moneyWorkerState;
		private AmmoWorkerState _ammoWorkerState;
		private SoldierUpgradesState _soldierUpgradesState;
		private SoldierAttackOrderState _soldierAttackOrderState;

		[Header("Components")]
		private PlayerAnimationHandler _playerAnimationHandler;
		private PlayerColliderComponent _playerColliderComponent;

		public UpgradeState(ComponentContainer componentContainer)
		{
			_upgradeIdleState = new UpgradeIdleState(componentContainer);
			_baseAreaUpgradesState = new BaseAreaUpgradesState(componentContainer);
			_weaponShopState = new WeaponShopState(componentContainer);
			_playerUpgradesState = new PlayerUpgradesState(componentContainer);
			_turretControlState = new TurretControlState(componentContainer);
			_turretAmmoAreaState = new TurretAmmoAreaState(componentContainer);
			_turretAmmoCollectState = new TurretAmmoCollectState(componentContainer);
			_turretSoldierState = new TurretSoldierState(componentContainer);
			_upgradeToMinerState = new UpgradeToMinerState(componentContainer);
			_upgradeToSoldierState = new UpgradeToSoldierState(componentContainer);
			_moneyWorkerState= new MoneyWorkerState(componentContainer);
			_ammoWorkerState= new AmmoWorkerState(componentContainer);	
			_soldierUpgradesState = new SoldierUpgradesState(componentContainer);
			_soldierAttackOrderState = new SoldierAttackOrderState(componentContainer);	
			_gemCollectState= new GemCollectState(componentContainer);	

			this.AddSubState(_upgradeIdleState);
			this.AddSubState(_baseAreaUpgradesState);
			this.AddSubState(_weaponShopState);
			this.AddSubState(_playerUpgradesState);
			this.AddSubState(_turretControlState);
			this.AddSubState(_turretAmmoAreaState);
			this.AddSubState(_turretAmmoCollectState);
			this.AddSubState(_turretSoldierState);
			this.AddSubState(_upgradeToMinerState);
			this.AddSubState(_upgradeToSoldierState);
			this.AddSubState(_moneyWorkerState);
			this.AddSubState(_ammoWorkerState);
			this.AddSubState(_soldierUpgradesState);
			this.AddSubState(_soldierAttackOrderState);
			this.AddSubState(_gemCollectState);


			SetupBaseAreaUpgradesTransitions();
			SetupWeaponShopTransitions();
			SetupPlayerUpgradesTransitions();
			SetupTurretControlTransitions();
			SetupTurretAmmoAreaTransitions();
			SetupTurretAmmoCollectTransitions();
			SetupTurretSoldierTransitions();
			SetupUpgradeToSoldierTransitions();
			SetupMoneyWorkerTransitions();
			SetupAmmoWorkerTransitions();
			SetupSoldierUpgradesTransitions();
			SetupSoldierAttackOrderTransitions();
			SetupGemCollectTransitions();

			_playerAnimationHandler = componentContainer.GetComponent("PlayerAnimationHandler") as PlayerAnimationHandler;
			_playerColliderComponent = componentContainer.GetComponent("PlayerColliderComponent") as PlayerColliderComponent;
		}

		#region Transitions
		private void SetupGemCollectTransitions()
		{
			this.AddTransition(_upgradeIdleState, _gemCollectState, (int)StateTriggers.GEM_COLLECT_REQUEST);
			this.AddTransition(_gemCollectState, _upgradeIdleState, (int)StateTriggers.RETURN_UPGRADE_IDLE_STATE);
		}

		private void SetupSoldierAttackOrderTransitions()
		{
			this.AddTransition(_upgradeIdleState, _soldierAttackOrderState, (int)StateTriggers.SOLDÝER_ATTACK_ORDER_REQUEST);
			this.AddTransition(_soldierAttackOrderState, _upgradeIdleState, (int)StateTriggers.RETURN_UPGRADE_IDLE_STATE);
		}

		private void SetupSoldierUpgradesTransitions()
		{
			this.AddTransition(_upgradeIdleState, _soldierUpgradesState, (int)StateTriggers.SOLDÝER_UPGRADES_REQUEST);
			this.AddTransition(_soldierUpgradesState, _upgradeIdleState, (int)StateTriggers.RETURN_UPGRADE_IDLE_STATE);
		}

		private void SetupAmmoWorkerTransitions()
		{
			this.AddTransition(_upgradeIdleState, _ammoWorkerState, (int)StateTriggers.AMMO_WORKER_REQUEST);
			this.AddTransition(_ammoWorkerState, _upgradeIdleState, (int)StateTriggers.RETURN_UPGRADE_IDLE_STATE);
		}

		private void SetupMoneyWorkerTransitions()
		{
			this.AddTransition(_upgradeIdleState, _moneyWorkerState, (int)StateTriggers.MONEY_WORKER_REQUEST);
			this.AddTransition(_moneyWorkerState, _upgradeIdleState, (int)StateTriggers.RETURN_UPGRADE_IDLE_STATE);
		}

		private void SetupUpgradeToSoldierTransitions()
		{
			this.AddTransition(_upgradeIdleState, _upgradeToSoldierState, (int)StateTriggers.UPGRADE_TO_SOLDÝER_REQUEST);
			this.AddTransition(_upgradeToSoldierState, _upgradeIdleState, (int)StateTriggers.RETURN_UPGRADE_IDLE_STATE);
		}

		private void SetupTurretControlTransitions()
		{
			this.AddTransition(_upgradeIdleState, _turretControlState, (int)StateTriggers.TURRET_CONTROL_REQUEST);
			this.AddTransition(_turretControlState, _upgradeIdleState, (int)StateTriggers.RETURN_UPGRADE_IDLE_STATE);
		}

		private void SetupTurretSoldierTransitions()
		{
			this.AddTransition(_upgradeIdleState, _turretSoldierState, (int)StateTriggers.TURRET_SOLDÝER_REQUEST);
			this.AddTransition(_turretSoldierState, _upgradeIdleState, (int)StateTriggers.RETURN_UPGRADE_IDLE_STATE);
		}

		private void SetupTurretAmmoCollectTransitions()
		{
			this.AddTransition(_upgradeIdleState, _turretAmmoCollectState, (int)StateTriggers.TURRET_AMMO_COLLECT_REQUEST);
			this.AddTransition(_turretAmmoCollectState, _upgradeIdleState, (int)StateTriggers.RETURN_UPGRADE_IDLE_STATE);
		}

		private void SetupTurretAmmoAreaTransitions()
		{
			this.AddTransition(_upgradeIdleState, _turretAmmoAreaState, (int)StateTriggers.TURRET_AMMO_AREA_REQUEST);
			this.AddTransition(_turretAmmoAreaState, _upgradeIdleState, (int)StateTriggers.RETURN_UPGRADE_IDLE_STATE);
		}

		private void SetupPlayerUpgradesTransitions()
		{
			this.AddTransition(_upgradeIdleState, _playerUpgradesState, (int)StateTriggers.PLAYER_UPGRADES_REQUEST);
			this.AddTransition(_playerUpgradesState, _upgradeIdleState, (int)StateTriggers.RETURN_UPGRADE_IDLE_STATE);
		}

		private void SetupWeaponShopTransitions()
		{
			this.AddTransition(_upgradeIdleState, _weaponShopState, (int)StateTriggers.WEAPON_SHOP_REQUEST);
			this.AddTransition(_weaponShopState, _upgradeIdleState, (int)StateTriggers.RETURN_UPGRADE_IDLE_STATE);
		}

		private void SetupBaseAreaUpgradesTransitions()
		{
			this.AddTransition(_upgradeIdleState, _baseAreaUpgradesState, (int)StateTriggers.BASE_AREA_UPGRADE_REQUEST);
			this.AddTransition(_baseAreaUpgradesState, _upgradeIdleState, (int)StateTriggers.RETURN_UPGRADE_IDLE_STATE);
		}
		#endregion

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
