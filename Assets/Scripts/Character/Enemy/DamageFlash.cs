using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    [SerializeField] private Color flashColor = Color.white;
    [SerializeField] private float flashTime = 0.25f;

    private SpriteRenderer[] spriteRenderers;
    private Material[] materials;

    private Coroutine damageFlashCoroution;

    private void Awake()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        Init();
    }

    private void Init()
    {
        materials = new Material[spriteRenderers.Length];

        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            materials[i] = spriteRenderers[i].material;
        }

        SetFlashAmount(0f);
    }

    public void CallDamageFlash()
    {
        damageFlashCoroution = StartCoroutine(DamageFlasher());
    }
    private IEnumerator DamageFlasher()
    {
        SetFlashColor();


        float currentFlashAmount = 0f;
        float elapsedTime = 0f;

        while (elapsedTime < flashTime)
        {
            elapsedTime += Time.deltaTime;

            currentFlashAmount = Mathf.Lerp(5f, 0f, (elapsedTime / flashTime));
            SetFlashAmount(currentFlashAmount);

            yield return null;
        }
    }

    public void SetFlashColor()
    {
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].SetColor("_FlashColor", flashColor);
        }
    }

    public void SetFlashAmount(float amount)
    {
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].SetFloat("_FlashAmount", amount);
        }
    }
}
