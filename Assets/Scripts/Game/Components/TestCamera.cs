namespace BaseDefense.Component
{
	using BaseDefense.Base.Component;
	using Cinemachine;
	using UnityEngine;

	[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
	public class TestCamera : MonoBehaviour, IComponent
	{
		[SerializeField] private Vector3 _boxSize;

		private BoxCollider _boxCollider;
		private Rigidbody _rigidbody;

		private CameraSwitcher _cameraSwitcher;
		private CameraContainer _cameraContainer;

		public void Initilaze(ComponentContainer componentContainer)
		{
			Debug.Log("<color=green>TestCamera initialized!</color>");
			_cameraSwitcher = componentContainer.GetComponent("CameraSwitcher") as CameraSwitcher;
			_cameraContainer = componentContainer.GetComponent("CameraContainer") as CameraContainer;
		}

		void Start()
		{
			_boxCollider = GetComponent<BoxCollider>();
			_rigidbody = GetComponent<Rigidbody>();
			_boxCollider.isTrigger = true;
			_boxCollider.size = _boxSize;

			_rigidbody.isKinematic = true;
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.green;	
			Gizmos.DrawWireCube(transform.position, _boxSize);	
		}

		private void OnTriggerEnter(Collider other)
		{			
			if (other.CompareTag("Player"))
			{
				if (!_cameraSwitcher.IsActiveCamera(_cameraContainer.TurretCamera))
				{
					_cameraSwitcher.SwitchCamera(_cameraContainer.TurretCamera);
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
				}
			}
		}
	}

}