using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManagementApp.Models
{
    public class IncomeItem
    {
        public int ID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal Amount { get; set; }
        [Required]
        public char Frequency { get; set; }
        [Required]
        [DisplayName("User")]
        public int User_Id { get; set; }

        public IncomeItem()
        {
            this.ID = new Random().Next();
            this.Description = "Your description";
            this.Amount = 0m;
            this.Frequency = 'Y';
            this.User_Id = 0;
        }
        public IncomeItem(int id, string description, decimal amount, char frequency, int user_id)
        {
            this.ID = id;
            this.Description = description;
            this.Amount = amount;
            this.Frequency = frequency;
            this.User_Id = user_id;
        }

        public decimal BiWeekly
        {
            get
            {
                switch (this.Frequency)
                {
                    case 'B':
                        return this.Amount;
                    case 'M':
                        return (this.Amount * 12) / 26;
                    case 'Y':
                        return this.Amount / 26;
                    default:
                        return 0;
                }
            }
        }

        public decimal Monthly
        {
            get
            {
                switch (this.Frequency)
                {
                    case 'B':
                        return (this.Amount * 26) / 12;
                    case 'M':
                        return this.Amount;
                    case 'Y':
                        return this.Amount / 12;
                    default:
                        return 0;
                }
            }
        }

        public decimal Yearly
        {
            get
            {
                switch (this.Frequency)
                {
                    case 'B':
                        return this.Amount * 26;
                    case 'M':
                        return this.Amount * 12;
                    case 'Y':
                        return this.Amount;
                    default:
                        return 0;
                }
            }
        }
    }
}