// Code128.cpp: implementation of the CCode128 class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "Code128.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CCode128::CCode128()
{
code[0]="212222";/// 0      space
code[1]="222122";///1
code[2]="222221";///2
code[3]="121223";///3
code[4]="121322";///4
code[5]="131222";///5
code[6]="122213";///6
code[7]="122312";///7
code[8]="132212";////8
code[9]="221213";///9
code[10]="221312";///10
code[11]="231212";////11
code[12]="112232"; ///12        -
code[13]="122132"; ///13
code[14]="122231"; ///14
code[15]="113222";///15         /
code[16]="123122";
code[17]="123221";
code[18]="223211";
code[19]="221132";
code[20]="221231"; ////20  4
code[21]="213212";
code[22]="223112";
code[23]="312131";
code[24]="311222";
code[25]="321122";
code[26]="321221"; ////26 
code[27]="312212";
code[28]="322112";
code[29]="322211";
code[30]="212123";  /////30
code[31]="212321";
code[32]="232121";
code[33]="111323";
code[34]="131123";
code[35]="131321";
code[36]="112313";
code[37]="132113";
code[38]="132311"; ////38  F
code[39]="211313";
code[40]="231113";
code[41]="231311";
code[42]="112133";
code[43]="112331";
code[44]="132131";  /////45
code[45]="113123";
code[46]="113321";
code[47]="133121";
code[48]="313121";
code[49]="211331";
code[50]="231131";
code[51]="213113";
code[52]="213311";
code[53]="213131";
code[54]="311123";
code[55]="311321";
code[56]="331121";
code[57]="312113";
code[58]="312311"; ////58 Z
code[59]="332111";
code[60]="314111";
code[61]="221411";
code[62]="431111";
code[63]="111224";
code[64]="111422";
code[65]="121124";
code[66]="121421";
code[67]="141122";
code[68]="141221";
code[69]="112214";
code[70]="112412";
code[71]="122114";
code[72]="122411";
code[73]="142112";
code[74]="142211";
code[75]="241211";
code[76]="221114";
code[77]="413111";
code[78]="241112";
code[79]="134111";
code[80]="111242";
code[81]="121142";
code[82]="121241";
code[83]="114212";
code[84]="124112";
code[85]="124211";
code[86]="411212"; /////86  	SYN  v
code[87]="421112";
code[88]="421211";
code[89]="212141";
code[90]="214121";
code[91]="412121";
code[92]="111143";
code[93]="111341";
code[94]="131141";
code[95]="114113";
code[96]="114311";///////FNC3   FNC3 96
code[97]="411113";   ////FNC2  FNC2  97
code[98]="411311";  ////SHIFT  SHIFT 98
code[99]="113141";  /////CODEC CODEC 99
code[100]="114131";  /////CODEB FNC4  CODEB 100 
code[101]="311141";  ////FNC4  CODEA  CODEA  101 
code[102]="411131";  ////FNC1  102 
code[103]="211412"; /////start_a  103 
code[104]="211214"; ///start_b    104 
code[105]="211232";////start_c  105
code[106]="2331112"; /////end barcode  106
}

CCode128::~CCode128()
{

}

