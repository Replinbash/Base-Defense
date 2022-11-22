namespace BaseDefense.State
{
	public enum StateTriggers
	{
		// Main States
		NONE,
		LOADING_COMPLETED,
		PLAY_GAME_REQUEST,
		REPLAY_GAME_REQUEST,
		GO_TO_BATTLE_REQUEST,
		GO_TO_UPGRADE_REQUEST,

		// Upgrade States
		RETURN_UPGRADE_IDLE_STATE,
		BASE_AREA_UPGRADE_REQUEST,
		WEAPON_SHOP_REQUEST,
		PLAYER_UPGRADES_REQUEST,
		SOLD�ER_UPGRADES_REQUEST,
		TURRET_CONTROL_REQUEST,
		TURRET_AMMO_COLLECT_REQUEST,
		TURRET_SOLD�ER_REQUEST,
		TURRET_AMMO_AREA_REQUEST,
		UPGRADE_TO_M�NER_REQUEST,
		UPGRADE_TO_SOLD�ER_REQUEST,
		GEM_COLLECT_REQUEST,
		MONEY_WORKER_REQUEST,
		AMMO_WORKER_REQUEST,
		SOLD�ER_ATTACK_ORDER_REQUEST,

		// Battle States
		RETURN_BATTLE_IDLE_REQUEST,
		MONEY_COLLECT_REQUEST,
		HELP_TO_SURV�VOR_REQUEST,
		SET_TRAP_REQUEST,
		ENEMY_AREA_UPGRADES_REQUEST
	}

}