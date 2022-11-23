namespace BaseDefense.Base.ObjectPool
{
	using BaseDefense.Component;
	using UnityEngine;

	public class SampleObject : MonoBehaviour, IPoolable
	{
		public void Activate()
		{
			gameObject.SetActive(true);
		}

		public void Deactivate()
		{
			gameObject.SetActive(false);	
		}

		public void Initialize()
		{
			//TODO: get components
			//TODO: set initial colors
		}
	}

}
