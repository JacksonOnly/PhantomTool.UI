using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

public class Class_55
{
	public delegate Class_56 Delegate_02(string arg_01);

	private readonly object field_412;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Delegate_02 field_413;

	public Delegate_02 property_12
	{
		[CompilerGenerated]
		get
		{
			return field_413;
		}
		[CompilerGenerated]
		private set
		{
			field_413 = value;
		}
	}

	public Class_55(Enum_06 arg_01, string arg_02)
	{
		switch (arg_01)
		{
		case Enum_06.field_409:
			field_412 = method_406(arg_02);
			property_12 = method_407;
			break;
		case Enum_06.field_410:
			field_412 = method_408(arg_02);
			property_12 = method_410;
			break;
		case Enum_06.field_411:
			field_412 = method_411(arg_02);
			property_12 = method_412;
			break;
		default:
			throw new ArgumentException("Unknown StringMatchingMethod value");
		}
	}

	private static object method_406(string arg_01)
	{
		return arg_01.ToLower();
	}

	private Class_56 method_407(string arg_01)
	{
		string text = (string)field_412;
		string text2 = arg_01.ToLower();
		List<string> list = new List<string>();
		int i = 0;
		int length = text.Length;
		int length2 = arg_01.Length;
		bool arg_2 = false;
		bool flag = false;
		for (int j = 0; j < length; j++)
		{
			int num = i;
			for (; i < length2; i++)
			{
				if (text2[i] == text[j])
				{
					flag = j == length - 1;
					if (num != i)
					{
						int length3 = i - num;
						int startIndex = num;
						list.Add(arg_01.Substring(startIndex, length3));
						list.Add(arg_01.Substring(i, 1));
					}
					else if (list.Count == 0)
					{
						list.Add(arg_01.Substring(i, 1));
						arg_2 = true;
					}
					else
					{
						List<string> list2 = list;
						int index = list.Count - 1;
						string text3 = list2[index];
						string text4 = arg_01[i].ToString();
						list2[index] = text3 + text4;
					}
					i++;
					break;
				}
			}
			if (i >= length2)
			{
				break;
			}
		}
		if (!flag)
		{
			return null;
		}
		if (i < length2)
		{
			int num2 = i;
			int length4 = length2 - i;
			int startIndex2 = num2;
			list.Add(arg_01.Substring(startIndex2, length4));
		}
		return new Class_56
		{
			property_13 = arg_01,
			property_14 = list,
			property_15 = arg_2
		};
	}

