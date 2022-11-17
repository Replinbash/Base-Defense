namespace BaseShooter.Component
{
	using BaseShooter.Base.Component;
	using BaseShooter.Enum;
	using UnityEngine;
	using UnityEngine.Events;

	public class PlayerAnimationHandler : IComponent, IUpdatable, IInitializable
	{
		private PlayerStateTriggers _playerState;
		private Animator _animator;

		public void Initilaze(ComponentContainer componentContainer)
		{
			Debug.Log("<color=green>PlayerAnimationHandler initialized!</color>");
			Init();
		}

		public void Init()
		{
			
		}
		public void CallUptade()
		{

		}

		public void SetPlayerState(PlayerStateTriggers playerState)
		{
			switch (playerState)
			{
				case PlayerStateTriggers.Run:
					_playerState = PlayerStateTriggers.Run;
					break;
				case PlayerStateTriggers.Fight:
					_playerState = PlayerStateTriggers.Fight;
					break;
				case PlayerStateTriggers.Death:
					_playerState = PlayerStateTriggers.Death;
					break;
			}
		}		

		public void HandleAnimation(bool isInvoke)
		{
			_animator.SetBool(_playerState.ToString(), isInvoke);
		}

		public Animator Animator
		{
			get => _animator;
			set => _animator = value;
		}


	}
}