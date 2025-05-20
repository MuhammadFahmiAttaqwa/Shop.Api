using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Common.Enums
{
    public enum Payment
    {
        [Description("Cash on delivery")]
        CashOnDelivery,
        [Description("Onlin Banking")]
        OnlinBanking,
        [Description("Payment Gateway")]
        PaymentGateway,
        [Description("Visa")]
        Visa,
        [Description("Master Card")]
        MasterCard,
        [Description("PayPal")]
        PayPal,
        [Description("Atm")]
        Atm
    }
}
