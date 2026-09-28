// NAVE espacial llega planeta descoconido.//

const int   distanciaAlEspacio     = 40;
const int   combustibleInicial     = 500;
const int   PerdidaPorEspera       = 50;
const int   EscudoMax              = 50;
const int   CombustiblePorTurno    = 5;
const int   AscensoPorTurno        = 5;
const int   EscudoPorTurno         = 2;
const float ZonaCalmaBonoEscudo    = 2f;
const int   DMG_Escombro           = 4;
const int   CombustibleParaEsquivar = 2;


var DistanciaRecorrida  = 0;
var CombustibleRestante = combustibleInicial;
var Escudoactual = 8f;

Console.WriteLine ("Bienvenido a la simulacion de vissje al espacio.");
Console.WriteLine ($"Distancia: {DistanciaRecorrida}");
Console.WriteLine ($"Combustible: {CombustibleRestante}");
Console.WriteLine ($"escudo: {Escudoactual}");

while (DistanciaRecorrida < distanciaAlEspacio && CombustibleRestante > 0 )
{
    var esZonaDeEscombros = true;
    var esZonaDeCalma     = false;
    var esZonaNeutral     = !esZonaDeEscombros && !esZonaDeCalma;

    string opcion;


    do
    {
        if (esZonaDeEscombros)
        {
            Console.WriteLine("estas en una zona de escombros");
            Console.WriteLine("Que accion quieres realizar:");
            Console.WriteLine("1. Ascender");
            Console.WriteLine("2. Esperar (bono de recuperacion)");
            if (CombustibleRestante >= CombustibleParaEsquivar)
            {
                Console.WriteLine("3. Esquivar");
            }
            else
            {
                Console.WriteLine("no puedes Esquivar");
            }

        }
        else if (esZonaDeCalma)
        {
            Console.WriteLine("estas en una zona de calma");
            Console.WriteLine("Que accion quieres realizar:");
            Console.WriteLine("1. Ascender");
            Console.WriteLine("2. Esperar (bono de recuperacion)");
        }
        else if (esZonaNeutral)
        {
            Console.WriteLine("estas en una zona neutral");
            Console.WriteLine("Que accion quieres realizar:");
            Console.WriteLine("1. Ascender");
            Console.WriteLine("2. Esperar");
        }


         opcion = Console.ReadLine() ?? "";

         if (opcion != "1" && opcion != "2" && (opcion == "3" && !esZonaDeEscombros))
         {
             Console.WriteLine("Opcion invalida, intente de nuevo");
         }

    } while (opcion != "1" && opcion != "2" && (opcion == "3" && !esZonaDeEscombros));

    if(opcion == "1")
    {
        if (esZonaDeEscombros)
        {
            Escudoactual = Math.Max(0, Escudoactual - DMG_Escombro);

            if (Escudoactual == 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("recibiste dano de los escombros.");
            }
        }
        Console.WriteLine("acendiendo...");
        DistanciaRecorrida  += AscensoPorTurno;
        CombustibleRestante -= CombustiblePorTurno;
    }
    else if (opcion == "2")
    {
        Console.WriteLine("esperando...");

        var bonoturno = esZonaDeCalma ? ZonaCalmaBonoEscudo : 1f;

        var escudoturno = Escudoactual + EscudoPorTurno * bonoturno;

        Escudoactual = Math.Min(EscudoMax, escudoturno);

        if (esZonaDeEscombros)
        {
            Escudoactual = Math.Min(0, Escudoactual - DMG_Escombro);

            if (Escudoactual == 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("recibiste dano de los escombros.");
            }

        }

        DistanciaRecorrida = Math.Max(0, DistanciaRecorrida - PerdidaPorEspera);
    }
    else if (opcion == "3")
    {
        if (CombustibleRestante >= CombustibleParaEsquivar)
        {
            Console.WriteLine("Haz esquivado los escombros");
            CombustibleRestante -= CombustibleParaEsquivar;
        }
        else
        {
            Escudoactual = Math.Max(0, Escudoactual - DMG_Escombro);
            if (Escudoactual == 0) break;

            Console.WriteLine("recibiste dano de los escombros.");
        }
    }

    Console.WriteLine ($"Distancia: {DistanciaRecorrida}");
    Console.WriteLine ($"Combustible: {CombustibleRestante}");
    Console.WriteLine ($"Escudo: {Escudoactual}");
}

if (DistanciaRecorrida >= distanciaAlEspacio)
{
    Console.WriteLine ("Llegaste a espacio!");
}
else
{
    Console.WriteLine("No llegaste a espacio!");
}
