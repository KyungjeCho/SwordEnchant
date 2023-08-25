using SwordEnchant.EventBus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SwordEnchant.UI
{
    public class CountdownTxtController : MonoBehaviour
    {
        #region Variables
        private int currentTime = 3;
        private float duration = 1f;
        private float timer = 0f;
        private RectTransform myRectTransfrom;
        private Text myText;

        public float minScale = 0f;
        public float maxScale = 1f;

        #endregion Variables

        private void OnEnable()
        {
            currentTime = 3;
            duration = 1f;
            timer = 0f;

            myRectTransfrom = GetComponent<RectTransform>();
            myText = GetComponent<Text>();

            myText.text = currentTime.ToString();
        }

        // Update is called once per frame
        void Update()
        {
            if (currentTime > 0)
                return;

            timer += Time.unscaledDeltaTime;

            if (timer > duration)
            {
                timer = 0f;
                currentTime -= 1;
                
                if (currentTime == 0)
                {
                    gameObject.SetActive(false);
                    BattleEventBus.Publish(BattleEventType.RESTART);
                }
                myText.text = currentTime.ToString();
            }
        }
    }
}


