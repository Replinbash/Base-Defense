namespace BaseDefense.Component
{
	using UnityEngine;
	using BaseDefense.Base.Component;
	using UnityEngine.Events;

	public class GameEventContainer : IComponent
	{
		public void Initilaze(ComponentContainer componentContainer)
		{
			Debug.Log("<color=green>GameEventContainer initialized!</color>");
		}

		public event UnityAction TurretControlRequest = delegate { };	

		public void TurretControl() => TurretControlRequest?.Invoke();
		
	}
}