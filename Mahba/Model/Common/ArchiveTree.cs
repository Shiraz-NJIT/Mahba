using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Model.Common
{
    partial class ArchiveTree
    {
        public enum NodeTypes
        {
            Node,
            ArchiveGroup,
            Archive,
            Filter,
            GroupBy
        }

        public string GetArchiveName()
        {
            switch (this.GetNodeType())
            {
                case NodeTypes.Node:
                    return null;
                case NodeTypes.ArchiveGroup:
                    return null;
                case NodeTypes.Archive:
                    return this.Archive.Name;
                case NodeTypes.Filter:
                    return this.Archive.Name;
                case NodeTypes.GroupBy:
                    return this.Archive.Name;
                default:
                    throw new Exception();
            }
        }

        public NodeTypes GetNodeType()
        {
            if (this.ArchiveGroupID == null && this.ArchiveID == null && this.Filter == null && this.GroupBy == null)
                return NodeTypes.Node;
            if (this.ArchiveGroupID.HasValue && this.ArchiveID == null)
                return NodeTypes.ArchiveGroup;
            if (this.ArchiveID.HasValue && this.Filter == null && this.GroupBy == null)
                return NodeTypes.Archive;
            if (this.ArchiveID.HasValue && this.Filter != null && this.GroupBy == null)
                return NodeTypes.Filter;
            if (this.ArchiveID.HasValue && this.Filter == null && this.GroupBy != null)
                return NodeTypes.GroupBy;
            throw new Exception();
        }
    }
}
