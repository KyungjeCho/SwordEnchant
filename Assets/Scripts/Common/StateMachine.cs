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
        private T _context;
        private State<T> _currentState;
        public State<T> CurrentState => _currentState;

        private float _elapsedTimeInState = 0.0f;
        public float ElapsedTimeInState => _elapsedTimeInState;

        private Dictionary<System.Type, State<T>> states = new Dictionary<System.Type, State<T>>();
        #endregion Variables

        #region Constructor
        public StateMachine(T context, State<T> initialState)
        {
            this._context = context;

            AddState(initialState);
            _currentState = initialState;
            _currentState.OnEnter();
        }
        #endregion Constructor

        #region StateMachine Methods
        public void AddState(State<T> state)
        {
            state.SetStateMachineAndContext(this, _context);
            states[state.GetType()] = state;
        }

        public void Update(float deltaTime)
        {
            _elapsedTimeInState += deltaTime;

            _currentState.Update(deltaTime);
        }

        public R ChangeState<R>() where R : State<T>
        {
            var newType = typeof(R);
            if (_currentState.GetType() == newType)
            {
                return _currentState as R;
            }

            if (_currentState != null)
            {
                _currentState.OnExit();
            }

            _currentState = states[newType];
            _currentState.OnEnter();
            _elapsedTimeInState = 0.0f;
            
            return _currentState as R;
        }
        #endregion StateMachine Methods
    }
}
