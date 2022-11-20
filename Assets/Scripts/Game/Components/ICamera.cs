using Cinemachine;

namespace BaseDefense.Interface
{
	public interface ICamera
	{
		void RegisterCamera(CinemachineVirtualCamera cam);
		void UnregisterCamera(CinemachineVirtualCamera cam);
	}
}
