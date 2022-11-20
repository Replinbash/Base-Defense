namespace BaseDefense.Component
{
	using BaseDefense.Base.Component;
	using BaseDefense.Base.ObjectPool;
	using BaseDefense.Interface;
	using System.Collections.Generic;
	using UnityEngine;

	public class BulletFactory : IBulletFactory, IDestructible
	{
		private Pool<Bullet> _pool;
		private const string SOURCE_OBJECT_PATH = "Prefabs/GunBullet";
		private List<Bullet> _activeBullets = new List<Bullet>();

		public BulletFactory()
		{
			_pool = new Pool<Bullet>(SOURCE_OBJECT_PATH);
			_pool.PopulatePool(20);
		}

		public void UptadeBullets()
		{
			foreach (var activeBullet in _activeBullets)
			{
				if (activeBullet.isActiveAndEnabled)
				{
					activeBullet.CallUptade();
				}
			}
		}

		public Bullet GetBullet()
		{
			var bullet = _pool.GetObjectFromPool();
			bullet.InjectBulletFactory(this);

			if (!_activeBullets.Contains(bullet))
			{
				_activeBullets.Add(bullet);
			}

			return bullet;
		}


		public void AdBulletPool(Bullet bullet)
		{
			_pool.AddObjectPool(bullet);
		}

		public void OnDestruct()
		{
			for (int i = 0; i < _activeBullets.Count; i++)
			{
				AdBulletPool(_activeBullets[i]);
			}

			_activeBullets.Clear();
		}
	}
}

