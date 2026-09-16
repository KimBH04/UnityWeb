using UnityEngine;
using UnityEngine.EventSystems;

public class HoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Transform player;

    [SerializeField] private Vector2 direction;

    [SerializeField] private float speed;

    private Vector3 move;

    public void OnPointerUp(PointerEventData eventData)
    {
        move = Vector3.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        move = direction;
    }

    private void Update()
    {
        player.position += move * (speed * Time.deltaTime);
    }
}
