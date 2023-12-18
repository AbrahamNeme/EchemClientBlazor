namespace EchemClient.Front.Models
{
    public class ChartDataset
    {
        public string Name { get; set; } = string.Empty;
        public double[] EData { get; set; } = [];
        public double[] JData { get; set; } = [];

        public ChartDataset(string name, double[] eData, double[] jData) 
        {
            Name = name;
            EData = eData;
            JData = jData;
        }
    }
}
