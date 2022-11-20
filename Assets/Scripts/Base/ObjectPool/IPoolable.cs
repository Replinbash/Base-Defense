namespace BaseDefense.Base.ObjectPool
{
	using BaseDefense.Component;
	public interface IPoolable
	{
		void Activate();
		void Deactivate();
		void Initialize();
		void InjectBulletFactory(BulletFactory bulletFactory);

	}
}

