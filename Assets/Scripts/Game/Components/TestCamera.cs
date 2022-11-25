namespace BaseDefense.Component
{
	using BaseDefense.Base.Component;
	using UnityEngine;

	public class TestCamera : BaseCollider, IComponent
	{
		private CameraSwitcher _cameraSwitcher;
		private CameraContainer _cameraContainer;

		public override void Initilaze(ComponentContainer componentContainer)
		{
			Debug.Log("<color=green>TestCamera initialized!</color>");
			base.Initilaze(componentContainer);
			_cameraSwitcher = componentContainer.GetComponent("CameraSwitcher") as CameraSwitcher;
			_cameraContainer = componentContainer.GetComponent("CameraContainer") as CameraContainer;

			Init();
		}

		protected override void OnTriggerEnter(Collider other)
		{			
			if (other.CompareTag(PLAYER_TRÝGGER))
			{
				if (!_cameraSwitcher.IsActiveCamera(_cameraContainer.TurretCamera))
				{
					_cameraSwitcher.SwitchCamera(_cameraContainer.TurretCamera);
				}
					_stateEventContainer.TurretControl();
			}
		}

		protected override void OnTriggerExit(Collider other)
		{			
			if (other.CompareTag(PLAYER_TRÝGGER))
			{
				if (!_cameraSwitcher.IsActiveCamera(_cameraContainer.GameCamera))
				{
					_cameraSwitcher.SwitchCamera(_cameraContainer.GameCamera);
				}
					_stateEventContainer.ReturnUpgradeIdle();
			}
		}
	}

}