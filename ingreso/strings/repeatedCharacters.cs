using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Ingreso.Strings
{
    public class RepeatedCharacters
    {
        /**
         * El metodo debe retornar un booleano indicando si el parametro `cadena` cumple con alguna de las siguientes propiedades:
         * 1- Todos los caracteres aparecen la misma cantidad de veces.
         *     Ejemplos: "aabbcc", "abcdef", "aaaaaa"
         * 2- Todos los caracteres aparecen la misma cantidad de veces, a excepcion de 1, que aparece un vez mas o una vez menos.
         *     Ejemplos: "aabbccc", "aabbc", "aaaaccccc"
         * @param cadena la cadena a evaluar
         * @return booleano indicando si la cadena cumple con las propiedades
         */
        public bool IsValid(string cadena)
        {
            // conteo de repeticion correcta de caracteres: una entrada de hash para cada caracter ,  acumular
            //var set = new HashSet<char>();
            //for (int i = 0; i < cadena.Length; i++)
            //{
            //    set.Add(cadena[i]);
            //}

            int[] array = new int[128];
            for (int i = 0; i < cadena.Length; i++)
            {
                int val = (int)cadena[i];
                var acc = array[val];
                array[val] = acc + 1;

            }
            // remover entradas con valor 0 .
            var flteredArray = array.Where(x => x != 0);



            // procesar con distinct , si no contamos 0 , la lista retornada debe constar de dos elementos sucesivos  ej  {1, 2} , {2,3}  {3,4}
            var foundInts = flteredArray.Distinct();
            int size = foundInts.Count();
            bool result = false;

            // chequear si los elementos de foundInts contiene o un elemento o solo  dos  algebraicamente sucesivos.

            if (size <= 1)
            {
                result = true;
            };

            if (size == 2)
            {
                if (Math.Abs(foundInts.ElementAt(0) - foundInts.ElementAt(1)) != 1)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            };

            if (size >= 3)
            {

                result = false;
            };

            return result;

        }
    }
}
