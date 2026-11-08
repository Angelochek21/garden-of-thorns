using UnityEngine;

public class CloudFloat : MonoBehaviour
{
    public float speed = 1f;    
    public float distance = 20f; 

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition; 
    }

    void Update()
    {
     
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * distance;
        transform.localPosition = new Vector3(startPos.x, newY, startPos.z);
    }
}
