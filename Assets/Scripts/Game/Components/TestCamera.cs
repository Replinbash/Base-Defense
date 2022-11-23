namespace BaseDefense.Component
{
	using BaseDefense.Base.Component;
	using UnityEngine;

	public class TestCamera : BaseCollider, IComponent
	{
		private CameraSwitcher _cameraSwitcher;
		private CameraContainer _cameraContainer;
		private StateEventContainer _stateEventContainer;

		public void Initilaze(ComponentContainer componentContainer)
		{
			Debug.Log("<color=green>TestCamera initialized!</color>");
			_cameraSwitcher = componentContainer.GetComponent("CameraSwitcher") as CameraSwitcher;
			_cameraContainer = componentContainer.GetComponent("CameraContainer") as CameraContainer;
			_stateEventContainer = componentContainer.GetComponent("StateEventContainer") as StateEventContainer;

			Init();
		}		

		private void OnTriggerEnter(Collider other)
		{			
			if (other.CompareTag("Player"))
			{
				if (!_cameraSwitcher.IsActiveCamera(_cameraContainer.TurretCamera))
				{
					_cameraSwitcher.SwitchCamera(_cameraContainer.TurretCamera);
					_stateEventContainer.TurretControl();
				}
			}
		}
		
		private void OnTriggerExit(Collider other)
		{			
			if (other.CompareTag("Player"))
			{
				if (!_cameraSwitcher.IsActiveCamera(_cameraContainer.GameCamera))
				{
					_cameraSwitcher.SwitchCamera(_cameraContainer.GameCamera);
					_stateEventContainer.ReturnUpgradeIdle();
				}
			}
		}
	}

}