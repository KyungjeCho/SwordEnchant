using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Characters
{
    public class BehaviourController : MonoBehaviour
    {
        #region Variables
        public FixedJoystick joystick;
        private List<GenericBehaviour> behaviours;
        private List<GenericBehaviour> overrideBehaviours; // 우선시 되는 동작
        private int currentBehaviour;
        private int defaultBehaviour;
        private int behaviourLocked;
        #endregion Variables
        #region Caching
        private Rigidbody2D myRigidbody2D;
        private Transform myTransform;
        #endregion Caching
        #region Properties
        private float h;
        private float v;
        protected Vector2 direction = Vector2.right;

        public float GetH { get => h; }
        public float GetV { get => v; }

        [HideInInspector]
        public Vector2 GetDir { get => direction; }

        public Rigidbody2D GetRigidbody { get => myRigidbody2D; }
        public int GetDefaultBehaviour { get => defaultBehaviour;  }
        #endregion Properties
        #region Unity Methods
        private void Awake()
        {
            behaviours = new List<GenericBehaviour>();
            overrideBehaviours = new List<GenericBehaviour>();
            myRigidbody2D = GetComponent<Rigidbody2D>();
            myTransform = transform;
        }
        private void Update()
        {

            h = Input.GetAxis(InputKeyName.Horizontal);
            v = Input.GetAxis(InputKeyName.Vertical);

            if (!(-Mathf.Epsilon < h && h < Mathf.Epsilon) ||
                !(-Mathf.Epsilon < v && v < Mathf.Epsilon))
            {

                direction = new Vector2(h, v).normalized;
            }

#if UNITY_ANDROID
            h = joystick.Horizontal;
            v = joystick.Vertical;

            if (new Vector2(h, v).magnitude > 0.8f)
            {
                direction = new Vector2(h, v);
            }
#endif


        }

        private void FixedUpdate()
        {
            bool isAnyBehaviourActive = false;
            if (behaviourLocked > 0 || overrideBehaviours.Count == 0)
            {
                foreach(GenericBehaviour behaviour in behaviours)
                {
                    if (behaviour.isActiveAndEnabled && currentBehaviour == behaviour.GetBehaviourCode)
                    {
                        isAnyBehaviourActive = true;
                        behaviour.LocalFixedUpdate();
                    }
                }
            }
            else
            {
                foreach(GenericBehaviour behaviour in overrideBehaviours)
                {
                    behaviour.LocalFixedUpdate();
                }
            }
            if (!isAnyBehaviourActive && overrideBehaviours.Count == 0)
            {

            }
        }

        private void LateUpdate()
        {
            if (behaviourLocked > 0 || overrideBehaviours.Count == 0)
            {
                foreach(GenericBehaviour behaviour in behaviours)
                {
                    if (behaviour.isActiveAndEnabled && currentBehaviour == behaviour.GetBehaviourCode)
                    {
                        behaviour.LocalLateUpdate();
                    }
                }
            }
            else
            {
                foreach(GenericBehaviour behaviour in overrideBehaviours)
                {
                    behaviour.LocalLateUpdate();
                }
            }
        }
        #endregion Unity Methods
        #region Behaviour Methods
        public void SubScribeBehaviour(GenericBehaviour behaviour)
        {
            behaviours.Add(behaviour);
        }

        public void RegisterDefaultBehaviour(int behaviourCode)
        {
            defaultBehaviour = behaviourCode;
            currentBehaviour = behaviourCode;
        }

        public void RegisterBehaviour(int behaviourCode)
        {
            if (currentBehaviour == defaultBehaviour)
            {
                currentBehaviour = behaviourCode;
            }
        }

        public void UnRegisterBehaviour(int behaviourCode)
        {
            if (currentBehaviour == behaviourCode)
            {
                currentBehaviour = defaultBehaviour;
            }
        }

        public bool OverrideWidthBehaviour(GenericBehaviour behaviour)
        {
            if (!overrideBehaviours.Contains(behaviour))
            {
                if (overrideBehaviours.Count == 0)
                {
                    foreach (GenericBehaviour behaviour1 in behaviours)
                    {
                        if (behaviour1.isActiveAndEnabled && currentBehaviour == behaviour1.GetBehaviourCode)
                        {
                            behaviour1.OnOverride();
                            break;
                        }
                    }
                }
                overrideBehaviours.Add(behaviour);
                return true;
            }
            return false;
        }

        public bool RevokeOverridingBehaviour(GenericBehaviour behaviour)
        {
            if (overrideBehaviours.Contains(behaviour))
            {
                overrideBehaviours.Remove(behaviour);
                return true;
            }
            return false;
        }

        public bool IsOverriding(GenericBehaviour behaviour = null)
        {
            if (behaviour == null)
            {
                return overrideBehaviours.Count > 0;
            }
            return overrideBehaviours.Contains(behaviour);
        }

        public bool IsCurrentBehaviour(int behaviourCode)
        {
            return currentBehaviour == behaviourCode;
        }

        public bool GetTempLockStatus(int behaviourCode = 0)
        {
            return (behaviourLocked != 0 && behaviourLocked != behaviourCode);
        }

        public void LockTempBehaviour(int behaviourCode)
        {
            if (behaviourLocked == 0)
            {
                behaviourLocked = behaviourCode;
            }
        }

        public void UnLockTempBehaviour(int behaviourCode)
        {
            if (behaviourLocked == behaviourCode)
            {
                behaviourLocked = 0;
            }
        }

        
        #endregion Behaviour Methods
        #region Check Methods
        public bool IsMoving()
        {
            return Mathf.Abs(h) > Mathf.Epsilon || Mathf.Abs(v) > Mathf.Epsilon;
        }

        public bool IsHorizontalMoving()
        {
            return Mathf.Abs(h) > Mathf.Epsilon;
        }

        public bool IsVerticalMoving()
        {
            return Mathf.Abs(v) > Mathf.Epsilon;
        }
#endregion Check Methods
    }

    public abstract class GenericBehaviour : MonoBehaviour
    {
#region Variables
        protected BehaviourController behaviourController;
        protected int behaviourCode;
#endregion Variables
#region Unity Methods
        private void Awake()
        {
            behaviourController = GetComponent<BehaviourController>();

            behaviourCode = GetType().GetHashCode();
        }
#endregion Unity Methods
#region Properties
        public int GetBehaviourCode
        {
            get => behaviourCode;
        }
#endregion Properties
#region Virtual Methods
        public virtual void LocalLateUpdate()
        {

        }

        public virtual void LocalFixedUpdate()
        {

        }

        public virtual void OnOverride()
        {

        }
#endregion Virtual Methods
    }
}
