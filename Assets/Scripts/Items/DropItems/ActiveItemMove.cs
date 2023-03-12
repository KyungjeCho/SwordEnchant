using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActiveItemMove : MonoBehaviour
{
    private GameObject Target;

    public float speed = 3f;
    public bool isAbleToMove;
    public UnityEvent RootItemEvent;

    // Start is called before the first frame update
    void Start()
    {
        isAbleToMove = false;
        Target = GameObject.Find("PlayerBody");

        if (RootItemEvent == null)
            RootItemEvent = new UnityEvent();

        RootItemEvent.AddListener(DestroyItem);
    }

    // Update is called once per frame
    void Update()
    {
        if (isAbleToMove)
        {
            OnMove();
        }
    }

    private void OnMove()
    {
        if (Target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            RootItemEvent.Invoke();
        }
    }

    private void DestroyItem()
    {
        StartCoroutine(IFadeOutAnim());

        Destroy(gameObject, 3f);
    }

    private IEnumerator IFadeOutAnim()
    {
        float time = 1f;

        while (time > 0f)
        {
            time -= Time.deltaTime;
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, time / 1f);
            yield return new WaitForSeconds(0.01f);
        }

        yield return null;
    }
}
