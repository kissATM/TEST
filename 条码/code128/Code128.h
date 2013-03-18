// Code128.h: interface for the CCode128 class.
//
//////////////////////////////////////////////////////////////////////
//
//               深圳柯迅电脑科技有限公司 
//
//                 code128条码编码演示
//
//				  http://www.koxen.com
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_CODE128_H__413033F9_51A6_49BF_8DDD_6FDF963D02BD__INCLUDED_)
#define AFX_CODE128_H__413033F9_51A6_49BF_8DDD_6FDF963D02BD__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

class CCode128  
{
public:
	/////just like   DrawCode128Ex(400,400,4,90,"/104/96/25/17/",pDC);
	//// In_String  must have \104 to select the barcode type
	/////           auto calc check-CODE and  end-CODE
	CString CalcBarcodeModel_C(CString m_inString);
	CString CalcBarcodeModel_B(CString m_inString);
	CString CalcBarcodeModel_A(CString m_inString);
	CString code[107];
	void Draw_Code_128(int posx, int posy,int pen_Width,int line_high,CString In_String,CString type,int position,CDC *pDC);
	CCode128();
	virtual ~CCode128();
};



#endif // !defined(AFX_CODE128_H__413033F9_51A6_49BF_8DDD_6FDF963D02BD__INCLUDED_)
