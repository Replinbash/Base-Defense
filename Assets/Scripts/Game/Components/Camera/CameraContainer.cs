namespace BaseDefense.Component
{
	using BaseDefense.Base.Component;
	using BaseDefense.Interface;
	using Cinemachine;
	using UnityEngine;

	public class CameraContainer : MonoBehaviour, IComponent, IDestructible, ICamera, IInitializable
	{
		[SerializeField] private CinemachineVirtualCamera _gameCamera;
		[SerializeField] private CinemachineVirtualCamera _turretCamera;
		
		private CameraSwitcher _cameraSwitcher;

		public CinemachineVirtualCamera GameCamera => _gameCamera;
		public CinemachineVirtualCamera TurretCamera => _turretCamera;

		public void Initilaze(ComponentContainer componentContainer)
		{
			Debug.Log("<color=green>CameraContainer initialized!</color>");
			_cameraSwitcher = componentContainer.GetComponent("CameraSwitcher") as CameraSwitcher;

			Init();			
		}

		public void Init()
		{			
			RegisterCamera(_gameCamera);
			RegisterCamera(_turretCamera);
		}

		public void OnDestruct()
		{
			UnregisterCamera(_gameCamera);	
			UnregisterCamera(_turretCamera);
		}

		public void RegisterCamera(CinemachineVirtualCamera cam)
		{
			_cameraSwitcher.Register(cam);
		}

		public void UnregisterCamera(CinemachineVirtualCamera cam)
		{
			_cameraSwitcher.Unregister(cam);
		}
	}
}

