namespace BaseDefense.Component
{
	using BaseDefense.Base.ObjectPool;
	using UnityEngine;

	public class TurretAmmo : MonoBehaviour, IPoolable
	{
		public void Initialize()
		{
			
		}

		public void Activate()
		{
			gameObject.SetActive(true);	
		}

		public void Deactivate()
		{
			gameObject.SetActive(false);
		}

			
	}

}
