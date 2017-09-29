using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloomySpider
{
    public enum Log
    {
        조회,     // 조회창 출력
        에러,     // 에러창 출력
        일반,     // 일반창 출력
        실시간    // 실시간창 출력
    }

    public class OPT10001_주식기본정보
    {
        private string _종목코드;
        private string _종목명;
        private string _현재가;
        private string _전일대비;
        private string _등락율;

        public string 종목코드 { get => _종목코드; set => _종목코드 = value; }
        public string 종목명 { get => _종목명; set => _종목명 = value; }
        public string 현재가 { get => _현재가.Replace("-","").Replace("+",""); set => _현재가 = value; }
        public string 전일대비 { get => _전일대비; set => _전일대비 = value; }
        public string 등락율 { get => _등락율; set => _등락율 = value; }
    }

        public class ConditionSearch
    {
        private string _조건번호;
        private string _조건명;

        public string 조건번호 { get => _조건번호; set => _조건번호 = value; }
        public string 조건명 { get => _조건명; set => _조건명 = value; }
    }

    public class OPW00018_계좌평가잔고내역요청
    {
        private string _RQName = "계좌평가잔고내역요청";
        private string _RQCode = "OPW00018";

        private string _계좌번호;
        private string _비밀번호;
        private string _비밀번호입력매체구분;
        private string _조회구분;

        public string RQName { get => _RQName; }
        public string RQCode { get => _RQCode; }

        public string 계좌번호 { get => _계좌번호; set => _계좌번호 = value; }
        public string 비밀번호 { get => _비밀번호; set => _비밀번호 = value; }
        public string 비밀번호입력매체구분 { get => _비밀번호입력매체구분; set => _비밀번호입력매체구분 = value; }
        public string 조회구분 { get => _조회구분; set => _조회구분 = value; }

    }

    public class OPW00018_계좌평가결과
    {
        private string _총매입금액;
        private string _총평가금액;
        private string _총평가손익금액;
        private string _총수익률;
        private string _추정예탁자산;
        private string _총대출금;
        private string _총융자금액;
        private string _총대주금액;
        private string _조회건수;

        public string 총매입금액 { get => _총매입금액.ToIntString(); set => _총매입금액 = value; }
        public string 총평가금액 { get => _총평가금액.ToIntString(); set => _총평가금액 = value; }
        public string 총평가손익금액 { get => _총평가손익금액.ToPrice(); set => _총평가손익금액 = value; }
        public string 총수익률 { get => _총수익률.ToPersentage(); set => _총수익률 = value; }
        public string 추정예탁자산 { get => _추정예탁자산.ToIntString(); set => _추정예탁자산 = value; }
        public string 총대출금 { get => _총대출금.ToIntString(); set => _총대출금 = value; }
        public string 총융자금액 { get => _총융자금액.ToIntString(); set => _총융자금액 = value; }
        public string 총대주금액 { get => _총대주금액.ToIntString(); set => _총대주금액 = value; }
        public string 조회건수 { get => _조회건수.ToIntString(); set => _조회건수 = value; }
    }

    public class OPW00018_계좌평가잔고개별합산
    {
        private string _종목번호;
        private string _종목명;
        private string _현재가;
        private string _평가손익;
        private string _수익률;
        private string _매입가;
        private string _전일종가;
        private string _보유수량;
        private string _매매가능수량;
        private string _매입금액;
        private string _매입수수료;
        private string _평가금액;
        private string _평가수수료;
        private string _세금;
        private string _수수료합;
        private string _보유비중;
        private string _신용구분;
        private string _신용구분명;
        private string _대출일;
        private string _전일매수수량;
        private string _전일매도수량;
        private string _금일매수수량;
        private string _금일매도수량;

        public string 종목번호 { get => _종목번호.Replace("A",""); set => _종목번호 = value; }
        public string 종목명 { get => _종목명; set => _종목명 = value; }
        public string 현재가 { get => _현재가.ToIntString(); set => _현재가 = value; }
        public string 평가손익 { get => _평가손익.ToPrice(); set => _평가손익 = value; }
        public string 수익률 { get => _수익률.ToPersentage(); set => _수익률 = value; }
        public string 매입가 { get => _매입가.ToIntString(); set => _매입가 = value; }
        public string 전일종가 { get => _전일종가.ToIntString(); set => _전일종가 = value; }
        public string 보유수량 { get => _보유수량.ToIntString(); set => _보유수량 = value; }
        public string 매매가능수량 { get => _매매가능수량.ToIntString(); set => _매매가능수량 = value; }
        
        public string 매입금액 { get => _매입금액.ToIntString(); set => _매입금액 = value; }
        public string 매입수수료 { get => _매입수수료.ToIntString(); set => _매입수수료 = value; }
        public string 평가금액 { get => _평가금액.ToIntString(); set => _평가금액 = value; }
        public string 평가수수료 { get => _평가수수료.ToIntString(); set => _평가수수료 = value; }
        public string 세금 { get => _세금.ToIntString(); set => _세금 = value; }
        public string 수수료합 { get => _수수료합.ToIntString(); set => _수수료합 = value; }
        public string 보유비중 { get => _보유비중.ToPersentage(); set => _보유비중 = value; }
        public string 신용구분 { get => _신용구분; set => _신용구분 = value; }
        public string 신용구분명 { get => _신용구분명; set => _신용구분명 = value; }
        public string 대출일 { get => _대출일; set => _대출일 = value; }
        public string 전일매수수량 { get => _전일매수수량.ToIntString(); set => _전일매수수량 = value; }
        public string 전일매도수량 { get => _전일매도수량.ToIntString(); set => _전일매도수량 = value; }
        public string 금일매수수량 { get => _금일매수수량.ToIntString(); set => _금일매수수량 = value; }
        public string 금일매도수량 { get => _금일매도수량.ToIntString(); set => _금일매도수량 = value; }
    }

    public class OPW00004_계좌평가현황요청_Single
    {
        private string _예수금;
        private string _유가잔고평가액;
        private string _예탁자산평가액;
        private string _총매입금액;
        private string _추정예탁자산;
        private string _당일투자원금;
        private string _당월투자원금;
        private string _누적투자원금;
        private string _당일투자손익;
        private string _당월투자손익;
        private string _누적투자손익;
        private string _당일투자손익율;
        private string _당월투자손익율;
        private string _누적투자손익율;

        public string 예수금 { get => _예수금.ToIntString(); set => _예수금 = value; }
        public string 유가잔고평가액 { get => _유가잔고평가액.ToIntString(); set => _유가잔고평가액 = value; }
        public string 예탁자산평가액 { get => _예탁자산평가액.ToIntString(); set => _예탁자산평가액 = value; }
        public string 총매입금액 { get => _총매입금액.ToIntString(); set => _총매입금액 = value; }
        public string 추정예탁자산 { get => _추정예탁자산.ToIntString(); set => _추정예탁자산 = value; }
        public string 당일투자원금 { get => _당일투자원금.ToIntString(); set => _당일투자원금 = value; }
        public string 당월투자원금 { get => _당월투자원금.ToIntString(); set => _당월투자원금 = value; }
        public string 누적투자원금 { get => _누적투자원금.ToIntString(); set => _누적투자원금 = value; }
        public string 당일투자손익 { get => _당일투자손익.ToPrice(); set => _당일투자손익 = value; }
        public string 당월투자손익 { get => _당월투자손익.ToPrice(); set => _당월투자손익 = value; }
        public string 누적투자손익 { get => _누적투자손익.ToPrice(); set => _누적투자손익 = value; }
        public string 당일투자손익율 { get => _당일투자손익율.ToPersentage(); set => _당일투자손익율 = value; }
        public string 당월투자손익율 { get => _당월투자손익율.ToPersentage(); set => _당월투자손익율 = value; }
        public string 누적투자손익율 { get => _누적투자손익율.ToPersentage(); set => _누적투자손익율 = value; }
    }

    public class OPW00004_계좌평가현황요청_Multi
    {
        private string _종목코드;
        private string _종목명;
        private string _보유수량;
        private string _평균단가;
        private string _평가금액;
        private string _현재가;
        private string _손익금액;
        private string _손익율;
        private string _대출일;
        private string _매입금액;
        private string _결제잔고;
        private string _전일매수수량;
        private string _전일매도수량;
        private string _금일매수수량;
        private string _금일매도수량;

        public string 종목코드 { get => _종목코드.Replace("A", "").ToIntString(); set => _종목코드 = value; }
        public string 종목명 { get => _종목명; set => _종목명 = value; }
        public string 현재가 { get => _현재가.ToIntString(); set => _현재가 = value; }
        public string 보유수량 { get => _보유수량.ToIntString(); set => _보유수량 = value; }
        public string 평균단가 { get => _평균단가; set => _평균단가 = value; }
        public string 평가금액 { get => _평가금액.ToIntString(); set => _평가금액 = value; }
        public string 손익금액
        {
            get => _손익금액.ToPrice();
            set => _손익금액 = value;
        }
        public string 손익율
        {
            get => _손익율.ToPersentage();
            set => _손익율 = value;
        }
        public string 대출일 { get => _대출일; set => _대출일 = value; }
        public string 매입금액 { get => _매입금액.ToIntString(); set => _매입금액 = value; }
        public string 결제잔고 { get => _결제잔고; set => _결제잔고 = value; }
        public string 전일매수수량 { get => _전일매수수량; set => _전일매수수량 = value; }
        public string 전일매도수량 { get => _전일매도수량; set => _전일매도수량 = value; }
        public string 금일매수수량 { get => _금일매수수량; set => _금일매수수량 = value; }
        public string 금일매도수량 { get => _금일매도수량; set => _금일매도수량 = value; }
    }

    public class OPW00011_증거금율별주문가능수량조회요청
    {
        private string _RQName = "증거금율별주문가능수량조회요청";
        private string _RQCode = "OPW00011";

        private string _계좌번호;
        private string _비밀번호;
        private string _비밀번호입력매체구분;
        private string _종목번호;
        private string _매수가격;

        public string RQName { get => _RQName; set => _RQName = value; }
        public string RQCode { get => _RQCode; set => _RQCode = value; }
        public string 계좌번호 { get => _계좌번호; set => _계좌번호 = value; }
        public string 비밀번호 { get => _비밀번호; set => _비밀번호 = value; }
        public string 비밀번호입력매체구분 { get => _비밀번호입력매체구분; set => _비밀번호입력매체구분 = value; }
        public string 종목번호 { get => _종목번호; set => _종목번호 = value; }
        public string 매수가격 { get => _매수가격; set => _매수가격 = value; }
    }

    public class OPW00011_증거금율별주문가능수량조회
    {
        private string _종목증거금율;
        private string _계좌증거금율;
        private string _적용증거금율;
        private string _증거금20주문가능금액;
        private string _증거금20주문가능수량;
        private string _증거금20전일재사용금액;
        private string _증거금20금일재사용금액;
        private string _증거금30주문가능금액;
        private string _증거금30주문가능수량;
        private string _증거금30전일재사용금액;
        private string _증거금30금일재사용금액;
        private string _증거금40주문가능금액;
        private string _증거금40주문가능수량;
        private string _증거금40전일재사용금액;
        private string _증거금40금일재사용금액;
        private string _증거금50주문가능금액;
        private string _증거금50주문가능수량;
        private string _증거금50전일재사용금액;
        private string _증거금50금일재사용금액;
        private string _증거금60주문가능금액;
        private string _증거금60주문가능수량;
        private string _증거금60전일재사용금액;
        private string _증거금60금일재사용금액;
        private string _증거금100주문가능금액;
        private string _증거금100주문가능수량;
        private string _증거금100전일재사용금액;
        private string _증거금100금일재사용금액;
        private string _미수불가주문가능금액;
        private string _미수불가주문가능수량;
        private string _미수불가전일재사용금액;
        private string _미수불가금일재사용금액;
        private string _예수금;
        private string _대용금;
        private string _미수금;
        private string _주문가능대용;
        private string _주문가능현금;

        public string 종목증거금율 { get => _종목증거금율; set => _종목증거금율 = value; }
        public string 계좌증거금율 { get => _계좌증거금율; set => _계좌증거금율 = value; }
        public string 적용증거금율 { get => _적용증거금율; set => _적용증거금율 = value; }
        public string 증거금20주문가능금액 { get => _증거금20주문가능금액; set => _증거금20주문가능금액 = value; }
        public string 증거금20주문가능수량 { get => _증거금20주문가능수량; set => _증거금20주문가능수량 = value; }
        public string 증거금20전일재사용금액 { get => _증거금20전일재사용금액; set => _증거금20전일재사용금액 = value; }
        public string 증거금20금일재사용금액 { get => _증거금20금일재사용금액; set => _증거금20금일재사용금액 = value; }
        public string 증거금30주문가능금액 { get => _증거금30주문가능금액; set => _증거금30주문가능금액 = value; }
        public string 증거금30주문가능수량 { get => _증거금30주문가능수량; set => _증거금30주문가능수량 = value; }
        public string 증거금30전일재사용금액 { get => _증거금30전일재사용금액; set => _증거금30전일재사용금액 = value; }
        public string 증거금30금일재사용금액 { get => _증거금30금일재사용금액; set => _증거금30금일재사용금액 = value; }
        public string 증거금40주문가능금액 { get => _증거금40주문가능금액; set => _증거금40주문가능금액 = value; }
        public string 증거금40주문가능수량 { get => _증거금40주문가능수량; set => _증거금40주문가능수량 = value; }
        public string 증거금40전일재사용금액 { get => _증거금40전일재사용금액; set => _증거금40전일재사용금액 = value; }
        public string 증거금40금일재사용금액 { get => _증거금40금일재사용금액; set => _증거금40금일재사용금액 = value; }
        public string 증거금50주문가능금액 { get => _증거금50주문가능금액; set => _증거금50주문가능금액 = value; }
        public string 증거금50주문가능수량 { get => _증거금50주문가능수량; set => _증거금50주문가능수량 = value; }
        public string 증거금50전일재사용금액 { get => _증거금50전일재사용금액; set => _증거금50전일재사용금액 = value; }
        public string 증거금50금일재사용금액 { get => _증거금50금일재사용금액; set => _증거금50금일재사용금액 = value; }
        public string 증거금60주문가능금액 { get => _증거금60주문가능금액; set => _증거금60주문가능금액 = value; }
        public string 증거금60주문가능수량 { get => _증거금60주문가능수량; set => _증거금60주문가능수량 = value; }
        public string 증거금60전일재사용금액 { get => _증거금60전일재사용금액; set => _증거금60전일재사용금액 = value; }
        public string 증거금60금일재사용금액 { get => _증거금60금일재사용금액; set => _증거금60금일재사용금액 = value; }
        public string 증거금100주문가능금액 { get => _증거금100주문가능금액; set => _증거금100주문가능금액 = value; }
        public string 증거금100주문가능수량 { get => _증거금100주문가능수량; set => _증거금100주문가능수량 = value; }
        public string 증거금100전일재사용금액 { get => _증거금100전일재사용금액; set => _증거금100전일재사용금액 = value; }
        public string 증거금100금일재사용금액 { get => _증거금100금일재사용금액; set => _증거금100금일재사용금액 = value; }
        public string 미수불가주문가능금액 { get => _미수불가주문가능금액; set => _미수불가주문가능금액 = value; }
        public string 미수불가주문가능수량 { get => _미수불가주문가능수량; set => _미수불가주문가능수량 = value; }
        public string 미수불가전일재사용금액 { get => _미수불가전일재사용금액; set => _미수불가전일재사용금액 = value; }
        public string 미수불가금일재사용금액 { get => _미수불가금일재사용금액; set => _미수불가금일재사용금액 = value; }
        public string 예수금 { get => _예수금; set => _예수금 = value; }
        public string 대용금 { get => _대용금; set => _대용금 = value; }
        public string 미수금 { get => _미수금; set => _미수금 = value; }
        public string 주문가능대용 { get => _주문가능대용; set => _주문가능대용 = value; }
        public string 주문가능현금 { get => _주문가능현금; set => _주문가능현금 = value; }
    }

    public class OPW00012_신용보증금율별주문가능수량조회요청
    {
        private string _RQName = "신용보증금율별주문가능수량조회요청";
        private string _RQCode = "OPW00012";

        private string _계좌번호;
        private string _비밀번호;
        private string _비밀번호입력매체구분;
        private string _종목번호;
        private string _매수가격;

        public string RQName { get => _RQName; set => _RQName = value; }
        public string RQCode { get => _RQCode; set => _RQCode = value; }
        public string 계좌번호 { get => _계좌번호; set => _계좌번호 = value; }
        public string 비밀번호 { get => _비밀번호; set => _비밀번호 = value; }
        public string 비밀번호입력매체구분 { get => _비밀번호입력매체구분; set => _비밀번호입력매체구분 = value; }
        public string 종목번호 { get => _종목번호; set => _종목번호 = value; }
        public string 매수가격 { get => _매수가격; set => _매수가격 = value; }
    }

        public class OPW00012_신용보증금율별주문가능수량조회
    {
        private string _종목보증금율;
        private string _종목보증금율명;
        private string _보증금30주문가능금액;
        private string _보증금30주문가능수량;
        private string _보증금30전일재사용금액;
        private string _보증금30금일재사용금액;
        private string _보증금40주문가능금액;
        private string _보증금40주문가능수량;
        private string _보증금40전일재사용금액;
        private string _보증금40금일재사용금액;
        private string _보증금50주문가능금액;
        private string _보증금50주문가능수량;
        private string _보증금50전일재사용금액;
        private string _보증금50금일재사용금액;
        private string _보증금60주문가능금액;
        private string _보증금60주문가능수량;
        private string _보증금60전일재사용금액;
        private string _보증금60금일재사용금액;
        private string _예수금;
        private string _대용금;
        private string _미수금;
        private string _주문가능대용;
        private string _주문가능현금;
        private string _미수가능금액;
        private string _미수가능수량;
        private string _미수불가금액;
        private string _미수불가수량;

        public string 종목보증금율 { get => _종목보증금율; set => _종목보증금율 = value; }
        public string 종목보증금율명 { get => _종목보증금율명; set => _종목보증금율명 = value; }
        public string 보증금30주문가능금액 { get => _보증금30주문가능금액; set => _보증금30주문가능금액 = value; }
        public string 보증금30주문가능수량 { get => _보증금30주문가능수량; set => _보증금30주문가능수량 = value; }
        public string 보증금30전일재사용금액 { get => _보증금30전일재사용금액; set => _보증금30전일재사용금액 = value; }
        public string 보증금30금일재사용금액 { get => _보증금30금일재사용금액; set => _보증금30금일재사용금액 = value; }
        public string 보증금40주문가능금액 { get => _보증금40주문가능금액; set => _보증금40주문가능금액 = value; }
        public string 보증금40주문가능수량 { get => _보증금40주문가능수량; set => _보증금40주문가능수량 = value; }
        public string 보증금40전일재사용금액 { get => _보증금40전일재사용금액; set => _보증금40전일재사용금액 = value; }
        public string 보증금40금일재사용금액 { get => _보증금40금일재사용금액; set => _보증금40금일재사용금액 = value; }
        public string 보증금50주문가능금액 { get => _보증금50주문가능금액; set => _보증금50주문가능금액 = value; }
        public string 보증금50주문가능수량 { get => _보증금50주문가능수량; set => _보증금50주문가능수량 = value; }
        public string 보증금50전일재사용금액 { get => _보증금50전일재사용금액; set => _보증금50전일재사용금액 = value; }
        public string 보증금50금일재사용금액 { get => _보증금50금일재사용금액; set => _보증금50금일재사용금액 = value; }
        public string 보증금60주문가능금액 { get => _보증금60주문가능금액; set => _보증금60주문가능금액 = value; }
        public string 보증금60주문가능수량 { get => _보증금60주문가능수량; set => _보증금60주문가능수량 = value; }
        public string 보증금60전일재사용금액 { get => _보증금60전일재사용금액; set => _보증금60전일재사용금액 = value; }
        public string 보증금60금일재사용금액 { get => _보증금60금일재사용금액; set => _보증금60금일재사용금액 = value; }
        public string 예수금 { get => _예수금; set => _예수금 = value; }
        public string 대용금 { get => _대용금; set => _대용금 = value; }
        public string 미수금 { get => _미수금; set => _미수금 = value; }
        public string 주문가능대용 { get => _주문가능대용; set => _주문가능대용 = value; }
        public string 주문가능현금 { get => _주문가능현금; set => _주문가능현금 = value; }
        public string 미수가능금액 { get => _미수가능금액; set => _미수가능금액 = value; }
        public string 미수가능수량 { get => _미수가능수량; set => _미수가능수량 = value; }
        public string 미수불가금액 { get => _미수불가금액; set => _미수불가금액 = value; }
        public string 미수불가수량 { get => _미수불가수량; set => _미수불가수량 = value; }
    }

    public class OPT10075_실시간미체결요청
    {
        private string _계좌번호;
        private string _체결구분;
        private string _매매구분;

        public string 계좌번호 { get => _계좌번호; set => _계좌번호 = value; }
        public string 체결구분 { get => _체결구분; set => _체결구분 = value; }
        public string 매매구분 { get => _매매구분; set => _매매구분 = value; }
    }

    public class OPT10075_실시간미체결
    {
        private string _계좌번호;
        private string _주문번호;
        private string _관리사번;
        private string _종목코드;
        private string _업무구분;
        private string _주문상태;
        private string _종목명;
        private string _주문수량;
        private string _주문가격;
        private string _미체결수량;
        private string _체결누계금액;
        private string _원주문번호;
        private string _주문구분;
        private string _매매구분;
        private string _시간;
        private string _체결번호;
        private string _체결가;
        private string _체결량;
        private string _현재가;
        private string _매도호가;
        private string _매수호가;
        private string _단위체결가;
        private string _단위체결량;
        private string _당일매매수수료;
        private string _당일매매세금;
        private string _개인투자자;

        public string 계좌번호 { get => _계좌번호; set => _계좌번호 = value; }
        public string 주문번호 { get => _주문번호; set => _주문번호 = value; }
        public string 관리사번 { get => _관리사번; set => _관리사번 = value; }
        public string 종목코드 { get => _종목코드; set => _종목코드 = value; }
        public string 업무구분 { get => _업무구분; set => _업무구분 = value; }
        public string 주문상태 { get => _주문상태; set => _주문상태 = value; }
        public string 종목명 { get => _종목명; set => _종목명 = value; }
        public string 주문수량 { get => _주문수량; set => _주문수량 = value; }
        public string 주문가격 { get => _주문가격; set => _주문가격 = value; }
        public string 미체결수량 { get => _미체결수량; set => _미체결수량 = value; }
        public string 체결누계금액 { get => _체결누계금액; set => _체결누계금액 = value; }
        public string 원주문번호 { get => _원주문번호; set => _원주문번호 = value; }
        public string 주문구분 { get => _주문구분; set => _주문구분 = value; }
        public string 매매구분 { get => _매매구분; set => _매매구분 = value; }
        public string 시간 { get => _시간; set => _시간 = value; }
        public string 체결번호 { get => _체결번호; set => _체결번호 = value; }
        public string 체결가 { get => _체결가; set => _체결가 = value; }
        public string 체결량 { get => _체결량; set => _체결량 = value; }
        public string 현재가 { get => _현재가; set => _현재가 = value; }
        public string 매도호가 { get => _매도호가; set => _매도호가 = value; }
        public string 매수호가 { get => _매수호가; set => _매수호가 = value; }
        public string 단위체결가 { get => _단위체결가; set => _단위체결가 = value; }
        public string 단위체결량 { get => _단위체결량; set => _단위체결량 = value; }
        public string 당일매매수수료 { get => _당일매매수수료; set => _당일매매수수료 = value; }
        public string 당일매매세금 { get => _당일매매세금; set => _당일매매세금 = value; }
        public string 개인투자자 { get => _개인투자자; set => _개인투자자 = value; }
    }

        class KOAErrorCode
    {
        public const int OP_ERR_NONE = 0;     //"정상처리"
        public const int OP_ERR_LOGIN = -100;  //"사용자정보교환에 실패하였습니다. 잠시후 다시 시작하여 주십시오."
        public const int OP_ERR_CONNECT = -101;  //"서버 접속 실패"
        public const int OP_ERR_VERSION = -102;  //"버전처리가 실패하였습니다.
        public const int OP_ERR_SISE_OVERFLOW = -200;  //”시세조회 과부하”
        public const int OP_ERR_RQ_STRUCT_FAIL = -201;  //”REQUEST_INPUT_st Failed”
        public const int OP_ERR_RQ_STRING_FAIL = -202;  //”요청 전문 작성 실패”
        public const int OP_ERR_ORD_WRONG_INPUT = -300;  //”주문 입력값 오류”
        public const int OP_ERR_ORD_WRONG_ACCNO = -301;  //”계좌비밀번호를 입력하십시오.”
        public const int OP_ERR_OTHER_ACC_USE = -302;  //”타인계좌는 사용할 수 없습니다.
        public const int OP_ERR_MIS_2BILL_EXC = -303;  //”주문가격이 20억원을 초과합니다.”
        public const int OP_ERR_MIS_5BILL_EXC = -304;  //”주문가격은 50억원을 초과할 수 없습니다.”
        public const int OP_ERR_MIS_1PER_EXC = -305;  //”주문수량이 총발행주수의 1%를 초과합니다.”
        public const int OP_ERR_MID_3PER_EXC = -306;  //”주문수량은 총발행주수의 3%를 초과할 수 없습니다.”
    }

    public class KOACode
    {

        /// <summary>
        /// 주문코드 클래스
        /// </summary>
        public struct OrderType
        {
            private string Name;
            private int Code;

            public OrderType(int nCode, string strName)
            {
                this.Name = strName;
                this.Code = nCode;
            }

            public string name
            {
                get
                {
                    return this.Name;
                }
            }

            public int code
            {
                get
                {
                    return this.Code;
                }
            }
        }

        public readonly static OrderType[] orderType = new OrderType[6];


        /// <summary>
        /// 호가구분 클래스
        /// </summary>
        public struct HogaGb
        {
            private string Name;
            private string Code;

            public HogaGb(string strCode, string strName)
            {
                this.Code = strCode;
                this.Name = strName;
            }

            public string name
            {
                get
                {
                    return this.Name;
                }
            }

            public string code
            {
                get
                {
                    return this.Code;
                }
            }
        }

        public readonly static HogaGb[] hogaGb = new HogaGb[13];

        public struct MarketCode
        {
            private string Name;
            private string Code;

            public MarketCode(string strCode, string strName)
            {
                this.Code = strCode;
                this.Name = strName;
            }

            public string name
            {
                get
                {
                    return this.Name;
                }
            }

            public string code
            {
                get
                {
                    return this.Code;
                }
            }
        }

        public readonly static MarketCode[] marketCode = new MarketCode[9];

        static KOACode()
        {
            // 주문타입 설정
            orderType[0] = new OrderType(1, "신규매수");
            orderType[1] = new OrderType(2, "신규매도");
            orderType[2] = new OrderType(3, "매수취소");
            orderType[3] = new OrderType(4, "매도취소");
            orderType[4] = new OrderType(5, "매수정정");
            orderType[5] = new OrderType(6, "매도정정");

            // 호가타입 설정
            hogaGb[0] = new HogaGb("00", "지정가");
            hogaGb[1] = new HogaGb("03", "시장가");
            hogaGb[2] = new HogaGb("05", "조건부지정가");
            hogaGb[3] = new HogaGb("06", "최유리지정가");
            hogaGb[4] = new HogaGb("07", "최우선지정가");
            hogaGb[5] = new HogaGb("10", "지정가IOC");
            hogaGb[6] = new HogaGb("13", "시장가IOC");
            hogaGb[7] = new HogaGb("16", "최유리IOC");
            hogaGb[8] = new HogaGb("20", "지정가FOK");
            hogaGb[9] = new HogaGb("23", "시장가FOK");
            hogaGb[10] = new HogaGb("26", "최유리FOK");
            hogaGb[11] = new HogaGb("61", "시간외단일가매매");
            hogaGb[12] = new HogaGb("81", "시간외종가");

            // 마켓코드 설정
            marketCode[0] = new MarketCode("0", "장내");
            marketCode[1] = new MarketCode("3", "ELW");
            marketCode[2] = new MarketCode("4", "뮤추얼펀드");
            marketCode[3] = new MarketCode("5", "신주인수권");
            marketCode[4] = new MarketCode("6", "리츠");
            marketCode[5] = new MarketCode("8", "ETF");
            marketCode[6] = new MarketCode("9", "하이일드펀드");
            marketCode[7] = new MarketCode("10", "코스닥");
            marketCode[8] = new MarketCode("30", "제3시장");
        }
    }

    class Error
    {
        private static string errorMessage;

        Error()
        {
            errorMessage = "";
        }

        ~Error()
        {
            errorMessage = "";
        }

        public static string GetErrorMessage()
        {
            return errorMessage;
        }

        public static bool IsError(int nErrorCode)
        {
            bool bRet = false;

            switch (nErrorCode)
            {
                case KOAErrorCode.OP_ERR_NONE:
                    errorMessage = "[" + nErrorCode.ToString() + "] :" + "정상처리";
                    bRet = true;
                    break;
                case KOAErrorCode.OP_ERR_LOGIN:
                    errorMessage = "[" + nErrorCode.ToString() + "] :" + "사용자정보교환에 실패하였습니다. 잠시 후 다시 시작하여 주십시오.";
                    break;
                case KOAErrorCode.OP_ERR_CONNECT:
                    errorMessage = "[" + nErrorCode.ToString() + "] :" + "서버 접속 실패";
                    break;
                case KOAErrorCode.OP_ERR_VERSION:
                    errorMessage = "[" + nErrorCode.ToString() + "] :" + "버전처리가 실패하였습니다";
                    break;
                case KOAErrorCode.OP_ERR_SISE_OVERFLOW:
                    errorMessage = "[" + nErrorCode.ToString() + "] :" + "시세조회 과부하";
                    break;
                case KOAErrorCode.OP_ERR_RQ_STRUCT_FAIL:
                    errorMessage = "[" + nErrorCode.ToString() + "] :" + "REQUEST_INPUT_st Failed";
                    break;
                case KOAErrorCode.OP_ERR_RQ_STRING_FAIL:
                    errorMessage = "[" + nErrorCode.ToString() + "] :" + "요청 전문 작성 실패";
                    break;
                case KOAErrorCode.OP_ERR_ORD_WRONG_INPUT:
                    errorMessage = "[" + nErrorCode.ToString() + "] :" + "주문 입력값 오류";
                    break;
                case KOAErrorCode.OP_ERR_ORD_WRONG_ACCNO:
                    errorMessage = "[" + nErrorCode.ToString() + "] :" + "계좌비밀번호를 입력하십시오.";
                    break;
                case KOAErrorCode.OP_ERR_OTHER_ACC_USE:
                    errorMessage = "[" + nErrorCode.ToString() + "] :" + "타인계좌는 사용할 수 없습니다.";
                    break;
                case KOAErrorCode.OP_ERR_MIS_2BILL_EXC:
                    errorMessage = "[" + nErrorCode.ToString() + "] :" + "주문가격이 20억원을 초과합니다.";
                    break;
                case KOAErrorCode.OP_ERR_MIS_5BILL_EXC:
                    errorMessage = "[" + nErrorCode.ToString() + "] :" + "주문가격은 50억원을 초과할 수 없습니다.";
                    break;
                case KOAErrorCode.OP_ERR_MIS_1PER_EXC:
                    errorMessage = "[" + nErrorCode.ToString() + "] :" + "주문수량이 총발행주수의 1%를 초과합니다.";
                    break;
                case KOAErrorCode.OP_ERR_MID_3PER_EXC:
                    errorMessage = "[" + nErrorCode.ToString() + "] :" + "주문수량은 총발행주수의 3%를 초과할 수 없습니다";
                    break;
                default:
                    errorMessage = "[" + nErrorCode.ToString() + "] :" + "알려지지 않은 오류입니다.";
                    break;
            }

            return bRet;
        }
    }
}
