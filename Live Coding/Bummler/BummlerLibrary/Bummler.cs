namespace BummlerLibrary
{
    public class Bummler
    {
        public string Bummeln()
        {
            double ergebnis = Wurzelsumme(2e9);
            return "Fertig mit Bummeln!";
        }

        public async Task<string> BummelnAsync()
        {
            double ergebnis = await Task.Run(() => Wurzelsumme(2e9));

            return "Fertig mit Bummeln!";
        }

        public string Troedeln()
        {
            double ergebnis = Wurzelsumme(3e9);
            return "Fertig mit Trödeln";
        }

        public async Task<string> TroedelnAsync()
        {
            try
            {
                double ergebnis = await Task.Run(() => Wurzelsumme(1e9));
            }
            catch (Exception ex)
            {
                return $"{ex.Message}{Environment.NewLine}{ex.InnerException?.Message}";
            }
            return "Fertig mit Trödeln";
        }

        private double Wurzelsumme(double max)
        {
            double result = 0;

            try
            {
                for (int i = 0; i < max; i++)
                {
                    result += Math.Sqrt(i);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler bei der Wurzelsumme", ex);
            }
        }
    }
}
