﻿using OSS.Common.Extention;
using OSS.EventTask.MetaMos;
using OSS.EventTask.Mos;

namespace OSS.EventNode.MetaMos
{
    public class NodeMeta
    {

        public string flow_id { get; set; }

        public string node_id { get; set; }

        public string node_alias { get; set; }

        
        public NodeProcessType Process_type { get; set; }

        public OwnerType owner_type { get; set; }
    }


    public enum NodeProcessType
    {
        /// <summary>
        ///  串行
        /// </summary>
        [OSDescript("串行")] Serial,

        /// <summary>
        /// 并行
        /// </summary>
        [OSDescript("并行")] Parallel
    }



    public static class NodeMetaExtention
    {
        public static void WithNodeMeta(this TaskMeta taskMeta,NodeMeta nodeMeta)
        {
            taskMeta.owner_type = nodeMeta.owner_type;
            taskMeta.flow_id = nodeMeta.flow_id;
            taskMeta.node_id = nodeMeta.node_id;
        }
    }


}
