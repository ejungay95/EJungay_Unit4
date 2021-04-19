using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  Rigidbody rbPlayer;
  GameObject focalPoint;
  Renderer playerRenderer;
  bool hasPowerUp = false;

  public float speed = 10.0f;
  public float powerUpSpeed = 15.0f;
  public GameObject powerUpIndicator;

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
    powerUpIndicator.transform.position = transform.position;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("PowerUp"))
    {
      hasPowerUp = true;
      Destroy(other.gameObject);
      StartCoroutine("PowerUpCountdown");
      powerUpIndicator.SetActive(true);
    }
  }

  private void OnCollisionEnter(Collision collision)
  {
    if(hasPowerUp && collision.gameObject.CompareTag("Enemy"))
    {
      Rigidbody rbEnemy = collision.gameObject.GetComponent<Rigidbody>();
      Vector3 awayDir = collision.gameObject.transform.position - transform.position;

      rbEnemy.AddForce(awayDir * powerUpSpeed, ForceMode.Impulse);
    }
  }

  IEnumerator PowerUpCountdown() {
    yield return new WaitForSeconds(8);
    hasPowerUp = false;
    powerUpIndicator.SetActive(false);
  }
}
