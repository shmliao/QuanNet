
#include "StdAfx.h"
#include "TraderSpi.h"
#include "CTPTraderAdapter.h"

using namespace Native;

namespace CTP
{

CTPTraderAdapter::CTPTraderAdapter(void)
{
	m_pApi = CThostFtdcTraderApi::CreateFtdcTraderApi();
	m_pSpi = new CTraderSpi(this);
	m_pApi->RegisterSpi((CThostFtdcTraderSpi*)m_pSpi);
}

CTPTraderAdapter::CTPTraderAdapter(String^ pszFlowPath, bool bIsUsingUdp)
{
	CAutoStrPtr asp(pszFlowPath);
	m_pApi = CThostFtdcTraderApi::CreateFtdcTraderApi(asp.m_pChar);
	m_pSpi = new CTraderSpi(this);
	m_pApi->RegisterSpi(m_pSpi);
}

CTPTraderAdapter::~CTPTraderAdapter(void)
{
	Release();
}

void CTPTraderAdapter::Release(void)
{
	if(m_pApi)
	{
		m_pApi->RegisterSpi(0);
		m_pApi->Release();
		m_pApi = nullptr;
		delete m_pSpi;
	}
}
///ע��ǰ�û������ַ
void CTPTraderAdapter::RegisterFront(String^  pszFrontAddress)
{
	CAutoStrPtr asp = CAutoStrPtr(pszFrontAddress);
	m_pApi->RegisterFront(asp.m_pChar);
}
///����˽������
void CTPTraderAdapter::SubscribePrivateTopic(EnumTeResumeType nResumeType)
{
	m_pApi->SubscribePrivateTopic((THOST_TE_RESUME_TYPE)nResumeType);
}
///���Ĺ�����
void CTPTraderAdapter::SubscribePublicTopic(EnumTeResumeType nResumeType)
{
	m_pApi->SubscribePublicTopic((THOST_TE_RESUME_TYPE)nResumeType);
}

void CTPTraderAdapter::Init(void)
{
	m_pApi->Init();
}

int CTPTraderAdapter::Join(void)
{
	return m_pApi->Join();
}

String^ CTPTraderAdapter::GetTradingDay()
{
	return gcnew String(m_pApi->GetTradingDay());
}
///�ͻ�����֤����
int CTPTraderAdapter::ReqAuthenticate(ThostFtdcReqAuthenticateField^ pReqAuthenticateField, int nRequestID){
	CThostFtdcReqAuthenticateField native;
	MNConv<ThostFtdcReqAuthenticateField^, CThostFtdcReqAuthenticateField>::M2N(pReqAuthenticateField, &native);
	return m_pApi->ReqAuthenticate(&native, nRequestID);
}
///�û���¼����
int CTPTraderAdapter::ReqUserLogin(ThostFtdcReqUserLoginField^ pReqUserLoginField, int nRequestID)
{
	CThostFtdcReqUserLoginField native;
	MNConv<ThostFtdcReqUserLoginField^, CThostFtdcReqUserLoginField>::M2N(pReqUserLoginField, &native);
	return m_pApi->ReqUserLogin(&native, nRequestID);
}
///�ǳ�����
int CTPTraderAdapter::ReqUserLogout(ThostFtdcUserLogoutField^ pUserLogout, int nRequestID)
{
	CThostFtdcUserLogoutField native;
	MNConv<ThostFtdcUserLogoutField^, CThostFtdcUserLogoutField>::M2N(pUserLogout, &native);
	return m_pApi->ReqUserLogout(&native, nRequestID);
}
///�û������������
int CTPTraderAdapter::ReqUserPasswordUpdate(ThostFtdcUserPasswordUpdateField^ pUserPasswordUpdate, int nRequestID)
{
	CThostFtdcUserPasswordUpdateField native;
	MNConv<ThostFtdcUserPasswordUpdateField^, CThostFtdcUserPasswordUpdateField>::M2N(pUserPasswordUpdate, &native);
	return m_pApi->ReqUserPasswordUpdate(&native, nRequestID);
}
///�ʽ��˻������������
int CTPTraderAdapter::ReqTradingAccountPasswordUpdate(ThostFtdcTradingAccountPasswordUpdateField^ pTradingAccountPasswordUpdate, int nRequestID)
{
	CThostFtdcTradingAccountPasswordUpdateField native;
	MNConv<ThostFtdcTradingAccountPasswordUpdateField^, CThostFtdcTradingAccountPasswordUpdateField>::M2N(pTradingAccountPasswordUpdate, &native);
	return m_pApi->ReqTradingAccountPasswordUpdate(&native, nRequestID);
}
///����¼������
int CTPTraderAdapter::ReqOrderInsert(ThostFtdcInputOrderField^ pInputOrder, int nRequestID)
{
	CThostFtdcInputOrderField native;
	MNConv<ThostFtdcInputOrderField^, CThostFtdcInputOrderField>::M2N(pInputOrder, &native);
	return m_pApi->ReqOrderInsert(&native, nRequestID);
}
///Ԥ��¼������
int CTPTraderAdapter::ReqParkedOrderInsert(ThostFtdcParkedOrderField^ pParkedOrder, int nRequestID)
{
	CThostFtdcParkedOrderField native;
	MNConv<ThostFtdcParkedOrderField^, CThostFtdcParkedOrderField>::M2N(pParkedOrder, &native);
	return m_pApi->ReqParkedOrderInsert(&native, nRequestID);
}
///Ԥ�񳷵�¼������
int CTPTraderAdapter::ReqParkedOrderAction(ThostFtdcParkedOrderActionField^ pParkedOrderAction, int nRequestID)
{
	CThostFtdcParkedOrderActionField native;
	MNConv<ThostFtdcParkedOrderActionField^, CThostFtdcParkedOrderActionField>::M2N(pParkedOrderAction, &native);
	return m_pApi->ReqParkedOrderAction(&native, nRequestID);
}
///������������
int CTPTraderAdapter::ReqOrderAction(ThostFtdcInputOrderActionField^ pInputOrderAction, int nRequestID)
{
	CThostFtdcInputOrderActionField native;
	MNConv<ThostFtdcInputOrderActionField^, CThostFtdcInputOrderActionField>::M2N(pInputOrderAction, &native);
	return m_pApi->ReqOrderAction(&native, nRequestID);
}
///��ѯ��󱨵���������
int CTPTraderAdapter::ReqQueryMaxOrderVolume(ThostFtdcQueryMaxOrderVolumeField^ pQueryMaxOrderVolume, int nRequestID)
{
	CThostFtdcQueryMaxOrderVolumeField native;
	MNConv<ThostFtdcQueryMaxOrderVolumeField^, CThostFtdcQueryMaxOrderVolumeField>::M2N(pQueryMaxOrderVolume, &native);
	return m_pApi->ReqQueryMaxOrderVolume(&native, nRequestID);
}
///Ͷ���߽�����ȷ��
int CTPTraderAdapter::ReqSettlementInfoConfirm(ThostFtdcSettlementInfoConfirmField^ pSettlementInfoConfirm, int nRequestID)
{
	CThostFtdcSettlementInfoConfirmField native;
	MNConv<ThostFtdcSettlementInfoConfirmField^, CThostFtdcSettlementInfoConfirmField>::M2N(pSettlementInfoConfirm, &native);
	return m_pApi->ReqSettlementInfoConfirm(&native, nRequestID);
}
///����ɾ��Ԥ��
int CTPTraderAdapter::ReqRemoveParkedOrder(ThostFtdcRemoveParkedOrderField^ pRemoveParkedOrder, int nRequestID)
{
	CThostFtdcRemoveParkedOrderField native;
	MNConv<ThostFtdcRemoveParkedOrderField^, CThostFtdcRemoveParkedOrderField>::M2N(pRemoveParkedOrder, &native);
	return m_pApi->ReqRemoveParkedOrder(&native, nRequestID);
}
///����ɾ��Ԥ�񳷵�
int CTPTraderAdapter::ReqRemoveParkedOrderAction(ThostFtdcRemoveParkedOrderActionField^ pRemoveParkedOrderAction, int nRequestID)
{
	CThostFtdcRemoveParkedOrderActionField native;
	MNConv<ThostFtdcRemoveParkedOrderActionField^, CThostFtdcRemoveParkedOrderActionField>::M2N(pRemoveParkedOrderAction, &native);
	return m_pApi->ReqRemoveParkedOrderAction(&native, nRequestID);
}
///�����ѯ����
int CTPTraderAdapter::ReqQryOrder(ThostFtdcQryOrderField^ pQryOrder, int nRequestID)
{
	CThostFtdcQryOrderField native;
	MNConv<ThostFtdcQryOrderField^, CThostFtdcQryOrderField>::M2N(pQryOrder, &native);
	return m_pApi->ReqQryOrder(&native, nRequestID);
}
///�����ѯ�ɽ�
int CTPTraderAdapter::ReqQryTrade(ThostFtdcQryTradeField^ pQryTrade, int nRequestID)
{
	CThostFtdcQryTradeField native;
	MNConv<ThostFtdcQryTradeField^, CThostFtdcQryTradeField>::M2N(pQryTrade, &native);
	return m_pApi->ReqQryTrade(&native, nRequestID);
}
///�����ѯͶ���ֲ߳�
int CTPTraderAdapter::ReqQryInvestorPosition(ThostFtdcQryInvestorPositionField^ pQryInvestorPosition, int nRequestID)
{
	CThostFtdcQryInvestorPositionField native;
	MNConv<ThostFtdcQryInvestorPositionField^, CThostFtdcQryInvestorPositionField>::M2N(pQryInvestorPosition, &native);
	return m_pApi->ReqQryInvestorPosition(&native, nRequestID);
}
///�����ѯ�ʽ��˻�
int CTPTraderAdapter::ReqQryTradingAccount(ThostFtdcQryTradingAccountField^ pQryTradingAccount, int nRequestID)
{
	CThostFtdcQryTradingAccountField native;
	MNConv<ThostFtdcQryTradingAccountField^, CThostFtdcQryTradingAccountField>::M2N(pQryTradingAccount, &native);
	return m_pApi->ReqQryTradingAccount(&native, nRequestID);
}
///�����ѯͶ����
int CTPTraderAdapter::ReqQryInvestor(ThostFtdcQryInvestorField^ pQryInvestor, int nRequestID)
{
	CThostFtdcQryInvestorField native;
	MNConv<ThostFtdcQryInvestorField^, CThostFtdcQryInvestorField>::M2N(pQryInvestor, &native);
	return m_pApi->ReqQryInvestor(&native, nRequestID);
}
///�����ѯ���ױ���
int CTPTraderAdapter::ReqQryTradingCode(ThostFtdcQryTradingCodeField^ pQryTradingCode, int nRequestID)
{
	CThostFtdcQryTradingCodeField native;
	MNConv<ThostFtdcQryTradingCodeField^, CThostFtdcQryTradingCodeField>::M2N(pQryTradingCode, &native);
	return m_pApi->ReqQryTradingCode(&native, nRequestID);
}
///�����ѯ��Լ��֤����
int CTPTraderAdapter::ReqQryInstrumentMarginRate(ThostFtdcQryInstrumentMarginRateField^ pQryInstrumentMarginRate, int nRequestID)
{
	CThostFtdcQryInstrumentMarginRateField native;
	MNConv<ThostFtdcQryInstrumentMarginRateField^, CThostFtdcQryInstrumentMarginRateField>::M2N(pQryInstrumentMarginRate, &native);
	return m_pApi->ReqQryInstrumentMarginRate(&native, nRequestID);
}
///�����ѯ��Լ��������
int CTPTraderAdapter::ReqQryInstrumentCommissionRate(ThostFtdcQryInstrumentCommissionRateField^ pQryInstrumentCommissionRate, int nRequestID)
{
	CThostFtdcQryInstrumentCommissionRateField native;
	MNConv<ThostFtdcQryInstrumentCommissionRateField^, CThostFtdcQryInstrumentCommissionRateField>::M2N(pQryInstrumentCommissionRate, &native);
	return m_pApi->ReqQryInstrumentCommissionRate(&native, nRequestID);
}
///�����ѯ������
int CTPTraderAdapter::ReqQryExchange(ThostFtdcQryExchangeField^ pQryExchange, int nRequestID)
{
	CThostFtdcQryExchangeField native;
	MNConv<ThostFtdcQryExchangeField^, CThostFtdcQryExchangeField>::M2N(pQryExchange, &native);
	return m_pApi->ReqQryExchange(&native, nRequestID);
}
///�����ѯ��Լ
int CTPTraderAdapter::ReqQryInstrument(ThostFtdcQryInstrumentField^ pQryInstrument, int nRequestID)
{
	CThostFtdcQryInstrumentField native;
	MNConv<ThostFtdcQryInstrumentField^, CThostFtdcQryInstrumentField>::M2N(pQryInstrument, &native);
	return m_pApi->ReqQryInstrument(&native, nRequestID);
}
///�����ѯ����
int CTPTraderAdapter::ReqQryDepthMarketData(ThostFtdcQryDepthMarketDataField^ pQryDepthMarketData, int nRequestID)
{
	CThostFtdcQryDepthMarketDataField native;
	MNConv<ThostFtdcQryDepthMarketDataField^, CThostFtdcQryDepthMarketDataField>::M2N(pQryDepthMarketData, &native);
	return m_pApi->ReqQryDepthMarketData(&native, nRequestID);
}
///�����ѯͶ���߽�����
int CTPTraderAdapter::ReqQrySettlementInfo(ThostFtdcQrySettlementInfoField^ pQrySettlementInfo, int nRequestID)
{
	CThostFtdcQrySettlementInfoField native;
	MNConv<ThostFtdcQrySettlementInfoField^, CThostFtdcQrySettlementInfoField>::M2N(pQrySettlementInfo, &native);
	return m_pApi->ReqQrySettlementInfo(&native, nRequestID);
}
///�����ѯת������
int CTPTraderAdapter::ReqQryTransferBank(ThostFtdcQryTransferBankField^ pQryTransferBank, int nRequestID)
{
	CThostFtdcQryTransferBankField native;
	MNConv<ThostFtdcQryTransferBankField^, CThostFtdcQryTransferBankField>::M2N(pQryTransferBank, &native);
	return m_pApi->ReqQryTransferBank(&native, nRequestID);
}
///�����ѯͶ���ֲ߳���ϸ
int CTPTraderAdapter::ReqQryInvestorPositionDetail(ThostFtdcQryInvestorPositionDetailField^ pQryInvestorPositionDetail, int nRequestID)
{
	CThostFtdcQryInvestorPositionDetailField native;
	MNConv<ThostFtdcQryInvestorPositionDetailField^, CThostFtdcQryInvestorPositionDetailField>::M2N(pQryInvestorPositionDetail, &native);
	return m_pApi->ReqQryInvestorPositionDetail(&native, nRequestID);
}
///�����ѯ�ͻ�֪ͨ
int CTPTraderAdapter::ReqQryNotice(ThostFtdcQryNoticeField^ pQryNotice, int nRequestID)
{
	CThostFtdcQryNoticeField native;
	MNConv<ThostFtdcQryNoticeField^, CThostFtdcQryNoticeField>::M2N(pQryNotice, &native);
	return m_pApi->ReqQryNotice(&native, nRequestID);
}
///�����ѯ������Ϣȷ��
int CTPTraderAdapter::ReqQrySettlementInfoConfirm(ThostFtdcQrySettlementInfoConfirmField^ pQrySettlementInfoConfirm, int nRequestID)
{
	CThostFtdcQrySettlementInfoConfirmField native;
	MNConv<ThostFtdcQrySettlementInfoConfirmField^, CThostFtdcQrySettlementInfoConfirmField>::M2N(pQrySettlementInfoConfirm, &native);
	return m_pApi->ReqQrySettlementInfoConfirm(&native, nRequestID);
}
///�����ѯͶ���ֲ߳���ϸ
int CTPTraderAdapter::ReqQryInvestorPositionCombineDetail(ThostFtdcQryInvestorPositionCombineDetailField^ pQryInvestorPositionCombineDetail, int nRequestID)
{
	CThostFtdcQryInvestorPositionCombineDetailField native;
	MNConv<ThostFtdcQryInvestorPositionCombineDetailField^, CThostFtdcQryInvestorPositionCombineDetailField>::M2N(pQryInvestorPositionCombineDetail, &native);
	return m_pApi->ReqQryInvestorPositionCombineDetail(&native, nRequestID);
}
///�����ѯ��֤����ϵͳ���͹�˾�ʽ��˻���Կ
int CTPTraderAdapter::ReqQryCFMMCTradingAccountKey(ThostFtdcQryCFMMCTradingAccountKeyField^ pQryCFMMCTradingAccountKey, int nRequestID)
{
	CThostFtdcQryCFMMCTradingAccountKeyField native;
	MNConv<ThostFtdcQryCFMMCTradingAccountKeyField^, CThostFtdcQryCFMMCTradingAccountKeyField>::M2N(pQryCFMMCTradingAccountKey, &native);
	return m_pApi->ReqQryCFMMCTradingAccountKey(&native, nRequestID);
}
///�����ѯ�ֵ��۵���Ϣ
int CTPTraderAdapter::ReqQryEWarrantOffset(ThostFtdcQryEWarrantOffsetField^ pQryEWarrantOffset, int nRequestID)
{
	CThostFtdcQryEWarrantOffsetField native;
	MNConv<ThostFtdcQryEWarrantOffsetField^, CThostFtdcQryEWarrantOffsetField>::M2N(pQryEWarrantOffset, &native);
	return m_pApi->ReqQryEWarrantOffset(&native, nRequestID);
}
///�����ѯת����ˮ
int CTPTraderAdapter::ReqQryTransferSerial(ThostFtdcQryTransferSerialField^ pQryTransferSerial, int nRequestID)
{
	CThostFtdcQryTransferSerialField native;
	MNConv<ThostFtdcQryTransferSerialField^, CThostFtdcQryTransferSerialField>::M2N(pQryTransferSerial, &native);
	return m_pApi->ReqQryTransferSerial(&native, nRequestID);
}
///�����ѯ����ǩԼ��ϵ
int CTPTraderAdapter::ReqQryAccountregister(ThostFtdcQryAccountregisterField^ pQryAccountregister, int nRequestID)
{
	CThostFtdcQryAccountregisterField native;
	MNConv<ThostFtdcQryAccountregisterField^, CThostFtdcQryAccountregisterField>::M2N(pQryAccountregister, &native);
	return m_pApi->ReqQryAccountregister(&native, nRequestID);
}
///�����ѯǩԼ����
int CTPTraderAdapter::ReqQryContractBank(ThostFtdcQryContractBankField^ pQryContractBank, int nRequestID)
{
	CThostFtdcQryContractBankField native;
	MNConv<ThostFtdcQryContractBankField^, CThostFtdcQryContractBankField>::M2N(pQryContractBank, &native);
	return m_pApi->ReqQryContractBank(&native, nRequestID);
}
///�����ѯԤ��
int CTPTraderAdapter::ReqQryParkedOrder(ThostFtdcQryParkedOrderField^ pQryParkedOrder, int nRequestID)
{
	CThostFtdcQryParkedOrderField native;
	MNConv<ThostFtdcQryParkedOrderField^, CThostFtdcQryParkedOrderField>::M2N(pQryParkedOrder, &native);
	return m_pApi->ReqQryParkedOrder(&native, nRequestID);
}
///�����ѯԤ�񳷵�
int CTPTraderAdapter::ReqQryParkedOrderAction(ThostFtdcQryParkedOrderActionField^ pQryParkedOrderAction, int nRequestID)
{
	CThostFtdcQryParkedOrderActionField native;
	MNConv<ThostFtdcQryParkedOrderActionField^, CThostFtdcQryParkedOrderActionField>::M2N(pQryParkedOrderAction, &native);
	return m_pApi->ReqQryParkedOrderAction(&native, nRequestID);
}
///�����ѯ����֪ͨ
int CTPTraderAdapter::ReqQryTradingNotice(ThostFtdcQryTradingNoticeField^ pQryTradingNotice, int nRequestID)
{
	CThostFtdcQryTradingNoticeField native;
	MNConv<ThostFtdcQryTradingNoticeField^, CThostFtdcQryTradingNoticeField>::M2N(pQryTradingNotice, &native);
	return m_pApi->ReqQryTradingNotice(&native, nRequestID);
}
///�����ѯ���͹�˾���ײ���
int CTPTraderAdapter::ReqQryBrokerTradingParams(ThostFtdcQryBrokerTradingParamsField^ pQryBrokerTradingParams, int nRequestID)
{
	CThostFtdcQryBrokerTradingParamsField native;
	MNConv<ThostFtdcQryBrokerTradingParamsField^, CThostFtdcQryBrokerTradingParamsField>::M2N(pQryBrokerTradingParams, &native);
	return m_pApi->ReqQryBrokerTradingParams(&native, nRequestID);
}
///�����ѯ���͹�˾�����㷨
int CTPTraderAdapter::ReqQryBrokerTradingAlgos(ThostFtdcQryBrokerTradingAlgosField^ pQryBrokerTradingAlgos, int nRequestID)
{
	CThostFtdcQryBrokerTradingAlgosField native;
	MNConv<ThostFtdcQryBrokerTradingAlgosField^, CThostFtdcQryBrokerTradingAlgosField>::M2N(pQryBrokerTradingAlgos, &native);
	return m_pApi->ReqQryBrokerTradingAlgos(&native, nRequestID);
}
///�ڻ����������ʽ�ת�ڻ�����
int CTPTraderAdapter::ReqFromBankToFutureByFuture(ThostFtdcReqTransferField^ pReqTransfer, int nRequestID)
{
	CThostFtdcReqTransferField native;
	MNConv<ThostFtdcReqTransferField^, CThostFtdcReqTransferField>::M2N(pReqTransfer, &native);
	return m_pApi->ReqFromBankToFutureByFuture(&native, nRequestID);
}
///�ڻ������ڻ��ʽ�ת��������
int CTPTraderAdapter::ReqFromFutureToBankByFuture(ThostFtdcReqTransferField^ pReqTransfer, int nRequestID)
{
	CThostFtdcReqTransferField native;
	MNConv<ThostFtdcReqTransferField^, CThostFtdcReqTransferField>::M2N(pReqTransfer, &native);
	return m_pApi->ReqFromFutureToBankByFuture(&native, nRequestID);
}
///�ڻ������ѯ�����������
int CTPTraderAdapter::ReqQueryBankAccountMoneyByFuture(ThostFtdcReqQueryAccountField^ pReqQueryAccount, int nRequestID)
{
	CThostFtdcReqQueryAccountField native;
	MNConv<ThostFtdcReqQueryAccountField^, CThostFtdcReqQueryAccountField>::M2N(pReqQueryAccount, &native);
	return m_pApi->ReqQueryBankAccountMoneyByFuture(&native, nRequestID);
}

} // end of namespace