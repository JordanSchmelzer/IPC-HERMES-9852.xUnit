using Xunit;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using IPC_HERMES_9852.Hermes.Messages;


namespace IPC_HERMES_9852.xUnit {
  public class BoardArrivedTests {
    [Fact]
    public void ToHermesXml_HasAllRequiredFields_V1_6() {
      // Arrange
      var hermes = new BoardArrived();
      var requiredNodes = new[] {
        "MachineId", "UpstreamLaneId", "UpstreamInterfaceId", "MagazineId",
        "SlotId", "BoardTransfer", "BoardId", "BoardIdCreatedBy", "FailedBoard",
        "ProductTypeId", "FlippedBoard", "TopBarcode", "BottomBarcode", "Length",
        "Width", "Thickness", "ConveyorSpeed", "TopClearanceHeight", "BottomClearanceHeight",
        "Weight", "WorkOrderId", "BatchId", "Route", "Action", "SubBoards"
      };

      // Act
      var xml = hermes.ToHermesXml();
      var nodes = xml.DescendantNodes()
                     .OfType<XElement>() // Filter to XElement types only
                     .Select(node => node.Name.LocalName)
                     .ToList();
      bool allNodesExist = requiredNodes.All(requiredNode => nodes.Contains(requiredNode));

      // Assert
      Assert.NotNull(nodes);
      Assert.True(allNodesExist);
    }
  }
}
