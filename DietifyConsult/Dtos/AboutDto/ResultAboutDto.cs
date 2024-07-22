namespace DietifyConsult.Dtos.AboutDto
{
    public class ResultAboutDto
    {
        public int AboutID { get; set; }
        public string AboutSmallTitle { get; set; }
        public string AboutLargeTitle { get; set; }
        public string AboutContent { get; set; }
        public int ConsultantCount { get; set; }
        public int ClientCount { get; set; }
    }
}
