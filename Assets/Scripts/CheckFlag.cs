using UnityEngine;
using static GameManager;

public class CheckFlag : MonoBehaviour
{
    private enum Direction { Left, Right };
    [SerializeField] private Direction flagDirection;
    private bool flagPassed = false;
    [SerializeField] private Material rightMaterial, badMaterial;
    public static event TimerEvent TimePenalty;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.playerPos != null && 
            PlayerMovement.playerPos.position.z < transform.position.z && !flagPassed)
        {
            Direction passingDirection = Direction.Right;
            if(PlayerMovement.playerPos.position.x < transform.position.x)
                passingDirection = Direction.Left;
            MeshRenderer rendered = GetComponent<MeshRenderer>();
            if (passingDirection == flagDirection)
            {
                rendered.material = rightMaterial;
            }
            else
            {
                rendered.material = badMaterial;
                TimePenalty.Invoke();
            }
            flagPassed = true ;
            Debug.Log("flag passed");
        }
    }
}
