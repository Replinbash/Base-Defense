namespace BaseDefense.Base.ObjectPool
{
	public interface IPoolable
	{
		void Activate();
		void Deactivate();
		void Initialize();
	}
}

