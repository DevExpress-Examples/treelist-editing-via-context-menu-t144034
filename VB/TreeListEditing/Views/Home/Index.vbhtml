@ModelType System.Collections.IEnumerable
<script type="text/javascript">
    var nodeKey;
    var parentNodeKey;

    function OnContextMenu(s, e) {
        if (e.objectType === "Node") {
            var x = ASPxClientUtils.GetEventX(e.htmlEvent);
            var y = ASPxClientUtils.GetEventY(e.htmlEvent);
            PopupMenu.ShowAtPos(x, y);

            nodeKey = e.objectKey;
            var node = s.GetNodeHtmlElement(nodeKey);
            parentNodeKey = node.getAttribute("ParentNodeKey");
        }
    }
    function OnItemClick(s, e) {
        switch (e.item.name) {
            case "NewRoot":
                TreeList.StartEditNewNode();
                break;
            case "NewSibling":
                TreeList.StartEditNewNode(parentNodeKey);
                break;
            case "NewChild":
                TreeList.StartEditNewNode(nodeKey);
                break;
            case "Edit":
                TreeList.StartEdit(nodeKey);
                break;
            case "Delete":
                TreeList.DeleteNode(nodeKey);
                break;
        }
    }
</script>
@Html.DevExpress().PopupMenu( _
    Sub(settings)
            settings.Name = "PopupMenu"
            settings.AllowSelectItem = False
            settings.Items.Add("New - Root", "NewRoot")
            settings.Items.Add("New - Sibling", "NewSibling")
            settings.Items.Add("New - Child", "NewChild")
            settings.Items.Add("Edit", "Edit")
            settings.Items.Add("Delete", "Delete")
            settings.ClientSideEvents.ItemClick = "OnItemClick"
End Sub).GetHtml()

@Using (Html.BeginForm())
    @Html.Partial("TreeListPartial", Model)
End Using