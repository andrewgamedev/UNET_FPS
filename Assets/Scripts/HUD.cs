﻿using UnityEngine;
using UnityEngine.UI;

public class HUD : HUD_Base<HUD> {

    /////
    ///// GUI Element References
    /////
    [Header("Ammo")]
    [SerializeField]
    Image clipAmmoImage;
    [SerializeField]
    Text clipAmmoText;

    [Header("Health")]
    [SerializeField]
    Text healthText;
    [SerializeField]
    Image healthImage;

    [Header("Health Pack")]
    [SerializeField]
    Text healthPackText;
    [SerializeField]
    Image healthPackImage;

    [Header("Bullet Inventory")]
    [SerializeField]
    Text bulletInventoryText;
    [SerializeField]
    Image bulletInventoryImage;

    [Header("Hit Marker")]
    [SerializeField]
    Image hitMarker;

    [Header("Dying and respawning")]
    [SerializeField]
    GameObject deathMessage;
    [SerializeField]
    Image reviveImg;
    [SerializeField]
    Text reviveTxt;


    [Header("Aimer")]
    Image aimer;


    [Header("Damage Direction Indicator")]
    [SerializeField]
    Image damageDirectionIndicator;
    [SerializeField]
    float damageDirectionIndicatorHighestAlpha = 0.5f;

    


    /////
    ///// Public Manipulation Functions
    /////


    public static void SetClipAmmo(int current, int max)
    {
        singleton.clipAmmoText.enabled = true;
        singleton.clipAmmoText.text = current + "/" + max;
    }


    public static void SetHealth(float current, float max)
    {
        singleton.healthImage.enabled = true;
        float ratio = current / max;
        singleton.healthImage.fillAmount = ratio;
        singleton.healthText.text = current + "/" + max;
    }
    

    public static void SetHealthPackVisible(bool visible)
    {
        singleton.healthPackImage.enabled = visible;
        singleton.healthPackText.enabled = visible;
    }
    

    public static void SetInventoryAmmo(int amount)
    {
        singleton.bulletInventoryImage.enabled = true;
        singleton.bulletInventoryText.text = amount.ToString();
    }


    public static void SetHitMarkerVisible(bool visible)
    {
        singleton.hitMarker.enabled = visible;
    }

    public static void SetDeathMessageVisible(bool visible){
        singleton.deathMessage.SetActive(visible);
    }


    public static void SetAimerVisible(bool visible)
    {
        singleton.aimer.enabled = visible;
    }

    public static void SetReviveText(string text){
        singleton.reviveTxt.text = text;
    }

    public static void SetReviveImageFill(float percentage01){
        singleton.reviveImg.fillAmount = percentage01;
    }

    public static void SetDamageDirectionIndicatorVisible(bool visible){
        singleton.damageDirectionIndicator.enabled = visible;
    }

    public static void SetDamageDirectionIndicatorAlpha(float alpha01){
        Color c = singleton.damageDirectionIndicator.color;

        if(alpha01 > singleton.damageDirectionIndicatorHighestAlpha){
            alpha01 = singleton.damageDirectionIndicatorHighestAlpha;
        }

        c.a = alpha01;

        singleton.damageDirectionIndicator. color = c;
    }

    public static void SetDamageDirectionIndicatorRotation(float rotation){
        SetDamageDirectionIndicatorVisible(true);

        Vector3 oldRot = singleton.damageDirectionIndicator.transform.rotation.eulerAngles; 

        singleton.damageDirectionIndicator.transform.rotation = Quaternion.Euler(oldRot.x, oldRot.y, rotation);
    }
}
