<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticleManage.aspx.cs" Inherits="WebUI.ArticleManage.ArticleManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>文章管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/js/jqwidgets-ver3.1.0/jqwidgets/styles/jqx.base.css" type="text/css" />
    <script type="text/javascript" src="/js/jqwidgets-ver3.1.0/scripts/jquery-1.10.2.min.js"></script>
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
    <script src="../js/lhgdialog/lhgdialog.min.js"></script>
    <script src="../js/lhgdialog/ShowDialog.js"></script>
    <script type="text/javascript">
        var deleteConfirm = function (id) {
            $.dialog.confirm("您确定要删除吗？", function () {
                var obj = new Object();
                obj.id = id;
                var jsonobj = JSON.stringify(obj);
                $.ajax({
                    type: "POST",
                    url: "../API/Article.svc/DeleteArticle",
                    contentType: "application/json; charset=utf-8",
                    data: jsonobj,
                    dataType: 'json',
                    beforeSend: function () {
                        $.dialog.tips('数据加载中...', 6000, 'loading.gif');
                    },
                    success: function (result) {
                        var jsondatas = JSON.parse(result.d);
                        MessageAlert(jsondatas.message, jsondatas.result, window.location.href);
                    }
                });
            });
        };
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
                url: '/HanderAshx/ArticleManage/ArticleHandler.ashx',
                cache: false,
                datatype: "json",
                root: "Rows",
                datafields: [
                    { name: 'ID', type: 'string' },
                    { name: 'OID', type: 'string' },
                    { name: 'Title', type: 'string' },
                    { name: 'Content', type: 'string' },
                    { name: 'IsHot', type: 'bool' },
                    { name: 'Type', type: 'string' }
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
                var data = $("#jqxgrid").jqxGrid('getrowdata', row);
                var rightEdit = '<%=RightEdit%>' === 'True';
                var rightDelete = '<%=RightDelete%>' === 'True';
                var link = "";
                if (rightEdit)
                    link += "<a href='ArticleEdit.aspx?" + parm + "'  target='_self' style='margin-left:10px;height:25px;line-height:25px;'>修改</a>";
                if (rightDelete)
                    link += "<a style='text-align:center;margin-left:15px;height:25px; line-height:25px;' href='javascript:void(0)' onclick=\"deleteConfirm('" + data.OID + "')\"; target='_self'>删除</a>";
                return link;
            };

            var isHotrenderer = function (row, column, value) {
                var strHtml = '<div style="text-overflow: ellipsis; overflow: hidden; padding-bottom: 2px; text-align: center; margin-top: 5px;">';
                if (value) {
                    strHtml += "是";
                } else {
                    strHtml += "否";
                }
                strHtml += "</div>";
                return strHtml;
            };
            
            var typerenderer = function (row, column, value) {
                var strHtml = '<div style="text-overflow: ellipsis; overflow: hidden; padding-bottom: 2px; text-align: center; margin-top: 5px;">';
                if (value == "txt") {
                    strHtml += "文本";
                } else if (value == "img") {
                    strHtml += "图文";
                } else if (value == "imgs") {
                    strHtml += "图集";
                } else {
                    strHtml += "视频";
                }
                strHtml += "</div>";
                return strHtml;
            };

            //数据绑定
            $("#jqxgrid").jqxGrid({
                theme: theme,
                source: dataadapter,
                width: 1580,
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
                        window.location.href = "/ArticleManage/ArticleEdit.aspx?columnId=<%=ColumnId%>";
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
                    { text: '<b>文章标题</b>', dataField: 'Title', width: 250, cellsalign: 'center', align: 'center' },
                    { text: '<b>文章类型</b>', dataField: 'Type', width: 120, cellsalign: 'center', align: 'center', cellsrenderer: typerenderer },
                    { text: '<b>文章内容</b>', dataField: 'Content', width: 500, cellsalign: 'center', align: 'center' },
                    { text: '<b>是否推荐</b>', dataField: 'IsHot', width: 120, cellsalign: 'center', align: 'center', cellsrenderer: isHotrenderer }
                ]
            });

        });
    </script>
</head>
<body>
    <div id='jqxWidget' style="font-size: 13px; font-family: Verdana; float: left;">
        <div id="jqxgrid">
        </div>
    </div>
</body>
</html>