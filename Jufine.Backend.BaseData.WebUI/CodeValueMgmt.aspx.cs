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
    public partial class CodeValueMgmt : PageBase
    {
        private QueryConditionInfo<CodeValueInfo> QueryCondition
        {
            get
            {
                QueryConditionInfo<CodeValueInfo> queryCondition
                    = ViewState["CODEVALUE_QUERYCONDITION"] as QueryConditionInfo<CodeValueInfo>;
                if (queryCondition == null)
                {
                    queryCondition = new QueryConditionInfo<CodeValueInfo>();
                    ViewState["CODEVALUE_QUERYCONDITION"] = queryCondition;
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
                FillEntityWithContentValue<CodeValueInfo>(QueryCondition.Condtion,plHeader);
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
            SetFocus(txtCodeValue);
            modalPopupExtender.Show();
            btnNextItem.Visible = btnPreviousItem.Visible = false;
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<Int32> keyList = new List<Int32>();
            foreach (GridViewRow row in gvCodeValueList.Rows)
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
                ICodeValueService service = CreateService<ICodeValueService>();
                service.BatchDelete(keyList);
                QueryData();
                ShowMessageBox("删除成功");
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.Message);
            }

        }


        protected void gvCodeValueList_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                e.Cancel = true;
                SetSortOrder<CodeValueInfo>(QueryCondition, e.SortExpression);
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
            foreach (GridViewRow row in gvCodeValueList.Rows)
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
            btnNextItem.Visible = btnPreviousItem.Visible = true;
            ShowDetail(key);
        }
        
        private void ShowDetail(Int32 key)
        {
            try
            {
                ICodeValueService service = CreateService<ICodeValueService>();
                CodeValueInfo codeValue = service.Get(key);
                FillContentValueWithEntity<CodeValueInfo>(codeValue,panelDetailInputArea);
                modalPopupExtender.Show();
                hdID.Value = key.ToString();
                upDetail.Update();
                SetFocus(txtCodeValue);
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
                    LinkButton btn = gvCodeValueList.Rows[CurrentRowIndex].FindControl("lnkEdit") as LinkButton;
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
                if (CurrentRowIndex <gvCodeValueList.Rows.Count-1)
                {
                    CurrentRowIndex = CurrentRowIndex + 1;
                    LinkButton btn = gvCodeValueList.Rows[CurrentRowIndex].FindControl("lnkEdit") as LinkButton;
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
            ICodeValueService service = CreateService<ICodeValueService>();
            QueryCondition.PageIndex = listPager.CurrentPageIndex;
            QueryCondition.PageSize = listPager.PageSize;
            QueryResultInfo<CodeValueInfo> result = service.Query(QueryCondition);

            SetOrderHeaderStyle(gvCodeValueList, QueryCondition);
            gvCodeValueList.DataSource = result.RecordList;
            gvCodeValueList.DataBind();
            NoRecords<CodeValueInfo>(gvCodeValueList);
            listPager.RecordCount = result.RecordCount;
            upList.Update();
        }


        private void CreateOrUpdate()
        {
            ICodeValueService service = CreateService<ICodeValueService>();
            CodeValueInfo codeValue = null;

            if (string.IsNullOrEmpty(hdID.Value))
            {
                codeValue = new CodeValueInfo();
                codeValue.CreateUser = CurrentUser.UserName;
				codeValue.CreateDate = DateTime.Now;
            }
            else
            {
                Int32 key = StringUtil.ToType<Int32>(hdID.Value);
                codeValue=service.Get(key);
            }

            
            FillEntityWithContentValue<CodeValueInfo>(codeValue, panelDetailInputArea);
            codeValue.Status = ckbStatus.Checked ? 1 : 0;
            codeValue.EditUser = CurrentUser.UserName;
            codeValue.EditDate = DateTime.Now;

            if (string.IsNullOrEmpty(hdID.Value))
            {
                service.Create(codeValue);
                ShowMessageBox("创建信息成功。");
                ClearControlInput(panelDetailInputArea);
                txtGroupCode.Text = codeValue.GroupCode;
                txtGroupName.Text = codeValue.GroupName;
                txtDisplayOrder.Text = (codeValue.DisplayOrder + 1).ToString();
                SetFocusControl(txtCodeValue);
            }
            else
            {
                service.Update(codeValue);
                modalPopupExtender.Hide();
                ShowMessageBox("更新信息成功。");
            }

        }
        
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            btnPreviousItem.Enabled = CurrentRowIndex > 0;
            btnNextItem.Enabled = CurrentRowIndex < (gvCodeValueList.Rows.Count-1);
        }
    }
}
