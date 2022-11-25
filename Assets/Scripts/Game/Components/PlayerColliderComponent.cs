namespace BaseDefense.Component
{
	using UnityEngine;
	using BaseDefense.Base.Component;

	public class PlayerColliderComponent : MonoBehaviour, IComponent
	{
		private StateEventContainer _stateEventContainer;

		private const string BASE_TR�GGER = "InBaseTrigger";
		private const string BASE_OUT_TR�GGER = "BaseOutTrigger";

		public void Initilaze(ComponentContainer componentContainer)
		{
			Debug.Log("<color=green>PlayerColliderComponent initialized!</color>");

			_stateEventContainer = componentContainer.GetComponent("StateEventContainer") as StateEventContainer;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag(BASE_TR�GGER))
			{
				_stateEventContainer.OnUpgradeState();
			}

			if (other.CompareTag(BASE_OUT_TR�GGER))
			{
				_stateEventContainer.OnFightState();
			}


		}		
	}
}
