using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextosTutorial : MonoBehaviour
{
    public string[] textos; 
    int contador = 1;
    public Button continuar;
    public Text textoTitulo;
    public Text textoTutorial;
    public Text textoBoton;
    public Canvas canvas;
    public Button saltar;
    public Button anterior;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        textos = new string[19];
        textos[0] = "Puedes acceder a este tutorial de nuevo haciendo click en el botón circular azul que aparece en la esquina superior derecha";
        textos[1] = "Tu objetivo es intentar que no te roben mientras haces lo posible para mantener un nivel bajo de estrés durante 5 minutos";
        textos[2] = "Tú eres el joven sentado con camiseta roja, tienes que estar pendiente de los objetos en tu maleta y de tu celular";
        textos[3] = "En la parte superior de la pantalla puedes ver la barra de estrés, ésta subirá cuando te roben objetos y con el paso del tiempo. Cuando la barra llegue al 100% pierdes";
        textos[4] = "Para evitar que te roben el celular puedes acomodarlo en el fondo de tu bolsillo";
        textos[5] = "Puedes acceder a tu bolsillo pasando el mouse sobre la barra azul en la parte inferior de la pantalla";
        textos[6] = "Debido al movimiento del bus y la vibración de las notificaciones, tu celular se moverá por momentos hacia la salida del bolsillo (incluso si no lo ves o si estás en otros minijuegos)";
        textos[7] = "Si tu celular esta en la salida de tu bolsillo se podrá robar e iniciarán intentos de robo para quitártelo, pero puedes arrastrarlo a la derecha para evitar que se pueda robar"; 
        textos[8] = "También puedes hacerle click derecho para ponerle la mano encima y que no se mueva, pero ten cuidado porque eso hará que tu estrés aumente más rápido";
        textos[9] = "Puedes hacerle click de nuevo para quitar la mano así el aumento de estrés volverá a su ritmo normal";
        textos[10] = "Para salir del bolsillo vuelve a pasar el mouse por la barra azul en la parte inferior de la pantalla";
        textos[11] = "Durante el juego es posible que se caiga tu maleta, si esto pasa tienes que recoger tus cosas en un tiempo límite para evitar que sean robadas";
        textos[12] = "Ten en cuenta que el tiempo empieza a contar apenas se caiga la maleta y eso puede ocurrir incluso si no la estás viendo";
        textos[13] = "Cuando tu maleta se caiga haz click sobre ella para empezar el minijuego";
        textos[14] = "Arrastra los objetos del suelo a la maleta para salvarlos y terminar el minijuego, cualquier objeto que no salves antes del tiempo límite se perderá";
        textos[15] = "Por último, puedes mirar por la ventana para reducir el estrés, para ello debes hacerle click a la ventana que está frente a tu personaje";
        textos[16] = "Pero recuerda, aunque vaya bajando el estrés tus objetos siguen en riesgo, así que intenta no quedarte mucho tiempo viendo por la ventana";
        textos[17] = "Ten en cuenta, que la efectividad de la ventana se vera reducida a medida que pierdas objetos";
        textos[18] = "Preparate para la prueba de estres. Buena Suerte!";
        textoTutorial.text = textos[0];
        contador = 0;
        continuar.onClick.AddListener(cambiarTexto);
        saltar.onClick.AddListener(saltarTutorial);
        anterior.onClick.AddListener(volverTexto);
        anterior.gameObject.SetActive(false);
        this.cambioTitulo();
    }

    public void cambiarTexto()
    {        
        contador++;
        if(contador >= textos.Length)
        {
            Time.timeScale = 1;
            canvas.enabled = false;
            GameManager.intro = false;
        }
        else if(contador == textos.Length -1)
        {
            //continuar.gameObject.GetComponent<Text>().text = "Jugar ->"; 
            anterior.gameObject.SetActive(true);
            textoTutorial.text = textos[contador];
            this.cambioTitulo();
        }
        else if(contador >= 1)
        {
            anterior.gameObject.SetActive(true);
            textoTutorial.text = textos[contador];
            this.cambioTitulo();
        }
        else
        {
            textoTutorial.text = textos[contador];
            this.cambioTitulo();
        }
    }

    public void cambioTitulo(){
        if(contador < 4){
            textoTitulo.text = "Tutorial - General";
        }else if(contador < 11){
            textoTitulo.text = "Tutorial - Celular";
        }else if(contador < 15){
            textoTitulo.text = "Tutorial - Maleta";
        }else if(contador < 18) {
            textoTitulo.text = "Tutorial - Ventana";
        }else{
            textoTitulo.text = "Fin del Tutorial";
        }
    }
    
    public void saltarTutorial()
    {
        Time.timeScale = 1;
        canvas.enabled = false;
        GameManager.intro = false;
    }

    public void volverTexto()
    {
        contador--;
        if(contador <= 0)
        {
            textoTutorial.text = textos[0];
            anterior.gameObject.SetActive(false);
            this.cambioTitulo();
        }
        else if(contador <= textos.Length -1)
        {
            textoTutorial.text = textos[contador];
            this.cambioTitulo();
            //continuar.gameObject.GetComponent<Text>().text = "Siguiente";
        }
        else
        {
            textoTutorial.text = textos[contador];
            this.cambioTitulo();
        }
    }

    public void restart()
    {
        Time.timeScale = 0;
        GameManager.intro = true;
        Start();
        //continuar.GetComponent<Text>().text = "Siguiente";
        canvas.enabled = true;
    }
}
