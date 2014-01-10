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
    public partial class AreaMgmt : PageBase
	{
		static IAreaService areaService = CreateService<IAreaService>();
        private QueryConditionInfo<AreaInfo> QueryCondition
        {
            get
            {
                QueryConditionInfo<AreaInfo> queryCondition
                    = ViewState["AREA_QUERYCONDITION"] as QueryConditionInfo<AreaInfo>;
                if (queryCondition == null)
                {
                    queryCondition = new QueryConditionInfo<AreaInfo>();
                    ViewState["AREA_QUERYCONDITION"] = queryCondition;
                }
				return queryCondition;
            }
			
        }

		protected void btnGenerate_Click(object sender, EventArgs e)
		{
			try
			{
				areaService.GenerateArea();
			}
			catch (Exception ex)
			{
				ShowMessageBox(ex.Message);
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
                FillEntityWithContentValue<AreaInfo>(QueryCondition.Condtion,plHeader);
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
            foreach (GridViewRow row in gvAreaList.Rows)
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
                
                areaService.BatchDelete(keyList);
                QueryData();
                ShowMessageBox("删除成功");
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.Message);
            }

        }


        protected void gvAreaList_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                e.Cancel = true;
                SetSortOrder<AreaInfo>(QueryCondition, e.SortExpression);
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
            foreach (GridViewRow row in gvAreaList.Rows)
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
                AreaInfo area = areaService.Get(key);
                FillContentValueWithEntity<AreaInfo>(area,panelDetailInputArea);
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
                    LinkButton btn = gvAreaList.Rows[CurrentRowIndex].FindControl("lnkEdit") as LinkButton;
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
                if (CurrentRowIndex <gvAreaList.Rows.Count-1)
                {
                    CurrentRowIndex = CurrentRowIndex + 1;
                    LinkButton btn = gvAreaList.Rows[CurrentRowIndex].FindControl("lnkEdit") as LinkButton;
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
            QueryCondition.PageIndex = listPager.CurrentPageIndex;
            QueryCondition.PageSize = listPager.PageSize;
            QueryResultInfo<AreaInfo> result = areaService.Query(QueryCondition);

            SetOrderHeaderStyle(gvAreaList, QueryCondition);
            gvAreaList.DataSource = result.RecordList;
            gvAreaList.DataBind();
            NoRecords<AreaInfo>(gvAreaList);
            listPager.RecordCount = result.RecordCount;
            upList.Update();
        }


        private void CreateOrUpdate()
        {
            AreaInfo area = null;

            if (string.IsNullOrEmpty(hdID.Value))
            {
                area = new AreaInfo();
                FillEntityWithContentValue<AreaInfo>(area,panelDetailInputArea);
                area.CreateUser = CurrentUser.UserName;
				area.CreateDate = DateTime.Now;
                area.EditUser = CurrentUser.UserName;
				area.EditDate = DateTime.Now;
                areaService.Create(area);
                ShowMessageBox("创建信息成功。");
                ClearControlInput(panelDetailInputArea);
                SetFocusControl(txtID);
            }
            else
            {
                Int32 key = StringUtil.ToType<Int32>(hdID.Value);
                area=areaService.Get(key);
                FillEntityWithContentValue<AreaInfo>(area,panelDetailInputArea);
                area.EditUser = CurrentUser.UserName;
				area.EditDate = DateTime.Now;
                areaService.Update(area);
                modalPopupExtender.Hide();
                ShowMessageBox("更新信息成功。");
            }


        }
        
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            btnPreviousItem.Enabled = CurrentRowIndex > 0;
            btnNextItem.Enabled = CurrentRowIndex < (gvAreaList.Rows.Count-1);
        }
    }
}
