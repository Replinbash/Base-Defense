namespace BaseShooter.State
{
	using BaseShooter.Base.Component;
	using BaseShooter.HFSM;
	using UnityEngine;

	public class AppState : StateMachine
	{
		private LoadingState _loadingState;
		private GameState _gameState;
		private ReplayGameState _replayGameState;

		public AppState(ComponentContainer componentContainer)
		{
			_loadingState = new LoadingState(componentContainer);
			_gameState = new GameState(componentContainer);
			_replayGameState = new ReplayGameState(componentContainer);

			this.AddSubState(_loadingState);
			this.AddSubState(_gameState);
			this.AddSubState(_replayGameState);

			_loadingState.AddTransition(_loadingState, _gameState, (int)StateTriggers.LOADING_COMPLETED);
			_gameState.AddTransition(_gameState, _replayGameState, (int)StateTriggers.REPLAY_GAME_REQUEST);
			_replayGameState.AddTransition(_replayGameState, _gameState, (int)StateTriggers.RESTART_GAME_REQUEST);
		}


		protected override void OnEnter()
		{
			Debug.Log("AppState OnEnter");
		}

		protected override void OnUpdate()
		{
			Debug.Log("AppState Update");
		}

		protected override void OnExit()
		{
			Debug.Log("AppState OnExit");
		}
	}

}
