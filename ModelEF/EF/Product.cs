namespace ModelEF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ID { get; set; }
   
        [Display(Name = "Mã Thể Loại")]
        public int? Category_ID { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Tên Sản Phẩm")]
        public string Name { get; set; }
        [Display(Name = "Giá Sản Phẩm")]
        public decimal UnitCost { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Số Lượng Sản Phẩm")]
        public string Quantity { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Hình Ảnh")]
        public string Image { get; set; }

        [StringLength(500)]
        [Display(Name = "Mô Tả")]
        public string Description { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Trạng Thái")]
        public string Status { get; set; }

        public virtual Category Category { get; set; }
    }
}
