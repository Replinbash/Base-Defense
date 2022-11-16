namespace BaseShooter.Component
{
	using BaseShooter.Base.Component;
	using UnityEngine;

	[RequireComponent(typeof(Rigidbody))]
	public class PlayerMovementComponent : MonoBehaviour, IComponent, IFixedUpdatable, IInitializable, IDestructible
	{
		[SerializeField] private float _moveSpeed = 5f;

		private PlayerAnimationHandler _playerAnimationHandler;
		private PlayerController _playerController;
		private Joystick _joystick;
		private Rigidbody _rigidbody;
		private Animator _animator;		
	
		private bool _isTouch;

		public void Initilaze(ComponentContainer componentContainer)
		{
			Debug.Log("<color=green>PlayerMovementComponent initialized!</color>");
			_playerAnimationHandler = componentContainer.GetComponent("PlayerAnimationHandler") as PlayerAnimationHandler;
			_joystick = componentContainer.GetComponent("Joystick") as Joystick;
			_playerController = GetComponent<PlayerController>();
			_rigidbody = GetComponent<Rigidbody>();
			_animator = GetComponent<Animator>();

			Init();			
		}

		public void Init()
		{					
			_playerAnimationHandler.Animator = _animator;
			_playerController.OnMovementEvent += SetMovement;
		}

		public void SetMovement(bool isTouch) => _isTouch = isTouch;
		
		public void CallFixedUptade()
		{
			if (_isTouch)
			{
				HandleMovement();
			}

			else 
			{
				CancelMovement();	
			}
		}

		private void HandleMovement()
		{
			Vector3 moveDirection = Vector3.zero;
			moveDirection.x = _joystick.Horizontal * _moveSpeed;
			moveDirection.z = _joystick.Vertical * _moveSpeed;

			_rigidbody.velocity = new Vector3(moveDirection.x, _rigidbody.velocity.y, moveDirection.z);

			if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
			{
				transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
				_playerAnimationHandler.HandleAnimation(true);
			}
			else if (_joystick.Horizontal == 0 && _joystick.Vertical == 0)
			{
				CancelMovement();
			}
		}

		private void CancelMovement()
		{
			_rigidbody.velocity = Vector3.zero;
			_rigidbody.angularVelocity = Vector3.zero;
			_playerAnimationHandler.HandleAnimation(false);
		}

		public void OnDestruct()
		{
			_playerController.OnMovementEvent -= SetMovement;
		}
	}
}


