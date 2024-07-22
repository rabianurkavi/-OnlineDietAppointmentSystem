using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class BlogComment
	{
		[Key]
		public int BlogCommentId { get; set; }
		public string CommentUserName { get; set; }
		public string CommentTitle { get; set; }
		public string CommentContent { get; set; }
		public DateTime CommentDate { get; set; }
		public float BlogScore { get; set; }
		public bool CommentStatus { get; set; }

		public int BlogId { get; set; }
		public virtual Blog Blogs { get; set; }
	}
}
