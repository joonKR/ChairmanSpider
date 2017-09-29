using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxKHOpenAPILib;
using MetroFramework;


namespace GloomySpider
{
    public partial class GloomyMainForm : MetroFramework.Forms.MetroForm
    {
        private int conditionLoadState;
        private int _scrNum = 5000;

        List<OPT10001_주식기본정보> ConditionResultStockList = new List<OPT10001_주식기본정보>();
        public GloomyMainForm()
        {
            InitializeComponent();

            GloomyAPI.getInstance(this.axKHOpenAPI);

            axKHOpenAPI.OnEventConnect += API_OnEventConnect;
            axKHOpenAPI.OnReceiveConditionVer += API_OnReceiveConditionVer;
            axKHOpenAPI.OnReceiveTrCondition += API_OnReceiveTrCondition;
            axKHOpenAPI.OnReceiveTrData += API_OnReceiveTrData;
            axKHOpenAPI.OnReceiveRealCondition += API_OnReceiveRealCondition;
            axKHOpenAPI.OnReceiveRealData += API_OnReceiveRealData;
            axKHOpenAPI.OnReceiveConditionVer += API_OnReceiveConditionVer;
            axKHOpenAPI.OnReceiveMsg += API_OnReceiveMsg;
            cb매수주문유형.DataSource = KOACode.hogaGb;
            cb매수주문유형.DisplayMember = "Name";
            cb매수주문유형.ValueMember = "Code";
            cb매도주문유형.DataSource = KOACode.hogaGb;
            cb매도주문유형.DisplayMember = "Name";
            cb매도주문유형.ValueMember = "Code";


            if (Properties.Settings.Default.AutoStart)
                this.cbAutoStart.Checked = true;
        }

        #region 키움 API 이벤트
        private void API_OnReceiveRealData(object sender, _DKHOpenAPIEvents_OnReceiveRealDataEvent e)
        {
            if (e.sRealType == "주식체결")
            {
                string stockCode = e.sRealKey;
                string stockPrice = Int32.Parse(axKHOpenAPI.GetCommRealData(e.sRealType, 10).Trim()).ToString();
                string stock전일대비 = axKHOpenAPI.GetCommRealData(e.sRealType, 11).Trim();
                string stock등락율 = axKHOpenAPI.GetCommRealData(e.sRealType, 12).Trim().ToPersentage();

                if (ConditionResultStockList.Where(x => x.종목코드.Equals(stockCode)).ToList()[0].현재가.Equals(stockPrice))
                    return;

                ConditionResultStockList.Where(x => x.종목코드.Equals(stockCode)).ToList().ForEach(i => { i.현재가 = stockPrice;i.전일대비 = stock전일대비; i.등락율 = stock등락율; });
                this.dataGridViewStockInfo.DataSource = ConditionResultStockList.Select(x => new { x.종목코드, x.종목명, x.현재가, x.전일대비, x.등락율 }).ToList();

                foreach(DataGridViewRow row in this.dataGridViewStockInfo.Rows)
                {
                    if (row.Cells[0].Value.Equals(stockCode))
                    {
                        this.dataGridViewStockInfo.Rows[row.Index].Selected = true;
                        break;
                    }
                }
            }
        }

        private void Get_OPW00011_증거금율별주문가능수량조회요청()
        {
            OPW00011_증거금율별주문가능수량조회요청 data = new OPW00011_증거금율별주문가능수량조회요청();

            data.계좌번호 = this.cbAccount.Text;
            data.비밀번호 = "";
            data.비밀번호입력매체구분 = "00";
            data.종목번호 = this.tbStockCode.Text;
            data.매수가격 = this.tb매수주문가격.Text;

            this.axKHOpenAPI.SetInputValue("계좌번호", data.계좌번호);
            this.axKHOpenAPI.SetInputValue("비밀번호", data.비밀번호);
            this.axKHOpenAPI.SetInputValue("비밀번호입력매체구분", data.비밀번호입력매체구분);
            this.axKHOpenAPI.SetInputValue("종목번호", data.종목번호);
            this.axKHOpenAPI.SetInputValue("매수가격", data.매수가격);

            int result1 = this.axKHOpenAPI.CommRqData(data.RQName, data.RQCode, 0, GetScreenNum());
        }

