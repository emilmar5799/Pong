using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioScena : MonoBehaviour
{

    [SerializeField] private float tiempoTransicion = 1f;
   private Animator transicionAnimator;



    public void Start()
    {
        transicionAnimator = GetComponent<Animator>();
    }

    public void cambiadorScena(string nombreScena)
    {
        SceneManager.LoadScene(nombreScena);
    }

    public void salirDelJuego()
    {
        Application.Quit();
    }


    //public  void iniciarAnimacion()
    //{
    //    transicionAnimator.SetTrigger("animacionFade");        
    //    SceneManager.LoadScene("Game");
    //}

    //public IEnumerator SceneLoad(string nombre)
    //{
    //    transicionAnimator.SetTrigger("animacionFade");

    //    yield return new WaitForSeconds(tiempoTransicion);
    //    SceneManager.LoadScene("Game");
    //}
}
