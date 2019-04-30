﻿using OSS.Common.ComModels;
using OSS.Common.ComModels.Enums;

namespace OSS.TaskFlow.Tasks.Util
{
    public static class FlowResultExtention
    {
        /// <summary>
        ///  是否任务执行失败
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public static bool IsRunFailed(this ResultMo res)
        {
            return res.sys_ret == (int) SysResultTypes.RunFailed;
        }

        /// <summary>
        /// 是否等待任务重试
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public static bool IsRunPause(this ResultMo res)
        {
            return res.sys_ret == (int) SysResultTypes.RunPause;
        }

        public static TRes CheckConvertToResult<TRes>(this ResultMo res)
            where TRes : ResultMo, new()
        {
            if (res is TRes tres)
                return tres;

            if (!res.IsSuccess())
                return res.ConvertToResultInherit<TRes>();

            return new TRes()
            {
                sys_ret = (int) SysResultTypes.InnerError,
                ret = (int) ResultTypes.InnerError,
                msg = $"Return value error! Can't convert to {typeof(TRes)}"
            };
        }

    }
}
