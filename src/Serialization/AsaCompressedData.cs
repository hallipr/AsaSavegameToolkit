namespace AsaSavegameToolkit.Serialization
{
    public static class AsaCompressedData
    {
        public static byte[] Inflate(ReadOnlySpan<byte> inputBuffer)
        {
            int currentPos = 0;
            using var outputStream = new MemoryStream();

            while (currentPos < inputBuffer.Length)
            {
                byte next = inputBuffer[currentPos];

                switch (next)
                {
                    case 0xF0: // escape
                        currentPos++;
                        if (currentPos < inputBuffer.Length)
                        {
                            outputStream.WriteByte(inputBuffer[currentPos]);
                        }
                        break;

                    case 0xF1: // switch
                        currentPos++;
                        if (currentPos < inputBuffer.Length)
                        {
                            next = inputBuffer[currentPos];
                            int returnValue = 0xF0 | ((next & 0xF0) >> 4);
                            outputStream.WriteByte((byte)returnValue);
                            outputStream.WriteByte((byte)(0xF0 | (next & 0x0F)));
                        }
                        break;

                    case >= 0xF2 and < 0xFF: // expand 0's
                        int byteCount = next & 0x0F;
                        outputStream.Write(new byte[byteCount]);
                        break;

                    case 0xFF: // expand
                        currentPos++;
                        if (currentPos < inputBuffer.Length)
                        {
                            byte b1 = inputBuffer[currentPos];
                            currentPos++;
                            if (currentPos < inputBuffer.Length)
                            {
                                byte b2 = inputBuffer[currentPos];
                                outputStream.WriteByte(0);
                                outputStream.WriteByte(0);
                                outputStream.WriteByte(0);
                                outputStream.WriteByte(b1);
                                outputStream.WriteByte(0);
                                outputStream.WriteByte(0);
                                outputStream.WriteByte(0);
                                outputStream.WriteByte(b2);
                                outputStream.WriteByte(0);
                                outputStream.WriteByte(0);
                                outputStream.WriteByte(0);
                            }
                        }
                        break;

                    default:
                        outputStream.WriteByte(next);
                        break;
                }
                currentPos++;
            }

            outputStream.Flush();
            return outputStream.ToArray();
        }
    }
}
