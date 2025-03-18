using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Object_interact : NewMonoBehaviour
{
    [SerializeField] protected GameObject offset;
    [SerializeField] protected float rotateSpeed = 2.0f;
    [SerializeField] protected GameObject UI_Rotate;
    private Dictionary<GameObject, Vector3> originalPositions = new Dictionary<GameObject, Vector3>();
    private Dictionary<GameObject, Quaternion> originalRotations = new Dictionary<GameObject, Quaternion>();
    
    private HashSet<GameObject> clickedObjects = new HashSet<GameObject>();
    private GameObject currentSelectedObject = null;
    private bool isRotating = false;
    public bool IsClickObj = false;

    protected void Update()
    {
        this.CLickMouse();
        this.RotateSelectedObject();
        this.HideUIRotate();
        this.CheckIsClick();
    }

    protected virtual void CLickMouse()
    {
        if (Mouse.current != null)
        { 
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("Selectable") || hit.collider.CompareTag("Book"))
                    {
                        GameObject selectedObject = hit.collider.gameObject;
                        if (!clickedObjects.Contains(selectedObject))
                        {
                            if (currentSelectedObject != null)
                            {
                                ResetObjectPosition(currentSelectedObject);
                                clickedObjects.Remove(currentSelectedObject);
                            }
                            this.MoveObjectToOffset(selectedObject);
                            clickedObjects.Add(selectedObject);
                            currentSelectedObject = selectedObject;
                        }
                        this.IsClickObj = true;
                    }
                }
            }

            if (Mouse.current.rightButton.wasPressedThisFrame)
            {
                if (currentSelectedObject != null)
                {
                    isRotating = true;
                }
            }
            if (Mouse.current.rightButton.wasReleasedThisFrame)
            {
                isRotating = false;
            }
        }
    }

    protected void RotateSelectedObject()
    {
        if (isRotating && currentSelectedObject != null)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();
            Vector3 rotation = new Vector3(-mouseDelta.y, mouseDelta.x, 0) * rotateSpeed;
            currentSelectedObject.transform.Rotate(rotation, Space.World);
        }
    }

    protected void MoveObjectToOffset(GameObject selectedObject)
    {
        if (offset != null)
        {
            if (!originalPositions.ContainsKey(selectedObject))
            {
                originalPositions[selectedObject] = selectedObject.transform.position;
            }
            if (!originalRotations.ContainsKey(selectedObject))
            {
                originalRotations[selectedObject] = selectedObject.transform.rotation;
            }

            Vector3 newPosition = offset.transform.position; 
            selectedObject.transform.position = newPosition;
        }
    }

    protected virtual void ResetObjectPosition(GameObject selectedObject)
    {
        if (originalPositions.ContainsKey(selectedObject))
        {

            selectedObject.transform.position = originalPositions[selectedObject];
            selectedObject.transform.rotation = originalRotations[selectedObject];
            originalPositions.Remove(selectedObject);
            originalRotations.Remove(selectedObject);
        }
    }

    protected virtual void HideUIRotate()
    {
        if (!this.IsClickObj)
        {
            this.UI_Rotate.gameObject.SetActive(false);
        }
        else
        {
            this.UI_Rotate.gameObject.SetActive(true);
        }
    }

    protected virtual void CheckIsClick()
    {
        if (!IsClickObj && currentSelectedObject != null)
        {
            ResetObjectPosition(currentSelectedObject);
            clickedObjects.Remove(currentSelectedObject);
            currentSelectedObject = null;
        }
    }
}
