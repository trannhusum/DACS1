using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarTimePVP : MonoBehaviour
{
    public static BarTimePVP Instance;
    [SerializeField] private Image imageToResize;
    [SerializeField] private float targetWidth;
    private bool canRun = true;
    public bool CanRun
    {
        set { canRun = value; }
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        StartCoroutine(ResizeGradually(2));
    }
    IEnumerator ResizeGradually(float duration)
    {
        canRun = true;
        RectTransform rectTransform = imageToResize.GetComponent<RectTransform>();
        while (canRun)
        {
            Vector2 initialSize = rectTransform.sizeDelta;
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                float width = Mathf.Lerp(initialSize.x, targetWidth, elapsedTime / duration);
                rectTransform.sizeDelta = new Vector2(width, initialSize.y);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            yield return new WaitForSeconds(1);
            rectTransform.sizeDelta = new Vector2(500, initialSize.y);

        }
    }
}
