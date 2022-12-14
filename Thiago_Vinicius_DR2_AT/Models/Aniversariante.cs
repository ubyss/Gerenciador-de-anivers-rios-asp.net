namespace Thiago_Vinicius_DR2_AT.Models
{
    public class Aniversariante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set;}
        public string DataDeAniversario { get; set;}

        public int CalcularAniversario()
        {
            int anoAtual = Convert.ToInt32(DateTime.Now.Year);
            string data = DataDeAniversario.Substring(0, 5) + $"/{anoAtual}";
            string dataAtual = String.Format("{0:d}", DateTime.Now);

            int totalDias = (DateTime.Parse(data).Subtract(DateTime.Parse(dataAtual))).Days;

            if (totalDias < 0)
            {
                data = DataDeAniversario.Substring(0, 5) + $"/{anoAtual + 1}";
                totalDias = (DateTime.Parse(data).Subtract(DateTime.Parse(dataAtual))).Days;
                return totalDias;
            }

            return totalDias;
        }
    }
}
