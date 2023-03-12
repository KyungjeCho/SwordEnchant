using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enchanting : MonoBehaviour
{
    public float timer;
    public int waitingTime;

    public GameObject PrefabSuccess;
    public GameObject PrefabKeep;
    public GameObject PrefabFall;
    public GameObject PrefabDestory;
    
    public Sword sword;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update() 
    {
        timer += Time.deltaTime;

        if (timer > waitingTime)
        {
            // 인챈트 결과
            
            // 확률 실행
            int value = sword.RandomEnhancement();
            
            // 실행 기반으로 결과창 생성
            switch(value)
            {
                case (3):
                    Instantiate(PrefabSuccess, Vector3.zero, Quaternion.identity);
                    break;
            }
            gm.EnhanceSword(value);
            
            // 바로 삭제
            Destroy(transform.gameObject, 0f);
        }
    }
}
