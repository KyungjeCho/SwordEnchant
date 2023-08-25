using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotListUI : MonoBehaviour
{
    public List<Vector3> posList = new List<Vector3>();
    public int currentIndex = 0;
    public float speed = 0.001f;

    public Interpolate.Function interpolate_Func = Interpolate.Ease(Interpolate.EaseType.EaseOutCirc);
    // Start is called before the first frame update
    void Start()
    {
        currentIndex = 0;
    }

    public void MoveIndexPos(int index)
    {
        StartCoroutine(CoMoveNextPos(index));
    }

    IEnumerator CoMoveNextPos(int index)
    {
        float timer = 0f;

        while(timer < 1f)
        {
            timer += speed * Time.unscaledTime;
            //transform.localPosition = Vector3.Lerp(posList[index], posList[(index + 1) % posList.Count], timer);
            transform.localPosition = Interpolate.Ease(this.interpolate_Func, posList[index], posList[(index + 1) % posList.Count] - posList[index], timer, 1f);
            yield return null;
        }


    }
}
