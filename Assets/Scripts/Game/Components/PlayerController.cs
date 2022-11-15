namespace BaseShooter.Component
{
	using BaseShooter.Base.Component;
	using BaseShooter.Enum;
	using System;
	using UnityEngine;

	public class PlayerController : MonoBehaviour, IUpdatable, IInitializable, IDestructible
	{
		private ComponentContainer _compenentContainer;
		private InputSystem _inputSystem;
		private PlayerAnimationComponent _playerAnimationComponent;

		public void Init()
		{
			_inputSystem = _compenentContainer.GetComponent("InputSystem") as InputSystem;
			_playerAnimationComponent = _compenentContainer.GetComponent("PlayerAnimationComponent") as PlayerAnimationComponent;

			InjectInputSystem();			
		}

		public void CallUptade()
		{
			_inputSystem.CallUptade();
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
			Debug.Log("Mouse's last position: " + Input.mousePosition);
			_playerAnimationComponent.ChangeAnimationState(true);
		}

		private void OnExit()
		{
			Debug.Log("Touch Exit");
			_playerAnimationComponent.ChangeAnimationState(false);
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
