namespace BaseShooter.HFSM
{
	using System;
	using System.Collections.Generic;
	using UnityEngine;

	public abstract class StateMachine
	{
		private Dictionary<Type, StateMachine> substates = new Dictionary<Type, StateMachine>();
		private Dictionary<int, StateMachine> transitions = new Dictionary<int, StateMachine>();

		private StateMachine parent;
		private StateMachine defaultSubState;
		private StateMachine currentSubState;		

		public void EnterStateMachine()
		{
			OnEnter();

			if (currentSubState ==null && defaultSubState !=null)
			{
				currentSubState= defaultSubState;
			}

			currentSubState?.EnterStateMachine();	
		}

		public void UpdateStateMachine()
		{
			OnUpdate();	
			currentSubState?.UpdateStateMachine();	
		}

		public void ExitStateMachine() 
		{
			currentSubState?.ExitStateMachine();	
			OnExit();
		}

		protected virtual void OnEnter() { }
		protected virtual void OnUpdate() { }
		protected virtual void OnExit() { }

		public void AddTransition(StateMachine sourceStateMachine, StateMachine targetStateMachine, int trigger)
		{
			if (sourceStateMachine.transitions.ContainsKey(trigger))
			{
				Debug.LogWarning("Duplicated transition! : " + trigger);
				return;
			}
			sourceStateMachine.transitions.Add(trigger, targetStateMachine);	
		}

		public void AddSubState(StateMachine subState)
		{
			if (substates.Count == 0)
			{
				defaultSubState = subState;
			}

			subState.parent = this;

			if (substates.ContainsKey(subState.GetType()))
			{
				Debug.LogWarning("Duplicated sub state! : " + subState.GetType());
			}

			substates.Add(subState.GetType(), subState);
		}

		public void SendTrigger(int trigger)
		{
			StateMachine root = this;
			while (root?.parent != null)
			{
				root = root.parent;
			}

			while (root != null)
			{
				if (root.transitions.TryGetValue(trigger, out StateMachine toState))
				{
					root.parent?.ChangeSubState(toState);
					return;
				}

				root = root.currentSubState;
			}
		}

		private void ChangeSubState(StateMachine state)
		{
			currentSubState?.ExitStateMachine();
			var nextState = substates[state.GetType()];
			currentSubState= nextState;
			nextState.EnterStateMachine();	
		}

		public void SetDefaultState() => ChangeSubState(defaultSubState);
	}
}
