using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SwordEnchant.UI
{
    public class RedEffectController : MonoBehaviour
    {
        #region Variables
        private float alpha;

        private Image myImage;

        public float duration = 1f;

        #endregion Variables
        void Awake()
        {
            myImage = GetComponent<Image>();
        }

        private void OnEnable()
        {
            StartCoroutine(CoAlphaFadeInAnim());
        }

        private IEnumerator CoAlphaFadeInAnim()
        {
            alpha = 0f;

            while (alpha <= duration)
            {
                alpha += Time.deltaTime;
                myImage.color = new Color(0.8f, 0f, 0f, alpha);

                yield return null;
            }
        }

        private IEnumerator CoAlphaFadeOutAnim()
        {
            alpha = 1f;

            while (alpha > 0f)
            {
                alpha -= Time.deltaTime;
                myImage.color = new Color(0.8f, 0f, 0f, alpha);

                yield return null;
            }

            gameObject.SetActive(false);
        }
    }
}


