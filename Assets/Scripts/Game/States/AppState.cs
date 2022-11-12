namespace BaseShooter.State
{
	using BaseShooter.Base.Component;
	using BaseShooter.HFSM;

	public class AppState : StateMachine
	{
		private LoadingState loadingState;
		private InGameState inGameState;
		private PauseGameState pauseGameState;
		private ReplayGameState replayGameState;

		public AppState(ComponentContainer componentContainer)
		{
			loadingState = new LoadingState(componentContainer);
			inGameState = new InGameState(componentContainer);
			pauseGameState = new PauseGameState(componentContainer);
			replayGameState = new ReplayGameState(componentContainer);

			AddSubState(loadingState);
			AddSubState(inGameState);
			AddSubState(pauseGameState);
			AddSubState(replayGameState);

			loadingState.AddTransition(loadingState, inGameState, (int)StateTriggers.START_GAME_REQUEST);
			inGameState.AddTransition(inGameState, pauseGameState, (int)StateTriggers.PAUSE_GAME_REQUEST);
			inGameState.AddTransition(inGameState, replayGameState, (int)StateTriggers.REPLAY_GAME_REQUEST);
			replayGameState.AddTransition(replayGameState, inGameState, (int)StateTriggers.RESUME_GAME_REQUEST);
			pauseGameState.AddTransition(pauseGameState, inGameState, (int)StateTriggers.RESUME_GAME_REQUEST);
		}


		protected override void OnEnter()
		{

		}

		protected override void OnUpdate()
		{

		}

		protected override void OnExit()
		{

		}
	}

}
