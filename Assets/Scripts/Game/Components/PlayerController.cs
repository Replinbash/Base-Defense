namespace BaseShooter.Component
{
	using BaseShooter.Base.Component;
	using System;
	using UnityEngine;

	public class PlayerController : MonoBehaviour, IUpdatable, IInitializable, IDestructible
	{
		private InputSystem _inputSystemReference;

		public void Init()
		{

		}

		public void CallUptade()
		{

		}		

		public void InjectInputSystem(InputSystem inputSystem)
		{
			if (_inputSystemReference == null) 
			{
				_inputSystemReference= inputSystem;
			}

			_inputSystemReference.OnScreenTouchEnter += OnScreenTouchEnter;
			_inputSystemReference.OnScreenTouch += OnScreenTouch;
			_inputSystemReference.OnScreenTouchExit += OnScreenTouchExit;
		}

		private void OnScreenTouchExit()
		{
			throw new NotImplementedException();
		}

		private void OnScreenTouchEnter()
		{
			throw new NotImplementedException();
		}

		private void OnScreenTouch()
		{
			throw new NotImplementedException();
		}

		public void OnDestruct()
		{

		}

		
	}

}
