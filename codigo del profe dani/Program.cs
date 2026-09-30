/* Cambios
 * 1. Ajuste de las constantes y los valores iniciales
 * - Se modificaron los valores de distancia, combustible, escudo y recuperación para que las partidas sean más largas.
 * - Se cambiaron los nombres de algunas constantes y variables para que sean más descriptivos.
 * - El jugador ahora comienza con el combustible y el escudo al máximo.
 * 2. Mejora de la condición del ciclo principal
 * - Antes, el ciclo continuaba mientras quedara combustible y no se hubiera llegado al espacio.
 * - Ahora, también comprueba que el jugador tenga suficiente combustible para ascender y que su escudo sea mayor que cero.
 * 3. Corrección de la validación de opciones
 * - La opción 3 solamente está disponible en la zona de escombros y cuando hay suficiente combustible.
 * 4. Sustitución de los condicionales por un switch
 * - Se reemplazó la estructura if / else if utilizada para ejecutar las acciones del jugador por un switch.
 * 5. Cambios en los cálculos
 * - Se introdujeron variables temporales para almacenar los resultados de algunos cálculos.
 * 6. Mejora de los mensajes y las condiciones de victoria y derrota
 * - Se agregaron estadísticas del jugador al inicio de cada turno.
 * - Se agregó un separador visual para distinguir los turnos.
 * - En lugar de mostrar únicamente si el jugador llegó o no al espacio, ahora se indica si perdió por falta de combustible o por quedarse sin escudo.
 */

// Constantes directas

const int   DISTANCIA_AL_ESPACIO    = 100;
const int   COMBUSTIBLE_MAX         = 40;
const float ESCUDO_MAX              = 100f;
const float BONUS_ESCUDO_ZONA_CALMA = 1.2f;

// Valores temporales para trabajar con resultados predecibles.
const int DISTANCIA_ASCENSO_MIN     = 5;
const int DISTANCIA_ASCENSO_MAX     = 10;
const int COMBUSTIBLE_ASCENSO_MIN       = 3;
const int COMBUSTIBLE_ASCENSO_MAX       = 7;
const int DISTANCIA_PERDIDA_ESPERAR = 5;
const int ESCUDO_RECUPERADO         = 10;
const int DMG_ESCOMBRO_ESCOMBRO     = 5;
const int COMBUSTIBLE_ESQUIVAR      = 6;

// Variables de estado
var distanciaRecorrida = 0;
var combustibleActual  = COMBUSTIBLE_MAX;
var escudoActual       = ESCUDO_MAX;

var rng = new Random();

