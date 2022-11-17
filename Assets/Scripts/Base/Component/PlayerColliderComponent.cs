namespace BaseShooter.Component
{
	using UnityEngine;
	using BaseShooter.Base.Component;
	using UnityEngine.Events;

	public class PlayerColliderComponent : MonoBehaviour, IComponent
	{
		public event UnityAction OnFightState = delegate { };
		public event UnityAction OnUpgradeState = delegate { };

		private const string _baseTrigger = "InBaseTrigger";
		private const string _baseOutTrigger = "BaseOutTrigger";

		public void Initilaze(ComponentContainer componentContainer)
		{
			Debug.Log("<color=green>PlayerColliderComponent initialized!</color>");
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag(_baseTrigger))
			{
				OnUpgradeState?.Invoke();
			}

			if (other.CompareTag(_baseOutTrigger))
			{
				OnFightState?.Invoke();
			}
		}

		
	}

}
