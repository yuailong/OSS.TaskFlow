using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSS.TaskFlow.Tests.TestNodes.AddNode;
using OSS.TaskFlow.Tests.TestOrder.AddOrderNode;
using OSS.TaskFlow.Tests.TestOrder.AddOrderNode.Reqs;

namespace OSS.TaskFlow.Tests
{
    [TestClass]
    public class SeqNodeTest
    {
        [TestMethod]
        public async Task AddTest()
        {
            //var orderInfo = new OrderInfo();
            var addReq = new AddOrderReq
            {
                coupon_id = "coupon100",
                title = "���Զ���",
                source_ids = "s_1"
            };

            var addNode = new AddNode();
            var idRes = await addNode.Process(addReq,0);
        }
    }
}
