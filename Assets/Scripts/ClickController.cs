using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickController : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    private void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
            Click();
    }
    void Click()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 1000f, layerMask))
        {
            int hitLayer = hit.collider.gameObject.layer;

            if (hitLayer == LayerMask.NameToLayer("Ground"))
            {
                Player.Current.SetTarget(null);
                Player.Current.Controller.MoveToPosition(hit.point);
            }
            else if (hitLayer == LayerMask.NameToLayer("Enemy"))
            {
                Character enemy = hit.collider.GetComponent<Character>();
                Player.Current.SetTarget(enemy);
            }
        }
    }
}
