using UnityEngine;
using System.Collections;

public class SnailWalk : MonoBehaviour
{
    public float speed = 50f; // Скорость (пикселей в секунду)
    public float distance = 50f; // Дистанция (10 пикселей)

    private RectTransform rectTransform;
    private Vector3 startScale;
    private Vector2 startPos;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startScale = rectTransform.localScale;
        startPos = rectTransform.anchoredPosition;

        StartCoroutine(WalkRoutine());
    }

    IEnumerator WalkRoutine()
    {
        while (true)
        {
        
            yield return MoveTo(startPos.x + distance);

            Flip(-1);

        
            yield return MoveTo(startPos.x - distance);

     
            Flip(1);
        }
    }

    IEnumerator MoveTo(float targetX)
    {
        while (Mathf.Abs(rectTransform.anchoredPosition.x - targetX) > 0.1f)
        {
            Vector2 pos = rectTransform.anchoredPosition;
            pos.x = Mathf.MoveTowards(pos.x, targetX, speed * Time.deltaTime);
            rectTransform.anchoredPosition = pos;
            yield return null;
        }
    }

    void Flip(int dir)
    {
        Vector3 scale = startScale;
        if (dir == -1) scale.x *= -1;
        rectTransform.localScale = scale;
    }
}
