namespace DietifyConsult.Models
{
	public class AddBlogImage
	{
		public int BlogID { get; set; }
		public int ConsultantID { get; set; }
		public string BlogTitle { get; set; }
		public string BlogDescription { get; set; }
		public IFormFile BlogImage { get; set; }
		public float BlogScore { get; set; }
		public bool Status { get; set; }
		public DateTime BlogCreateDate { get; set; }
	}
}
