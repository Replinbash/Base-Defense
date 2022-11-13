namespace BaseShooter.Component
{
	using BaseShooter.Base.Component;
	using UnityEngine;

	public class GamePlayComponent : MonoBehaviour, IComponent, IUpdatable
	{
		[SerializeField] private PlayerController _player;
		private InputSystem _inputSystem;

		public void Initilaze(ComponentContainer componentContainer)
		{
			Debug.Log("<color=green>GamePlayComponent initialized!</color>");
			_inputSystem = componentContainer.GetComponent("InputSystem") as InputSystem;

		}

		public void CallUptade()
		{
			Debug.Log("<color=cyan>GamePlayComponent is on!</color>");
			_inputSystem.CallUptade();
			_player.CallUptade();
		}

		public void OnEnter()
		{

		}

		
	}

}
