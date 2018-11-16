/// <summary>
/// Zoom camera.
/// Attach this to a camera system and refference these functions to tell the camera when to zoom in and out.
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ZoomCamera : MonoBehaviour {

    
	[Header("Zoom Settings")]
	public float zoomSpeed, minZoom;

    Camera m_Camaera;
    //public bool bZoomIn = false, bZoomOut = false;
    //float maxZoom;

    // Use this for initialization
    void Start () {	m_Camaera = gameObject.GetComponent<Camera> ();	 
		//minZoom = m_Camaera.orthographicSize;
		//maxZoom = minZoom*1.4f;// 140% Zoom CAPACITY!!!!!!!
	}

	void LateUpdate (){
		 ZoomIn ();
	}
/*
    void ZoomOut() {
		if (m_Camaera.orthographicSize <= maxZoom) { m_Camaera.orthographicSize = Mathf.MoveTowards(m_Camaera.orthographicSize, maxZoom, zoomSpeed * Time.deltaTime);}
    }
    */
    void ZoomIn() {
		if (m_Camaera.orthographicSize >= minZoom) { m_Camaera.orthographicSize = Mathf.MoveTowards(m_Camaera.orthographicSize, minZoom, zoomSpeed * Time.deltaTime);}
    }



}