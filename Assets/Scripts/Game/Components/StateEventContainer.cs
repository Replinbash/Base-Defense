namespace BaseDefense.Component
{
	using UnityEngine;
	using BaseDefense.Base.Component;
	using UnityEngine.Events;

	public class StateEventContainer : IComponent
	{
		// TODO: Add new states
		public void Initilaze(ComponentContainer componentContainer)
		{
			Debug.Log("<color=green>StateEventContainer initialized!</color>");
		}

		public event UnityAction ReturnUpgradeIdleEvent = delegate { };
		public event UnityAction TurretControlRequest = delegate { };	

		public void ReturnUpgradeIdle() => ReturnUpgradeIdleEvent?.Invoke();	
		public void TurretControl() => TurretControlRequest?.Invoke();
		
	}
}