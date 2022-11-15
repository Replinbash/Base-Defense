namespace BaseShooter.Component
{
	using BaseShooter.Base.Component;
	using UnityEngine;
	using UnityEngine.Events;

	public class InputSystem : IComponent, IUpdatable
	{
		public event UnityAction OnScreenTouchEnter = delegate { };
		public event UnityAction OnScreenTouch = delegate { };
		public event UnityAction OnScreenTouchExit = delegate { };

		public void Initilaze(ComponentContainer componentContainer)
		{
			Debug.Log("<color=green>InputSystem Component Initialized!</color>");
		}

		public void CallUptade()
		{
			if (Input.GetMouseButtonDown(0))
			{				
				OnScreenTouchEnter?.Invoke();
			}

			if (Input.GetMouseButton(0))
			{	
				OnScreenTouch?.Invoke();
			}

			if (Input.GetMouseButtonUp(0))
			{				
				OnScreenTouchExit?.Invoke();
			}
		}		
	}
}
