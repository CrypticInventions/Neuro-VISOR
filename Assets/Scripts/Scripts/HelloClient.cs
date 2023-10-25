using UnityEngine;

public class HelloClient : MonoBehaviour
{
    private HelloRequester _helloRequester;


    private void Start()
    {
        _helloRequester = new HelloRequester();
       // _helloRequester.Start(); WIP

    }
     public void Oncick()
     {
        Debug.Log("Pressed Button");
        _helloRequester.Start();
        
         /*else if(Input.GetKeyUp("c"))
        {
            Debug.Log("Stopping program");
            _helloRequester.Stop();
        }*/

     }

    private void OnDestroy()
    {
        _helloRequester.Stop();

    }
}