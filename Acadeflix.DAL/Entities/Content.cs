using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acadeflix.DAL.Entities
{
    public class Content
    {
		public string Title { get; set; }
		public string Plot { get; set; }
		public ContentEnum ContentType { get; set; }
		public TimeSpan Runtime { get; set; }
        public DateTime PublishDate { get; set; }

		public int Id { get; set; }
		public Content Previous { get; set; }
		public int? PreviousId { get; set; }
		public Content Parent { get; set; }
		public int? ParentId { get; set; }

		public List<Media> Medias { get; set; }
		public List<Watcher> Watchers { get; set; }
		public List<Genre> Genres { get; set; }
		public List<Credit> Credits { get; set; }
	}
}