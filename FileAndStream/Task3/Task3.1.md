# Issue in the code 
1. memoryStream.ToArray() creates a new byte array, doubling memory usage.<br>
2. The writeBuffer array duplicates the data in MemoryStream.<br>
3. Reading one character at a time from the buffer in a loop is inefficient.<br>
4. new FileStream(path, FileMode.Open) locks the file for other processes.

# Modification

1. Instead of ToArray(), write directly to FileStream using memoryStream.WriteTo(fileStream).<br>
2. Removed writeBuffer and wrote MemoryStream content directly to FileStream.<br>
3. Use Encoding.UTF8.GetString(buffer, 0, bytesRead) to convert the buffer in one step.<br>
4. Use FileAccess.Read and FileShare.Read to allow multiple reads.

# Explaination about fixed issue

1. Creating another byte array of data when using memoryStream.ToArray().This will double the size of memory usage.It can be resolved by using the memoryStream.WriteTo(fileStream) which directly write to the fileStream
2. Reading one character at a time takes more time to read the entire data.To overcome this inefficiency , used Encoding.UTF8.GetString(buffer, 0, bytesRead) to convert the buffer in one step.
3. While reading the file ,it is in the Open mode which block other user to read or perform other operations until the file is closed.For this issue ,Only to read the file,open file in read mode which allows other user to perform operations simultaneously.