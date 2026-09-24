namespace PBEncDec.src.core;

internal class Crypt
{
	public static void decrypt(byte[] data, int shift)
	{
		byte b = data[data.Length - 1];
		for (int num = data.Length - 1; num > 0; num--)
		{
			data[num] = (byte)((data[num - 1] << 8 - shift) | (data[num] >> shift));
		}
		data[0] = (byte)((b << 8 - shift) | (data[0] >> shift));
	}

	public static void encrypt(byte[] data, byte shift)
	{
		byte b = data[data.Length - 1];
		for (int num = data.Length - 1; num > 0; num--)
		{
			data[num] = (byte)((data[num - 1] << 8 - shift) | (data[num] >> (int)shift));
		}
		data[0] = (byte)((b << 8 - shift) | (data[0] >> (int)shift));
		byte[] array = new byte[data.Length];
		for (int num = 0; num < data.Length - 1; num++)
		{
			array[num] = data[num + 1];
		}
		array[data.Length - 1] = data[0];
		array.CopyTo(data, 0);
	}

	public static void decrypt2(byte[] data, int length, int shift)
	{
		byte b = (byte)length;
		byte b2 = (byte)shift;
		int num = length - 1;
		int num2 = 8 - shift;
		byte b3 = data[length - 1];
		while (num >= 0)
		{
			byte b4 = ((num > 0) ? data[num - 1] : b3);
			b = (byte)((b4 << num2) | (data[num--] >> (int)b2));
			data[num + 1] = b;
		}
	}

	public static void encrypt2(byte[] data, int length, int shift)
	{
		byte b = data[0];
		int num = 8 - shift;
		int num2 = 0;
		int num3 = 8 - shift;
		if (length <= 0)
		{
			return;
		}
		while (true)
		{
			bool flag = true;
			int num4 = ((num2 >= length - 1) ? b : data[num2 + 1]);
			int num5 = data[num2++] << shift;
			data[num2 - 1] = (byte)(num5 | (num4 >> num));
			if (num2 >= length)
			{
				break;
			}
			int num6 = (ushort)num & 0xFF;
			int num7 = (ushort)num >> 8;
			num = (num3 & 0xFF) | ((num7 & 0xFF) << 8);
		}
	}
}
