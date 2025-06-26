using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class SalaDeEscape
{
    //Atributos
    
    [JsonProperty]
    public int NumeroSala;

     [JsonProperty]
    public Dictionary <int, string> RespuestasCorrectas  {get;private set;}

    [JsonProperty]
    public Dictionary <int, string> Pistas  {get;private set;}

    public SalaDeEscape()
    {
        NumeroSala = 1;
        RespuestasCorrectas = new Dictionary <int, string>();
        RespuestasCorrectas.Add(1,"C9");
        RespuestasCorrectas.Add(2,"UNION");
        RespuestasCorrectas.Add(3,"SOS");
        RespuestasCorrectas.Add(4,"C9");
        RespuestasCorrectas.Add(5,"EMPATIA");
        Pistas = new Dictionary <int, string>();
        Pistas.Add(1, "El niño que esta mas perdido es aquel cuyo numero termina con 1");  
        Pistas.Add(2, "El trabajo individual es mas dificil que si trabajamos todos ......");  
        Pistas.Add(3, "Son 3 letras de las cuales dos se repiten y una no (La que no se repite es una vocal)");  
        Pistas.Add(4, "Es el mismo que en el inicio");  
        Pistas.Add(5, "El audio habla sobre un tema random pero tiene una palabra clave, esa es la respuesta!");  

    }

    public bool CompararRespuesta (string respuesta)
    {
        respuesta = respuesta.ToUpper();

        if (RespuestasCorrectas.ContainsKey(NumeroSala))
        {
            if (respuesta == RespuestasCorrectas[NumeroSala])
            {
                NumeroSala++;
                return true;
            }
        }
            return false;
    
    }


    public string DarPista()
    {
        if(Pistas.ContainsKey(NumeroSala))
        {
            return Pistas[NumeroSala];
        }
        else
        {
            return "No hay pistas disponibles";
        }

    }


}

