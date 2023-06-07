using UnityEngine;

public class Enemy_Chaser : Enemy, IChaser
{
    public float Speed => speed;
    public GameObject Target => target;

    [SerializeField] private float speed;
    
    private GameObject target;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (!target)
            return;
        
        Vector2 direction = target.transform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.left, direction);
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }
}
