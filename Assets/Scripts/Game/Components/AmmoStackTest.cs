namespace BaseDefense.Component
{
	using UnityEngine;
	using DG.Tweening;
	using System.Collections.Generic;
	using System;
	using Random = UnityEngine.Random;
	using BaseDefense.Base.Component;
	using Unity.VisualScripting.Antlr3.Runtime.Collections;
	using BaseDefense.State;

	public class AmmoStackTest : MonoBehaviour, IComponent
	{

		public List<TurretAmmo> StackList = new List<TurretAmmo>();

		[SerializeField] private GameObject ammoArea;

		[SerializeField] private AmmoStackData _data;
		[SerializeField] private TurretDepotAmmoData _zoneData;
		private TurretAmmoFactory _turretAmmoFactory;
		private GamePlayComponent _gamePlayComponent;
		private AmmoAreaComponent _ammoAreaComponent;

		private Tween tween;

		private int _maxAmmoCount = 0;
		private List<int> _capacity;
		private int _ammoDistance;
		private Vector3 direct = Vector3.zero;
		private Transform _stackParent;

		public void Initilaze(ComponentContainer componentContainer)
		{
			Debug.Log("<color=green>AmmoStackTest initialized!</color>");
			_gamePlayComponent = componentContainer.GetComponent("GamePlayComponent") as GamePlayComponent;
			_ammoAreaComponent = componentContainer.GetComponent("AmmoAreaComponent") as AmmoAreaComponent;

			_stackParent = _gamePlayComponent.Player.transform.GetChild(0).transform;
		}

		public void InjectAmmoBullet(TurretAmmoFactory turretAmmoFactory)
		{
			_turretAmmoFactory = turretAmmoFactory;
		}

		private void AddStack(TurretAmmo obj)
		{
			obj.transform.SetParent(_stackParent);
			StackObjPosition(obj);
			StackList.Add(obj);
		}

		/// <summary>
		/// Burada TurretAmmo Factoryden objeyi cekiyoruz.
		/// </summary>
		public void OnGetAmmo()
		{
			StackList.Capacity = _data.MaxAmmoCount;
			if (_maxAmmoCount < StackList.Capacity)
			{
				//var obj = PoolSignals.Instance.onGetPoolObject(PoolType.AmmoBox.ToString(), transform);
				TurretAmmo turretAmmo = _turretAmmoFactory.GetAmmo();
				AddStack(turretAmmo);
			}
		}

		public void DecreaseStack()
		{
			_maxAmmoCount--;
		}

		public TurretAmmo SendAmmoArea()
		{
			if (StackList.Count > 0)
			{
				int limit = StackList.Count;
				for (int i = 0; i < limit; i++)
				{
					var obj = StackList[0];
					StackList.RemoveAt(0);
					StackList.TrimExcess();
					obj.transform.parent = _ammoAreaComponent.transform.root;
					obj.transform.DOLocalMove(
						new Vector3(Random.Range(-0.5f, 1f), Random.Range(-0.5f, 1f), Random.Range(-0.5f, 1f)), 0.5f);
					obj.transform.DOLocalMove(new Vector3(0, 0.1f, 0), 0.5f).SetDelay(0.2f).OnComplete(() =>
					{
						_turretAmmoFactory.AddAmmoPool(obj);
					});
					_maxAmmoCount--;
				}
			}

			return null;
		}

		private void StackObjPosition(TurretAmmo obj)
		{			
			direct.y = StackList.Count % _data.AmmoLimitY * _data.OffsetY;
			direct.z = StackList.Count / (_data.AmmoLimitY * _data.AmmoLimitZ) * _data.OffsetX;
			direct.x = -(StackList.Count % (_data.AmmoLimitY * _data.AmmoLimitZ) / _data.AmmoLimitY * _data.OffsetZ);
			obj.transform.DOLocalRotate(Vector3.zero, 1f);
			obj.transform.DOLocalMove(new Vector3(direct.x, direct.y, direct.z), 0.5f);
			_maxAmmoCount++;
		}


	}

	[Serializable]
	public class AmmoStackData
	{
		public Vector3 AmmoInitPoint;
		public int MaxAmmoCount;
		[Range(0, 10)] public int AmmoLimitX;
		[Range(0, 10)] public int AmmoLimitY;
		[Range(0, 10)] public int AmmoLimitZ;

		[Range(0, 5)] public float OffsetX;
		[Range(0, 5)] public float OffsetY;
		[Range(0, 5)] public float OffsetZ;
	}

	[Serializable]
	public class TurretDepotAmmoData
	{
		[Header("Capacity & Startpos")]
		public int MaxAmmoCapacity;
		public Vector3 AmmoInitPoint;

		[Space(10), Header("Counts")]
		[Space(2.5f), Range(0, 10)] public int AmmoLimitX;
		[Range(0, 10)] public int AmmoCountY;
		[Range(0, 10)] public int AmmoCountZ;

		[Space(10), Header("Offsets")]
		[Space(2.5f), Range(0, 5)] public float OffsetFactorX;
		[Range(0, 5)] public float OffsetFactorY;
		[Range(0, 5)] public float OffsetFactorZ;


	}
}