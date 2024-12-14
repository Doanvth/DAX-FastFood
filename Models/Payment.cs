using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAX_FastFood.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public DateTime PaymentDate { get; set; }

        [Column(TypeName = "tinyint")]
        [Range(0, 2, ErrorMessage = "Trạng thái thanh toán phải nằm trong khoảng từ 0 đến 2.")]
        public byte PaymentStatus { get; set; }

        [Column(TypeName = "varchar(125)")]
        [StringLength(125, ErrorMessage = "Thông tin ghi chú không được vượt quá 125 ký tự.")]
        public string NoteInformation { get; set; }

        public DateTime ConfirmationDate { get; set; }

     
        public int TransactionCode { get; set; }

        [ForeignKey("PaymentMethod")]
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public Order Order { get; set; }
    }
}
