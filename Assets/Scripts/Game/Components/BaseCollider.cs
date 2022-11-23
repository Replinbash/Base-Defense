namespace BaseDefense.Component
{
	using BaseDefense.Base.Component;
	using UnityEngine;

	[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
	public class BaseCollider : MonoBehaviour, IInitializable
	{
		[SerializeField] protected Vector3 _boxSize;

		protected BoxCollider _boxCollider;
		protected Rigidbody _rigidbody;

		public void Init()
		{
			_boxCollider = GetComponent<BoxCollider>();
			_rigidbody = GetComponent<Rigidbody>();
			SetCollider();
		}

		protected void SetCollider()
		{
			_boxCollider.size = _boxSize;
			_boxCollider.isTrigger = true;
			_rigidbody.isKinematic = true;
		}

		protected void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireCube(transform.position, _boxSize);
		}
	}

}
