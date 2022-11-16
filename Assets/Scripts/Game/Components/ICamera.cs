using Cinemachine;

namespace BaseShooter.Component
{
	public interface ICamera
	{
		void RegisterCamera(CinemachineVirtualCamera cam);
		void UnregisterCamera(CinemachineVirtualCamera cam);
	}
}
