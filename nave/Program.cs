// NAVE espacial llega planeta descoconido.//

const int distanciaAlEspacio  = 40;
const int combustibleInicial  = 500;
const int PerdidaPorEspera    = 50;
const int EscudoMax           = 50;
const int CombustiblePorTurno = 5;
const int AscensoPorTurno     = 5;
const int EscudoPorTurno      = 2;

var DistanciaRecorrida  = 0;
var CombustibleRestante = combustibleInicial;
var Escudoactual = EscudoMax;

Console.WriteLine ("Bienvenido a la simulacion de vissje al espacio.");
Console.WriteLine ($"Distancia: {DistanciaRecorrida}");
Console.WriteLine ($"Combustible: {CombustibleRestante}");
Console.WriteLine ($"escudo: {Escudoactual}");

while (DistanciaRecorrida < distanciaAlEspacio && CombustibleRestante > 0 )
{
    var esZonaDeEscombros = false;
    var esZonaDeCalma = false;
    var esZonaNeutral = !esZonaDeEscombros && !esZonaDeCalma;

    string opcion;

    do
    {
        if (esZonaDeEscombros)
        {
            Console.WriteLine("estas en una zona de escombros");
        }
        else if (esZonaDeCalma)
        {
            Console.WriteLine("estas en una zona de calma");
        }
        else if (esZonaNeutral)
        {
            Console.WriteLine("estas en una zona neutral");
        }

        Console.WriteLine("Que accion quieres realizar:");
        Console.WriteLine("1. Ascender");
        Console.WriteLine("2. Esperar");
         opcion = Console.ReadLine() ?? "";

         if (opcion != "1" && opcion != "2")
         {
             Console.WriteLine("Opcion invalida, intente de nuevo");
         }

    } while (opcion != "1" && opcion != "2");

    if(opcion == "1")
    {
        Console.WriteLine("acendiendo...");
        DistanciaRecorrida  += AscensoPorTurno;
        CombustibleRestante -= CombustiblePorTurno;
    }
    else if (opcion == "2")
    {
        Console.WriteLine("esperando...");
        Escudoactual = Math.Min(EscudoMax, Escudoactual + EscudoPorTurno);

        DistanciaRecorrida = Math.Max(0, DistanciaRecorrida - PerdidaPorEspera);
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
    Console.WriteLine ("No llegaste a espacio!");
}
