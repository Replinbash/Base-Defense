namespace BaseShooter.State
{
	using BaseShooter.Base.Component;
	using BaseShooter.Component;
	using BaseShooter.HFSM;
	using UnityEngine;

	public class InGameState : StateMachine
	{
		private GamePlayComponent _gamePlayComponent;
		private ComponentContainer _componentContainer;
		
		public InGameState(ComponentContainer componentContainer)
		{
			_componentContainer = componentContainer;	
			_gamePlayComponent = componentContainer.GetComponent("GamePlayComponent") as GamePlayComponent;			
		}

		protected override void OnEnter()
		{
			Debug.Log("InGameState State OnEnter");
		}

		protected override void OnUpdate()
		{
			_gamePlayComponent.CallUptade();
		}

		protected override void OnExit()
		{
			Debug.Log("InGameState State OnExit");
		}
	}

}
