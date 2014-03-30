var rTLSkills;

function findParentItem(element) {
    if (element.tagName.toLowerCase() == "html")
        return null;
    while (!(element.id != "" && typeof element.tagName != "undefined" && element.tagName.toLowerCase() == "tr")) {
        if (element.parentNode == null)
            return null;
        element = element.parentNode;
    }
    return element;
}

function get_isTreeListChild(elem) {
    var isInrTLSkills = $telerik.isDescendant(rTLSkills.get_element(), elem);
    return isInrTLSkills;
}

function get_dropTarget(domEvent) {
    return domEvent.srcElement || domEvent.target;
}

function itemDragging(sender, args) {
    var isChild;
    var dropClue = $telerik.findElement(args.get_draggedContainer(), "DropClue");
    args.set_dropClueVisible(true);  //drop clue is always visible

    if (!args.get_canDrop()) //trying to drag a parent item onto its own child
    {
        dropClue.className = "dropClue dropDisabled";

        return;
    }

    else
    {
        isChild = get_isTreeListChild(get_dropTarget(args.get_domEvent()));   //is child of rTLSkills 
    }

    var className = isChild ? "dropEnabled" : "dropDisabled"; //Change drop clue icon depending on the drop target             
    args.set_canDrop(isChild);
    dropClue.className = "dropClue " + className;
}

function itemDropping(sender, args) {

    var targetRow = findParentItem(args.get_destinationHtmlElement());

    //Target row is null or not a child of RadTreeList -> Cancel
    if (targetRow == null || !get_isTreeListChild(targetRow)) {
        args.set_cancel(true);
        return;
    }

    //Target row is descendant of the sender -> Reorder operation
    if ($telerik.isDescendant(sender.get_element(), targetRow))
        return;

    ////Target row is descendant of RadTreeList2 -> Copy/Move item 
    //args.set_cancel(true);

    var itm = args.get_draggedItems()[0];
    var SkillID = $find(targetRow.id).get_dataKeyValue("SkillID");
    itm.fireCommand("CustomItemsDropped", SkillID); //Fire custom command
}