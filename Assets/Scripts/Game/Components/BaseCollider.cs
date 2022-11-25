namespace BaseDefense.Component
{
	using BaseDefense.Base.Component;
	using UnityEngine;

	[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
	public  class BaseCollider : MonoBehaviour, IInitializable, IComponent
	{
		[SerializeField] protected Vector3 _boxSize;
		protected BoxCollider _boxCollider;
		protected Rigidbody _rigidbody;
		protected const string PLAYER_TRÝGGER = "Player";
		protected StateEventContainer _stateEventContainer;

		public virtual void Initilaze(ComponentContainer componentContainer)
		{
			_stateEventContainer = componentContainer.GetComponent("StateEventContainer") as StateEventContainer;
		}

		public virtual void Init()
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

		protected virtual void OnTriggerEnter(Collider other)
		{
			
		}

		protected virtual void OnTriggerExit(Collider other)
		{
			
		}

	}

}
