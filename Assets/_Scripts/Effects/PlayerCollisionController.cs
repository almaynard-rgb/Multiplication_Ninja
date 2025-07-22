//Alexander Maynard (301170707)
//COMP395 - Project 2 - Part 2

//PlayerCollisionController.cs
//Created Date: 04/04/2025
//Last Modified: 04/04/2025


//Description: This script manages the behaviour after the player collides with an object.

//Log:
//03/27/2025: Created and implemented the full functionality for this script

using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    //reference to smoke animation
    [SerializeField] Animator _smokeAnimator;
    //holder to deaactivate the annimation
    [SerializeField] GameObject _smokeObject;
    //timer for the smoke to run
    private float _smokeTimer;
    //reference to the LevelController
    [SerializeField] private LevelController _levelController;

    // Update is called once per frame
    void Update()
    {
        //decrement time
        _smokeTimer -= Time.deltaTime;

        //check if the timer is below 0
        if(_smokeTimer <= 0)
        {
            //if so, set the smoke object off and stop the animation
            _smokeObject.SetActive(false);
            _smokeAnimator.StopPlayback();
        }
    }

    /// <summary>
    /// When the pplayer collides with an object...
    /// </summary>
    /// <param name="collision">other gameobject the player collided with</param>
    private void OnCollisionEnter(Collision collision)
    {
        //if the object we collided with isn't a dummy or wall
        if(!collision.gameObject.CompareTag("Dummy") && !collision.gameObject.CompareTag("Wall"))
        {
            //deactivate the object
            collision.gameObject.SetActive(false);
            //decrement score
            _levelController.QuestionFalse();
            //set the smoke object on
            _smokeObject.SetActive(true);
            //re-play the smoke animation
            _smokeAnimator.Play("Puff_Of_Smoke", -1, 0f);
            _smokeTimer = 0.5f; //reset the timr
        }
    }
}
