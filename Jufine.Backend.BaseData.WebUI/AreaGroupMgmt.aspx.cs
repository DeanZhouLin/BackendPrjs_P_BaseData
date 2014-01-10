using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.WebControls;

using Com.BaseLibrary.Entity;
using Com.BaseLibrary.Utility;

using Jufine.Backend.WebModel;
using Jufine.Backend.BaseData.DataContracts;
using Jufine.Backend.BaseData.ServiceContracts;

namespace Jufine.Backend.BaseData.WebUI
{
    public partial class AreaGroupMgmt : PageBase
    {
        private QueryConditionInfo<AreaGroup> QueryCondition
        {
            get
            {
                QueryConditionInfo<AreaGroup> queryCondition
                    = ViewState["AREAGROUP_QUERYCONDITION"] as QueryConditionInfo<AreaGroup>;
                if (queryCondition == null)
                {
                    queryCondition = new QueryConditionInfo<AreaGroup>();
                    ViewState["AREAGROUP_QUERYCONDITION"] = queryCondition;
                }
                return queryCondition;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    QueryData();
                    AddEnterEscPress(panelDetailInputArea, btnSave, btnCancel);
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.Message);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                listPager.CurrentPageIndex = 1;
                FillEntityWithContentValue<AreaGroup>(QueryCondition.Condtion,plHeader);
                QueryData();
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.Message);
            }

        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            ClearControlInput(panelDetailInputArea);
            SetFocus(txtID);
            modalPopupExtender.Show();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<Int32> keyList = new List<Int32>();
            foreach (GridViewRow row in gvAreaGroupList.Rows)
            {
                if (row.RowType != DataControlRowType.DataRow)
                {
                    continue;
                }
                CheckBox ckbSelect = row.FindControl("ckbSelect") as CheckBox;
                if (ckbSelect.Checked)
                {
                    Int32 key = StringUtil.ToType<Int32>(ckbSelect.ToolTip);
                    keyList.Add(key);
                }
            }

            if (keyList.Count == 0)
            {
                ShowMessageBox("请至少选择一条记录。");
                return;
            }

            try
            {
                IAreaGroupService service = CreateService<IAreaGroupService>();
                service.BatchDelete(keyList);
                QueryData();
                ShowMessageBox("删除成功");
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.Message);
            }

        }


        protected void gvAreaGroupList_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                e.Cancel = true;
                SetSortOrder<AreaGroup>(QueryCondition, e.SortExpression);
                listPager.CurrentPageIndex = 0;
                QueryData();
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.Message);
            }

        }


        protected void ckbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ckbSelectAll = sender as CheckBox;
            foreach (GridViewRow row in gvAreaGroupList.Rows)
            {
                if (row.RowType != DataControlRowType.DataRow)
                {
                    continue;
                }
                CheckBox ckbSelect = row.Cells[0].FindControl("ckbSelect") as CheckBox;
                if (ckbSelect != null)
                {
                    ckbSelect.Checked = ckbSelectAll.Checked;
                }
            }
            upList.Update();
        }
        
        private int? currentRowIndex;
        public int CurrentRowIndex
        {
            get
            {
                if (currentRowIndex == null)
                {
                    object rowIndex = ViewState["CURRENTROWINDEX"];
                    if (rowIndex == null)
                    {
                        currentRowIndex = 0;
                    }
                    else
                    {
                        currentRowIndex = int.Parse(rowIndex.ToString());
                    }
                }
                return currentRowIndex.Value;
            }
            set
            {
                ViewState["CURRENTROWINDEX"] = currentRowIndex = value;
            }
        }
        
        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            Int32 key = StringUtil.ToType<Int32>(btn.CommandArgument);
            CurrentRowIndex = int.Parse(btn.Attributes["RowIndex"]);
            ShowDetail(key);
        }
        
        private void ShowDetail(Int32 key)
        {
            try
            {
                IAreaGroupService service = CreateService<IAreaGroupService>();
                AreaGroup areaGroup = service.Get(key);
                FillContentValueWithEntity<AreaGroup>(areaGroup,panelDetailInputArea);
                modalPopupExtender.Show();
                hdID.Value = key.ToString();
                upDetail.Update();
                SetFocus(txtID);
            }
            catch (Exception ex)
            {

                ShowMessageBox(ex.Message);
            }
        }
        
        protected void btnPreviousItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentRowIndex > 0)
                {
                    CurrentRowIndex = CurrentRowIndex - 1;
                    LinkButton btn = gvAreaGroupList.Rows[CurrentRowIndex].FindControl("lnkEdit") as LinkButton;
                    Int32 key = StringUtil.ToType<Int32>(btn.CommandArgument);
                    ShowDetail(key);
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.Message);
            }
        }
        protected void btnNextItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentRowIndex <gvAreaGroupList.Rows.Count-1)
                {
                    CurrentRowIndex = CurrentRowIndex + 1;
                    LinkButton btn = gvAreaGroupList.Rows[CurrentRowIndex].FindControl("lnkEdit") as LinkButton;
                    Int32 key = StringUtil.ToType<Int32>(btn.CommandArgument);
                    ShowDetail(key);
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.Message);
            }
        }
        
        protected void listPager_PageChanged(object sender, EventArgs e)
        {
            try
            {
                QueryData();
            }
            catch (Exception ex)
            {

                ShowMessageBox(ex.Message);
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool isValid = ValidateControl(panelDetailInputArea);
                if (!isValid)
                {
                    return;
                }
                CreateOrUpdate();
                QueryData();
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.Message);
            }

        }
        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            modalPopupExtender.Hide();
        }

        private void QueryData()
        {
            IAreaGroupService service = CreateService<IAreaGroupService>();
            QueryCondition.PageIndex = listPager.CurrentPageIndex;
            QueryCondition.PageSize = listPager.PageSize;
            QueryResultInfo<AreaGroup> result = service.Query(QueryCondition);

            SetOrderHeaderStyle(gvAreaGroupList, QueryCondition);
            gvAreaGroupList.DataSource = result.RecordList;
            gvAreaGroupList.DataBind();
            NoRecords<AreaGroup>(gvAreaGroupList);
            listPager.RecordCount = result.RecordCount;
            upList.Update();
        }


        private void CreateOrUpdate()
        {
            IAreaGroupService service = CreateService<IAreaGroupService>();
            AreaGroup areaGroup = null;

            if (string.IsNullOrEmpty(hdID.Value))
            {
                areaGroup = new AreaGroup();
                FillEntityWithContentValue<AreaGroup>(areaGroup,panelDetailInputArea);
                areaGroup.CreateUser = CurrentUser.UserName;
				areaGroup.CreateDate = DateTime.Now;
                areaGroup.EditUser = CurrentUser.UserName;
				areaGroup.EditDate = DateTime.Now;
                service.Create(areaGroup);
                ShowMessageBox("创建信息成功。");
                ClearControlInput(panelDetailInputArea);
                SetFocusControl(txtID);
            }
            else
            {
                Int32 key = StringUtil.ToType<Int32>(hdID.Value);
                areaGroup=service.Get(key);
                FillEntityWithContentValue<AreaGroup>(areaGroup,panelDetailInputArea);
                areaGroup.EditUser = CurrentUser.UserName;
				areaGroup.EditDate = DateTime.Now;
                service.Update(areaGroup);
                modalPopupExtender.Hide();
                ShowMessageBox("更新信息成功。");
            }


        }
        
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            btnPreviousItem.Enabled = CurrentRowIndex > 0;
            btnNextItem.Enabled = CurrentRowIndex < (gvAreaGroupList.Rows.Count-1);
        }
    }
}
