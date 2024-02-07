
using Newtonsoft.Json;

namespace software_design_and_architecture_3_colleges
{
    public class ExportJson : IExport
    {
        public void Export(List<MovieTicket> movieTickets)
        {
            string jsonDataFile = "C:\\Software projecten\\software-design-and-architecture-3-colleges\\software-design-and-architecture-3-colleges\\json.json";

            string json = JsonConvert.SerializeObject(movieTickets);
            File.WriteAllText(jsonDataFile, json);
            Console.WriteLine("Json data exported successfully.");
        }
    }
}
