using System.Xml.Linq;

namespace NullableReferences;

public class Nullables
{
    private void UseSimpleNullables()
    {
        // Nullable value types
        int b;
        int a1 = 12;
        int? a2 = null;
        System.Nullable<int> a3 = null;

        int ergebnis1 = a1 + (a2.HasValue ? a2.Value : -1);
        int ergebnis2 = a1 + a2 ?? -1;

        int ergebnis3 = a1; // +b ;

        // Nullable Reference Types -> Compiler versucht, NullExceptiosn fürhzeitig zu erkennen und zu warnen
        Gefluegel hilde = null!;
        var hannah = new Huhn();
        Huhn? herta = null; // = new();

        herta.Name = "Herta"; // Risiko einer Excpetion

        if (herta != null)
        {
            herta.Name = "Herta"; // kein Risiko einer Excpetion
        }

#nullable disable
        herta.Name = "Herta";
#nullable enable


        Huhn tier2 = (Huhn)hilde; // DirectCast -> 4.8: Exception, wenn Cast fehlschlägt, ab .NET Core 3.1: null, wwenn Cast fehlschlägt
        Huhn tier = hilde as Huhn; // SaveCast -> null, wwenn Cast fehlschlägt
        tier.Name = "Hilde";

        if (tier2 != null)
        {
            tier2.Name = "Hilde";
        }


        if (hilde is Huhn huhn) // kein Risiko einer Exception
        {
            huhn.Name = "Hilde";
        }


        XDocument document = XDocument.Load("https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml");

        var days = document.Root?.Descendants() // Inline-Null-Prüfung: Bricht Anweisung ab und gibt null zurück, falls Prüfung erfolgreich.
                                .Where(xe => xe.Name.LocalName == "Cube" && xe.Attributes().Any(at => at.Name == "time"))
                                .Select(xe => Convert.ToDateTime(xe.Attribute("time")?.Value)) //new TradingDay())
                                .ToList();

        //foreach (var day in days)

        // Sonderfall String
        string text = null!;
        string text2 = String.Empty;

        if (text.Length > 0) // Risiko einer Null-Exception ohne Warnung!
        {

        }


    }
}

public class Gefluegel()
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public List<Ei> Eier { get; set; } = new List<Ei>();

}

public class Huhn() : Gefluegel
{

    public string Name { get; set; }
}

public class Ei
{
}