void CCode128::Draw_Code_128(int posx, int posy, int pen_Width, int line_high, CString In_String, CString type,int position,CDC *pDC)
{					/////////x 位置     y位置      画笔宽度      条码高度        条码字符值        条码类型      识别字符位置			
	CPen pen_black;																//eg."123wed"		//CODE128A	 0: 不显示  				
	CPen pen_white;																					//CODE128B	 1: 左侧		
																									//CODE128C	
	int n,m,length,abc;
  //  int posx,posy;
	COLORREF m_color;
	CString lines,barModel;

//		pDC->SetMapMode(MM_TWIPS|MM_ISOTROPIC);

//////////        
		BOOL pen=TRUE;
	    m_color=0;
	    pen_black.CreatePen(PS_SOLID,pen_Width,m_color);
	    m_color=0x00ffffff;
	    pen_white.CreatePen(PS_SOLID,pen_Width,m_color);
/////////////////
	   if (type=="CODE128A")
	       barModel=CalcBarcodeModel_A(In_String);
	   else if ( (type=="CODE128B") || type=="" )
		   barModel=CalcBarcodeModel_B(In_String);
       else if (type=="CODE128C")
			barModel=CalcBarcodeModel_C(In_String);
	   else AfxMessageBox("不支持条码类型");
////////////////////
	   abc=0;
	   length=barModel.GetLength();
	   for(m=0;m<length;m++)
	   {
		   lines=barModel.GetAt(m);
  		    if (pen)
			{
		     pDC->SelectObject(&pen_black);
		     pen=FALSE;
 			}
		    else
			{
            pDC->SelectObject(&pen_white);
		    pen=TRUE;
			}

		   int theline = atoi(lines);
		   for (n=0;n<theline;n++)
		   {

		     pDC->MoveTo((posx+abc*pen_Width),posy);
    	     pDC->LineTo((posx+abc*pen_Width),posy+line_high);
		     abc+=1;
		   } /////for n end 
	   } /////for m end 
//////////////////
	  switch(position)
	  {
	  case 1:
		  {
			  pDC->TextOut(posx+10,posy+line_high+10,In_String);
			  break;
		  }
	  case 2:
		  {
			 // pDC->TextOut(posx,posy,In_string);
			//  break;
		  }
	  case 3:
		  {
			//  pDC->TextOut(posx,posy,In_string);
			 // break;
		  }
	  default:
		  break;
	  }

 
    pen_black.DeleteObject();
     pen_white.DeleteObject();
}

CString CCode128::CalcBarcodeModel_A(CString m_inString)
{
CString BarcodeModel;
int length,i,data[50],check;
char nchar;

BarcodeModel="211412";
data[0]=103;

////ASCII 0--31  + 64     32-95  -32  
length=m_inString.GetLength();
for (i=0;i<length;i++)
{
 nchar=m_inString.GetAt(i);

 if (nchar>=32  && nchar<=95)
	 data[i+1]=nchar-32;
 else if (nchar>=0 && nchar<=31)
	 data[i+1]=nchar+64;

 BarcodeModel+=code[nchar-32];
}
//////计算校验码。
check=data[0];
for (i=1;i<length+1;i++)
 check+=data[i]*i;
check=check%103;
BarcodeModel+=code[check];
////条码结束：
BarcodeModel+="2331112";
  return BarcodeModel;

 return BarcodeModel;
}

CString CCode128::CalcBarcodeModel_B(CString m_inString)
{
CString BarcodeModel;
///eg barcodemodel="212222   .....    2331112";
///首先取得字符，计算数据，再去数据的对应编码。
////B字符集开始：
int length,i,data[50],check;
char nchar;

BarcodeModel="211214";
data[0]=104;

length=m_inString.GetLength();
for (i=0;i<length;i++)
{
 nchar=m_inString.GetAt(i);

 data[i+1]=nchar-32;
 BarcodeModel+=code[nchar-32];

}
//////计算校验码。
check=data[0];
for (i=1;i<length+1;i++)
 check+=data[i]*i;

check=check%103;

BarcodeModel+=code[check];
////条码结束：
BarcodeModel+="2331112";
  return BarcodeModel;
}

CString CCode128::CalcBarcodeModel_C(CString m_inString)
{
CString BarcodeModel;


int length,i,data[50],check,n;
CString nchar;

BarcodeModel="211232";
data[0]=105;
n=1;
length=m_inString.GetLength();
for (i=0;i<length;i++)
{
 nchar=m_inString.GetAt(i);
 i++;
 nchar+=m_inString.GetAt(i);
 
 data[n]=atoi(nchar);
 BarcodeModel+=code[data[n]];
 n++;

nchar="";
}

//////计算校验码。
check=data[0];
for (i=1;i<n;i++)
 check+=data[i]*i;

check=check%103;

BarcodeModel+=code[check];
////条码结束：
BarcodeModel+="2331112";
 return BarcodeModel;
}


