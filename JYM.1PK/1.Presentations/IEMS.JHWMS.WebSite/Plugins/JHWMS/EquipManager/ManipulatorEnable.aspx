<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManipulatorEnable.aspx.cs" Inherits="Plugins_JHWMS_EquipManager_ManipulatorEnable" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>设备信息查询与维护</title>
    <link rel="Stylesheet" type="text/css" href="<%= Page.ResolveUrl("~/") %>resources/css/ext-chinese-font.css" />
    <link rel="Stylesheet" type="text/css" href="<%= Page.ResolveUrl("~/") %>resources/css/main.css" />
    <script type="text/javascript">
        var thisDirUrl = "<%= Page.ResolveUrl("./") %>";
        var thisRootUrl = "<%= Page.ResolveUrl("~/") %>";
    </script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/") %>resources/js/jquery-1.7.1.js"></script>
    <!--gridMain数据展示-->
    <script type="text/javascript">
        //列表刷新数据重载方法
        var gridMainFresh = function () {
            var store = App.gridMain.getStore();
            store.currentPage = 1;
            store.pageSize = 100;
            App.gridMainPagingToolbar.doRefresh();
            return false;
        }
    </script>
    <script type="text/javascript">
        var commandcolumn_click = function (command, record) {
            if (command.toLowerCase() == "changeenable".toLowerCase()) {
                changeEnable(record);
            }
           
        }
    </script>
    <!--设置设备状态-->
    <script type="text/javascript">
        //列表刷新数据重载方法
        var changeEnable = function (record) {
            if (!record) {
                Ext.Msg.alert("提示", "请选择需要修改的设备");
                return;
            }
            var msg = "确定将码垛机械手【" + record.data.Equip_no + "】" + "设置为【"
            if (record.data.IS_ENABLED == 1) {
                msg = msg + "禁用";
            }
            else {
                msg = msg + "启用";
            }
            msg = msg + "】？";
            Ext.Msg.confirm("提示", msg, function (btn) {
                if (btn == "yes") {
                    var equipNo = record.data.Equip_no;
                    var enable = record.data.IS_ENABLED;
                    if (enable == '可用') { enable = 1; }
                    else { enable = 0;}
                    App.direct.ChangeEnable(equipNo, enable, {
                        success: function (result) {
                            if (result == "") {
                                gridMainFresh();
                                Ext.Msg.alert('成功', "数据保存成功！");
                            } else {
                                Ext.Msg.alert("失败", result);
                            }
                        },
                        failure: function (errorMsg) {
                            Ext.Msg.alert("错误", errorMsg);
                        }
                    });
                }
            });
            return false;
        }
    </script>
   
   
    <script type="text/javascript">
        //历史查询根据DeleteFlag的值进行样式绑定
        var SetRowClass = function (record) {
            if ((record.get("IS_ENABLED") == "0")) {
                return "x-grid-row-deleted";
            }
        }
        var template = '<span style="background:{0};width:70px;display:block;text-align:center;">{1}</span>';
        var pctChange = function (value) {
            return Ext.String.format(template, (value == "可用") ? "green" : "red", value);
        };
    </script>


</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server" />
        <ext:Viewport ID="viewport" runat="server" Layout="border">
            <Items>
                 <ext:Panel runat="server" Region="North" AutoHeight="true">
                   <TopBar>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:ToolbarSeparator />
                                <ext:Button runat="server" Icon="Find" Text="查询" ID="Button2">
                                    <Listeners>
                                        <Click Handler="gridMainFresh();" />
                                    </Listeners>
                                </ext:Button>
                                <ext:ToolbarSeparator />
                                <ext:ToolbarFill />
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                </ext:Panel>
                <ext:GridPanel ID="gridMain" runat="server" Region="Center">
                    <Store>
                        <ext:Store runat="server" PageSize="15">
                            <Proxy>
                                <ext:PageProxy DirectFn="App.direct.GridPanelBindData" />
                            </Proxy>
                            <Model>
                                <ext:Model runat="server">
                                    <Fields>
                                        <ext:ModelField Name="Equip_no" />
                                        <ext:ModelField Name="Equip_Name" />
                                        <ext:ModelField Name="Bind_product_line" />
                                        <ext:ModelField Name="IS_ENABLED" />
                                      <%--  <ext:ModelField Name="MAX_OUT_TASK_COUNT" />
                                        <ext:ModelField Name="MAX_IN_TASK_COUNT" />
                                        <ext:ModelField Name="MAX_INPUT_OUTTIME" />
                                        <ext:ModelField Name="CRN_STATUS" />
                                        <ext:ModelField Name="CRN_IN_ENABLE" />
                                        <ext:ModelField Name="CRN_OUT_ENABLE" />
                                        <ext:ModelField Name="LIMIT_TASK_SIZE" />
                                        <ext:ModelField Name="CRN_IN_ENABLE_DESC" />
                                        <ext:ModelField Name="CRN_OUT_ENABLE_DESC" />
                                        <ext:ModelField Name="CRN_FORK_ENABLE" />
                                        <ext:ModelField Name="CRN_FORK_ENABLE_DESC" />--%>

                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Width="35" runat="server" />
                            <ext:Column runat="server" DataIndex="Equip_no"      Text="设备编号"    Width="100" />
                            <ext:Column runat="server" DataIndex="Equip_Name"           Text="设备名称"    Width="100" />
                            <ext:Column runat="server" DataIndex="Bind_product_line"         Text="绑定生产线"    Width="100" />
                            <%--<ext:Column runat="server" DataIndex="Is_Enabled"  Text="叉状态位"        Width="80"/>--%>
                       
                            <ext:Column runat="server" DataIndex="IS_ENABLED" Text="是否可用"    Width="80" >
                                <Renderer Fn="pctChange" />
                            </ext:Column>

                          <%--  <ext:Column runat="server" DataIndex="CRN_OUT_ENABLE_DESC" Text="出库禁用" Width="80" >
                                <Renderer Fn="pctChange" />
                            </ext:Column>

                            <ext:Column runat="server" DataIndex="CRN_FORK_ENABLE_DESC" Text="叉禁用"    Width="80" >
                                <Renderer Fn="pctChange" />
                            </ext:Column>--%>
                            <ext:CommandColumn runat="server" Width="320" Text="操作" Align="Center">
                                <Commands>
                                    <ext:GridCommand Icon="LockKey" CommandName="changeEnable" Text="改变可用状态">
                                        <ToolTip Text="禁用/启用" />
                                    </ext:GridCommand>
                                    <ext:CommandSeparator />
                                   <%-- <ext:GridCommand Icon="LockKey" CommandName="OutputEnable" Text="改变出库状态">
                                        <ToolTip Text="禁用/启用堆垛机出库功能" />
                                    </ext:GridCommand>
                                    <ext:GridCommand Icon="LockKey" CommandName="DisEnable" Text="改变叉状态">
                                        <ToolTip Text="禁用/启用堆垛机叉" />
                                    </ext:GridCommand>--%>
                                </Commands>
                                <Listeners>
                                    <Command Handler="return commandcolumn_click(command, record);" />
                                </Listeners>
                            </ext:CommandColumn>
                            
                        </Columns>
                    </ColumnModel>
                    <BottomBar>
                        <ext:PagingToolbar ID="gridMainPagingToolbar" runat="server">
                            <Plugins>
                                <ext:ProgressBarPager runat="server" />
                            </Plugins>
                        </ext:PagingToolbar>
                    </BottomBar>
                    <View>
                        <ext:GridView runat="server" StripeRows="true" TrackOver="true" />
                    </View>
                </ext:GridPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
