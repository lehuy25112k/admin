namespace ModelEF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAcount")]
    public partial class UserAcount
    {
        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name ="Tên Đăng Nhập")]
        public string UserName { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Trạng Thái")]
        public string Status { get; set; }
    }
}
