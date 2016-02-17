<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoteUserManage.aspx.cs" Inherits="WebUI.VoteManage.VoteUserManage" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>报名管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/js/jqwidgets-ver3.1.0/jqwidgets/styles/jqx.base.css" type="text/css" />
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/scripts/jquery-1.10.2.min.js"></script>
    <script src="/js/select2css.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxcore.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxdata.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxbuttons.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxscrollbar.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxlistbox.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxdropdownlist.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxmenu.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxgrid.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxgrid.pager.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxgrid.sort.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxgrid.filter.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxgrid.columnsresize.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxgrid.selection.js"></script>
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/jqwidgets/jqxpanel.js"></script>
    <link href="/js/jqwidgets-ver3.1.0/jqwidgets/styles/jqx.arctic.css" rel="stylesheet" />
    <link href="../css/global.css" rel="stylesheet" />
    <link href="../css/icon.css" rel="stylesheet" />
    <link href="/css/select.css" rel="stylesheet" />
    <script src="../js/lhgdialog/lhgdialog.min.js"></script>
    <script src="../js/lhgdialog/ShowDialog.js"></script>
    <style type="text/css">
        #searchbar span { height: 29px; text-indent: 5px; line-height: 29px; }
        .selectDiv .select_box { width: 85px; }
        .selectDiv2 .select_box { width: 105px; }
    </style>
    <script type="text/javascript">
        $(function () {
            //主题
            var theme = "arctic";

            //参数组装
            function buildQueryString(data) {
                var str = ''; for (var prop in data) {
                    if (data.hasOwnProperty(prop)) {
                        str += prop + '=' + data[prop] + '&';
                    }
                }
                return str.substr(0, str.length - 1);
            }

            var formatedData = '';

            //数据源
            var source = {
                url: '/HanderAshx/VoteManage/VoteUserHandler.ashx',
                cache: false,
                datatype: "json",
                root: "Rows",
                datafields: [
                    { name: 'ID', type: 'string' },
                    { name: 'UserName', type: 'string' }
                ],
                pagesize: 20,
                formatdata: function (data) {
                    data.pagenum = data.pagenum || 0;
                    data.pagesize = data.pagesize || 20;
                    data.sortdatafield = data.sortdatafield || 'ID';
                    data.sortorder = data.sortorder || 'DESC';
                    formatedData = buildQueryString(data);
                    return formatedData;
                },
                sort: function () { $("#jqxgrid").jqxGrid('updatebounddata', 'sort'); },
                beforeprocessing: function (data) { source.totalrecords = data.TotalRows; }
            };

            //数据处理
            var dataadapter = new $.jqx.dataAdapter(source, {
                contentType: "application/json; charset=utf-8",
                loadError: function (xhr, status, error) {
                    alert(error);
                }
            });
            var linkrenderer = function (row, column, value) {
                var parm = column + "=" + value + "&columnId=<%=ColumnId%>";
                var rightEdit = '<%=RightEdit%>' === 'True';
                var link = "";
                if (rightEdit)
                    link += "<a href='VoteEdit.aspx?" + parm + "'  target='_self' style='margin-left:10px;height:25px;line-height:25px;'>修改</a>";
                return link;
            };
            //数据绑定
            $("#jqxgrid").jqxGrid({
                theme: theme,
                source: dataadapter,
                width: 1180,
                rendergridrows: function (args) {
                    return args.data;
                },
                renderstatusbar: function (statusbar) {
                    var container = $("<div style='overflow: hidden; position: relative; margin: 5px;'></div>");
                    var addButton = $("<div style='float: left; margin-left: 5px; cursor:pointer;'><img style='position: relative; margin-top: 2px;' src='/js/jqwidgets-ver3.1.0/images/add.png'/><span style='margin-left: 4px; position: relative; top: -3px;'>增加</span></div>");
                    container.append(addButton);
                    statusbar.append(container);
                    addButton.jqxButton({ width: 60, height: 20 });
                    addButton.click(function (event) {
                        window.location.href = "/VoteManage/VoteEdit.aspx?columnId=<%=ColumnId%>";
                    });
                },
                showstatusbar: true,
                sortable: true,
                pageable: true,
                autoheight: true,
                virtualmode: true,
                sorttogglestates: 1,
                pagesizeoptions: ['10', '20', '30'],
                columns: [
                    { text: '<b>操作</b>', dataField: 'ID', width: 80, cellsalign: 'center', align: 'center', cellsrenderer: linkrenderer },
                    { text: '<b>文章标题</b>', dataField: 'Title', width: 250, cellsalign: 'center', align: 'center' }
                ]
            });

        });
    </script>
</head>
<body>
    <div id="searchbar" class="selectDiv" style="min-width: 1000px;">
        <div class="fl">
            <img src="/images/input_left.png" width="4" height="29" alt="" />
        </div>
        <select name="selSUserType" id="selSUserType" class="fl" runat="server">
            <option value="0">会员名</option>
            <option value="1">真实姓名</option>
            <option value="2">手机号码</option>
        </select>
        <div class="fl" style="margin-left: -5px; cursor: pointer;">
            <img src="../images/select_right.png" width="31" height="29" alt="" id="img_selSUserType" />
        </div>
        <div style="float: left;">
            <input id="txtName" type="text" name="txtName" value="" class="input_text fl" maxlength="20" style="width: 150px;" runat="server" />
            <div class="fl">
                <img src="../images/input_right.png" style="width: 4px; height: 29px;" alt="" />
            </div>
        </div>
        <div class="fl" style="margin-left: 10px;">
            <img src="/images/input_left.png" width="4" height="29" alt="" />
        </div>
        <select name="selVote" runat="server" id="selVote" class="fl">
        </select>
        <div class="fl" style="margin-left: -5px; cursor: pointer;">
            <img src="../images/select_right.png" width="31" height="29" alt="" id="img_selVote" />
        </div>
        <div style="float: left; margin-left: 5px;">
            <input type="button" id="applyfilter" value="查 询" class="inputButton" />
        </div>
    </div>
    <div id='jqxWidget' style="font-size: 13px; font-family: Verdana; float: left;">
        <div id="jqxgrid">
        </div>
    </div>
</body>
</html>