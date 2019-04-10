<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductEnter.aspx.cs" Inherits="Plugins_JHWMS_TaskManager_ProductEnter" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>平库入库</title>
    <link rel="Stylesheet" type="text/css" href="<%= Page.ResolveUrl("~/") %>resources/css/ext-chinese-font.css" />
    <link rel="Stylesheet" type="text/css" href="<%= Page.ResolveUrl("~/") %>resources/css/main.css" />
    <script type="text/javascript">
        var thisDirUrl = "<%= Page.ResolveUrl("./") %>";
        var thisRootUrl = "<%= Page.ResolveUrl("~/") %>";
    </script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/") %>resources/js/jquery-1.7.1.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("./") %>TriggerFieldSearchMaterDatas.js?id=<%=DateTime.Now.ToString("yyyyMMddHHmmss") %>"></script>

    <!--gridMain数据展示-->
    <script type="text/javascript">
        var gridMainFresh = function () {
            var store = App.gridMain.getStore();
            store.currentPage = 1;
            store.pageSize = 100;
            App.gridMainPagingToolbar.doRefresh();
            return false;
        }
    </script>

    <script type="text/javascript">
        //按钮点击处理
        var cmdcol_click_handle = function (command, record) {

            if (command.toLowerCase() == "forcedelete") {
                var objId = record.data.OBJID;
                if (objId == 0) {
                    Ext.Msg.alert("错误", '未获取到OBJID，请联系管理员');
                    return;
                }
                Ext.Msg.confirm("提示", '确定要删除产品信息【' + objId + '】吗？', function (btn) {
                    if (btn == "yes") {
                        App.direct.ForceDelete(objId, {
                            success: function (result) {
                                if (result == "") {
                                    Ext.Msg.alert('成功', "删除产品信息【" + objId + "】成功！");
                                    //站台状态刷新
                                    App.gridMainPagingToolbar.doRefresh();
                                } else {
                                    Ext.Msg.alert("删除失败", result);
                                }
                            },
                            failure: function (errorMsg) {
                                Ext.Msg.alert("错误", errorMsg);
                            }
                        });
                    }
                });
            }
            if (command.toLowerCase() == "forceexchange") {
                var objId = record.data.OBJID;
                if (objId == 0) {
                    Ext.Msg.alert("错误", '未获取到OBJID，请联系管理员');
                    return;
                }
                Ext.Msg.confirm("提示", '确定该产品信息【' + objId + '】入库吗？', function (btn) {
                    if (btn == "yes") {
                        App.direct.ForceExchange(objId, {
                            success: function (result) {
                                if (result == "") {
                                    Ext.Msg.alert('成功', "切换【" + objId + "】成功！");
                                    //站台状态刷新
                                    App.gridMainPagingToolbar.doRefresh();
                                } else {
                                    Ext.Msg.alert("切换失败", result);
                                }
                            },
                            failure: function (errorMsg) {
                                Ext.Msg.alert("错误", errorMsg);
                            }
                        });
                    }
                });
            }


            return false;
        };
    </script>
    <script type="text/javascript">
        var saveAddWindows = function () {
            var binArea = App.txtAddBinArea.getValue();
            var batchNo = App.txtAddBatchNo.getValue();

            if (binArea == null || binArea == "") {
                Ext.Msg.alert("错误", '请选择归属库区!');
                return;
            }
            if (batchNo == null || batchNo == "") {
                Ext.Msg.alert("错误", '请选择批次号!');
                return;
            }

            App.direct.InsertDb(binArea, batchNo, {
                success: function (result) {
                    if (result == "True") {
                        Ext.Msg.alert('成功', "生成产品信息成功！");
                    }
                    else {
                        Ext.Msg.alert('错误', result);
                    }
                    App.winAdd.close();
                    gridMainFresh();
                },

                failure: function (errorMsg) {
                    Ext.Msg.alert('异常', errorMsg);
                }
            });

            return false;
        };
    </script>




    <script type="text/javascript">
        var showAddWindows = function () {
            App.txtAddBinArea.setValue("");

            App.txtAddBatchNo.setValue("");

            App.winAdd.show();
            return false;
        }
    </script>



