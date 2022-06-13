namespace KiemTra_NguyenVuDucMinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDangKy")]
    public partial class ChiTietDangKy
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDK { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string MaHP { get; set; }
    }
}
