namespace BaseDefense.State
{
	using BaseDefense.Base.Component;
	using BaseDefense.HFSM;
	using UnityEngine;

	public class WeaponShopState : StateMachine
	{
		public WeaponShopState(ComponentContainer componentContainer)
		{

		}

		protected override void OnEnter()
		{
			Debug.Log("Weapon Shop State OnEnter!");
		}

		protected override void OnUpdate()
		{
			Debug.Log("Weapon Shop State OnUpdate!");
		}

		protected override void OnExit()
		{
			Debug.Log("Weapon Shop State OnExit!");
		}

	}
}