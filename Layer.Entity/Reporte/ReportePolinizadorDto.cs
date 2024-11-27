using System;
using System.Collections.Generic;
using System.Text;

namespace Layer.Entity
{
    public class ReportePolinizadorDto
    {
        public int IdPolinizador { get; set; }
        public string CodePolinizador { get; set; }
        public string Polinizador { get; set; }
        
        public int TotalIntentos { get; set; }
        public int TotalPods { get; set; }
        public int TotalRealVainas { get; set; }
        public int Target { get; set; }
        public int NewTarget { get; set; }

        public int DiasPolinizacion { get; set; }
        public double PorcentajeEficiencia { get; set; }
        public double PromedioDiario { get; set; }
        public double PromedioVivos { get; set; }
        public string CrossNumber { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
