namespace BaseDefense.Component
{
	using BaseDefense.Base.Component;
	using BaseDefense.Base.ObjectPool;
	using System.Collections.Generic;
	
	public class TurretAmmoFactory : IDestructible
	{
		private Pool<TurretAmmo> _pool;
		private const string SOURCE_OBJECT_PATH = "Prefabs/TurretAmmo";
		private List<TurretAmmo> _activeAmmo = new List<TurretAmmo>();

		public TurretAmmoFactory()
		{
			_pool = new Pool<TurretAmmo>(SOURCE_OBJECT_PATH);
			_pool.PopulatePool(20);			 
		}

		public TurretAmmo GetAmmo()
		{
			var ammo = _pool.GetObjectFromPool();

			if (!_activeAmmo.Contains(ammo))
			{
				_activeAmmo.Add(ammo);	
			}

			return ammo;	
		}

		public void AddAmmoPool(TurretAmmo ammo)
		{
			_pool.AddObjectPool(ammo);	
		}

		public void OnDestruct()
		{
			for (int i = 0; i < _activeAmmo.Count; i++)
			{
				AddAmmoPool(_activeAmmo[i]);
			}

			_activeAmmo.Clear();	
		}
	}
}
