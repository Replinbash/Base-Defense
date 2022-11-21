namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.Component;
	using BaseDefense.HFSM;
	using UnityEngine;

	public class GameState : StateMachine
	{
		private UpgradeState _upgradeState;
		private BattleState _battleState;

		private GamePlayComponent _gamePlayComponent;

		public GameState(ComponentContainer componentContainer)
		{
			_gamePlayComponent = componentContainer.GetComponent("GamePlayComponent") as GamePlayComponent;

			_upgradeState = new UpgradeState(componentContainer);
			_battleState = new BattleState(componentContainer);

			this.AddSubState(_upgradeState);
			this.AddSubState(_battleState);

			this.AddTransition(_upgradeState, _battleState, (int)StateTriggers.GO_TO_BATTLE_REQUEST);
			this.AddTransition(_battleState, _upgradeState, (int)StateTriggers.GO_TO_UPGRADE_REQUEST);
		}

		// TODO: Show Tutorial
		protected override void OnEnter()
		{
			SetDefaultState();
			Debug.Log("<color=cyan>GameState OnEnter</color>");
		}

		protected override void OnUpdate()
		{
			_gamePlayComponent.CallUptade();
		}

		protected override void OnExit()
		{
			Debug.Log("<color=cyan>GameState OnExit</color>");
		}
	}

}
