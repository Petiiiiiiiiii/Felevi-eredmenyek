using CA231107;
using System.Runtime.CompilerServices;

static List<double> Atlagok(List<tanulo> tanulok) 
{
    var osztalyAtlag = tanulok.Average(t => t.TanuloAtlag);
    List<double> tantargyHelp = new List<double>() 
    {
        {0},{0},{0},{0},{0},{0},{0},{0}
    };
    for (var i = 0; i < tanulok.Count; i++) 
    {
        for (var j = 0; j < tanulok[i].Jegyek.Count; j++) 
        {
            tantargyHelp[j] += tanulok[i].Jegyek[j];
        } 
    }
    List<double> tantargyAtlag = new List<double>();
    for (var i = 0; i < tantargyHelp.Count; i++) 
    {
        tantargyAtlag.Add(tantargyHelp[i] / tanulok.Count);
    }
    tantargyAtlag.Add(osztalyAtlag);

    return tantargyAtlag;
}
static string[] tantargyNev()
{
    var sr = new StreamReader(@"..\..\..\src\tanulok.txt");
    string[] tantargyakNevei = sr.ReadLine().Split("\t");
    sr.Close();

    int index = 0;

    for (int i = index + 1; i < tantargyakNevei.Length; i++)
    {
        tantargyakNevei[i - 1] = tantargyakNevei[i];
    }

    index = 1;

    for (int i = index + 1; i < tantargyakNevei.Length; i++)
    {
        tantargyakNevei[i - 1] = tantargyakNevei[i];
    }
    return tantargyakNevei;
}
static List<tanulo> bukottak(List<tanulo> tanulok) 
{
    var bukottak = new List<tanulo>();
    for (int i = 0; i < tanulok.Count; i++)
    {
        if (tanulok[i].Jegyek[2] == 1)
        {
            bukottak.Add(tanulok[i]);
        }
    }
    return bukottak;
}
static tanulo angol3(List<tanulo> tanulok) 
{
    for (int i = 0; i < tanulok.Count; i++)
    {
        if (tanulok[i].Jegyek[4] == 3)
        {
            return tanulok[i];
        }
    }
    return tanulok[0];
}
static tanulo legjobbJegyTanulonak(List<tanulo> tanulok) 
{
    int i = 1;
    foreach (var tanulo in tanulok)
    {
        Console.WriteLine($"\t{i}." + tanulo);
        i++;
    }

    Console.Write("\nMelyik tanuló legjobb jegyét szeretnéd megtudni (hányadik): ");
    int input = int.Parse(Console.ReadLine())-1;
    int max = tanulok[input].Jegyek[0];

    for (int j = 0; j < tanulok[input].Jegyek.Count; j++)
    {
        if (max < tanulok[input].Jegyek[j])
        {
            max = tanulok[input].Jegyek[j];
        }
    }
    Console.WriteLine($"\t{tanulok[input].TanuloNeve}, legjobb jegye: {max}");

    return tanulok[input];
}
static void Kiiras(tanulo tanuloKiiras)
{
    var sw = new StreamWriter(@"..\..\..\src\tanulo.txt",false);
    sw.WriteLine($"{tanuloKiiras.TanuloNeve}, {tanuloKiiras.OktatasiAzonosito}");
    sw.Close();
}

var sr = new StreamReader(@"..\..\..\src\tanulok.txt");
var tanulok = new List<tanulo>();
_ = sr.ReadLine();

while (!sr.EndOfStream)
{
    tanulok.Add(new tanulo(sr.ReadLine()));
    _ = sr.ReadLine();
}
sr.Close();

List<double> atlagok = Atlagok(tanulok);
string[] tantargyakNevei = tantargyNev();

Console.WriteLine("1. feladat: ");
for (int i = 0; i < atlagok.Count; i++)
{
    if (i == 8)
    {
        Console.WriteLine($"\tOsztály átlag: {atlagok[i]:0.00}");
    }
    else 
    {
        Console.WriteLine($"\t{tantargyakNevei[i]} : {atlagok[i]:0.00}");
    }
}

var bukottakAdatai = bukottak(tanulok);

Console.WriteLine("\n2. feladat: ");
for (int i = 0; i < bukottakAdatai.Count; i++)
{
    Console.WriteLine($"\t{bukottakAdatai[i].TanuloNeve}, {bukottakAdatai[i].OktatasiAzonosito}");
}

Console.WriteLine("\n3. feladat:");
Console.WriteLine($"\t{angol3(tanulok).TanuloNeve}, {angol3(tanulok).OktatasiAzonosito}");

Console.WriteLine("\n4. feladat:");
var tanuloKiiras = legjobbJegyTanulonak(tanulok);

Kiiras(tanuloKiiras);

Console.ReadKey();