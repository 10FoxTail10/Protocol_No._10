using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Screen_Blackout : MonoBehaviour
{
    public float blackoutSpeed = 1.0f;


    public void OnBlack()
    {
        Start();
    }

    IEnumerator Start()
    {
        Image blackoutImage = GetComponent<Image>();
        Color color = blackoutImage.color;

        while (color.a < 1f)
        {
            color.a += blackoutSpeed * Time.deltaTime;
            blackoutImage.color = color;
            yield return null;
        }
        yield return new WaitForSeconds(2f);
        color.a = 0;
        blackoutImage.color = color;
        gameObject.SetActive(false);
    }

}
