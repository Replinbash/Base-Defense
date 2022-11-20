namespace BaseDefense.Component
{
	using BaseDefense.Base.Component;
	using BaseDefense.Base.ObjectPool;
	using BaseDefense.Interface;
	using UnityEngine;

	public class Bullet : MonoBehaviour, IPoolable, IUpdatable
	{
		[SerializeField] private float _bulletSpeed;

		private IBulletFactory _bulletFactory;
		private Rigidbody _rigidbody;

		public void Initialize()
		{
			_rigidbody = GetComponent<Rigidbody>();
		}

		public void CallUptade()
		{
			_rigidbody.AddRelativeForce(Vector3.forward * _bulletSpeed, ForceMode.Force);
		}

		// TODO: Set Damage and Add pool bullet
		//private void OnTriggerEnter(Collider other)
		//{
		//	if (other.CompareTag("Enemy"))
		//	{
				
		//	}
		//}

		public void Activate()
		{
			gameObject.SetActive(true);
		}

		public void Deactivate()
		{
			gameObject.SetActive(false);
		}

		public void InjectBulletFactory(BulletFactory bulletFactory)
		{
			if (_bulletFactory == null)
			{
				return;
			}

			_bulletFactory = bulletFactory;
		}

		
	}

}