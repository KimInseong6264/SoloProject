using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public void OnClick(InputAction.CallbackContext ctx)
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("UI¸¦ Å¬¸¯");
            return;
        }

        Vector2 mousePos = Mouse.current.position.ReadValue();
        
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log(hit);
            Debug.Log(hit.transform);
        }
    }
}
