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
				Debug.Log("Touch Enter");
				OnScreenTouchEnter?.Invoke();
			}

			if (Input.GetMouseButton(0))
			{
				Debug.Log("Mouse's last position: " + Input.mousePosition);

				OnScreenTouch?.Invoke();
			}

			if (Input.GetMouseButtonUp(0))
			{
				Debug.Log("Touch Exit");
				OnScreenTouchExit?.Invoke();
			}
		}		
	}
}
