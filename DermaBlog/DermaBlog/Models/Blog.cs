using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace DermaBlog.Models
{
	public class Blog
	{
		public int Id { get; set; }
		public required String Name { get; set; }
		[NotMapped]
        public IFormFile? Images { get; set; }
        public required string Photo { get; set; }
        public required String Title { get; set; }
		public required String By { get; set; }
		public DateTime CreateTime { get; set; }
        public bool IsDeactive { get; set; }
    }
}
