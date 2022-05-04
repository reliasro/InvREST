namespace Soinsoft.Inventory.Presentation.WebAPI;

public class WeatherForecast
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }

    public void ImprimiDoc(Func<int, int, string, bool> doc, Predicate<string> esValido){
            doc(15,2,"h--5"); //callback
            if (esValido("")) return; 
    }
    public void ImprimiDoc(Func<int, int, string> doc){
            doc(15,2); //callback
    }
    public void TestDoc(){
        ImprimiDoc((a,b,c)=>true,g=>true); //lambda
    }

}
