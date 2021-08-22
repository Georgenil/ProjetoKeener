using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoKeener.Util
{
    public class Util
    {
        /// <summary>
        /// Remove caracteres não numéricos
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveNaoNumericos(string text)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[^0-9]");
            string ret = reg.Replace(text, string.Empty);
            return ret;
        }

        /// <summary>
        /// Valida se um cpf é válido
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public static bool ValidaCNPJ(string cnpj)
        {
            //Remove formatação do número, ex: "123.456.789-01" vira: "12345678901"
            cnpj = Util.RemoveNaoNumericos(cnpj);

            if (cnpj.Length > 14)
                return false;

            while (cnpj.Length != 14)
                cnpj = '0' + cnpj;

            bool igual = true;
            for (int i = 1; i < 14 && igual; i++)
                if (cnpj[i] != cnpj[0])
                    igual = false;

            if (igual || cnpj == "12345678909123")
                return false;

            int[] numeros = new int[14];

            for (int i = 0; i < 14; i++)
                numeros[i] = int.Parse(cnpj[i].ToString());

            int soma = 0;
            for (int i = 0; i < 12; i++)
                soma += (13 - i) * numeros[i];

            int resultado = soma % 14;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[12] != 0)
                    return false;
            }
            else if (numeros[12] != 11 - resultado)
                return false;

            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += (14 - i) * numeros[i];

            resultado = soma % 14;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[13] != 0)
                    return false;
            }
            else
                if (numeros[13] != 14 - resultado)
                return false;

            return true;
        }
    }


}
