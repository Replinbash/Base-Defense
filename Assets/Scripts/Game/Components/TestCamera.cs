namespace BaseShooter.Component
{
	using BaseShooter.Base.Component;
	using Cinemachine;
	using UnityEngine;

	[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
	public class TestCamera : MonoBehaviour, IComponent
	{
		[SerializeField] private CinemachineVirtualCamera _turretCam, _gameCam;
		[SerializeField] private Vector3 _boxSize;

		private BoxCollider _boxCollider;
		private Rigidbody _rigidbody;
		private CameraSwitcher _cameraSwitcher;

		public void Initilaze(ComponentContainer componentContainer)
		{
			Debug.Log("<color=green>TestCamera initialized!</color>");
			_cameraSwitcher = componentContainer.GetComponent("CameraSwitcher") as CameraSwitcher;
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
			{;
				if (!_cameraSwitcher.IsActiveCamera(_turretCam))
				{
					_cameraSwitcher.SwitchCamera(_turretCam);
				}
			}
		}
		
		private void OnTriggerExit(Collider other)
		{
			
			if (other.CompareTag("Player"))
			{
				if (!_cameraSwitcher.IsActiveCamera(_gameCam))
				{
					_cameraSwitcher.SwitchCamera(_gameCam);
				}
			}
		}
	}

}