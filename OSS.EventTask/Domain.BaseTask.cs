﻿using System.Threading.Tasks;
using OSS.Common.ComModels;
using OSS.Common.ComModels.Enums;
using OSS.EventTask.Mos;
using OSS.EventTask.Util;

namespace OSS.EventTask
{
    /// <summary>
    /// 基础领域任务
    /// </summary>
    /// <typeparam name="TReq"></typeparam>
    /// <typeparam name="TDomain"></typeparam>
    /// <typeparam name="TRes"></typeparam>
    public abstract partial class BaseDomainTask<TDomain, TReq, TRes> : BaseTask<TaskContext<TDomain,TReq,TRes>, TRes>
        where TRes : ResultMo, new()
    {
        /// <summary>
        ///  执行任务
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Task<TRes> Run(TaskReq<TDomain,TReq> req)
        {
            var context = new TaskContext<TDomain, TReq, TRes>
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
        public Task<TRes> RunWithRetry(TaskReq<TDomain, TReq> req,RunCondition taskCondition)
        {
            var context = new TaskContext<TDomain, TReq, TRes>
            {
                req = req,
                task_condition = taskCondition,
                task_meta = TaskMeta
            };
            return Run(context);
        }


        #region 内部方法扩展

        internal override TRes RunCheck(TaskContext<TDomain, TReq, TRes> context)
        {
            if (context.req == null)
                return new TRes().SetErrorResult(SysResultTypes.ApplicationError, "Task must Run with request info!");

            if (context.req.domain_data == null)
                return new TRes().SetErrorResult(SysResultTypes.ApplicationError, "Domain task must Run with domain_data!");

            return base.RunCheck(context);
        }

        #endregion



    }
}