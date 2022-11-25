namespace BaseDefense.Component
{
	using UnityEngine;
	using BaseDefense.Base.Component;

	public class PlayerColliderComponent : MonoBehaviour, IComponent
	{
		private StateEventContainer _stateEventContainer;

		private const string BASE_TRÝGGER = "InBaseTrigger";
		private const string BASE_OUT_TRÝGGER = "BaseOutTrigger";

		public void Initilaze(ComponentContainer componentContainer)
		{
			Debug.Log("<color=green>PlayerColliderComponent initialized!</color>");

			_stateEventContainer = componentContainer.GetComponent("StateEventContainer") as StateEventContainer;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag(BASE_TRÝGGER))
			{
				_stateEventContainer.OnUpgradeState();
			}

			if (other.CompareTag(BASE_OUT_TRÝGGER))
			{
				_stateEventContainer.OnFightState();
			}


		}		
	}
}
