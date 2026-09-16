using UnityEngine;
using UnityEngine.InputSystem;
 
public class StickMover : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Vector2 move;
 
    public void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }
 
    private void Update()
    {
        transform.Translate(move * (speed * Time.deltaTime));
    }
}
