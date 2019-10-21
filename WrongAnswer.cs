using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WrongAnswer : MonoBehaviour
{
    public Color normalColor;
    public Color wrongColor;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.color = normalColor;
    }
    public void LerpColor() 
    {
       StartCoroutine(LerpColorToWrongAndBackTONormal(0.2f));
    }
    IEnumerator LerpColorToWrongAndBackTONormal(float aTime)
    {
        Color color = image.color;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            image.color = Color.Lerp(color,wrongColor,t);
            yield return null;
        }
        yield return new WaitForSeconds(1.5f);
        color = image.color;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            image.color = Color.Lerp(color, normalColor, t);
            yield return null;
        }
    }
}
