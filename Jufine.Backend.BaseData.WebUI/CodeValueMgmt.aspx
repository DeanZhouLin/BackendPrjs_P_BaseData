<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="True" CodeBehind="CodeValueMgmt.aspx.cs" Inherits="Jufine.Backend.BaseData.WebUI.CodeValueMgmt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
    <asp:Panel ID="plHeader" runat="server" DefaultButton="btnSearch" CssClass="tools_bar">
        <div class="toolbg toolbgline toolheight nowrap" style="">
            <div class="right">
            </div>
            <div class="nowrap left">
                <asp:Button ID="btnSearch" runat="server" CssClass="btn" OnClick="btnSearch_Click" Text="查找" />
                <asp:Button ID="btnCreate" runat="server" CssClass="btn" OnClick="btnCreate_Click" Text="新增" />
                <asp:Button ID="btnDelete" runat="server" CssClass="btn" Text="删除" OnClientClick="return DeleteConfirm('ckbSelect');" OnClick="btnDelete_Click" />
            </div>
            <div class="clr">
                &nbsp;</div>
        </div>
        <div class="edit_bar">
            <table style="width: 100%;" class="search_table">
<tr>                
                
                <td style="width: 80px;">
                      代码：
                    </td>
                    <td>
                        <asp:TextBox ID="stxtCodeValue" PropertyName="CodeValue" Width="300" runat="server"></asp:TextBox>
                    </td>
                
              <td style="width: 80px;">
                      名称：
                    </td>
                    <td>
                        <asp:TextBox ID="stxtCodeText" PropertyName="CodeText" Width="300" runat="server"></asp:TextBox>
                    </td>
 </tr><tr>               
                <td style="width: 80px;">
                      分组代码：
                    </td>
                    <td>
                        <asp:TextBox ID="stxtGroupCode" PropertyName="GroupCode" Width="300" runat="server"></asp:TextBox>
                    </td>
                
              <td style="width: 80px;">
                      分组名称：
                    </td>
                    <td>
                        <asp:TextBox ID="stxtGroupName" PropertyName="GroupName" Width="300" runat="server"></asp:TextBox>
                    </td>
</tr>
            </table>
        </div>
    </asp:Panel>
    <asp:UpdatePanel ID="upList" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <contenttemplate>
                    <asp:GridView ID="gvCodeValueList" 
                        runat="server" 
                        OnSorting="gvCodeValueList_Sorting" 
                        AutoGenerateColumns="False" 
                        AllowSorting="true" 
                        CssClass="business_list">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="30">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="ckbSelectAll" runat="server" AutoPostBack="True" OnCheckedChanged="ckbSelectAll_CheckedChanged" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="ckbSelect" runat="server"  ToolTip='<%# Eval("ID") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="30" HeaderText="编辑">
                                <ItemTemplate>
                                   <asp:LinkButton ID="lnkEdit" runat="server" RowIndex='<%#Container.DataItemIndex %>' CommandArgument='<%# Eval("ID") %>' OnClick="lnkEdit_Click">编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" ItemStyle-Width="30" />
                            <asp:BoundField DataField="CodeValue" HeaderText="代码" SortExpression="CodeValue" ItemStyle-Width="60" />
                            <asp:BoundField DataField="CodeText" HeaderText="名称" SortExpression="CodeText" ItemStyle-Width="60" />
                            <asp:BoundField DataField="GroupCode" HeaderText="分组代码" SortExpression="GroupCode" ItemStyle-Width="100" />
                            <asp:BoundField DataField="GroupName" HeaderText="分组名称" SortExpression="GroupName" ItemStyle-Width="80" />
                            <asp:BoundField DataField="DisplayOrder" HeaderText="显示顺序" SortExpression="DisplayOrder" ItemStyle-Width="30" />
                             <asp:TemplateField HeaderText="状态" SortExpression="Status" ItemStyle-Width="60">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# (Eval("Status") != null && Eval("Status").ToString().Trim() == "1") ?"激活":"禁用" %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                            <asp:BoundField DataField="CreateUser" HeaderText="创建用户" SortExpression="CreateUser" ItemStyle-Width="60" />
                            <asp:BoundField DataField="CreateDate" HeaderText="创建日期" SortExpression="CreateDate" ItemStyle-Width="60" />
                            <asp:BoundField DataField="EditUser" HeaderText="编辑用户" SortExpression="EditUser" ItemStyle-Width="60" />
                            <asp:BoundField DataField="EditDate" HeaderText="编辑日期" SortExpression="EditDate" ItemStyle-Width="60" />
                        </Columns>
             </asp:GridView>
            <div class="pagination">
                    <asp:ListPager Width="100%" ID="listPager" runat="server" FirstPageText="首页" LastPageText="尾页"
                        NextPageText="下一页" OnPageChanged="listPager_PageChanged" PageSize="15" PrevPageText="上一页"
                        ShowPageIndexBox="Always" PageIndexBoxType="TextBox" ShowNavigationToolTip="True"
                        CustomInfoTextAlign="Left" ShowCustomInfoSection="Left" CustomInfoHTML="&nbsp;&nbsp;第 %CurrentPageIndex% 页，共 %PageCount% 页"
                        SubmitButtonClass="pages_butt" TextBeforePageIndexBox="到第" TextAfterPageIndexBox="页  "
                        CustomInfoStyle="padding-top:3px!important;padding-top:6px;height:20px;"  CustomInfoSectionWidth="20%">
                    </asp:ListPager>
            </div>
        </contenttemplate>
        <triggers>
            <asp:AsyncPostBackTrigger ControlID="listPager" />
            <asp:AsyncPostBackTrigger ControlID="btnSearch" />
            <asp:AsyncPostBackTrigger ControlID="btnDelete" />
        </triggers>
    </asp:UpdatePanel>
    <asp:Panel CssClass="miniWindow" ID="plDetail" runat="server" Style="display: none; width: 680px;">
                        <div class="container">
                            <asp:Panel ID="plTitle" Style="cursor: move;" runat="server">
                                <div class="" id="miniWindow_close">
                                </div>
                                <div class="t" id="miniWindow_handle">
                                    <div class="l">
                                    </div>
                                    <div class="title">
                                      Add or update CodeValueInfo</div>
                                    <div class="r">
                                    </div>
                                </div>
                            </asp:Panel>
                            <div class="c">
                                <asp:UpdatePanel ID="upDetail" runat="server" UpdateMode="Conditional">
                                    <contenttemplate>
                                        <asp:Panel ID="panelDetailInputArea" runat="server" DefaultButton="btnSave">
                                        <asp:HiddenField ID="hdID" runat="server" />
                                            <div class="c1">
                                                    <table style="width: 100%;">
