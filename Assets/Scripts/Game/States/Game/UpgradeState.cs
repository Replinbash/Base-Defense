namespace BaseShooter.State
{
	using BaseShooter.Base.Component;
	using BaseShooter.Component;
	using BaseShooter.Enum;
	using BaseShooter.HFSM;
	using System;
	using UnityEngine;
	using UnityEngine.Events;

	public class UpgradeState : StateMachine
	{
		private PlayerAnimationComponent _playerAnimationComponent;

		public UpgradeState(ComponentContainer componentContainer)
		{
			_playerAnimationComponent = componentContainer.GetComponent("PlayerAnimationComponent") as PlayerAnimationComponent;
		}

		// TODO : Enter the run anim state
		protected override void OnEnter()
		{
			_playerAnimationComponent.SetPlayerState(PlayerStateTriggers.Run);
		}		

		protected override void OnExit()
		{
			Debug.Log("UpgradeState OnExit");
		}
	}

}
