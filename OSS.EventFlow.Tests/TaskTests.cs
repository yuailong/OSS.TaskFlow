using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OSS.Common.Plugs.LogPlug;
using OSS.EventFlow.Tasks.Mos;
using OSS.EventFlow.Tests.TestOrder;
using OSS.EventFlow.Tests.TestOrder.Tasks;

namespace OSS.EventFlow.Tests
{
    [TestClass]
    public class TaskTests
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var msg = new OrderInfo()
            {
                order_name = "测试订单!",
                id = 123456,
                price = 10.23M
            };
            var taskContext = new TaskContext<OrderInfo>(msg);
            var task = new OrderNotifyTask();

            task.SetContinueRetry(9);
            task.SetIntervalRetry(2, SaveTaskContext);

            await task.Process(taskContext);
        }




        public Task SaveTaskContext(TaskContext<OrderInfo> context)
        {
            LogUtil.Info("临时保存任务相关请求信息：" + JsonConvert.SerializeObject(context));
            return Task.CompletedTask;
        }
    }
}
