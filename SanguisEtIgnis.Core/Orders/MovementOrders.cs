using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Orders
{
    public abstract class MovementOrders
    {
    }

    public class RotateMovementOrders : MovementOrders
    {

    }

    // could also be a fallback
    public class AdvanceMovementOrders : MovementOrders
    {

    }

}
