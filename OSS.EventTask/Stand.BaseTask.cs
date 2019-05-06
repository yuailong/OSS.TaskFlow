﻿using System.Threading.Tasks;
using OSS.Common.ComModels;
using OSS.EventTask.Mos;

namespace OSS.EventTask
{
    public abstract partial class BaseStandTask<TReq, TRes> : BaseTask<TaskContext<TReq,TRes>,TRes>
        where TRes : ResultMo, new()
    {
        /// <summary>
        ///  执行任务
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Task<TRes> Run(TaskReq<TReq> req)
        {
            var context = new TaskContext<TReq, TRes>
            {
                req = req,
                task_condition = new RunCondition(),
                task_meta = TaskMeta
            };

            return Run(context);
        }

        /// <summary>
        ///  执行任务
        /// </summary>
        /// <param name="req"></param>
        /// <param name="taskCondition"></param>
        /// <returns></returns>
        public Task<TRes> RunWithRetry(TaskReq<TReq> req, RunCondition taskCondition)
        {
            var context = new TaskContext<TReq, TRes>
            {
                req = req,
                task_condition = taskCondition,
                task_meta = TaskMeta
            };
            return Run(context);
        }
    }
}