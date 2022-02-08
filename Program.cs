// See https://es.wikipedia.org/wiki/C%C3%B3digo_escape_ANSI for more information
// See https://gist.github.com/fnky/458719343aabd01cfb17a3a4f7296797 for more information

/**
 * 
 *   Unicode  DEC  OCT  HEX  Carret C-Escape  Name
 *   -------- ---- ---- ---- ------ --------- --------
 *   NUL      0    000  00   ^@     \0        null
 *   ESC      27   33   1b   ^[     \e        escape
 *   
 *   
 *   
 *   
 * Códigos de escape ANSI
 * 
 * Sintaxis:
 * 
 *   <'Carácter ESC'>[<'Secuencia'>
 * 
 * 
 * 
 * Carácter ESC:
 *   
 *   Unicode  DEC  OCT  HEX  Carret C-escape
 *   -------- ---- ---- ---- ------ ---------
 *   ESC      27   033  1b   ^[     \e
 *   
 *   Valor ASCII:  27(DEC)  33(OCT)  1b(HEX)
 * 
 * 
 * 
 * Secuencia:
 *   
 *   <'Parametros'><'Carácter de cierre'>
 *   
 *   El carácter de cierre selecciona la acción:
 *   
 *     Chr  Secuencia       Descripción                                               Info
 *     ---- --------------- --------------------------------------------------------- -----------------------------------
 *     A    ESC[<n>A        Desplaza el cursor n posiciones hacia arriba.             (default 1) 
 *     B    ESC[<n>B        Desplaza el cursor n posiciones hacia abajo.              (default 1) 
 *     C    ESC[<n>C        Desplaza el cursor n posiciones hacia la derecha.         (default 1) 
 *     D    ESC[<n>D        Desplaza el cursor n posiciones hacia la izquierda.       (default 1) 
 *     E    ESC[<n>E        Moves cursor to beginning of the n lines down.            (default 1) 
 *     F    ESC[<n>F         Moves cursor to beginning of the n lines up.              (default 1)
 *     G    ESC[<n>G        Desplaza el cursor a la columna n.                        (default 1)
 *     H    ESC[<y><x>H     Mueve el cursor a la posición columna=x fila=y            (default top left corner) 
 *
 *     J    ESC[<n>J        Borra la pantalla desde la posición del cursor.           n=0 - hasta el final
 *                                                                                    n=1 - hasta el principio
 *                                                                                    n=2 - toda la pantalla 
 *                                                                                    
 *     K    ESC[<n>K        Borra la linea desde la posición del cursor.              n=0 - hasta el final
 *                                                                                    n=1 - hasta el principio
 *                                                                                    n=2 - toda la línea 
 *                                                                                                                             
 *     f    ESC[<n><m>f     Same as H, but counts as a format effector function       (default top left corner) 
 *                          (like CR or LF) rather than an editor function (like 
 *                          CUD or CNL). This can lead to different handling in 
 *                          certain terminal modes.
 *                                                                                                                                      
 *     S    ESC[<n>S        Scroll Up. Scroll whole page up by n lines. New lines     (default 1) 
 *                          are added at the bottom.                     
 *                                              
 *     T    ESC[<n>T        Scroll Down. Scroll whole page down by n lines. New       (default 1) 
 *                          lines are added at the top.                                                                   
 *
 *     m    ESC[<a;b;…>m    Set style. (b;fg;bg) b=intensity, fg=foreground, 
 *                          bg=background
 *                          https://en.wikipedia.org/wiki/ANSI_escape_code#SGR
 *
 *     p    ESC[<n>p        Define el comportamiento de una tecla (Key stroke ???)
 *                            
 *   
 *   
 *     Si el cursor se encontraba en la parte superior de la pantalla, no tenía ningún efecto. Si no se especificaba n el cursor subía una fila.
 *     ESC [ n B	Desplaza el cursor n filas hacia abajo. Al igual que con el desplazamiento hacia arriba, si el cursor se encontraba en la parte inferior de la pantalla el cursor no se movía, y si no se especificaba n bajaba una fila.
 *     ESC [ n C	Mueve el cursor n columnas hacia la derecha. Si el cursor se encuentra en la última columna este comando no tiene efecto. Si no se especifica n el desplazamiento es de una columna.
 *     ESC [ n D	Mueve el cursor n columnas a la izquierda, salvo que se encuentre en la primera columna, en cuyo caso no tiene efecto. Si n no se especifica toma el valor de 1.
 *     ESC [ n; m f	Mueve el cursor a la fila n y columna m. Si n no se especifica el cursor se mueve a la primera fila.
 *     ESC [ n J	Borra parte de la pantalla. Si n vale 0 se borra desde el cursor hasta el final de la pantalla. En caso de que n valga 1 se borra hasta el principio de la pantalla desde la posición del cursor. Si n vale 2 se borra toda la pantalla (y utilizando ANSI. SYS de MS-DOS el cursor va al principio de la pantalla)
 *     ESC [ n K	Borra parte de la línea. Si n es cero, desde el cursor al final de la línea, en caso de que valga 1 se borra hasta el principio. Si n vale 2 se borra toda la línea.
 *     ESC [ código; parámetro [; parámetro ] p	Con este comando se redefine el comportamiento de una tecla.
 *     ESC [ s	Guarda la posición actual del cursor.
 *     ESC [ u	Coloca el cursor en la posición guardada anteriormente.
 *     ESC [ b ; fg ; bg m	Establece la intensidad, el color del primer plano y el color de fondo del texto. Más ejemplos de códigos y colores en http://softwarelivre.org/terceiro/blog/a-visual-cheat-sheet-for-ansi-color-codes
 * 
 * Name            FG  BG 
 * --------------- --- ---
 * Black           30  40
 * Red             31  41
 * Green           32  42
 * Yellow          33  43
 * Blue            34  44
 * Magenta         35  45
 * Cyan            36  46
 * White           37  47
 * Bright Black    90  100
 * Bright Red      91  101
 * Bright Green    92  102
 * Bright Yellow   93  103
 * Bright Blue     94  104
 * Bright Magenta  95  105
 * Bright Cyan     96  106
 * Bright White    97  107
 */

