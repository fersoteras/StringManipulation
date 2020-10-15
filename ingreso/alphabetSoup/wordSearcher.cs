using System;

namespace Ingreso.AlphabetSoup
{

    public class WordSearcher
    {

        private char[][] soup;

        // Row y Columns en la grid soup.
        static int R, C;

        public WordSearcher(char[][] soup)
        {
            this.soup = soup;
            R = soup.Length;
            C = soup.Length;
        }

        /**
         * El objetivo de este ejercicio es implementar una función que determine si una palabra está en una sopa de letras.
         *
         * ### Reglas
         * - Las palabras pueden estar dispuestas direcciones horizontal o vertical, _no_ en diagonal.
         * - Las palabras pueden estar orientadas en cualquier sentido, esto es, de derecha a izquierda o viceversa, y de arriba
         * para abajo o viceversa.
         * - El cambio de dirección puede estar a media palabra, de modo que, por ejemplo, parte de la palabra
         * esté horizontal y de izquierda a derecha, parte esté vertical y de arriba hacia abajo, y otra parte horizontal
         * de derecha a la izquierda.
         *
         * @param word	Palabra a buscar en la sopa de letras.
         *
         * @return {@link Boolean}	true si la palabra se encuentra
         * en la sopa de letras.
         * */
        // This function searches in all 8-direction 
        // from point (row, col) in grid[, ] 
        // funcion de busqueda multidireccion  desde el punto (row, col) en la grid soup.



        private bool findmatch(char[][] mat, String pat, int x, int y,
                        int nrow, int ncol, int level)
        {
            int l = pat.Length;

            if (level == l)
                return true;

            // Chequeo de limites.
            if (x < 0 || y < 0 || x >= nrow || y >= ncol)
                return false;

            // If grid matches with a letter while 
            // recursion 
            if (mat[x][y] == pat[level])
            {

                // Marking this cell as visited 
                char temp = mat[x][y];
                mat[x][y] = '#';

                // finding subpattern in 4 directions 
                bool res = findmatch(mat, pat, x - 1, y, nrow, ncol, level + 1) |
                                 findmatch(mat, pat, x + 1, y, nrow, ncol, level + 1) |
                                  findmatch(mat, pat, x, y - 1, nrow, ncol, level + 1) |
                                 findmatch(mat, pat, x, y + 1, nrow, ncol, level + 1);

                // marking this cell 
                // as unvisited again 
                mat[x][y] = temp;
                return res;
            }
            else // Not matching then false 
                return false;
        }



        public bool IsPresent(string word)
        {
            // Consider every point as starting 
            // point and search given word 
            for (int row = 0; row < R; row++)
            {
                for (int col = 0; col < C; col++)
                {

                    if (findmatch(soup, word, row, col, R, C, 0))
                    {
                        // Console.WriteLine("pattern found at " + row + ", " + col);
                        return true;
                    }
                }
            }
            return false;

        }


    }
}