using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Threading;

namespace ChristmasSimpleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream s = a.GetManifestResourceStream(@"ChristmasSimpleApp.jingle_bells.wav");
            SoundPlayer player = new SoundPlayer(s);
            player.Play();
            string snowflake = @"                                          *
                                   *      *      *
                                     * ^  *  ^ *
                                   ^   *  *  *   ^
                                *  * *  *****  * *  *
                                   ^   *  *  *   ^
                                     * ^  *  ^ *
                                   *      *      *
                                          *";
            string christmasTree = @"                          _______________./\.
                          _____________ >___<
                          _____________Ѽ./ Ѽ
                          ___________;->( ɕѼ Ҩ .
                          ___________@.♥ '(█) ♥ *$
                          ________Ѽ ""( ()♥t (Ѽ)o*♥*
                          _______(█),-♥.-Ѽ _Q@,0 ɕ(█)
                          ____________>o*oѼ @.<
                          _________o`Ѽ Q Ѽ Q Ѽ~@'
                          ______♥.'Ѽ ♥ *Ѽ ɕҨ ‘♥ @-.)'*
                          ____Ѽ o (█) @ *Ѽ ɕҨ ‘♥ *(█)’Ѽ
                          __________Ѽ -♥-'Ѽ ♥._ Ѽ
                          _______@.♥ '*Q ♥ *(█), @.♥ '*
                          ___.♥' @ _ ɕ♥ _.-'~♥-. @ ´(♥)`-*.o
                          __.(█)* ♥ ..-' (Ѽ) o *.(Ѽ) 0 *(█)`)
                          _________(Ѽ ) '-._♥__(Ѽ)@
                          ____;--♥' ♥Ҩ 0‘(Ѽ) Q o *♥ * Ѽ ♥
                          ___ * (Ѽ). ♥ * .Q.~ ♥- ♥Ҩ.0() Q ♥*'.
                          _(█)* ♥ *‘ o * ♥ _(█)Q~ ♥Ҩ _Ѽ♥_(█)
                          _____________▓▓▓▓▓
                          __________ ▓▓▓▓▓▓▓▓▓";

            Console.WindowHeight = 31;

            while (true)
            {
                Console.ForegroundColor = (ConsoleColor) rnd.Next(0, 15);
                Console.WriteLine(snowflake);
                Console.WriteLine(christmasTree);
                Thread.Sleep(100);
                Console.Clear();
            }
        }
    }
}
