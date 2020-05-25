using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
   private Vector2 _initialPosition;
   private bool _birdWasLaunced;
   private float _timeSittingAround;

   [SerializeField] private float _launchPower;


   private void Awake()
   {
      _initialPosition = transform.position;
   

   }

   private void Update() 
   {
      
      GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
      GetComponent<LineRenderer>().SetPosition(0, transform.position);



      if (_birdWasLaunced && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1) {
         _timeSittingAround += Time.deltaTime;
      }


      if (transform.position.y >= 25 || transform.position.x <= -30 || transform.position.x >= 20 || _timeSittingAround > 1.5) {
         string currentSceneName = SceneManager.GetActiveScene().name;
         SceneManager.LoadScene(currentSceneName);
      }

   }
   
   public void onMouseDown() 
    {
       GetComponent<LineRenderer>().enabled = true;
    }
   
    
    public void OnMouseUp() 
    {
       
      Vector2 newPosition = new Vector2(transform.position.x, transform.position.y);
      Vector2 direction = _initialPosition - newPosition; 

      GetComponent<Rigidbody2D>().AddForce(direction* _launchPower);

      GetComponent<Rigidbody2D>().gravityScale = 1;

      _birdWasLaunced = true;
      GetComponent<LineRenderer>().enabled = false;

    }


    public void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = newPosition;

    }
   

}
