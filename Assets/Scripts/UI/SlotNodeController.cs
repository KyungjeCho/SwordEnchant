using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SwordEnchant.UI
{
    public class SlotNodeController : MonoBehaviour
    {
        #region Variables
        public Image iconImg;
        public Image cooldownImg;
        #endregion Variables

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void InitUI(Sprite icon, bool isCooldownSlot = true)
        {
            
            if (iconImg == null || (cooldownImg == null && isCooldownSlot))
            {
                Debug.LogError("아이콘 이미지와 쿨다운 이미지를 설정해주세요");
                return;
            }    


            if (icon == null)
            {
                iconImg.color = new Color(1f, 1f, 1f, 0f);

                cooldownImg.color = new Color(1f, 1f, 1f, 0f);

            }
            else // icon != null
            {
                iconImg.color = new Color(1f, 1f, 1f, 1f);

                if (isCooldownSlot)
                    cooldownImg.color = new Color(1f, 1f, 1f, 1f);
                else
                    cooldownImg.color = new Color(1f, 1f, 1f, 0f);
                iconImg.sprite = icon;
            }
        }

        public void UpdateCooldown(float amount)
        {
            cooldownImg.fillAmount = amount;
        }
    }
}


