using UnityEngine;

public class MoveRotation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float timer = 0.25f;
    [SerializeField] private float timermax = 0.25f;
    [SerializeField] private float angle = 5f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            transform.rotation = transform.rotation * Quaternion.AngleAxis(angle, Vector3.left);
            timer = timermax;
        }
        
    }
}
