namespace BaseShooter.Component
{
	using BaseShooter.Base.Component;
	using Cinemachine;
	using UnityEngine;

	public class GameCamera : MonoBehaviour, IComponent, IDestructible, ICamera, IInitializable
	{
		private CameraSwitcher _cameraSwitcher;
		private CinemachineVirtualCamera _camera;

		public void Initilaze(ComponentContainer componentContainer)
		{
			_cameraSwitcher = componentContainer.GetComponent("CameraSwitcher") as CameraSwitcher;
			_camera = GetComponent<CinemachineVirtualCamera>();

			Init();			
		}

		public void Init()
		{			
			RegisterCamera(_camera);
		}

		public void OnDestruct()
		{
			UnregisterCamera(_camera);	
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

