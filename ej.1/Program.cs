//Challenge 01: Combate por turnos
// Problema: Generar un programa que defina un rango de vida y ataque y que realice un combate por turnos donde el jugador decida si atacar o curar
// Objetivo: Generar un programa que defina un rango de vida y ataque de dos personajes y que le pregunte al jugador si atacar o curar
//ENTRADAS: Ataque, Salud
//SALIDAS: Ataque, Salud

Random rndVida = new Random();
int    vida    = rndVida.Next(100,200);
int    vidaMax = 200;
int    vidaMin = 0;
int    vida2   = rndVida.Next(100,200);


Random rndElecc          = new Random();
Random rndJugadores      = new Random();
int    jugadoresEleccion = rndElecc.Next(1,3);


if (jugadoresEleccion == 1) // Inicia Jugador 2
{
   do
   {
       Random rndCura = new Random();
       int    cura    = rndVida.Next(1,50);


       Random rndAtaque = new Random();
       int    ataque    = rndAtaque.Next(1,50);


       int ataque2 = rndAtaque.Next(1,50);




       Console.WriteLine("Jugador 1");


       Console.WriteLine("Vida: " + vida);
       Console.WriteLine("Ataque: " + ataque);


       Console.WriteLine("\n");


       Console.WriteLine("Jugador 2");


       Console.WriteLine("Vida: " + vida2);
       Console.WriteLine("Ataque: " + ataque2);


       Random rndJugador2      = new Random();
       int    jugador2Eleccion = rndElecc.Next(1, 3);


       if (jugador2Eleccion == 1) // Decisión 1 jugador 2
       {
           Console.WriteLine("\n");
           Console.WriteLine("Se cura: " + cura);
           vida2 = Math.Min(vidaMax, vida2 + cura);
           Console.WriteLine("Vida Jugador 2: " + vida2);


           Console.WriteLine("\n");
           int decicionINT;


           do // elección del jugador 1
           {
               Console.WriteLine("1 si quieres curarte, 2 si quieres atacar");


               string Decicion = Console.ReadLine();


               bool si = int.TryParse(Decicion, out decicionINT);


               if (si == false || decicionINT < 1 || decicionINT > 2)
               {
                   Console.WriteLine("Dato no válido. Intenta de nuevo");
               }


           } while (decicionINT < 1 || decicionINT > 2);




           // Jugador 1 se cura
           if (decicionINT == 1)
           {
               Console.WriteLine("\n");
               Console.WriteLine("Te curas: " + cura);


               vida = Math.Min(vidaMax, vida + cura);


               Console.WriteLine("Vida Jugador 1: " + vida);
           }


           // Jugador 1 ataca
           else if (decicionINT == 2)
           {
               Console.WriteLine("\n");
               Console.WriteLine("Ataque: " + ataque);


               vida2 = Math.Max(vidaMin, vida2 - ataque);


               Console.WriteLine("Vida Jugador 2: " + vida2);
           }
       }


       if (jugador2Eleccion == 2) // Decisión 2 jugador 2
       {
           Console.WriteLine("\n");
           Console.WriteLine("Ataque: " + ataque2);
           vida = Math.Max(vidaMin, vida - ataque2);
           Console.WriteLine("Vida Jugador 1: " + vida);


           Console.WriteLine("\n");
           int decicionINT;


           do // eleccion del jugador 1
           {
               Console.WriteLine("\n");
               Console.WriteLine("1 si quieres curarte, 2 si quieres atacar");


               string Decicion = Console.ReadLine();


               bool si = int.TryParse(Decicion, out decicionINT);


               if (si == false || decicionINT < 1 || decicionINT > 2)
               {
                   Console.WriteLine("Dato no válido. Intenta de nuevo");
               }


           } while (decicionINT < 1 || decicionINT > 2);




           // Jugador 1 se cura
           if (decicionINT == 1)
           {
         Console.WriteLine("\n");
               Console.WriteLine("Te curas: " + cura);


               vida = Math.Min(vidaMax, vida + cura);


               Console.WriteLine("Vida Jugador 1: " + vida);
           }


           // Jugador 1 ataca
           else if (decicionINT == 2)
           {
               Console.WriteLine("\n");
               Console.WriteLine("Ataque: " + ataque);


               vida2 = Math.Max(vidaMin, vida2 - ataque);


               Console.WriteLine("Vida Jugador 2: " + vida2);
           }
       }
       Console.WriteLine("\n\n");
   } while (vida > 0 && vida2 > 0);
}




