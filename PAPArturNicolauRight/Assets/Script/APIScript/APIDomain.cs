using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIDomain
{
    
    //este é o dominio local, mais rapido mas n permanente
    private static string domain = "http://localhost/API/";
    
    
    //este é o dominio online, mais lento mas permanete 
    //private static string domain = "http://nicsgames.epizy.com/API/";

    

    //Manda o dominio todo para as alturas necesasrias
    public static string Domain(string page)
    {
        string fulldomain = domain + page;

        return fulldomain;
    }
}
