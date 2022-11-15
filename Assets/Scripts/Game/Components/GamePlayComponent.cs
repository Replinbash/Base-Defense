namespace BaseShooter.Component
{
	using BaseShooter.Base.Component;
	using UnityEngine;

	public class GamePlayComponent : MonoBehaviour, IComponent, IUpdatable
	{
		[SerializeField] private PlayerController _player;
		private ComponentContainer _componentContainer;

		public void Initilaze(ComponentContainer componentContainer)
		{
			Debug.Log("<color=green>GamePlayComponent initialized!</color>");
			_componentContainer = componentContainer;

			CreatePlayer();
		}

		public void CallUptade()
		{
			Debug.Log("<color=cyan>GamePlayComponent is on!</color>");
			_player.CallUptade();
		}

		private void FixedUpdate()
		{
			_player.CallFixedUptade();	
		}

		private void CreatePlayer()
		{
			_player.ComponentContaier = _componentContainer;
			_player.Init();
		}


	}

}
