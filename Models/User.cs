//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAnPC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.OrderPro = new HashSet<OrderPro>();
        }
    
        public int ID { get; set; }


        [Required(ErrorMessage = "Không được bỏ trống")]
        [Display(Name ="Tài Khoản")]
        public string TaiKhoan { get; set; }


        [Required(ErrorMessage = "Không được bỏ trống")]
        [Display(Name = "Họ Tên")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống")]      
        [StringLength(50, MinimumLength = 10, ErrorMessage = "{0} Phải có độ dài từ {2} đến {1} kí tự")]

        public string Mail { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "{0} Phải có độ dài từ {2} đến {1} kí tự")]
        [Display(Name = "Mật Khẩu")]
        public string MatKhau { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderPro> OrderPro { get; set; }
    }
}