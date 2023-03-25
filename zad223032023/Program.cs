using System;

namespace Potwierdzenia
{
    class Program
    {
        static void Main(string[] args)
        {
            Menadzer marcin = new Menadzer();
            Kierownik luiza = new Kierownik();
            Prezes marek = new Prezes();

            marcin.UstawPrzelozonego(luiza);
            luiza.UstawPrzelozonego(marek);

            Faktura faktura1 = new Faktura(1, 5000.0, "materiały");
            Faktura faktura2 = new Faktura(2, 15000.0, "usługi");
            Faktura faktura3 = new Faktura(3, 25000.0, "sprzęt");

            marcin.RozpatrzFakture(faktura1);
            marcin.RozpatrzFakture(faktura2);
            marcin.RozpatrzFakture(faktura3);
        }
    }

    class Faktura
    {
        public int Numer { get; set; }
        public double Wartosc { get; set; }
        public string Cel { get; set; }

        public Faktura(int numer, double wartosc, string cel)
        {
            Numer = numer;
            Wartosc = wartosc;
            Cel = cel;
        }
    }

    abstract class Przelozony
    {
        protected Przelozony przelozony;

        public void UstawPrzelozonego(Przelozony przelozony)
        {
            this.przelozony = przelozony;
        }

        public abstract void RozpatrzFakture(Faktura faktura);
    }

    class Menadzer : Przelozony
    {
        public override void RozpatrzFakture(Faktura faktura)
        {
            if (faktura.Wartosc < 10000.0)
            {
                Console.WriteLine("{0} zaakceptowano fakture o numerze {1}", this.GetType().Name, faktura.Numer);
            }
            else if (przelozony != null)
            {
                przelozony.RozpatrzFakture(faktura);
            }
        }
    }

    class Kierownik : Przelozony
    {
        public override void RozpatrzFakture(Faktura faktura)
        {
            if (faktura.Wartosc < 20000.0)
            {
                Console.WriteLine("{0} zaakceptowano fakture o numerze {1}", this.GetType().Name, faktura.Numer);
            }
            else if (przelozony != null)
            {
                przelozony.RozpatrzFakture(faktura);
            }
        }
    }

    class Prezes : Przelozony
    {
        public override void RozpatrzFakture(Faktura faktura)
        {
            if (faktura.Wartosc < 30000.0)
            {
                Console.WriteLine("{0} zaakceptowano fakture o numerze {1}", this.GetType().Name, faktura.Numer);
            }
            else
            {
                Console.WriteLine("Faktura o numerze {0} wymaga konsultacji!", faktura.Numer);
            }
        }
    }
}
