namespace BaseDefense.Component
{
	using BaseDefense.Base.Component;
	using UnityEngine;

	public class AmmoCollectorComponent : BaseCollider
	{
		public override void Initilaze(ComponentContainer componentContainer)
		{
			Debug.Log("<color=green>AmmoCollectorComponent initialized!</color>");
			base.Initilaze(componentContainer);

			Init();
		}

		protected override void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag(PLAYER_TR�GGER))
			{				
				_stateEventContainer.OnAmmoCollect();
			}
		}

		protected override void OnTriggerExit(Collider other)
		{
			if (other.CompareTag(PLAYER_TR�GGER))
			{
				_stateEventContainer.ReturnUpgradeIdle();
			}
		}


	}

}