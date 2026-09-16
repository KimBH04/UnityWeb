using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeMover : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Transform player;

    [SerializeField] private float step = 1f;

    private Vector2 start;

    public void OnPointerUp(PointerEventData eventData)
    {
        var delta = eventData.position - start;
        if (delta.sqrMagnitude < 2500f)
        {
            return;
        }

        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        {
            Move(delta.x > 0 ? Vector3.right : Vector3.left);
        }
        else
        {
            Move(delta.y > 0 ? Vector3.up : Vector3.down);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        start = eventData.position;
    }

    private void Move(Vector3 dir)
    {
        player.transform.position += dir * step;
    }
}
