using System.Collections.Generic;
using System.Linq;
using UltraNuke.Barasingha.Permission.Domain.AggregatesModel;

namespace UltraNuke.Barasingha.Permission.API.Application.Commands
{
    public class MenuCommandHandlerBase
    {
        protected IList<Menu> Traverse(IList<Menu> allNodes, IList<Menu> nodes)
        {
            foreach (var node in nodes)
            {
                var childNodes = allNodes.Where(x => x.ParentNodeId == node.Id).ToList();
                node.SetChildNodes(childNodes);
                node.SetChildNodes(Traverse(allNodes, node.ChildNodes));
            }
            return nodes;
        }
    }

}
