namespace BaseDefense.Base.ObjectPool
{
	using UnityEngine;

	public class SampleObjectTest : MonoBehaviour
	{
		private Pool<SampleObject> pool;
		private SampleObject sampleOject;
		private const string SOURCE_OBJECT_PATH = "Prefabs/SourceObject";

		void Start()
		{
			pool = new Pool<SampleObject>(SOURCE_OBJECT_PATH);
			pool.PopulatePool(10);
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.W))
			{
				sampleOject = pool.GetObjectFromPool();
			}

			if (Input.GetKeyDown(KeyCode.S))
			{
				pool.AddObjectPool(sampleOject);	
			}
		}
	}

}
