using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // attack sprite?
    // attack animation
    private PlayerMove playerMove;
    private PlayerStats playerStat;
    public GameObject SwordPrefab;
    private bool isAvailable = true;
    
    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        playerStat = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAvailable)
        {
            GameObject instance;
            if (playerMove.FaceDirection < 0)
            {
                Vector3 position = new Vector3(transform.position.x - 2f, transform.position.y, 0f);
                instance = Instantiate(SwordPrefab, position, transform.rotation) as GameObject;
            }
            else
            {
                Vector3 position = new Vector3(transform.position.x + 2f, transform.position.y, 0f);
                instance = Instantiate(SwordPrefab, position, transform.rotation) as GameObject;
            }
            //instance.transform.SetParent(this.transform);
            StartCoroutine(CoolDown());
            Destroy(instance, 0.5f);
        }
    }

    private IEnumerator CoolDown()
    {
        isAvailable = false;

        yield return new WaitForSeconds(playerStat.ProjectileCooldown);

        isAvailable = true;
        yield return null;
    }
}
