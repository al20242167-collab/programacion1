//Challenge 01: Combate por turnos
// Generar un progrma que defina un rango de vida y ataque y que realize un comabate por turnos donde el jugador decida si atacar o curar
//Generar un programa que defina un rango de vida y ataque de dos personajes y que le pregunte al jugador si atacr o curar
//ENTRADAS: Ataque, Salud
//SALIDAS: Ataque, Salud

using System.Net.Mail;

Random rndVida = new Random();
int    vida    = rndVida.Next(100,200);
int    vidaMax = 200;

Random rndCura = new Random();
int    cura    = rndVida.Next(1,50);

Random rndAtaque = new Random();
int    ataque    = rndAtaque.Next(1,50);

int  vida2   = rndVida.Next(100,200);
int ataque2 = rndAtaque.Next(1,50);


Console.WriteLine("Jugador 1");

Console.WriteLine("Vida: " + vida);
Console.WriteLine("Ataque: " + ataque);

Console.WriteLine("\n");

Console.WriteLine("Jugador 2");

Console.WriteLine("Vida: " + vida2);
Console.WriteLine("Ataque: " + ataque2);

Random rndJugadores      = new Random();
int    jugadoresEleccion = rndAtaque.Next(1,3);

if (jugadoresEleccion == 1) // Inicia Jugador 2
{
    do
    {
        Random rndJugador2      = new Random();
        int    jugador2Eleccion = rndAtaque.Next(1, 3);

        if (jugador2Eleccion == 1) // Decicion 1 jugador 2
        {
            Console.WriteLine("Te curas: " + cura);
            vida2 = Math.Min(vidaMax, vida2 + cura);
            Console.WriteLine("Vida: " + vida2);

            Console.WriteLine("1 si quieres curarte, 2 si quieres Atacar"); //Toma decicion Jugador 1
            string Decicion = Console.ReadLine();

            bool si = int.TryParse(Decicion, out int decicionINT);
            if (si == true)
            {
                if (decicionINT < 1 || decicionINT > 2) // Inicia Jugador 1
                {
                    Console.WriteLine("Dato no valido ");
                }
                else
                {
                    if (decicionINT == 1) // Decicion 1 jugador 1
                    {
                        Console.WriteLine("Te curas: " + cura);
                        vida = Math.Min(vidaMax, vida + cura);
                        Console.WriteLine("Vida: " + vida);
                    }

                    if (decicionINT == 2) // Decicion 2 jugador 1
                    {
                        Console.WriteLine("Ataque " + ataque);
                        vida2 = vida2 - ataque;
                        Console.WriteLine("Vida Jugador2: " + vida2);
                    }
                }
            }
            else
            {
                Console.WriteLine("Dato no valido ");
            }
        }

        if (jugador2Eleccion == 2) // Decicion 2 jugador 2
        {
            Console.WriteLine("Ataque: " + ataque2);
            vida = vida + ataque2;
            Console.WriteLine("Vida: " + vida);

            Console.WriteLine("1 si quieres curarte, 2 si quieres Atacar"); //Toma decicion Jugador 1
            string Decicion = Console.ReadLine();

            bool si = int.TryParse(Decicion, out int decicionINT);
            if (si == true)
            {
                if (decicionINT < 1 || decicionINT > 2) // Inicia Jugador 1
                {
                    Console.WriteLine("Dato no valido ");
                }
                else
                {
                    if (decicionINT == 1) // Decicion 1 jugador 1
                    {
                        Console.WriteLine("Te curas: " + cura);
                        vida = vida + cura;
                        Console.WriteLine("Vida: " + vida);
                    }

                    if (decicionINT == 2) // Decicion 2 jugador 1
                    {
                        Console.WriteLine("Ataque " + ataque);
                        vida2 = vida2 - ataque;
                        Console.WriteLine("Vida Jugador2: " + vida2);
                    }
                }
            }
            else
            {
                Console.WriteLine("Dato no valido ");
            }
        }
        Console.WriteLine("\n\n");
    } while (vida > 0 && vida2 > 0);
}


if (jugadoresEleccion == 2) // Inicia Jugador 2
{
    do
    {
        Random rndJugador2      = new Random();
        int    jugador2Eleccion = rndAtaque.Next(1, 3);

        Console.WriteLine("1 si quieres curarte, 2 si quieres Atacar"); //Toma decicion Jugador 1
        string Decicion = Console.ReadLine();

        bool si = int.TryParse(Decicion, out int decicionINT);
        if (si == true)
        {
            if (decicionINT < 1 || decicionINT > 2) // Inicia Jugador 1
            {
                Console.WriteLine("Dato no valido ");
            }
            else
            {
                if (decicionINT == 1) // Decicion 1 jugador 1
                {
                    Console.WriteLine("Te curas: " + cura);
                    vida = vida + cura;
                    Console.WriteLine("Vida: " + vida);

                    if (jugador2Eleccion == 1) // Decicion 1 jugador 2
                    {
                        Console.WriteLine("Te curas: " + cura);
                        vida2 = Math.Min(vidaMax, vida2 + cura);
                        Console.WriteLine("Vida: " + vida2);
                    }

                    if (jugador2Eleccion == 2) // Decicion 2 jugador 2
                    {
                        Console.WriteLine("Ataque: " + ataque2);
                        vida = vida + ataque2;
                        Console.WriteLine("Vida: " + vida);
                    }
                }

                if (decicionINT == 2) // Decicion 2 jugador 1
                {
                    Console.WriteLine("Ataque " + ataque);
                    vida2 = vida2 - ataque;
                    Console.WriteLine("Vida Jugador2: " + vida2);

                    if (jugador2Eleccion == 1) // Decicion 1 jugador 2
                    {
                        Console.WriteLine("Te curas: " + cura);
                        vida2 = Math.Min(vidaMax, vida2 + cura);
                        Console.WriteLine("Vida: " + vida2);
                    }

                    if (jugador2Eleccion == 2) // Decicion 2 jugador 2
                    {
                        Console.WriteLine("Ataque: " + ataque2);
                        vida = vida + ataque2;
                        Console.WriteLine("Vida: " + vida);
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Dato no valido ");
        }
        Console.WriteLine("\n\n");
    } while (vida > 0 && vida2 > 0);
}
