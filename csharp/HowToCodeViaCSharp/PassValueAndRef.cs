//c#�еĲ������ݣ�ֵ���ݺ����ô���
using System;
namespace Miracle 
{
	public class Program 
	{
		static void Main()
	 {
	 	#region
	 	Point p1 = new Point(0,0);
	 	Console.WriteLine("Before call ChangePointValue:");
	 	Console.WriteLine(p1.ToString());
	 	ChangePointValue(p1);
	 	Console.WriteLine("After call ChangedPointValue:");
	 	Console.WriteLine(p1.ToString());
	 	Point p2 = new Point(0,0);
	 	Console.WriteLine("Before call ChangePointOut:");
	 	Console.WriteLine(p2.ToString());
	 	ChangePointOut(out p2);
	 	Console.WriteLine("After call ChangePointOut:");
	 	Console.WriteLine(p2.ToString());
	 	Console.WriteLine("Before call ChangePointRef:");
	 	Point pt3 = new Point(0,0);
	 	Console.WriteLine(pt3.ToString());
	 	ChangePointRef(ref pt3);
	 	Console.WriteLine("After call ChangePointRef:");
	 	Console.WriteLine(pt3.ToString());
	 	Console.WriteLine("---------------------------");
	 	Console.WriteLine("---------------------------");
	 	#endregion  
	 	#region 
	 	Person pp1 = new Person();
	 	Console.WriteLine("Before call ChangePersonValue");
	 	Console.WriteLine(pp1.ToString());
	 	Console.WriteLine("After call ChangePersonValue");
	 	ChangePersonValue(pp1);
	 	Console.WriteLine(pp1.ToString());
	 	Person pp2 = new Person();
	 	Console.WriteLine("Before call ChangePersonRef");
	 	Console.WriteLine(pp2.ToString());
	 	Console.WriteLine("After call ChangePersonRef");
	 	ChangePersonRef(ref pp2);
	 	Console.WriteLine(pp2.ToString());
	 	
	 	Person pp3 = new Person();
	 	Console.WriteLine("Before call ChangePersonOut:");
	 	Console.WriteLine(pp3.ToString());
	 	Console.WriteLine("After call ChangePersonOut:");
	 	ChangePersonOut(out pp3);
	 	Console.WriteLine(pp3.ToString());
	 	#endregion
	 	Console.WriteLine("press any key to exit...");  
	 	Console.ReadKey();
	 }
	 //��ֵ����ֵ����
	 static void ChangePointValue(Point p)
	 {
	 	p.X = 100;
	 	p.Y = 100;
	 } 
	 //�����ô���ֵ����
	 static void ChangePointOut(out Point p) 
	 {
	 	 p = new Point(0,0);
	 	p.X= 10;
	 	p.Y= 10;
	 }
	 //�����ô���ֵ����
	 static void ChangePointRef(ref Point p)
	 {
	 	 p = new Point(20,20);
	 	// p.X= 20;
	 	 //p.Y= 20;
	 }  
	 //��ֵ������������
	 static void ChangePersonValue(Person p) 
	 {
	 	 p.Name = "ChangePersonValue";
	 	 p.Age = 18;
	 	 p.Birthday = DateTime.Now; 
	 	 //�������ʹ�ֵʱ����ǰ���ñ���ָ������������Ч
	 	p = new Person("ChangeValue",0,DateTime.Now);
	 }
	 static void ChangePersonOut(out Person p)
	 {
	 	p = new Person();
	 	p.Name = "ChangePersonOut";
	 	p.Age = 18;
	 	p.Birthday = DateTime.Now;
	 }
	 static void ChangePersonRef(ref Person p) 
	 {
	 	p.Name = "ChangepersonRef";
	 	p.Age = 18;
	 	p.Birthday =DateTime.Now;  
	 	//�����������ô���ʱ�������ñ���ָ������������Ч
	 	p = new Person("YuHuanLong",18,DateTime.Now);
	 }
	}
	
	//ֵ���ͣ�
	public struct Point
	{
		Int32 m_x;
		Int32 m_y;
		public Int32 X 
		{
			get {return this.m_x;}
			set { this.m_x = value;}
		}
		public Int32 Y 
		{
			get { return this.m_y;}
			set { this.m_y = value;}
		}
		/*�ṹ���ܰ�����ʾ���޲ι��캯��
		public Point()
		{
			this.m_x = 0;
			this.m_y = 0;
		}
		*/
		public Point(Int32 x,Int32 y) 
		{
			this.m_x = x;
			this.m_y = y;
		}
	  public  override String ToString()
	  {
	  	 return String.Format("The location is ({0},{1}).",this.X,this.Y);
	  }
	  public void Change()
	  {
	  	this.X = 1000000;
	  	this.Y = 1000000;
	  }
	}
	//�����ͣ�
	public class Person 
	{
	 
	  private String m_Name;
	  private Int32  m_Age;
	  private DateTime m_Birthday;
	  public String Name 
	  {
	  	get {return m_Name;}
	  	set { this.m_Name = value;}
	  }
	  public Int32 Age
	  {
	  	get {return this.m_Age;}
	  	set {this.m_Age = value;}
	  }
	  public DateTime Birthday 
	  {
	  	get { return this.m_Birthday;}
	  	set { this.m_Birthday = value;}
	  }
	  public Person() 
	  {
	  	
	  	this.m_Name = String.Empty;
	  	this.m_Age = 0;
	  	this.m_Birthday = DateTime.Now;
	  }
	  public Person(String name,Int32 age,DateTime date)
	  {
	  	this.m_Name= name;
	  	this.m_Age= age;
	  	this.m_Birthday = date;
	  }
	  public override String ToString()
	  {
	  	return String.Format("Hello,My Name is {0},I was born in {2},I'm {1} years old Now.",this.Name,this.Age,this.Birthday);
	  }
	  public void Change()
	  {
	  	this.Name = "YuHuanLong";
	  	this.Age = 188;
	  	this.Birthday = DateTime.Now;
	  }
	 

	}
}