using SwordEnchant.Characters;
using SwordEnchant.Data;
using SwordEnchant.Managers;
using SwordEnchant.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordEnchant.Projectile
{
    public class AxeController : ProjectileController
    {
        private Transform playerTr;

        [Header("Bezier Curves")]
        public Vector2 vertex;
        public float vertexHeight = 1f;
        private float timer = 0f;
        public float duration = 1f;
        private Vector2 startPos = Vector2.zero;

        public float rotSpeed;
        private bool isInitialzed = false;

        // Start is called before the first frame update
        void Start()
        {
            playerTr = GameManager.Instance.playerTr;
        }

        public override void OnEnable()
        {
            base.OnEnable();

            if (playerTr == null)
                playerTr = GameManager.Instance.playerTr;
        }
        // Update is called once per frame
        void Update()
        {
            if (isInitialzed == false)
                return;

            // 도끼가 돌아가면서 발사될 거기 때문에 로테이션 
            transform.Rotate(new Vector3(0f, 0f, rotSpeed * Time.deltaTime));

            Vector2 p4 = Vector2.Lerp(startPos, vertex, timer);
            Vector2 p5 = Vector2.Lerp(vertex, target.position, timer);
            transform.position = Vector2.Lerp(p4, p5, timer);

            timer += Time.deltaTime / duration;
        }

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);
            if (collision.CompareTag("Enemy") && collided == false)
            {
                collided = true;
                Poolable poolable = GetComponent<Poolable>();
                if (poolable.isUsing)
                    PoolManager.Instance.Push(GetComponent<Poolable>());
                else
                    Destroy(gameObject);
            }
        }
        public override void OnEnter()
        {
            base.OnEnter();

            SetPosition();

            SetTargetObject();

            CalcVertex();

            timer = 0f;
            isInitialzed = true;
        }

        public override void SetTargetObject(Transform target)
        {

        }

        public override void SetTargetObject()
        {
            Scanner scanner = GameManager.Instance.scanner;
            target = scanner.targets[Random.Range(0, scanner.targets.Length)].transform;

            if (target == null)
            {
                int random = Random.Range(0, 360);
                float x = Mathf.Cos(random * Mathf.Deg2Rad) * 5f;
                float y = Mathf.Sin(random * Mathf.Deg2Rad) * 5f;

                Vector2 pos = transform.position + new Vector3(x, 0, y);
                target = new GameObject().transform;
                target.position = pos;
            }
        }

        public void SetPosition()
        {
            if (playerTr == null)
                playerTr = GameManager.Instance.playerTr;

            transform.position = playerTr.position;
            startPos = playerTr.position;
        }

        public void CalcVertex()
        {
            Vector2 targetDirection = target.position - playerTr.position;
            targetDirection.Normalize();
            Vector2 centerPos = (target.position + playerTr.position) / 2f;

            Vector2 rot90Direction = Vector2.zero;

            if (targetDirection.x > 0f)
                rot90Direction = new Vector2(-targetDirection.y, targetDirection.x);
            else
                rot90Direction = new Vector2(targetDirection.y, -targetDirection.x);

            vertex = centerPos + rot90Direction * vertexHeight;
        }
    }

}