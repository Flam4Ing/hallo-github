﻿using System;
using System.IO;
using System.Net;

namespace HalloGitHub
{
    class Program
    {
        private static readonly string octocatAsciiArtUrl = @"https://raw.githubusercontent.com/pi314/ascii-arts/master/octocat.asciiart";

        static void Main(string[] args)
        {
            Console.WriteLine("Ich weiß es ist nicht der Hammer, aber trotzdem:");
            Console.WriteLine("Hallo GitHub".ToUpper());

            Console.WriteLine();
            Console.WriteLine("Spannender wird es im GitHub-Projekt: LMStudent/hallo-octocat");

            Console.WriteLine();
            Console.WriteLine("Oder kannst du mir sagen in welcher Lektion des Udemy-Kurses");
            Console.WriteLine("'Einstieg in GitHub - professionelle Entwicklung im Team'");
            Console.WriteLine("dieses Projekt zu erst verwendet wird? Mit der richtigen Antwort ");
            Console.WriteLine("bekommst du noch ein wenig ASCII-Art von pi314 in deine Konsole!");
            Console.WriteLine("TIP: Schaue in der Kursbeschreibung oder im Quellcode nach ;-)");

            Console.WriteLine();
            Console.Write("Antwort: ");

            if (HoleAntwortVomBenutzer() == 14)
            {
                string asciiArt = LadeAsciiArtVomServer(octocatAsciiArtUrl);

                Console.WriteLine(asciiArt);
                Console.WriteLine();
                Console.WriteLine("ASCII-Art aus dem GitHub-Verzeichnis: pi314/ascii-arts - DANKE an pi314!!!");

            }
            else
            {
                Console.WriteLine("Schade, dass war nicht die richtige Antwort.");
            }

            ZeigeAbspann();

            Console.WriteLine("Drücke RETURN zum beenden.");
            Console.ReadLine();
        }

        private static int HoleAntwortVomBenutzer()
        {
            string antwort = Console.ReadLine();

            int antwortAlsZahl = 0;
            int.TryParse(antwort, out antwortAlsZahl);

            return antwortAlsZahl;
        }

        private static string LadeAsciiArtVomServer(string url)
        {
            string asciiArt = string.Empty;

            var webRequest = WebRequest.Create(url);

            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                asciiArt = reader.ReadToEnd();
            }

            return asciiArt;
        }

        private static void ZeigeAbspann()
        {
            Console.WriteLine();
            Console.WriteLine("ABSPANN - Am Kurs haben bisher teilgenommen:");

            Console.WriteLine(" - LMStudent");
            Console.WriteLine(" - suchja");
            // Kopiere die vorherige Zeile und verwende deinen Namen anstelle von LMStudent.

            Console.WriteLine();
        }
    }
}