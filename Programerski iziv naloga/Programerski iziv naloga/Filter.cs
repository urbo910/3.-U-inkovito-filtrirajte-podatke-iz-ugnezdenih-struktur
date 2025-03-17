using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilterOsebe;


namespace FilterOsebe
{
    public class Filter
    {
        public static void FilterRecords(List<Oseba> osebe, List<(string kriterij, string tip, object vrednost)> criteria)
        {
            for (int i = 0; i < osebe.Count; i++)
            {
                Oseba oseba = osebe[i];
                bool izpolnjujeKriterij = true;

                for (int j = 0; j < criteria.Count; j++)
                {
                    var (kriterij, tip, vrednost) = criteria[j];

                    switch (kriterij)
                    {
                        case "starost":
                            int starost = oseba.Starost;
                            int vrednostSt = Convert.ToInt32(vrednost);

                            if (tip == ">" && !(starost > vrednostSt)) izpolnjujeKriterij = false;
                            else if (tip == ">=" && !(starost >= vrednostSt)) izpolnjujeKriterij = false;
                            else if (tip == "<" && !(starost < vrednostSt)) izpolnjujeKriterij = false;
                            else if (tip == "<=" && !(starost <= vrednostSt)) izpolnjujeKriterij = false;
                            else if (tip == "==" && !(starost == vrednostSt)) izpolnjujeKriterij = false;
                            else if (tip == "=" && !(starost == vrednostSt)) izpolnjujeKriterij = false;
                            break;

                        case "placa":
                            decimal placa = oseba.Placa;
                            decimal vrednostPl = Convert.ToDecimal(vrednost);

                            if (tip == ">" && !(placa > vrednostPl)) izpolnjujeKriterij = false;
                            else if (tip == ">=" && !(placa >= vrednostPl)) izpolnjujeKriterij = false;
                            else if (tip == "<" && !(placa < vrednostPl)) izpolnjujeKriterij = false;
                            else if (tip == "<=" && !(placa <= vrednostPl)) izpolnjujeKriterij = false;
                            else if (tip == "==" && !(placa == vrednostPl)) izpolnjujeKriterij = false;
                            else if (tip == "=" && !(placa == vrednostPl)) izpolnjujeKriterij = false;
                            break;

                        case "ime":
                            string ime = oseba.Ime.ToLower();
                            string vrednostIme = vrednost.ToString().Trim().ToLower();

                            if (tip == "==" && ime != vrednostIme) izpolnjujeKriterij = false;
                            break;

                        default:
                            izpolnjujeKriterij = false;
                            break;
                    }

                    if (!izpolnjujeKriterij) break; // Prekini, če oseba ne izpolnjuje kriterija
                }

                if (izpolnjujeKriterij)
                {
                    Console.WriteLine($"Oseba: {oseba.Ime}, Starost: {oseba.Starost}, Plača: {oseba.Placa}");
                }
            }
        }

    }
}
