<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LayoutEditorTestPage.aspx.cs" Inherits="LayoutEditor.Web.LayoutEditorTestPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>LayoutEditor</title>
    <style type="text/css">
        html, body
        {
            height: 100%;
            overflow: auto;
        }

        body
        {
            padding: 0;
            margin: 0;
        }

        #silverlightControlHost
        {
            height: 100%;
            text-align: center;
        }
    </style>
    <script type="text/javascript" src="Silverlight.js"></script>
    <%--    <script type="text/javascript" src="LayoutEditorJS.js"></script>--%>
    <script type="text/javascript">
        function oncancel() {
            alert('onclose');
        }

        function clickok() {
            alert('clickok');
        }

        function onok(path, layoutid, typegroupinfo, numUsedWellsFirstPlate) {
            clickok();
            alert('onok');
            //            window.parent.document.getElementById(idprefix + 'HiddenFieldPng').value = path;
            //            window.parent.document.getElementById(idprefix + 'HiddenFieldLayoutId').value = layoutid;
            //            window.parent.document.getElementById(idprefix + 'HiddenFieldTypeGroupInfo').value = typegroupinfo;
            //            window.parent.document.getElementById(idprefix + 'HiddenFieldNUWFP').value = numUsedWellsFirstPlate;
        }


        function onflagok(flaggedPositionNums) {
            alert('onflagok');
            //            // Note, here we are reusing the hidden fields for a different purpose else
            //            window.parent.document.getElementById(idprefix + 'HiddenFieldPng').value = 'flag';
            //            window.parent.document.getElementById(idprefix + 'HiddenFieldTypeGroupInfo').value = flaggedPositionNums;
            clickok();
        }


        function GetJsonLPE() {
            switch (<%= ConfigNum%>) {
                case 0:
                    return '{\"Default\":\"2,1,2,1,5,1,5,1,5,9,5,9,5,17,5,17,5,25,5,25,5,33,5,33,2,2,2,2,5,2,5,2,5,10,5,10,5,18,5,18,5,26,5,26,5,34,5,34,2,3,2,3,5,3,5,3,5,11,5,11,5,19,5,19,5,27,5,27,5,35,5,35,2,4,2,4,5,4,5,4,5,12,5,12,5,20,5,20,5,28,5,28,5,36,5,36,2,5,2,5,5,5,5,5,5,13,5,13,5,21,5,21,5,29,5,29,5,37,5,37,2,6,2,6,5,6,5,6,5,14,5,14,5,22,5,22,5,30,5,30,5,38,5,38,3,1,3,1,5,7,5,7,5,15,5,15,5,23,5,23,5,31,5,31,5,39,5,39,4,1,4,1,5,8,5,8,5,16,5,16,5,24,5,24,5,32,5,32,5,40,5,40\",\"EraseOnly\":false,\"Height\":8,\"RackMode\":false,\"Rules\":[{\"AllGroupsSameReplicates\":false,\"Description\":null,\"MatchGroupsInTypeId\":0,\"MaxNumGroups\":0,\"MaxNumReplicates\":0,\"MergeGroupsWithType\":0,\"MinNumGroups\":2,\"MinNumReplicates\":0,\"NumGroups\":0,\"NumReplicates\":0,\"TypeId\":2},{\"AllGroupsSameReplicates\":false,\"Description\":null,\"MatchGroupsInTypeId\":0,\"MaxNumGroups\":1,\"MaxNumReplicates\":0,\"MergeGroupsWithType\":0,\"MinNumGroups\":0,\"MinNumReplicates\":0,\"NumGroups\":0,\"NumReplicates\":0,\"TypeId\":3}],\"SampleTypes\":[{\"Colour\":\"White\",\"Id\":1,\"Name\":\"Unused\"},{\"Colour\":\"Red\",\"Id\":2,\"Name\":\"Standard\"},{\"Colour\":\"Aqua\",\"Id\":4,\"Name\":\"Control\"},{\"Colour\":\"Lime\",\"Id\":5,\"Name\":\"Unknown\"},{\"Colour\":\"Yellow\",\"Id\":3,\"Name\":\"Blank\"}],\"Width\":12}';
                case 1:
                    return '{"Default":"3,1,2,1,2,5,5,4,5,8,5,12,5,16,5,20,5,24,5,28,5,32,5,36,3,1,2,1,2,5,5,4,5,8,5,12,5,16,5,20,5,24,5,28,5,32,5,36,26,1,2,2,5,1,5,5,5,9,5,13,5,17,5,21,5,25,5,29,5,33,5,37,26,1,2,2,5,1,5,5,5,9,5,13,5,17,5,21,5,25,5,29,5,33,5,37,25,1,2,3,5,2,5,6,5,10,5,14,5,18,5,22,5,26,5,30,5,34,5,38,25,1,2,3,5,2,5,6,5,10,5,14,5,18,5,22,5,26,5,30,5,34,5,38,24,1,2,4,5,3,5,7,5,11,5,15,5,19,5,23,5,27,5,31,5,35,5,39,24,1,2,4,5,3,5,7,5,11,5,15,5,19,5,23,5,27,5,31,5,35,5,39","EraseOnly":false,"Height":8,"RackMode":false,"Rules":[{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MinNumGroups":1,"MinNumReplicates":0,"NumGroups":0,"NumReplicates":0,"TypeId":5},{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":5,"NumReplicates":0,"TypeId":2},{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":1,"NumReplicates":0,"TypeId":3},{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":1,"NumReplicates":0,"TypeId":24},{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":1,"NumReplicates":0,"TypeId":25},{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":1,"NumReplicates":0,"TypeId":26}],"SampleTypes":[{"Colour":"White","Id":1,"Name":"Unused"},{"Colour":"Red","Id":2,"Name":"Standard"},{"Colour":"Yellow","Id":3,"Name":"Blank"},{"Colour":"#FFD080","Id":24,"Name":"B0"},{"Colour":"#FF80FF","Id":25,"Name":"NSB"},{"Colour":"#9E8010","Id":26,"Name":"TA"},{"Colour":"Lime","Id":5,"Name":"Unknown"}],"Width":12}';
                case 2:
                    return '{"Default":"8,1,8,1,8,1,7,1,7,1,7,1,5,6,5,6,5,6,5,6,5,6,5,6,3,1,3,2,3,3,3,4,3,5,3,6,5,7,5,7,5,7,5,7,5,7,5,7,3,1,3,2,3,3,3,4,3,5,3,6,5,8,5,8,5,8,5,8,5,8,5,8,5,1,5,1,5,1,5,1,5,1,5,1,5,9,5,9,5,9,5,9,5,9,5,9,5,2,5,2,5,2,5,2,5,2,5,2,5,10,5,10,5,10,5,10,5,10,5,10,5,3,5,3,5,3,5,3,5,3,5,3,5,11,5,11,5,11,5,11,5,11,5,11,5,4,5,4,5,4,5,4,5,4,5,4,5,12,5,12,5,12,5,12,5,12,5,12,5,5,5,5,5,5,5,5,5,5,5,5,5,13,5,13,5,13,5,13,5,13,5,13","EraseOnly":true,"Height":8,"RackMode":false,"Rules":[{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":6,"NumReplicates":0,"TypeId":3},{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":1,"NumReplicates":0,"TypeId":7},{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":1,"NumReplicates":0,"TypeId":8},{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MinNumGroups":1,"MinNumReplicates":0,"NumGroups":0,"NumReplicates":0,"TypeId":5}],"SampleTypes":[{"Colour":"White","Id":1,"Name":"Unused"},{"Colour":"Yellow","Id":3,"Name":"Blank"},{"Colour":"#7DFFFF","Id":7,"Name":"Pos Control"},{"Colour":"#FEFCCF","Id":8,"Name":"Neg Control"},{"Colour":"Lime","Id":5,"Name":"Unknown"}],"Width":12}';
                case 3:
                    return '{"Default":"8,1,8,1,8,1,7,1,7,1,7,1,5,6,5,6,5,6,5,6,5,6,5,6,3,1,3,2,3,3,3,4,3,5,3,6,5,7,5,7,5,7,5,7,5,7,5,7,3,1,3,2,3,3,3,4,3,5,3,6,5,8,5,8,5,8,5,8,5,8,5,8,5,1,5,1,5,1,5,1,5,1,5,1,5,9,5,9,5,9,5,9,5,9,5,9,5,2,5,2,5,2,5,2,5,2,5,2,5,10,5,10,5,10,5,10,5,10,5,10,5,3,5,3,5,3,5,3,5,3,5,3,5,11,5,11,5,11,5,11,5,11,5,11,5,4,5,4,5,4,5,4,5,4,5,4,5,12,5,12,5,12,5,12,5,12,5,12,5,5,5,5,5,5,5,5,5,5,5,5,5,13,5,13,5,13,5,13,5,13,5,13,8,1,8,1,8,1,7,1,7,1,7,1,5,6,5,6,5,6,5,6,5,6,5,6,3,1,3,2,3,3,3,4,3,5,3,6,5,7,5,7,5,7,5,7,5,7,5,7,3,1,3,2,3,3,3,4,3,5,3,6,5,8,5,8,5,8,5,8,5,8,5,8,5,1,5,1,5,1,5,1,5,1,5,1,5,9,5,9,5,9,5,9,5,9,5,9,5,2,5,2,5,2,5,2,5,2,5,2,5,10,5,10,5,10,5,10,5,10,5,10,5,3,5,3,5,3,5,3,5,3,5,3,5,11,5,11,5,11,5,11,5,11,5,11,5,4,5,4,5,4,5,4,5,4,5,4,5,12,5,12,5,12,5,12,5,12,5,12,5,5,5,5,5,5,5,5,5,5,5,5,5,13,5,13,5,13,5,13,5,13,5,13,8,1,8,1,8,1,7,1,7,1,7,1,5,6,5,6,5,6,5,6,5,6,5,6,3,1,3,2,3,3,3,4,3,5,3,6,5,7,5,7,5,7,5,7,5,7,5,7,3,1,3,2,3,3,3,4,3,5,3,6,5,8,5,8,5,8,5,8,5,8,5,8,5,1,5,1,5,1,5,1,5,1,5,1,5,9,5,9,5,9,5,9,5,9,5,9,5,2,5,2,5,2,5,2,5,2,5,2,5,10,5,10,5,10,5,10,5,10,5,10,5,3,5,3,5,3,5,3,5,3,5,3,5,11,5,11,5,11,5,11,5,11,5,11,5,4,5,4,5,4,5,4,5,4,5,4,5,12,5,12,5,12,5,12,5,12,5,12,5,5,5,5,5,5,5,5,5,5,5,5,5,13,5,13,5,13,5,13,5,13,5,13,8,1,8,1,8,1,7,1,7,1,7,1,5,6,5,6,5,6,5,6,5,6,5,6,3,1,3,2,3,3,3,4,3,5,3,6,5,7,5,7,5,7,5,7,5,7,5,7,3,1,3,2,3,3,3,4,3,5,3,6,5,8,5,8,5,8,5,8,5,8,5,8,5,1,5,1,5,1,5,1,5,1,5,1,5,9,5,9,5,9,5,9,5,9,5,9,5,2,5,2,5,2,5,2,5,2,5,2,5,10,5,10,5,10,5,10,5,10,5,10,5,3,5,3,5,3,5,3,5,3,5,3,5,11,5,11,5,11,5,11,5,11,5,11,5,4,5,4,5,4,5,4,5,4,5,4,5,12,5,12,5,12,5,12,5,12,5,12,5,5,5,5,5,5,5,5,5,5,5,5,5,13,5,13,5,13,5,13,5,13,5,13","EraseOnly":true,"Height":16,"RackMode":false,"Rules":[{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":6,"NumReplicates":0,"TypeId":3},{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":1,"NumReplicates":0,"TypeId":7},{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":1,"NumReplicates":0,"TypeId":8},{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MinNumGroups":1,"MinNumReplicates":0,"NumGroups":0,"NumReplicates":0,"TypeId":5}],"SampleTypes":[{"Colour":"White","Id":1,"Name":"Unused"},{"Colour":"Yellow","Id":3,"Name":"Blank"},{"Colour":"#7DFFFF","Id":7,"Name":"Pos Control"},{"Colour":"#FEFCCF","Id":8,"Name":"Neg Control"},{"Colour":"Lime","Id":5,"Name":"Unknown"}],"Width":24}';
                case 4:
                    return '{"Default":"8,1,8,1,8,1,7,1,7,1,7,1,5,6,5,6,5,6,5,6,5,6,5,6","EraseOnly":true,"Height":3,"RackMode":false,"Rules":[{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":6,"NumReplicates":0,"TypeId":3},{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":1,"NumReplicates":0,"TypeId":7},{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":1,"NumReplicates":0,"TypeId":8},{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MinNumGroups":1,"MinNumReplicates":0,"NumGroups":0,"NumReplicates":0,"TypeId":5}],"SampleTypes":[{"Colour":"White","Id":1,"Name":"Unused"},{"Colour":"Yellow","Id":3,"Name":"Blank"},{"Colour":"#7DFFFF","Id":7,"Name":"Pos Control"},{"Colour":"#FEFCCF","Id":8,"Name":"Neg Control"},{"Colour":"Lime","Id":5,"Name":"Unknown"}],"Width":4}';
                case 5:
                    return '{"Default":"2,1,2,1,110,1,110,5,110,9,110,13,110,17,110,21,110,25,110,29,110,33,110,37,2,2,2,2,111,1,111,5,111,9,111,13,111,17,111,21,111,25,111,29,111,33,111,37,2,3,2,3,110,2,110,6,110,10,110,14,110,18,110,22,110,26,110,30,110,34,110,38,2,4,2,4,111,2,111,6,111,10,111,14,111,18,111,22,111,26,111,30,111,34,111,38,2,5,2,5,110,3,110,7,110,11,110,15,110,19,110,23,110,27,110,31,110,35,110,39,2,6,2,6,111,3,111,7,111,11,111,15,111,19,111,23,111,27,111,31,111,35,111,39,7,1,7,1,110,4,110,8,110,12,110,16,110,20,110,24,110,28,110,32,110,36,110,40,8,1,8,1,111,4,111,8,111,12,111,16,111,20,111,24,111,28,111,32,111,36,111,40","EraseOnly":false,"Height":8,"RackMode":false,"Rules":[{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MergeGroupsWithType":0,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":6,"NumReplicates":0,"TypeId":2},{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":2,"MergeGroupsWithType":0,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":0,"NumReplicates":0,"TypeId":2},{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MergeGroupsWithType":0,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":1,"NumReplicates":0,"TypeId":7},{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":2,"MergeGroupsWithType":0,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":0,"NumReplicates":0,"TypeId":7},{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MergeGroupsWithType":0,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":1,"NumReplicates":0,"TypeId":8},{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":2,"MergeGroupsWithType":0,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":0,"NumReplicates":0,"TypeId":8},{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":2,"MergeGroupsWithType":0,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":0,"NumReplicates":0,"TypeId":110},{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":2,"MergeGroupsWithType":0,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":0,"NumReplicates":0,"TypeId":111},{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MergeGroupsWithType":111,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":0,"NumReplicates":0,"TypeId":110}],"SampleTypes":[{"Colour":"White","Id":1,"Name":"Unused"},{"Colour":"Red","Id":2,"Name":"ADL CAL"},{"Colour":"Cyan","Id":7,"Name":"PC"},{"Colour":"Yellow","Id":8,"Name":"NC"},{"Colour":"#00c000","Id":110,"Name":"Unknown 1:10"},{"Colour":"#c0ffc0","Id":111,"Name":"Unknown 1:200"}],"Width":12}';
                case 6:
                    return '{"Default":"5,1,5,2,5,3,5,4,5,5,5,6,5,7,5,8,2,1,2,2,2,3,2,4,2,5,2,6,2,7,2,8","EraseOnly":false,"RackMode":false,"Rules":[{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MergeGroupsWithType":0,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":8,"NumReplicates":0,"TypeId":2},{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MergeGroupsWithType":0,"MinNumGroups":1,"MinNumReplicates":0,"NumGroups":0,"NumReplicates":0,"TypeId":5}],"SampleTypes":[{"Colour":"White","Id":1,"Name":"Unused"},{"Colour":"Red","Id":2,"Name":"Standard"},{"Colour":"Green","Id":5,"Name":"Unknown"}],"Height":8,"Width":2,"IsMultiple":true,"ContainerName":"Slide","MultipleLayout":"ThumbsVertical"}';
                case 7:
                    return '{"Height":8,"Width":2,"Default":"5,1,5,2,5,3,5,4,5,5,5,6,5,7,5,8,2,1,2,2,2,3,2,4,2,5,2,6,2,7,2,8","IsMultiple":true,"ContainerName":"Slide","MultipleLayout":"ThumbsVertical","CalibratorGroups":"12,13,14","GroupCalibratorTypes": true,"GroupNumbering":"AbsoluteExceptCalibrators","EraseOnly":false,"RackMode":false,"Rules":[{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MergeGroupsWithType":0,"MinNumGroups":0,"MinNumReplicates":0,"NumGroups":8,"NumReplicates":0,"TypeId":2},{"AllGroupsSameReplicates":false,"Description":null,"MatchGroupsInTypeId":0,"MaxNumGroups":0,"MaxNumReplicates":0,"MergeGroupsWithType":0,"MinNumGroups":1,"MinNumReplicates":0,"NumGroups":0,"NumReplicates":0,"TypeId":5}],"SampleTypes":[{"Colour":"White","Id":1,"Name":"Unused"},{"Colour":"Red","Id":2,"Name":"StandardX"},{"Colour":"Pink","Id":3,"Name":"StandardY"},{"Colour":"#FFE9E9","Id":4,"Name":"StandardZ"},{"Colour":"Green","Id":5,"Name":"Unknown"}]}';
                default :
                    alert("Configuration not implemented");
            }
        }

        function hideslc() {
            alert('hideslc');
            //            s = document.getElementById('silverlightControlHost');
            //            s.setAttribute("style", "visibility:hidden");
        }

        function Help(page) {
            alert('help');
            //            PopupHelp(page);
        }
        function onSilverlightError(sender, args) {
            var appSource = "";
            if (sender != null && sender != 0) {
                appSource = sender.getHost().Source;
            }

            var errorType = args.ErrorType;
            var iErrorCode = args.ErrorCode;

            if (errorType == "ImageError" || errorType == "MediaError") {
                return;
            }

            var errMsg = "Unhandled Error in Silverlight Application " + appSource + "\n";

            errMsg += "Code: " + iErrorCode + "    \n";
            errMsg += "Category: " + errorType + "       \n";
            errMsg += "Message: " + args.ErrorMessage + "     \n";

            if (errorType == "ParserError") {
                errMsg += "File: " + args.xamlFile + "     \n";
                errMsg += "Line: " + args.lineNumber + "     \n";
                errMsg += "Position: " + args.charPosition + "     \n";
            }
            else if (errorType == "RuntimeError") {
                if (args.lineNumber != 0) {
                    errMsg += "Line: " + args.lineNumber + "     \n";
                    errMsg += "Position: " + args.charPosition + "     \n";
                }
                errMsg += "MethodName: " + args.methodName + "     \n";
            }

            throw new Error(errMsg);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" style="height: 100%">
        <div id="silverlightControlHost">
            <object data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="100%" height="100%">
                <param name="source" value="ClientBin/LayoutEditor.xap" />
                <param name="onError" value="onSilverlightError" />
                <param name="background" value="white" />
                <param name="minRuntimeVersion" value="4.0.60310.0" />
                <param name="autoUpgrade" value="true" />
                <param name="initParams" value="LayoutId=<%=GetLayoutId () %>,
                    UserId=<%=GetUserId ()%>,
                    ServiceAddress=<%=GetServiceAddress() %>,
                    AssociatedAssayId=<%=GetAssociatedAssayId () %>,
                    IsPreviousRunEdit=<%=GetIsPreviousRunEdit() %>, 
                    PreviousRunId=<%=GetPreviousRunId() %>, 
                    PreviousRunOriginator=<%=GetPreviousRunOriginator() %>, 
                    IsFlagMode=<%=GetIsFlagMode() %>, 
                    ResultsPathFormat=MyAssaysBlobAzure" />
                <a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=4.0.60310.0" style="text-decoration: none">
                    <img src="http://go.microsoft.com/fwlink/?LinkId=161376" alt="Get Microsoft Silverlight" style="border-style: none" />
                </a>
            </object>
            <iframe id="_sl_historyFrame" style="visibility: hidden; height: 0px; width: 0px; border: 0px"></iframe>
        </div>
    </form>
</body>
</html>
