
namespace software_design_and_architecture_3_colleges
{
    public class ExportText : IExport
    {
        public void Export(List<MovieTicket> movieTickets)
        {
            string plainTextFile = "C:\\Software projecten\\software-design-and-architecture-3-colleges\\software-design-and-architecture-3-colleges\\plaintext.txt";
            string tickets = "";

            foreach (MovieTicket movieTicket in movieTickets)
            {
                tickets += movieTicket.ToString();
                tickets += "\n\n";
            }

            File.WriteAllText(plainTextFile, tickets);
            Console.WriteLine("Plaintext data exported successfully.");
        }
    }
}
