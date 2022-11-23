namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.Component;
	using BaseDefense.Enum;
	using BaseDefense.HFSM;
	using System;
	using UnityEngine;

	public class BattleState : StateMachine
	{
		[Header("States")]
		private BattleIdleState _battleIdleState;
		private MoneyCollectState _moneyCollectState;
		private HelpToSurvivorState _helpToSurvivorState;
		private SetTrapState _setTrapState;
		private EnemyAreaUpgradeState _enemyAreaUpgradeState;

		[Header("Components")]
		private PlayerAnimationHandler _playerAnimationHandler;
		private StateEventContainer _stateEventContainer;

		public BattleState(ComponentContainer componentContainer)
		{
			_battleIdleState = new BattleIdleState(componentContainer);
			_moneyCollectState = new MoneyCollectState(componentContainer);
			_helpToSurvivorState = new HelpToSurvivorState(componentContainer);
			_setTrapState = new SetTrapState(componentContainer);
			_enemyAreaUpgradeState = new EnemyAreaUpgradeState(componentContainer);

			this.AddSubState(_battleIdleState);
			this.AddSubState(_moneyCollectState);
			this.AddSubState(_helpToSurvivorState);
			this.AddSubState(_setTrapState);
			this.AddSubState(_enemyAreaUpgradeState);

			SetupMoneyCollectTransitions();
			SetupHelpToSurvivorTransitions();
			SetupSetTrapTransitions();
			SetupEnemyAreaUpgradeTransitions();

			_playerAnimationHandler = componentContainer.GetComponent("PlayerAnimationHandler") as PlayerAnimationHandler;
			_stateEventContainer = componentContainer.GetComponent("StateEventContainer") as StateEventContainer;
		}

		#region Transitions
		private void SetupEnemyAreaUpgradeTransitions()
		{
			this.AddTransition(_battleIdleState, _enemyAreaUpgradeState, (int)StateTriggers.ENEMY_AREA_UPGRADES_REQUEST);
			this.AddTransition(_enemyAreaUpgradeState, _battleIdleState, (int)StateTriggers.RETURN_BATTLE_IDLE_REQUEST);
		}

		private void SetupSetTrapTransitions()
		{
			this.AddTransition(_battleIdleState, _setTrapState, (int)StateTriggers.SET_TRAP_REQUEST);
			this.AddTransition(_setTrapState, _battleIdleState, (int)StateTriggers.RETURN_BATTLE_IDLE_REQUEST);
		}

		private void SetupHelpToSurvivorTransitions()
		{
			this.AddTransition(_battleIdleState, _helpToSurvivorState, (int)StateTriggers.HELP_TO_SURVÝVOR_REQUEST);
			this.AddTransition(_helpToSurvivorState, _battleIdleState, (int)StateTriggers.RETURN_BATTLE_IDLE_REQUEST);
		}

		private void SetupMoneyCollectTransitions()
		{
			this.AddTransition(_battleIdleState, _moneyCollectState, (int)StateTriggers.MONEY_COLLECT_REQUEST);
			this.AddTransition(_moneyCollectState, _battleIdleState, (int)StateTriggers.RETURN_BATTLE_IDLE_REQUEST);
		}
		#endregion

		// TODO: Disable health bar and gun
		// TODO: Set enemy aggro
		// TODO: Set aim at the enemy
		protected override void OnEnter()
		{
			Debug.Log("<color=red>BattleState OnEnter</color>");
			_playerAnimationHandler.SetPlayerState(PlayerStateTriggers.Attack);
			_stateEventContainer.OnUpgradeStateEvent += GoToUpgradeState;
		}

		public void GoToUpgradeState()
		{
			SendTrigger((int)StateTriggers.GO_TO_UPGRADE_REQUEST);
		}

		protected override void OnExit()
		{
			Debug.Log("<color=red>BattleState OnExit</color>");
			_playerAnimationHandler.HandleAnimation(false);
			_stateEventContainer.OnUpgradeStateEvent -= GoToUpgradeState;
		}
	}

}