if (jugadoresEleccion == 2) // Inicia Jugador 2
{
   do
   {
       Random rndCura = new Random();
       int    cura    = rndVida.Next(1,50);


       Random rndAtaque = new Random();
       int    ataque    = rndAtaque.Next(1,50);


       int ataque2 = rndAtaque.Next(1,50);




       Console.WriteLine("Jugador 1");


       Console.WriteLine("Vida: " + vida);
       Console.WriteLine("Ataque: " + ataque);


       Console.WriteLine("\n");


       Console.WriteLine("Jugador 2");


       Console.WriteLine("Vida: " + vida2);
       Console.WriteLine("Ataque: " + ataque2);


       Random rndJugador2      = new Random();
       int    jugador2Eleccion = rndAtaque.Next(1, 3);


       Console.WriteLine("\n");
       int decicionINT;


       do // eleccion jugador 1
       {
           Console.WriteLine("\n");
           Console.WriteLine("1 si quieres curarte, 2 si quieres atacar");


           string Decicion = Console.ReadLine();


           bool si = int.TryParse(Decicion, out decicionINT);


           if (si == false || decicionINT < 1 || decicionINT > 2)
           {
               Console.WriteLine("Dato no válido. Intenta de nuevo");
           }


       } while (decicionINT < 1 || decicionINT > 2);




       // Jugador 1 se cura
       if (decicionINT == 1)
       {
           Console.WriteLine("\n");
           Console.WriteLine("Te curas: " + cura);


           vida = Math.Min(vidaMax, vida + cura);


           Console.WriteLine("Vida Jugador 1: " + vida);


           if (jugador2Eleccion == 1) // Decisión 1 jugador 2
           {
               Console.WriteLine("\n");
               Console.WriteLine("Se cura: " + cura);
               vida2 = Math.Min(vidaMax, vida2 + cura);
               Console.WriteLine("Vida Jugador 2: " + vida2);
           }


           if (jugador2Eleccion == 2) // Decisión 2 jugador 2
           {
               Console.WriteLine("\n");
               Console.WriteLine("Ataque: " + ataque2);
               vida = Math.Max(vidaMin, vida - ataque2);
               Console.WriteLine("Vida Jugador 1: " + vida);
           }
       }


       // Jugador 1 ataca
       else if (decicionINT == 2)
       {
           Console.WriteLine("\n");
           Console.WriteLine("Ataque: " + ataque);


           vida2 = Math.Max(vidaMin, vida2 - ataque);


           Console.WriteLine("Vida Jugador 2: " + vida2);


           if (jugador2Eleccion == 1) // Decisión 1 jugador 2
           {
               Console.WriteLine("\n");
               Console.WriteLine("Se cura: " + cura);
               vida2 = Math.Min(vidaMax, vida2 + cura);
               Console.WriteLine("Vida Jugador 2: " + vida2);
           }


           if (jugador2Eleccion == 2) // Decisión 2 jugador 2
           {
               Console.WriteLine("\n");
               Console.WriteLine("Ataque: " + ataque2);
               vida = Math.Max(vidaMin, vida - ataque2);
               Console.WriteLine("Vida Jugador 1: " + vida);
           }
       }
       Console.WriteLine("\n");
   } while (vida > 0 && vida2 > 0);
}


if (vida == 0)
{
   Console.WriteLine("Gana Jugador 2");
}
else
{
   Console.WriteLine("Gana Jugador 1");
}
