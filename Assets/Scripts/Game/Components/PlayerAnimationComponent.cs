namespace BaseShooter.Component
{
	using BaseShooter.Base.Component;
	using BaseShooter.Enum;
	using UnityEngine;
	using UnityEngine.Events;

	public class PlayerAnimationComponent : MonoBehaviour, IComponent, IUpdatable, IInitializable
	{
		public event UnityAction OnFightAnimation = delegate { };
		public event UnityAction OnRunAnimation = delegate { };
		private PlayerStateTriggers _playerState;
		private Animator _animator;

		public void Initilaze(ComponentContainer componentContainer)
		{
			Debug.Log("<color=green>PlayerAnimationComponent initialized!</color>");
			Init();
		}

		public void Init()
		{
			_animator = GetComponent<Animator>();
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

			}
		}

			

		public void CallUptade()
		{
			throw new System.NotImplementedException();
		}

		public void ChangeAnimationState(bool isInvoke)
		{
			_animator.SetBool(_playerState.ToString(), isInvoke);
		}

		
	}
}