        private void Get_OPW00012_신용보증금율별주문가능수량조회요청()
        {
            OPW00012_신용보증금율별주문가능수량조회요청 data = new OPW00012_신용보증금율별주문가능수량조회요청();

            data.계좌번호 = this.cbAccount.Text;
            data.비밀번호 = "";
            data.비밀번호입력매체구분 = "00";
            data.종목번호 = this.tbStockCode.Text;
            data.매수가격 = this.tb매수주문가격.Text;

            this.axKHOpenAPI.SetInputValue("계좌번호", data.계좌번호);
            this.axKHOpenAPI.SetInputValue("비밀번호", data.비밀번호);
            this.axKHOpenAPI.SetInputValue("비밀번호입력매체구분", data.비밀번호입력매체구분);
            this.axKHOpenAPI.SetInputValue("종목번호", data.종목번호);
            this.axKHOpenAPI.SetInputValue("매수가격", data.매수가격);

            int result1 = this.axKHOpenAPI.CommRqData(data.RQName, data.RQCode, 0, GetScreenNum());
        }

        private void API_OnReceiveMsg(object sender, _DKHOpenAPIEvents_OnReceiveMsgEvent e)
        {
            if (e.sRQName.Equals("주식주문"))
            {
                Logger(Log.에러, e.sMsg);
            }
        }

        private void API_OnReceiveConditionVer(object sender, _DKHOpenAPIEvents_OnReceiveConditionVerEvent e)
        {

            this.dataGridViewCondition.DataSource = null;
            string conditionSearchList = axKHOpenAPI.GetConditionNameList().Trim();

            // 분리된 문자 배열 저장
            string[] spconditionSearchListArr = conditionSearchList.Split(';');

            List<ConditionSearch> dataList = new List<ConditionSearch>();
            foreach (string condition in spconditionSearchListArr)
            {
                if (string.IsNullOrEmpty(condition))
                    continue;

                string[] conditionaArr = condition.Split('^');

                ConditionSearch data = new ConditionSearch();
                data.조건번호= conditionaArr[0];
                data.조건명 = conditionaArr[1];
                dataList.Add(data);
            }

            this.dataGridViewCondition.DataSource = dataList;
        }

     

        private void API_OnReceiveRealCondition(object sender, _DKHOpenAPIEvents_OnReceiveRealConditionEvent e)
        {
            string type = e.strType.Equals("I") ? "종목편입" : "종목이탈";
            Logger(Log.일반, e.strConditionName + ";" + type + ";" + e.sTrCode);

            if (type.Equals("종목편입"))
            {

            }
            else
            {
                var found = ConditionResultStockList.Find(x => x.종목코드.Equals(e.sTrCode));
                if (found != null) ConditionResultStockList.Remove(found);
            }


        }

