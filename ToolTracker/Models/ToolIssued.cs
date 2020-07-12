using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolTracker.Models
{
    [Table("ToolsIssued")]
    public class ToolIssued
    {
        public int Id { get; set; }

        [Required]
        public int ToolId { get; set; }

        [Required]
        public DateTime DateTimeOut { get; set; }

        public DateTime? DateTimeIn { get; set; }

        [Required]
        public int ReceivedByInmateId { get; set; }

        public int? ReceivedByOfficerId { get; set; }

        [Required]
        public int IssuedByOfficerId { get; set; }

        public int? ReturnedByInmateId { get; set; }

        [Required]
        public bool ToolReturned { get; set; }

        public virtual Tool Tool { get; set; }
    }
}
