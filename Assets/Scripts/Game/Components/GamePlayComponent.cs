namespace BaseDefense.Component
{
	using BaseDefense.Base.Component;
	using UnityEngine;

	public class GamePlayComponent : MonoBehaviour, IComponent, IUpdatable
	{
		[SerializeField] private PlayerController _player;
		private ComponentContainer _componentContainer;
		private BulletFactory _bulletFactory;

		public void Initilaze(ComponentContainer componentContainer)
		{
			Debug.Log("<color=green>GamePlayComponent initialized!</color>");
			_bulletFactory = new BulletFactory();
			_componentContainer = componentContainer;

			CreatePlayer();
		}

		public void CallUptade()
		{
			_player.CallUptade();
			_bulletFactory.UptadeBullets();

		}

		private void FixedUpdate()
		{
			_player.CallFixedUptade();	
		}

		private void CreatePlayer()
		{
			_player.ComponentContainer = _componentContainer;
			_player.Init();

		}

		// TODO: Inject replay game state
		public void RestartGame()
		{
			_player.OnDestruct();
			_bulletFactory.OnDestruct();
		}


	}

}
