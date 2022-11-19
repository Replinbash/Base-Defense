namespace BaseDefense.Base.ObjectPool
{
	using System.Collections.Generic;
	using UnityEngine;

	public class Pool<ObjectType> where ObjectType : IPoolable
	{
		protected Queue<ObjectType> pool;
		private string _sourceObjectPath;
		private GameObject _parentObject;

		private Pool() { }

		public Pool(string sourceObjectPath)
		{
			_sourceObjectPath = sourceObjectPath;
			_parentObject = new GameObject(sourceObjectPath);
		}

		public void PopulatePool(int initialPoolSize)
		{
			pool = new Queue<ObjectType>();

			for (int i = 0; i < initialPoolSize; i++)
			{
				GenerateObject();
			}
		}

		private void GenerateObject()
		{
			var sourceObject = Resources.Load<GameObject>(_sourceObjectPath);
			var poolableObject = GameObject.Instantiate(sourceObject, _parentObject.transform);

			if (poolableObject.TryGetComponent<ObjectType>(out ObjectType objectType))
			{
				objectType.Initialize();
				objectType.Deactivate();
				pool.Enqueue(objectType);
			}
			else
			{
				Debug.LogError("Source prefab does not contain any IPoolable");
			}			
		}

		public void AddObjectPool(ObjectType poolable)
		{
			poolable.Deactivate();
			pool.Enqueue(poolable);	
		}

		public ObjectType GetObjectFromPool()
		{
			if (pool.Count == 0)
			{
				GenerateObject();
			}

			var pooledObject = pool.Dequeue();	
			pooledObject.Activate();	
			return pooledObject;
		}

		public Queue<ObjectType> GetPool => pool;
	}
}
