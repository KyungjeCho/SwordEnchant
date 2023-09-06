using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Core
{
    public abstract class State<T>
    {
        #region Variables
        protected StateMachine<T> stateMachine;
        protected T context;
        #endregion Variables

        #region Constructor
        public State()
        {

        }
        #endregion Constructor

        internal void SetStateMachineAndContext(StateMachine<T> stateMachine, T context)
        {
            this.stateMachine   = stateMachine;
            this.context        = context;

            OnInitialized();
        }

        #region Virtual Methods
        public virtual void OnInitialized()
        { }

        public virtual void OnEnter()
        { }

        public virtual void OnExit()
        { }
        #endregion Virtual Methods

        #region Update Method
        public abstract void Update(float deltaTime);
        #endregion Update Method
    }

    public sealed class StateMachine<T>
    {
        #region Variables
        private T context;
        private State<T> currentState;
        public State<T> CurrentState => currentState;

        private float elapsedTimeInState = 0.0f;
        public float ElapsedTimeInState => elapsedTimeInState;

        private Dictionary<System.Type, State<T>> states = new Dictionary<System.Type, State<T>>();
        #endregion Variables

        #region Constructor
        public StateMachine(T context, State<T> initialState)
        {
            this.context = context;

            AddState(initialState);
            currentState = initialState;
            currentState.OnEnter();
        }
        #endregion Constructor

        #region StateMachine Methods
        public void AddState(State<T> state)
        {
            state.SetStateMachineAndContext(this, context);
            states[state.GetType()] = state;
        }

        public void Update(float deltaTime)
        {
            elapsedTimeInState += deltaTime;

            currentState.Update(deltaTime);
        }

        public R ChangeState<R>() where R : State<T>
        {
            var newType = typeof(R);
            if (currentState.GetType() == newType)
            {
                return currentState as R;
            }

            if (currentState != null)
            {
                currentState.OnExit();
            }

            currentState = states[newType];
            currentState.OnEnter();
            elapsedTimeInState = 0.0f;
            
            return currentState as R;
        }
        #endregion StateMachine Methods
    }
}
