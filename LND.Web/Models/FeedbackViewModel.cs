using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LND.Web.Models
{
    public class FeedbackViewModel
    {
        public int ID { set; get; }
        [Required]
        [MaxLength(250,ErrorMessage="Ten khong duoc de trong")]
       
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string Email { get; set; }
        [Required]
        [MaxLength(1000,ErrorMessage =" Tin nhan khong duoc de trong")]
        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        public bool Status { get; set; }
        public ContactDetailViewModel ContactDetail { set; get; }
    }
}