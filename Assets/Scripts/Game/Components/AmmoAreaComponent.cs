namespace BaseDefense.Component
{
	using BaseDefense.Base.Component;
	using UnityEngine;

	public class AmmoAreaComponent : BaseCollider
	{
		public override void Initilaze(ComponentContainer componentContainer)
		{
			Debug.Log("<color=green>AmmoAreaComponent initialized!</color>");
			base.Initilaze(componentContainer);

			Init();
		}

		protected override void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag(PLAYER_TRÝGGER))
			{
				_stateEventContainer.OnAmmoArea();
			}
		}

		protected override void OnTriggerExit(Collider other)
		{
			if (other.CompareTag(PLAYER_TRÝGGER))
			{
				_stateEventContainer.ReturnUpgradeIdle();
			}
		}
	}
}