string autor = "José Herce";
string helloWorld = "Hello, World !!!";
string deco = "°·.°·..·°";
(string ini, string fin) decoration = ($"{deco}(", $"){new string(deco.Reverse().ToArray())}");
string titleIni = "It's not my first";
string[] title = new string[] { $"{decoration.ini} ", $"{titleIni} ", "\"", $"{helloWorld}", "\"", $" {decoration.fin}" };
int titleLength = 0;
foreach (var i in title) titleLength += i.Length;
const string ESC = "\x1b";
const string C_UP = $"{ESC}[A";
const string C_DOWN = $"{ESC}[B";
const string C_BACK = $"{ESC}[D";

var r = new Random();
string TO(int f, int c = 1) => $"{ESC}{string.Format("[{0};{1}f", f, c)}";
string BACK(int n = 1) => $"{ESC}{string.Format("[{0}D", n)}";

void PrintString((int line, int column) pos, string format, string text, int delay = 2000)
{
    Console.Write(TO(pos.line, pos.column) + format);
    foreach (var c in text)
    {
        Thread.Sleep(new Random().Next(30, 250));
        Console.Write(c);
    }
    Thread.Sleep(delay);
}

void printCharSequence(string format, string cSequence, int times, int delay = 10)
{
    Console.Write(format);
    for (int i = 0; i < times; i++)
    {
        Thread.Sleep(delay);
        Console.Write(cSequence);
    }
}

void printHead()
{
    int time = 10;
    printCharSequence(TO(1, 3) + ESC + "[0;38;5;228m", "═", titleLength + 4);
    Thread.Sleep(time);
    Console.Write('╗' + C_BACK);
    Thread.Sleep(time);
    Console.Write(C_DOWN + '║' + C_BACK);
    Thread.Sleep(time);
    Console.Write(C_DOWN + '╝' + C_BACK);
    printCharSequence("", C_BACK + '═' + C_BACK, titleLength + 4);
    Thread.Sleep(time);
    Console.Write(C_BACK + '╚' + C_BACK);
    Thread.Sleep(time);
    Console.Write(C_UP + '║' + C_BACK);
    Thread.Sleep(time);
    Console.Write(C_UP + '╔' + C_BACK);
}
// "\x1b[<num>u"  // Sets maximum length of lines in window to n.
// "\x1b[<num>t"  // Sets maximum number of lines in window to n.
// "\x1b[<num>x"  // Starts text n pixels from left edge of window.
// "\x1b[<num>y"  // Starts text n pixels from top edge of window.
Console.Write(ESC + "[100u");
Console.Write(ESC + "[100t");

// '\x1b[?25h'  // Shows the cursor
// '\x1b[?25l'  // Hides the cursor.
Console.Write(ESC + "[?25l" + ESC + "[2J");

printHead();

int p = 5;
PrintString((2, p), $"{ESC}[0;2;36m", title[0], 0);
PrintString((2, p += title[0].Length), $"{ESC}[0;3;36m", title[1], 0);
PrintString((2, p += title[1].Length), $"{ESC}[0;22;36m", title[2], 0);
PrintString((2, p += title[2].Length), $"{ESC}[0;1;36;6m", title[3], 0);
PrintString((2, p += title[3].Length), $"{ESC}[0;22;36m", title[4], 0);
PrintString((2, p += title[4].Length), $"{ESC}[0;2;36m", title[5], 0);

string devLabel = "- Developed by: ";
PrintString((4, 3), ESC + "[3;34m", devLabel);
PrintString((4, 3 + devLabel.Length), ESC + "[0;1;34m", autor, 0);
Console.Write(BACK(autor.Length) + ESC + "[0;1;34;5m" + autor);
Thread.Sleep(2000);


int x_str = (titleLength + 7) / 2 - helloWorld.Length / 2 + 1;
PrintString((7, x_str), ESC + "[m", helloWorld);

int iteraciones = (int)Math.Pow(2, 12);
Console.Write(TO(9) + ESC + "[0;2;3;90m" + "Finaliza en " + iteraciones);
int maxFG = 255, minFG = maxFG - 208;
int minBG = 0, maxBG = minBG + 48;
for (int i = 0; i < iteraciones; i++)
{
    int x = r.Next(0, helloWorld.Length);
    Thread.Sleep(1);
    Console.Write(
        ESC + "[7;{0}f" + ESC + "[{1};{2};38;2;{3};{4};{5};48;2;{6};{7};{8}m{9}",
        x + x_str,                                 // Column
        r.Next(0, 2) * (r.Next(0, 2) * 22 + 1),    // Bold or not bold
        r.Next(0, 2) * 20 + 3,                     // Italic or not italic
        r.Next(minFG, maxFG),                      // Foreground color R
        r.Next(minFG, maxFG),                      // Foreground color G
        r.Next(minFG, maxFG),                      // Foreground color B
        r.Next(minBG, maxBG),                      // Background color R
        r.Next(minBG, maxBG),                      // Background color G
        r.Next(minBG, maxBG),                      // Background color B
        r.Next(101) > 90 ? char.ToUpper(helloWorld[x]) : char.ToLower(helloWorld[x])   // Character
    );
    Console.Write(TO(9, 13) + ESC + "[m" + ESC + "[K");
    Console.Write($"{ESC}[0;2;3;90m{iteraciones - i - 1}");
}

Console.Write(TO(11) + ESC + "[0m" + ESC + "[?25h");
