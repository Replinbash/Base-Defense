namespace BaseDefense
{
	using BaseDefense.Base.Component;
	using BaseDefense.Component;
	using BaseDefense.State;
	using Unity.VisualScripting;
	using UnityEngine;

	public class MainComponent : MonoBehaviour
	{
		private AppState _appState;
		private ComponentContainer _componentContainer;
		private GamePlayComponent _gamePlayComponent;
		private InputSystem _inputSystem;
		private PlayerAnimationHandler _playerAnimationHandler;
		private PlayerMovementComponent _playerMovementComponent;
		private PlayerColliderComponent _playerColliderComponent;
		private Joystick _joystick;
		private CameraSwitcher _cameraSwitcher;
		private CameraContainer _cameraContainer;

		private TestCamera _testCamera;


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
			CreatePlayerMovementComponent();
			CreatePlayerColliderComponent();
			CreateCameraSwitcher();
			CreateCameraContainer();
			CreateTestCamera();


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

		private void CreateTestCamera()
		{
			_testCamera = FindObjectOfType<TestCamera>();
			_componentContainer.AddComponent("TestCamera", _testCamera);
		}		

		private void InitializeComponents()
		{
			_inputSystem.Initilaze(_componentContainer);
			_gamePlayComponent.Initilaze(_componentContainer);
			_playerAnimationHandler.Initilaze(_componentContainer);
			_playerMovementComponent.Initilaze(_componentContainer);
			_playerColliderComponent.Initilaze(_componentContainer);
			_cameraSwitcher.Initilaze(_componentContainer);	
			_cameraContainer.Initilaze(_componentContainer);	
			_testCamera.Initilaze(_componentContainer);
		}

		private void CreateAppState() => _appState = new AppState(_componentContainer);
	}
}
