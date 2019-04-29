﻿using OSS.Common.ComModels;
using OSS.TaskFlow.Tasks.Interfaces;

namespace OSS.TaskFlow.Node.DNodes
{
   public class BaseCloseNode<TReq, TDomain, TRes> : BaseDomainNode<TReq, TDomain, TRes> 
       where TRes : ResultMo, new()
       where TDomain : IDomainMo
    {

    }
}