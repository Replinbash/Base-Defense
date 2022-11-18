using Cinemachine;

namespace BaseDefense.Component
{
	public interface ICamera
	{
		void RegisterCamera(CinemachineVirtualCamera cam);
		void UnregisterCamera(CinemachineVirtualCamera cam);
	}
}
