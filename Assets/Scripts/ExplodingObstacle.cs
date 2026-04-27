using UnityEngine;

public class ExplodingObstacle : Obstacle
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    internal override void OnCollision(Collision collision)
    {
        base.OnCollision(collision);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