        private void API_OnReceiveTrData(object sender, _DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            if (e.sRQName.Equals("계좌평가잔고내역요청"))
            {
                #region 계좌평가잔고내역요청
                this.dataGridViewAccount.DataSource = null;
                int multiCount = 0;
                List<OPW00018_계좌평가결과> dataSingleList = new List<OPW00018_계좌평가결과>();
                OPW00018_계좌평가결과 dataSingle = new OPW00018_계좌평가결과();
                dataSingle.총매입금액 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "총매입금액").Trim();
                dataSingle.총수익률 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "총수익률(%)").Trim();
                dataSingle.총평가손익금액 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "총평가손익금액").Trim();
                dataSingle.총평가금액 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "총평가금액").Trim();
                dataSingle.총대주금액 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "총대주금액").Trim();
                dataSingle.총대출금 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "총대출금").Trim();
                dataSingle.총융자금액 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "총융자금액").Trim();
                dataSingle.추정예탁자산 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "추정예탁자산").Trim();
                dataSingle.조회건수 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "조회건수").Trim();
                dataSingleList.Add(dataSingle);
                dataGridViewAccount.DataSource = dataSingleList;
                if (string.IsNullOrEmpty(dataSingle.조회건수))
                    return;

                multiCount = Int32.Parse(dataSingle.조회건수);

                List<OPW00018_계좌평가잔고개별합산> dataMultiList = new List<OPW00018_계좌평가잔고개별합산>();
                for (int i = 0; i < multiCount; i++)
                {
                    OPW00018_계좌평가잔고개별합산 dataMulti = new OPW00018_계좌평가잔고개별합산();
                    dataMulti.금일매도수량 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "금일매도수량").Trim();
                    dataMulti.금일매수수량 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "금일매수수량").Trim();
                    dataMulti.대출일 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "대출일").Trim();
                    dataMulti.매입가 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "매입가").Trim();
                    dataMulti.매입금액 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "매입금액").Trim();
                    dataMulti.매입수수료 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "매입수수료").Trim();
                    dataMulti.보유비중 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "보유비중(%)").Trim();
                    dataMulti.보유수량 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "보유수량").Trim();
                    dataMulti.세금 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "세금").Trim();
                    dataMulti.수수료합 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "수수료합").Trim();
                    dataMulti.수익률 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "수익률(%)").Trim();
                    dataMulti.신용구분 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "신용구분").Trim();
                    dataMulti.신용구분명 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "신용구분명").Trim();
                    dataMulti.전일매도수량 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "전일매도수량").Trim();
                    dataMulti.전일매수수량 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "전일매수수량").Trim();
                    dataMulti.전일종가 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "전일종가").Trim();
                    dataMulti.종목명 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "종목명").Trim();
                    dataMulti.종목번호 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "종목번호").Trim();
                    dataMulti.평가금액 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "평가금액").Trim();
                    dataMulti.평가손익 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "평가손익").Trim();
                    dataMulti.평가수수료 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "평가수수료").Trim();
                    dataMulti.현재가 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "현재가").Trim();
                    dataMulti.매매가능수량 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "매매가능수량").Trim();
                    dataMultiList.Add(dataMulti);
                }
                this.dataGridViewAccountStock.DataSource = dataMultiList;

                foreach (DataGridViewColumn col in dataGridViewAccount.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dataGridViewAccount.SelectedRows[0].Selected = false;

                foreach (DataGridViewColumn col in dataGridViewAccountStock.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dataGridViewAccountStock.SelectedRows[0].Selected = false;
                Logger(Log.조회, "계좌평가잔고 완료");
                #endregion
            }
            else if (e.sRQName.Equals("조건검색주식기본정보"))
            {
                #region 조건검색결과
                int count = axKHOpenAPI.GetRepeatCnt(e.sTrCode, e.sRQName);
                string stockList = "";

                ConditionResultStockList.Clear();
                for (int i = 0; i < count; i++)
                {
                    this.dataGridViewStockInfo.DataSource = null;
                   OPT10001_주식기본정보 data = new OPT10001_주식기본정보();
                    data.종목코드 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "종목코드").Trim();
                    data.종목명 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "종목명").Trim();
                    data.현재가= axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "현재가").Trim();
                    data.등락율 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "등락율").Trim();
                    data.전일대비 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "전일대비").Trim();
                    ConditionResultStockList.Add(data);

                    if(i==count-1)
                        stockList += data.종목코드;
                    else
                        stockList += data.종목코드 + ";";
                }
                this.dataGridViewStockInfo.DataSource = ConditionResultStockList.Select(x => new { x.종목코드, x.종목명, x.현재가,x.전일대비, x.등락율}).ToList();
                this.dataGridViewStockInfo.SelectedRows[0].Selected = false;
                Logger(Log.조회, "조건검색결과 완료");

                long lRet = axKHOpenAPI.SetRealReg(GetScreenNum(),              // 화면번호
                                 stockList,    // 종콕코드 리스트
                                  "10;12",//FID번호
                                  "0");       // 0 : 마지막에 등록한 종목만 실시간
                #endregion
            }
            else if (e.sRQName.Equals("계좌평가현황요청"))
            {
                #region 계좌평가현황요청
                this.dataGridViewAccountStock.DataSource = null;

                List<OPW00004_계좌평가현황요청_Single> OPW00004SingleDataList = new List<OPW00004_계좌평가현황요청_Single>();
                OPW00004_계좌평가현황요청_Single singleData = new OPW00004_계좌평가현황요청_Single();
                singleData.예수금 = this.axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "예수금").Trim();
                singleData.예탁자산평가액 = this.axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "예탁자산평가액").Trim();
                singleData.유가잔고평가액 = this.axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "유가잔고평가액").Trim();
                singleData.총매입금액 = this.axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "총매입금액").Trim();
                singleData.추정예탁자산 = this.axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "추정예탁자산").Trim();
                OPW00004SingleDataList.Add(singleData);
                this.dataGridViewAccount.DataSource = OPW00004SingleDataList;
                int count = axKHOpenAPI.GetRepeatCnt(e.sTrCode, e.sRQName);

                List<OPW00004_계좌평가현황요청_Multi> OPW00004_dataList = new List<OPW00004_계좌평가현황요청_Multi>();
                for (int i = 0; i < count; i++)
                {
                    OPW00004_계좌평가현황요청_Multi multiData = new OPW00004_계좌평가현황요청_Multi();
                    multiData.종목코드 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "종목코드").Trim();
                    multiData.종목명 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "종목명").Trim();
                    multiData.보유수량 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "보유수량").Trim();
                    multiData.평균단가 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "평균단가").Trim();
                    multiData.현재가 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "현재가").Trim();
                    multiData.평가금액 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "평가금액").Trim();
                    multiData.손익금액 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "손익금액").Trim();
                    multiData.손익율 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "손익율").Trim();
                    multiData.대출일 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "대출일").Trim();
                    multiData.매입금액 = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "매입금액").Trim();

                    OPW00004_dataList.Add(multiData);
                }

                this.dataGridViewAccountStock.DataSource = OPW00004_dataList;

                foreach (DataGridViewColumn col in dataGridViewAccountStock.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                if(dataGridViewAccountStock.SelectedRows.Count>0)
                    dataGridViewAccountStock.SelectedRows[0].Selected = false;


                Logger(Log.조회, "계좌정보 조회 성공");
                #endregion
            }
            else if (e.sRQName.Equals("증거금율별주문가능수량조회요청"))
            {
                this.tb매수주문수량.Text = Int32.Parse(this.axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "증거금100주문가능수량").Trim()).ToString();

                Logger(Log.조회, "증거금율별주문가능수량조회요청 성공");
            }
            else if (e.sRQName.Equals("신용보증금율별주문가능수량조회요청"))
            {
                this.tb매수주문수량.Text = Int32.Parse(this.axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "보증금40주문가능수량").Trim()).ToString();

                Logger(Log.조회, "신용보증금율별주문가능수량조회요청 성공");
            }
        }

        private void API_OnReceiveTrCondition(object sender, _DKHOpenAPIEvents_OnReceiveTrConditionEvent e)
        {
            string codeList = e.strCodeList.Trim();
            if (codeList.Length > 0)
                codeList = codeList.Remove(codeList.Length - 1);

            if (string.IsNullOrEmpty(codeList))
            {
                Logger(Log.일반, "해당 조건 검색 종목 없음");
                this.dataGridViewStockInfo.DataSource = null;
                return;
            }

            int count = codeList.Trim().Split(';').Length;

            if (e.nNext == 2)
            {
                axKHOpenAPI.SendCondition(e.sScrNo, e.strConditionName, e.nIndex, 2);
            }
            if (count > 100)
            {
                count = 100;
                Logger(Log.일반, "100개만 조회가능");
            }
            axKHOpenAPI.CommKwRqData(codeList, 0, count, 0, "조건검색주식기본정보", GetScreenNum());
        }

        private void API_OnEventConnect(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                Logger(Log.일반, "로그인 성공");

                GetAccountInfo();

                Get_OPW00018_계좌평가잔고내역요청();
                //Get_OPW00004_계좌평가현황요청();
            }
            else
            {
                Logger(Log.에러, "로그인 실패");
            }
        }
        #endregion

        #region UI 이벤트
        private void MainFrom_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AutoStart)
            {
                LogIn();
            }
        }

        private void cb매도주문유형_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb매도주문유형.SelectedValue.ToString().Equals("03"))
            {
                tb매도주문가격.Enabled = false;
            }
            else
            {
                tb매도주문가격.Enabled = true;
            }
        }

        private void cb매수주문유형_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb매수주문유형.SelectedValue.ToString().Equals("03"))
            {
                tb매수주문가격.Enabled = false;
            }
            else
            {
                tb매수주문가격.Enabled = true;
            }
        }

        private void btn매수가능수량_Click(object sender, EventArgs e)
        {
            if (rb매수현금.Checked)
            {
                Get_OPW00011_증거금율별주문가능수량조회요청();
            }

            if (rb매수신용.Checked)
            {
                Get_OPW00012_신용보증금율별주문가능수량조회요청();
            }
        }

        private void cbAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbAutoStart.Checked)
                Properties.Settings.Default.AutoStart = true;
            else
                Properties.Settings.Default.AutoStart = false;

            Properties.Settings.Default.Save();
        }

        private void bttnStart_Click(object sender, EventArgs e)
        {
            LogIn();
        }

        private void bttnConditionLoad_Click(object sender, EventArgs e)
        {
            LoadConditionSearch();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            string orderGb = cb매도주문유형.SelectedValue.ToString();
            int orderPrice = Int32.Parse(tb매도주문가격.Text);

            sendOrderGS(2, tbStockCode.Text, int.Parse(tb매도주문수량.Text), orderPrice, orderGb, rb매도신용.Checked);
        }

        private void bttnConditionSearchStart_Click(object sender, EventArgs e)
        {
            GetConditionResult();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            string orderGb = cb매수주문유형.SelectedValue.ToString();
            int orderPrice = Int32.Parse(tb매수주문가격.Text);           

            sendOrderGS(1, tbStockCode.Text, int.Parse(tb매수주문수량.Text), orderPrice, orderGb, rb매수신용.Checked);
        }

        private void btn계좌정보조회_Click(object sender, EventArgs e)
        {
            Get_OPW00018_계좌평가잔고내역요청();
            //Get_OPW00004_계좌평가현황요청();
        }

        #region CellFormatting
        private void dataGridViewAccInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == this.dataGridViewAccountStock.Columns["평가손익"].Index)
            {
                if (e.Value != null)
                {
                    if (string.IsNullOrEmpty(e.Value.ToString()))
                        return;

                    double value = double.Parse(e.Value.ToString());
                    if (value > 0)
                    {
                        //this.dataGridViewAccInfo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                        this.dataGridViewAccountStock.Rows[e.RowIndex].Cells["수익률"].Style.ForeColor = Color.Red;
                        this.dataGridViewAccountStock.Rows[e.RowIndex].Cells["평가손익"].Style.ForeColor = Color.Red;

                    }
                    else if (value < 0)
                    {
                        //this.dataGridViewAccInfo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                        this.dataGridViewAccountStock.Rows[e.RowIndex].Cells["수익률"].Style.ForeColor = Color.Blue;
                        this.dataGridViewAccountStock.Rows[e.RowIndex].Cells["평가손익"].Style.ForeColor = Color.Blue;

                    }
                }
            }
        }

        private void dataGridViewStockInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == this.dataGridViewStockInfo.Columns["등락율"].Index)
            {
                if (e.Value != null)
                {
                    if (string.IsNullOrEmpty(e.Value.ToString()))
                        return;
                    double value = double.Parse(e.Value.ToString());
                    if (value > 0)
                    {
                        //this.dataGridViewAccInfo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                        this.dataGridViewStockInfo.Rows[e.RowIndex].Cells["등락율"].Style.ForeColor = Color.Red;
                        this.dataGridViewStockInfo.Rows[e.RowIndex].Cells["전일대비"].Style.ForeColor = Color.Red;
                    }
                    else if (value < 0)
                    {
                        //this.dataGridViewAccInfo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                        this.dataGridViewStockInfo.Rows[e.RowIndex].Cells["등락율"].Style.ForeColor = Color.Blue;
                        this.dataGridViewStockInfo.Rows[e.RowIndex].Cells["전일대비"].Style.ForeColor = Color.Blue;
                    }
                }
            }
        }


        private void dataGridViewAccount_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == this.dataGridViewAccount.Columns["총평가손익금액"].Index)
            {
                if (e.Value != null)
                {
                    if (string.IsNullOrEmpty(e.Value.ToString()))
                        return;
                    double value = double.Parse(e.Value.ToString());
                    if (value > 0)
                    {
                        //this.dataGridViewAccInfo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                        this.dataGridViewAccount.Rows[e.RowIndex].Cells["총평가손익금액"].Style.ForeColor = Color.Red;
                        this.dataGridViewAccount.Rows[e.RowIndex].Cells["총수익률"].Style.ForeColor = Color.Red;
                    }
                    else if (value < 0)
                    {
                        //this.dataGridViewAccInfo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                        this.dataGridViewAccount.Rows[e.RowIndex].Cells["총평가손익금액"].Style.ForeColor = Color.Blue;
                        this.dataGridViewAccount.Rows[e.RowIndex].Cells["총수익률"].Style.ForeColor = Color.Blue;
                    }
                }
            }
        } 
        #endregion

        private void dataGridViewCondition_DoubleClick(object sender, EventArgs e)
        {
            GetConditionResult();
        }

        private void btn매도가능수량_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewAccountStock_DoubleClick(object sender, EventArgs e)
        {
            if (this.tabCtr주문유형.SelectedIndex == 0) //매수
            {
                string stockCode = this.dataGridViewAccountStock.SelectedRows[0].Cells["종목번호"].Value.ToString();
                string currentPrice = this.dataGridViewAccountStock.SelectedRows[0].Cells["현재가AccountStock"].Value.ToString();

                this.tbStockCode.Text = stockCode;
                this.tb매수주문가격.Text = currentPrice;
            }
            else if (this.tabCtr주문유형.SelectedIndex == 1) //매도
            {
                string stockCode = this.dataGridViewAccountStock.SelectedRows[0].Cells["종목번호"].Value.ToString();
                string currentPrice = this.dataGridViewAccountStock.SelectedRows[0].Cells["현재가AccountStock"].Value.ToString();
                string loanDate = this.dataGridViewAccountStock.SelectedRows[0].Cells["대출일"].Value.ToString();

                this.tbStockCode.Text = stockCode;
                this.tb매도주문가격.Text = currentPrice;
                this.tbLoanDate.Text = loanDate;

            }
            else //취소
            {

            }
        }

        private void dataGridViewStockInfo_DoubleClick(object sender, EventArgs e)
        {
            if (this.tabCtr주문유형.SelectedIndex == 0) //매수
            {
                string stockCode = this.dataGridViewStockInfo.SelectedRows[0].Cells["종목코드"].Value.ToString();
                string currentPrice = this.dataGridViewStockInfo.SelectedRows[0].Cells["현재가"].Value.ToString();

                this.tbStockCode.Text = stockCode;
                this.tb매수주문가격.Text = currentPrice;
            }
            else if (this.tabCtr주문유형.SelectedIndex == 2) //취소
            {

            }
            else //취소
            {

            }
        }

        private void btn정정취소미체결_Click(object sender, EventArgs e)
        {
            NotConclude nc = new NotConclude();
            nc.Show();
        }
        #endregion

        #region 사용자 함수
        private void Get_OPW00018_계좌평가잔고내역요청()
        {
            OPW00018_계좌평가잔고내역요청 data = new OPW00018_계좌평가잔고내역요청();
            data.계좌번호 = this.cbAccount.Text;
            data.비밀번호 = "";
            data.비밀번호입력매체구분 = "00";
            data.조회구분 = "2";

            this.axKHOpenAPI.SetInputValue("계좌번호", data.계좌번호);
            this.axKHOpenAPI.SetInputValue("비밀번호", data.비밀번호);
            this.axKHOpenAPI.SetInputValue("비밀번호입력매체구분", data.비밀번호입력매체구분);
            this.axKHOpenAPI.SetInputValue("조회구분", data.조회구분);

            int result1 = this.axKHOpenAPI.CommRqData(data.RQName, data.RQCode, 0, GetScreenNum());
        }

        private void Get_OPW00004_계좌평가현황요청()
        {
            this.axKHOpenAPI.SetInputValue("계좌번호", this.cbAccount.Text);
            this.axKHOpenAPI.SetInputValue("비밀번호", "");
            this.axKHOpenAPI.SetInputValue("상장폐지조회구분", "0");
            this.axKHOpenAPI.SetInputValue("비밀번호입력매체구분", "00");

            int result = this.axKHOpenAPI.CommRqData("계좌평가현황요청", "OPW00004", 0, "6001");
        }

        private void sendOrderGS(int orderType, string stockCode, int orderQty, int orderPrice, string orderGb, bool creditYn, string orgOrderNo = "")
        {
            int lRet;
            string orderTypeStr = "";

            switch (orderType)
            {
                case 1:
                    orderTypeStr = "신규매수";
                    break;
                case 2:
                    orderTypeStr = "신규매도";
                    break;
                case 3:
                    orderTypeStr = "매수취소";
                    break;
                case 4:
                    orderTypeStr = "매도취소";
                    break;
                case 5:
                    orderTypeStr = "매수정정";
                    break;
                case 6:
                    orderTypeStr = "매도정정";
                    break;
                default:
                    break;
            }

            if (creditYn)
            {
                orderTypeStr = "신용" + orderTypeStr;

                lRet = axKHOpenAPI.SendOrderCredit("주식주문",
                            GetScreenNum(),
                            cbAccount.Text.Trim(),
                            orderType,      // 매매구분
                            stockCode,   // 종목코드
                            orderQty,      // 주문수량
                            orderPrice,      // 주문가격 
                            orderGb,    // 거래구분 (시장가)
                            orderType % 2 == 1 ? "03" : "33",
                            orderType % 2 == 1 ? "" : this.tbLoanDate.Text,
                            orgOrderNo);    // 원주문 번호
            }
            else
            {
                lRet = axKHOpenAPI.SendOrder("주식주문",
                            GetScreenNum(),
                            cbAccount.Text.Trim(),
                            orderType,      // 매매구분
                            stockCode,   // 종목코드
                            orderQty,      // 주문수량
                            orderPrice,      // 주문가격 
                            orderGb,    // 거래구분 (시장가)
                            orgOrderNo);    // 원주문 번호
            }

            if (lRet == 0)
            {
                Logger(Log.일반, orderTypeStr + " 주문이 전송 되었습니다");
            }
            else
            {
                Logger(Log.에러, orderTypeStr + " 주문이 전송 실패 하였습니다. [에러] : " + lRet);
            }
        }

        private string GetScreenNum()
        {
            if (_scrNum < 9000)
                this._scrNum++;
            else
                this._scrNum = 5000;
            return this._scrNum.ToString();
        }

        private void LoadConditionSearch()
        {
            conditionLoadState = axKHOpenAPI.GetConditionLoad();

            if (conditionLoadState == 1)
            {
                Logger(Log.일반, "조건식 저장 성공");

            }
            else
            {
                Logger(Log.에러, "조건식 저장 실패");
            }
        }

        private void GetAccountInfo()
        {
            string account = axKHOpenAPI.GetLoginInfo("ACCNO");
            string[] accounts = account.Split(';');

            foreach (string acc in accounts)
            {
                if (string.IsNullOrEmpty(acc))
                    continue;

                this.cbAccount.Items.Add(acc);
            }

            this.cbAccount.SelectedIndex = 0;
        }

        private void LogIn()
        {
            if (axKHOpenAPI.GetConnectState() == 0)
            {
                axKHOpenAPI.CommConnect();
            }
            else
            {
                Logger(Log.일반, "연결중");
            }
        }

        public void Logger(Log type, string msg)
        {
            this.richTextBoxLog.AppendText(type.ToString() + " : " + msg + "\n");
        }

        private void GetConditionResult()
        {
            if (this.dataGridViewCondition.SelectedRows.Count == 0)
            {
                Logger(Log.일반, "투란나 조건식을 선택해야지!");
                return;
            }

            int conditionIndex = Int32.Parse(this.dataGridViewCondition.SelectedRows[0].Cells[0].Value.ToString());
            string conditionName = this.dataGridViewCondition.SelectedRows[0].Cells[1].Value.ToString();

            int result = axKHOpenAPI.SendCondition(GetScreenNum(), conditionName, conditionIndex, 1);
            if(result==1)
            {

            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                axKHOpenAPI.SendCondition(GetScreenNum(), conditionName, conditionIndex, 1);
            }
        }

        #endregion


        // 실시간 연결 종료
        private void DisconnectAllRealData()
        {
            for (int i = _scrNum; i > 5000; i--)
            {
                axKHOpenAPI.DisconnectRealData(i.ToString());
            }

            _scrNum = 5000;
        }
    }
}
