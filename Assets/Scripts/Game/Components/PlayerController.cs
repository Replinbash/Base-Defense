namespace BaseShooter.Component
{
	using BaseShooter.Base.Component;
	using UnityEngine;
	using UnityEngine.Events;

	public class PlayerController : MonoBehaviour, IUpdatable, IFixedUpdatable, IInitializable, IDestructible
	{
		public event UnityAction<bool> OnMovementEvent = delegate { };

		private ComponentContainer _compenentContainer;
		private InputSystem _inputSystem;
		private PlayerMovementComponent _playerMovementComponent;

		public void Init()
		{
			_inputSystem = _compenentContainer.GetComponent("InputSystem") as InputSystem;			
			_playerMovementComponent = _compenentContainer.GetComponent("PlayerMovementComponent") as PlayerMovementComponent;			

			InjectInputSystem();			
		}

		public void CallUptade()
		{
			_inputSystem.CallUptade();
		}

		public void CallFixedUptade()
		{
			_playerMovementComponent.CallFixedUptade();
		}

		public void InjectInputSystem()
		{		
			_inputSystem.OnScreenTouchEnter += OnEnter;
			_inputSystem.OnScreenTouch += OnPlay;
			_inputSystem.OnScreenTouchExit += OnExit;
		}

		private void OnEnter()
		{
			Debug.Log("Touch Enter");
		}				

		private void OnPlay()
		{
			OnMovementEvent?.Invoke(true);
		}

		private void OnExit()
		{
			OnMovementEvent?.Invoke(false);
		}

		public void OnDestruct()
		{
			_inputSystem.OnScreenTouchEnter -= OnEnter;
			_inputSystem.OnScreenTouch -= OnPlay;
			_inputSystem.OnScreenTouchExit -= OnExit;
		}		

		public ComponentContainer ComponentContaier
		{
			get => _compenentContainer;
			set => _compenentContainer = value;
		}
	}

}
