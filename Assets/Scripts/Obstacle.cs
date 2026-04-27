using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public delegate void PlayerHitAction();
    public static event PlayerHitAction OnPlayerHit;

    private void OnCollisionEnter(Collision collision)
    {
        OnCollision(collision);
    }
    internal virtual void OnCollision(Collision collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            Debug.Log("player collided with" + name);
        }
        OnPlayerHit.Invoke();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
