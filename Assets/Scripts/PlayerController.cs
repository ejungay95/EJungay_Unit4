using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  Rigidbody rbPlayer;
  GameObject focalPoint;
  Renderer playerRenderer;

  public float speed = 10.0f;
  // Start is called before the first frame update
  void Start()
  {
    rbPlayer = GetComponent<Rigidbody>();
    focalPoint = GameObject.Find("FocalPoint");
    playerRenderer = GetComponent<Renderer>();
  }

  // Update is called once per frame
  void Update()
  {
    float playerInput = Input.GetAxis("Vertical");
    float magnitude = playerInput * speed * Time.deltaTime;
    rbPlayer.AddForce(focalPoint.transform.forward * magnitude, ForceMode.Impulse);

    // GetAxis is in a range of -1 to 1 so we can just do the abs of playerInput for the same result?
    //playerRenderer.material.color = new Color(1.0f - Mathf.Abs(playerInput), 1.0f, 1.0f - Mathf.Abs(playerInput));

    if(playerInput > 0)
    {
      playerRenderer.material.color = new Color(1.0f - playerInput, 1.0f, 1.0f - playerInput);
    }
    else
    {
      playerRenderer.material.color = new Color(1.0f + playerInput, 1.0f, 1.0f + playerInput);
    }
  }
}
