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
		private PlayerAnimationHandler _playerAnimationHandler;
		private PlayerMovementComponent _playerMovementComponent;
		private Joystick _joystick;

		private void Awake()
		{
			_componentContainer = new ComponentContainer();
		}

		private void Start()
		{
			CreateGamePlayComponent();
			CreateInputSystem();
			CreateJoystick();
			CreatePlayerAnimationHandler();
			CreateMovementComponent();

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

		private void CreateJoystick()
		{
			_joystick = FindObjectOfType<Joystick>();
			_componentContainer.AddComponent("Joystick", _joystick);
		}

		private void CreatePlayerAnimationHandler()
		{
			_playerAnimationHandler = new PlayerAnimationHandler();
			_componentContainer.AddComponent("PlayerAnimationHandler", _playerAnimationHandler);
		}

		private void CreateMovementComponent()
		{
			_playerMovementComponent = FindObjectOfType<PlayerMovementComponent>();
			_componentContainer.AddComponent("PlayerMovementComponent", _playerMovementComponent);
		}

		private void InitializeComponents()
		{
			_inputSystem.Initilaze(_componentContainer);
			_gamePlayComponent.Initilaze(_componentContainer);
			_playerAnimationHandler.Initilaze(_componentContainer);
			_playerMovementComponent.Initilaze(_componentContainer);
		}

		private void CreateAppState() => _appState = new AppState(_componentContainer);
	}
}
