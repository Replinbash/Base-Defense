namespace BaseShooter
{
	using BaseShooter.Base.Component;
	using BaseShooter.Component;
	using BaseShooter.State;
	using System;
	using UnityEngine;

	public class MainComponent : MonoBehaviour
	{
		private AppState _appState;
		private ComponentContainer _componentContainer;
		private GamePlayComponent _gamePlayComponent;
		private InputSystem _inputSystem;
		private PlayerAnimationComponent _playerAnimationComponent;

		private void Awake() => _componentContainer = new ComponentContainer();

		private void Start()
		{
			CreateGamePlayComponent();
			CreateInputSystem();
			CreatePlayerAnimationController();

			InitializeComponents();
			CreateAppState();
			_appState.EnterStateMachine();
		}		

		private void Update()
		{
			_appState.UpdateStateMachine();
		}

		private void OnDestroy()
		{
			
		}

		private void CreateGamePlayComponent()
		{
			_gamePlayComponent = FindObjectOfType<GamePlayComponent>();
			_componentContainer.AddComponent("GamePlayComponent", _gamePlayComponent);
		}

		private void CreateInputSystem()
		{
			_inputSystem = new InputSystem();
			_componentContainer.AddComponent("InputSystem", _inputSystem);
		}

		private void CreatePlayerAnimationController()
		{
			_playerAnimationComponent = FindObjectOfType<PlayerAnimationComponent>();
			_componentContainer.AddComponent("PlayerAnimationComponent", _playerAnimationComponent);
		}

		private void InitializeComponents()
		{
			_inputSystem.Initilaze(_componentContainer);
			_gamePlayComponent.Initilaze(_componentContainer);
			_playerAnimationComponent.Initilaze(_componentContainer);	
		}

		private void CreateAppState() => _appState = new AppState(_componentContainer);
	}
}
