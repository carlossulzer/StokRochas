using System;
using System.Collections.Generic;
using System.Text;

public class SenhaAleatoria
{
    public static string GerarSenha() 
    { 
        int Tamanho = 15; // Numero de digitos da senha 
        string senha = string.Empty; 
        for (int i = 0; i < Tamanho; i++) 
        { 
            Random random = new Random(); 
            int codigo = Convert.ToInt32(random.Next(48, 122).ToString()); 
            if ((codigo >= 48 && codigo <= 57) || (codigo >= 97 && codigo <= 122)) 
            { 
                string _char = ((char)codigo).ToString(); 
                if (!senha.Contains(_char)) 
                { 
                    senha += _char; 
                } 
                else
                { 
                    i--; 
                } 
            } 
            else
            { 
                i--; 
            } 
        } 
        return Criptografia.encriptar(senha); 
    }
}
