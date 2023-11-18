using SmartAgri.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartAgri.Entities.Concrete
{
    public class Topic : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = null!;
        [JsonPropertyName("content")]
        public string Text { get; set; } = null!;
        public DateTime Date { get; set; }
        public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();
        public virtual User User { get; set; } = null!;
    }
}
