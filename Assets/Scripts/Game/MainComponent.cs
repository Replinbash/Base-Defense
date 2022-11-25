namespace BaseDefense
{
	using BaseDefense.Base.Component;
	using BaseDefense.Component;
	using BaseDefense.State;
	using System;
	using UnityEngine;

	public class MainComponent : MonoBehaviour
	{
		private AppState _appState;
		private ComponentContainer _componentContainer;
		private StateEventContainer _stateEventContainer;
		private GamePlayComponent _gamePlayComponent;
		private InputSystem _inputSystem;
		private PlayerAnimationHandler _playerAnimationHandler;
		private PlayerMovementComponent _playerMovementComponent;
		private PlayerColliderComponent _playerColliderComponent;
		private Joystick _joystick;
		private CameraSwitcher _cameraSwitcher;
		private CameraContainer _cameraContainer;
		private AmmoCollectorComponent _ammoCollectorComponent;
		private AmmoAreaComponent _ammoAreaComponent;

		// Test Scripts
		private TestCamera _testCamera;
		private AmmoStackTest _ammoStackTest;


		private void Awake()
		{
			_componentContainer = new ComponentContainer();
		}

		private void Start()
		{
			CreateGamePlayComponent();
			CreateGameEventContainer();
			CreateInputSystem();
			CreateJoystick();
			CreatePlayerAnimationHandler();
			CreatePlayerMovementComponent();
			CreatePlayerColliderComponent();
			CreateCameraSwitcher();
			CreateCameraContainer();
			CreateAmmoCollector();
			CreateAmmoArea();

			CreateTestCamera();
			CreateAmmoStackTest();

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

		private void CreateGameEventContainer()
		{
			_stateEventContainer = new StateEventContainer();
			_componentContainer.AddComponent("StateEventContainer", _stateEventContainer);
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

		private void CreatePlayerMovementComponent()
		{
			_playerMovementComponent = FindObjectOfType<PlayerMovementComponent>();
			_componentContainer.AddComponent("PlayerMovementComponent", _playerMovementComponent);
		}

		private void CreatePlayerColliderComponent()
		{
			_playerColliderComponent = FindObjectOfType<PlayerColliderComponent>();
			_componentContainer.AddComponent("PlayerColliderComponent", _playerColliderComponent);

		}

		private void CreateCameraSwitcher()
		{
			_cameraSwitcher = new CameraSwitcher();
			_componentContainer.AddComponent("CameraSwitcher", _cameraSwitcher);
		}

		private void CreateCameraContainer()
		{
			_cameraContainer = FindObjectOfType<CameraContainer>();
			_componentContainer.AddComponent("CameraContainer", _cameraContainer);
		}

		private void CreateAmmoCollector()
		{
			_ammoCollectorComponent = FindObjectOfType<AmmoCollectorComponent>();
			_componentContainer.AddComponent("AmmoCollectorComponent", _ammoCollectorComponent);
		}

		private void CreateAmmoArea()
		{
			_ammoAreaComponent = FindObjectOfType<AmmoAreaComponent>();
			_componentContainer.AddComponent("AmmoAreaComponent", _ammoAreaComponent);
		}

		private void CreateTestCamera()
		{
			_testCamera = FindObjectOfType<TestCamera>();
			_componentContainer.AddComponent("TestCamera", _testCamera);
		}		

		private void CreateAmmoStackTest()
		{
			_ammoStackTest = FindObjectOfType<AmmoStackTest>();
			_componentContainer.AddComponent("AmmoStackTest", _ammoStackTest);
		}

		private void InitializeComponents()
		{
			_inputSystem.Initilaze(_componentContainer);
			_gamePlayComponent.Initilaze(_componentContainer);
			_stateEventContainer.Initilaze(_componentContainer);
			_playerAnimationHandler.Initilaze(_componentContainer);
			_playerMovementComponent.Initilaze(_componentContainer);
			_playerColliderComponent.Initilaze(_componentContainer);
			_cameraSwitcher.Initilaze(_componentContainer);	
			_cameraContainer.Initilaze(_componentContainer);
			_ammoCollectorComponent.Initilaze(_componentContainer);
			_ammoAreaComponent.Initilaze(_componentContainer);

			_testCamera.Initilaze(_componentContainer);
			_ammoStackTest.Initilaze(_componentContainer);
		}

		private void CreateAppState() => _appState = new AppState(_componentContainer);
	}
}