// Ciclo principal del juego
while (distanciaRecorrida < DISTANCIA_AL_ESPACIO && combustibleActual >= COMBUSTIBLE_ASCENSO_MIN && escudoActual > 0)
{
    var esZonaCalma     = false;
    var esZonaEscombros = true;

    // Estadísticas del jugador
    Console.WriteLine("Distancia recorrida: " + distanciaRecorrida + " / " + DISTANCIA_AL_ESPACIO);
    Console.WriteLine("Escudo actual: " + escudoActual + " / " + ESCUDO_MAX);
    Console.WriteLine("Combustible actual: " + combustibleActual + " / " + COMBUSTIBLE_MAX);


    // Selección de la acción del jugador
    string opcion;
    bool   esOpcionValida;
    do
    {
        if (esZonaCalma)
        {
            Console.WriteLine("¡Has entrado en una zona de calma!");
            Console.WriteLine("Opciones:");
            Console.WriteLine("1. Ascender");
            Console.WriteLine("2. Esperar");
        }
        else if (esZonaEscombros)
        {
            Console.WriteLine("¡Has entrado en una zona de escombros!");
            Console.WriteLine("Opciones:");
            Console.WriteLine("1. Ascender");
            Console.WriteLine("2. Esperar");

            if (combustibleActual >= COMBUSTIBLE_ESQUIVAR)
            {
                Console.WriteLine("3. Esquivar");
            }
            else
            {
                Console.WriteLine("3. Esquivar (No tienes suficiente combustible para esquivar)");
            }
        }
        else
        {
            Console.WriteLine("Opciones:");
            Console.WriteLine("1. Ascender");
            Console.WriteLine("2. Esperar");
        }

        opcion = Console.ReadLine() ?? "";

        esOpcionValida = opcion == "1" ||
                         opcion == "2" ||
                         (esZonaEscombros && combustibleActual >= COMBUSTIBLE_ESQUIVAR && opcion == "3");

        if (!esOpcionValida)
        {
            Console.WriteLine("Opción inválida. Intenta de nuevo.");
        }
    } while (!esOpcionValida);

    switch (opcion)
    {
        case "1":
        {
            if (esZonaEscombros)
            {
                float dmgEscudo = DMG_ESCOMBRO_ESCOMBRO;
                dmgEscudo    =  Math.Min(dmgEscudo, escudoActual);
                escudoActual -= dmgEscudo;

                Console.WriteLine("¡Has recibido " + dmgEscudo + " unidades de daño en el escudo!");

                if (escudoActual <= 0)
                {
                    Console.WriteLine("¡Tu escudo se ha agotado!");
                    break;
                }
            }

            var combustibleReal = rng.Next(COMBUSTIBLE_ASCENSO_MIN, COMBUSTIBLE_ASCENSO_MAX + 1);

            if (combustibleActual > combustibleReal)
            {
                Console.WriteLine("No tienes suficiente combustible!");
            }
            else
            {
                var distanciaReal = rng.Next(DISTANCIA_ASCENSO_MIN, DISTANCIA_ASCENSO_MAX + 1);

                distanciaRecorrida += distanciaReal;

                combustibleActual  -= combustibleReal;

                Console.WriteLine("Has ascendido " + distanciaReal + " unidades.");
                Console.WriteLine("Has utilizado " + combustibleReal + " unidades de combustible.");
            }

            break;
        }
        case "2":
        {
            var bonus            = esZonaCalma ? BONUS_ESCUDO_ZONA_CALMA : 1f;
            var escudoRecuperado = ESCUDO_RECUPERADO * bonus;
            escudoRecuperado =  Math.Min(escudoRecuperado, ESCUDO_MAX - escudoActual);
            escudoActual     += escudoRecuperado;
            Console.WriteLine("¡Has recuperado " + escudoRecuperado + " unidades de escudo!");

            if (esZonaEscombros)
            {
                float dmgEscudo = DMG_ESCOMBRO_ESCOMBRO;
                dmgEscudo    =  Math.Min(dmgEscudo, escudoActual);
                escudoActual -= dmgEscudo;

                Console.WriteLine("¡Has recibido " + dmgEscudo + " unidades de daño en el escudo!");
            }

            var distanciaPerdida = Math.Min(DISTANCIA_PERDIDA_ESPERAR, distanciaRecorrida);
            distanciaRecorrida -= distanciaPerdida;
            Console.WriteLine("Has perdido " + distanciaPerdida + " unidades de distancia.");

            break;
        }
        case "3":
        {
            combustibleActual -= COMBUSTIBLE_ESQUIVAR;

            Console.WriteLine("Has esquivado un obstáculo.");
            Console.WriteLine("Has utilizado " + COMBUSTIBLE_ESQUIVAR + " unidades de combustible.");
            break;
        }
    }

    Console.WriteLine();
    Console.WriteLine("----------------------------------------");
}

if (distanciaRecorrida >= DISTANCIA_AL_ESPACIO)
{
    Console.WriteLine("¡Felicidades! Has llegado al espacio.");
}
else if (combustibleActual < COMBUSTIBLE_ASCENSO_MIN)
{
    Console.WriteLine("¡No tienes suficiente combustible para ascender! Has perdido.");
}
else if (escudoActual <= 0)
{
    Console.WriteLine("¡Tu escudo se ha agotado! Has perdido.");
}