</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
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
                                <ext:Button runat="server" Icon="Add" Text="添加" ID="Button3">
                                    <Listeners>
                                        <Click Handler="showAddWindows();" />
                                    </Listeners>
                                </ext:Button>
                                <ext:ToolbarSpacer />
                                <ext:ToolbarFill />
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <Items>
                        <ext:FormPanel runat="server" Layout="ColumnLayout" AutoHeight="true" Region="North">
                            <Items>
                                <ext:Container runat="server" Layout="FormLayout" ColumnWidth=".3" Padding="1">
                                    <Items>
                                        <ext:TextField ID="txtBinArea" runat="server" FieldLabel="归属库区" ReadOnly="false"
                                            LabelAlign="Right">
                                        </ext:TextField>
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" Layout="FormLayout" ColumnWidth=".3" Padding="1">
                                    <Items>
                                        <ext:TextField ID="txtBatchNo" runat="server" FieldLabel="生产批次" ReadOnly="false"
                                            LabelAlign="Right">
                                        </ext:TextField>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:FormPanel>
                    </Items>
                </ext:Panel>
                <ext:GridPanel ID="gridMain" runat="server" Region="Center">
                    <Store>
                        <ext:Store runat="server" PageSize="100" Height="100%">
                            <Proxy>
                                <ext:PageProxy DirectFn="App.direct.GetProductInfo" />
                            </Proxy>
                            <Model>
                                <ext:Model ID="model1" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="OBJID" />
                                        <ext:ModelField Name="BATCH_NO" />
                                        <ext:ModelField Name="BIN_AREA" />
                                        <ext:ModelField Name="SLMS_FLAG" />
                                        <ext:ModelField Name="UPDATE_DATE" />
                                        <ext:ModelField Name="READ_USER_ID" />
                                        <ext:ModelField Name="TASK_NO" />
                                        <ext:ModelField Name="CMD_OBJID" />
                                        <ext:ModelField Name="ERR_CODE" />
                                        <ext:ModelField Name="ERR_DESC" />



                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="columnModel" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Width="30" runat="server" />
                            <ext:Column runat="server" DataIndex="OBJID" Text="OBJID" Width="70" />
                            <ext:Column runat="server" DataIndex="BATCH_NO" Text="批次号" Width="70" />
                            <ext:Column runat="server" DataIndex="BIN_AREA" Text="所属库区" Width="90" />
                            <ext:Column runat="server" DataIndex="SLMS_FLAG" Text="使用标记" Width="80" />
                            <ext:Column runat="server" DataIndex="READ_USER_ID" Text="切换用户" Width="80" />
                            <ext:Column runat="server" DataIndex="TASK_NO" Text="任务号" Width="80" />

                            <ext:Column runat="server" DataIndex="CMD_OBJID" Text="指令OBJID" Width="80" />
                            <ext:Column runat="server" DataIndex="ERR_CODE" Text="异常编码" Width="80" />
                            <ext:Column runat="server" DataIndex="ERR_DESC" Text="异常描述" Width="80" />

                            <ext:DateColumn runat="server" DataIndex="UPDATE_DATE" Text="切换日期" Width="140" Format="yyyy-MM-dd HH:mm:ss" />

                            <ext:CommandColumn runat="server" Width="350" Text="操作" Align="Center">
                                <Commands>
                                    <ext:GridCommand Icon="Delete" CommandName="ForceDelete" Text="删除">
                                        <ToolTip Text="删除" />
                                    </ext:GridCommand>
                                    <ext:CommandSeparator />
                                    <%--   <ext:GridCommand Icon="TableEdit" CommandName="ForceEdit" Text="修改">
                                        <ToolTip Text="修改" />
                                    </ext:GridCommand>--%>
                                    <ext:CommandSeparator />
                                    <ext:GridCommand Icon="Accept" CommandName="ForceExchange" Text="切换">
                                        <ToolTip Text="切换" />
                                    </ext:GridCommand>
                                    <ext:CommandSeparator />

                                </Commands>
                                <Listeners>
                                    <Command Handler="return cmdcol_click_handle(command, record);" />
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
                        <ext:GridView runat="server" StripeRows="true" TrackOver="true" EnableTextSelection="true" />
                    </View>
                </ext:GridPanel>
                <ext:Window ID="winAdd" runat="server" Icon="MonitorAdd" Closable="false" Title="添加产品入库信息"
                    Width="600" Height="450" Resizable="false" Hidden="true" Modal="false" BodyStyle="background-color:#fff;"
                    BodyPadding="5" Layout="Form">
                    <Items>
                        <ext:FormPanel runat="server" BodyPadding="5" Border="false">
                            <FieldDefaults>
                                <CustomConfig>
                                    <ext:ConfigItem Name="LabelWidth" Value="80" Mode="Raw" />
                                    <ext:ConfigItem Name="PreserveIndicatorIcon" Value="true" Mode="Raw" />
                                </CustomConfig>
                            </FieldDefaults>
                            <Items>

                                <ext:Container runat="server" Layout="HBoxLayout" Padding="5">
                                    <Items>
                                        <ext:ComboBox ID="txtAddBinArea" runat="server" Editable="false" FieldLabel="归属库区" LabelAlign="Right" Flex="1" IndicatorText="*" IndicatorCls="red-text" />
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" Layout="HBoxLayout" Padding="5">
                                    <Items>
                                        <ext:ComboBox ID="txtAddBatchNo" runat="server" Editable="false" FieldLabel="批次号" LabelAlign="Right" Flex="1" IndicatorText="*" IndicatorCls="red-text" />
                                    </Items>
                                </ext:Container>


                            </Items>
                        </ext:FormPanel>
                    </Items>
                    <Buttons>
                        <ext:Button ID="btnAddSave" runat="server" Text="确定" Icon="Accept">
                            <ToolTips>
                                <ext:ToolTip runat="server" Html="点击进行添加" />
                            </ToolTips>
                            <Listeners>
                                <Click Handler="saveAddWindows();" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button ID="btnAddCancel" runat="server" Text="取消" Icon="Cancel">
                            <ToolTips>
                                <ext:ToolTip runat="server" Html="点击关闭窗口" />
                            </ToolTips>
                            <Listeners>
                                <Click Handler="App.winAdd.close();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:Window>

            </Items>
        </ext:Viewport>
    </form>
</body>
</html>