	private static object method_408(string arg_01)
	{
		StringBuilder stringBuilder = new StringBuilder(arg_01.StartsWith("*") ? "" : "*");
		int length = arg_01.Length;
		for (int i = 0; i < length; i++)
		{
			char c = arg_01[i];
			if (c == '*')
			{
				for (; i < length && arg_01[i] == '*'; i++)
				{
				}
				stringBuilder.Append('*');
				if (i < length)
				{
					char value = arg_01[i];
					stringBuilder.Append(value);
				}
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString().ToLower();
	}

	private static void method_409(Class_56 arg_01, string arg_02, bool arg_03)
	{
		if (arg_01.property_14.Count == 0)
		{
			arg_01.property_15 = arg_03;
			arg_01.property_14.Add(arg_02);
			return;
		}
		bool flag = arg_01.property_14.Count % 2 != 0 == arg_01.property_15;
		if (flag == arg_03)
		{
			arg_01.property_14[arg_01.property_14.Count - 1] = arg_01.property_14[arg_01.property_14.Count - 1] + arg_02;
		}
		else
		{
			arg_01.property_14.Add(arg_02);
		}
	}

	private Class_56 method_410(string arg_01)
	{
		Class_56 class_ = new Class_56
		{
			property_13 = arg_01,
			property_14 = new List<string>(),
			property_15 = false
		};
		string text = (string)field_412;
		string text2 = arg_01.ToLower();
		int i = 0;
		int num = 0;
		int num2 = -1;
		int num3 = -1;
		int num4 = -1;
		int num5 = -1;
		int length = text.Length;
		int length2 = arg_01.Length;
		for (; i != length; i++)
		{
			if (num == length2)
			{
				break;
			}
			if (text[i] == '*')
			{
				break;
			}
			if (text2[num] != text[i])
			{
				return null;
			}
			num++;
		}
		if (num != 0)
		{
			method_409(class_, arg_01.Substring(0, num), arg_03: true);
		}
		if (i != length)
		{
			while (num != length2)
			{
				if (text[i] == '*')
				{
					i++;
					if (i == length)
					{
						break;
					}
					if (num2 != i)
					{
						if (num2 >= 0)
						{
							if (num4 != num5)
							{
								int num6 = num4;
								int length3 = num5 - num4;
								int startIndex = num6;
								method_409(class_, arg_01.Substring(startIndex, length3), arg_03: false);
							}
							if (num5 != num)
							{
								int num7 = num5;
								int length4 = num - num5;
								int startIndex2 = num7;
								method_409(class_, arg_01.Substring(startIndex2, length4), arg_03: true);
							}
						}
						num4 = num;
						num5 = -1;
					}
					num2 = i;
					num3 = num + 1;
				}
				else if (text2[num] == text[i])
				{
					if (num5 == -1)
					{
						num5 = num;
					}
					num++;
					i++;
				}
				else
				{
					i = num2;
					num = num3++;
				}
				if (i == length)
				{
					break;
				}
			}
			for (; i != length && text[i] == '*'; i++)
			{
			}
		}
		if (i == length)
		{
			if (num2 != i && num4 != -1)
			{
				if (num5 == -1)
				{
					int num8 = num4;
					int length5 = num - num4;
					int startIndex3 = num8;
					method_409(class_, arg_01.Substring(startIndex3, length5), arg_03: false);
				}
				else
				{
					if (num5 != num4)
					{
						int num9 = num4;
						int length6 = num5 - num4;
						int startIndex4 = num9;
						method_409(class_, arg_01.Substring(startIndex4, length6), arg_03: false);
					}
					if (num5 != num)
					{
						int num10 = num5;
						int length7 = num - num5;
						int startIndex5 = num10;
						method_409(class_, arg_01.Substring(startIndex5, length7), arg_03: true);
					}
				}
			}
			if (num != length2)
			{
				int num11 = num;
				int length8 = length2 - num;
				int startIndex6 = num11;
				method_409(class_, arg_01.Substring(startIndex6, length8), arg_03: false);
			}
			return class_;
		}
		return null;
	}

	private static object method_411(string arg_01)
	{
		try
		{
			return new Regex(arg_01, RegexOptions.IgnoreCase);
		}
		catch
		{
		}
		return null;
	}

	private Class_56 method_412(string arg_01)
	{
		if (field_412 == null)
		{
			return null;
		}
		Regex regex = (Regex)field_412;
		List<string> list = new List<string>();
		bool arg_2 = false;
		bool flag = false;
		int num = 0;
		Match match = regex.Match(arg_01, 0);
		if (match.Success)
		{
			flag = true;
			if (match.Index == 0)
			{
				if (match.Index == 0)
				{
					arg_2 = true;
				}
				int index = match.Index;
				int length = match.Length;
				int startIndex = index;
				list.Add(arg_01.Substring(startIndex, length));
			}
			else
			{
				int num2 = num;
				int length2 = match.Index - num;
				int startIndex2 = num2;
				list.Add(arg_01.Substring(startIndex2, length2));
				int index2 = match.Index;
				int length3 = match.Length;
				int startIndex3 = index2;
				list.Add(arg_01.Substring(startIndex3, length3));
			}
			num = match.Index + match.Length;
		}
		if (!flag)
		{
			return null;
		}
		if (num < arg_01.Length)
		{
			int num3 = num;
			int length4 = arg_01.Length - num;
			int startIndex4 = num3;
			list.Add(arg_01.Substring(startIndex4, length4));
		}
		return new Class_56
		{
			property_13 = arg_01,
			property_14 = list,
			property_15 = arg_2
		};
	}
}