<tr>                                                      
                                                        
                                                        <td style="width: 80px;">
                                                            代码：
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtCodeValue" PropertyName="CodeValue" MaxLength="50" Width="200" runat="server"></asp:TextBox>
                                                            </td>
                                                        
</tr><tr>                                                        <td style="width: 80px;">
                                                            名称：
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtCodeText" PropertyName="CodeText" MaxLength="400" Width="200" runat="server"></asp:TextBox>
                                                            </td>
 </tr><tr>                                                        
                                                        <td style="width: 80px;">
                                                            分组代码：
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtGroupCode" PropertyName="GroupCode" MaxLength="50" Width="200" runat="server"></asp:TextBox>
                                                            </td>
                                                        
</tr><tr>                                                        <td style="width: 80px;">
                                                            分组名称：
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtGroupName" PropertyName="GroupName" MaxLength="4000" Width="200" runat="server"></asp:TextBox>
                                                            </td>
 </tr><tr>                                                        
                                                        <td style="width: 80px;">
                                                            显示顺序：
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtDisplayOrder" PropertyName="DisplayOrder" MaxLength="4" Width="200" runat="server"></asp:TextBox>
                                                            </td>
                                                        
</tr><tr>                                                        <td style="width: 80px;">
                                                            状态：
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="ckbStatus" Checked="true" runat="server" Text="激活" />
                                                            </td>
</tr>                                        
                                                    </table>
                            </div>
                            </asp:Panel>
                            <div class="prenext">
                            <asp:Button ID="btnPreviousItem" runat="server" Text="<上一条" OnClick="btnPreviousItem_Click" />
                            <asp:Button ID="btnNextItem" runat="server" Text="下一条>" OnClick="btnNextItem_Click" />
                            </div>
                        </ContentTemplate>
                            <triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnPreviousItem" />
                                <asp:AsyncPostBackTrigger ControlID="btnNextItem" />
                                <asp:AsyncPostBackTrigger ControlID="btnCreate" />
                                <asp:AsyncPostBackTrigger ControlID="btnSave" />
                                <asp:AsyncPostBackTrigger ControlID="btnCancel" />
                            </triggers>
                        </asp:UpdatePanel>
                        <div class="saveexit">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="保存" />
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_OnClick" Text="取消" />
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="b">
            </div>
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="modalPopupExtender" runat="server" TargetControlID="OkButton" PopupControlID="plDetail" BackgroundCssClass="modalBackground" Drag="true" PopupDragHandleControlID="plTitle">
    </asp:ModalPopupExtender>
    <asp:LinkButton ID="OkButton" runat="server" Text="" />
</asp:Content>