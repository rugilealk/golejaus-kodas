# Golejaus_kodas

An implementation of the binary Golay code (23, 12) which is capable to correct three bit errors. The implementation is programmed in C# and has a 
Windows Forms graphical user interface.

1) The user writes a vector of the length 12 made of binary elements. The program checks whether the vector format is correct, 
encodes it with the Golay code, displays the encoded vector, sends it through the channel, displays the vector that has left the 
channel, reports how many and in which positions errors occurred, decodes the received vector and displays the result. The 
user can also edit the vector that has left the channel before decoding and add more/less errors.

2) The user writes text (the text can consist of several lines). The program splits and converts the given text into binary vectors of the
required length. Then: 
- Each vector is sent to the channel without using a code, the program then reproduces the text from the received vectors and displays it.
- Each vector is encoded, sent via a channel, decoded. Text is reproduced from the received vectors and displayed.

3) The user specifies a picture (bmp 24-bit format). The program opens it and displays it. Then it splits/converts the given picture into
binary vectors of the required length. Then: 
- Each vector is sent via a channel without using a code, a picture is reproduced from the received vectors and displayed.
- Each vector is encoded, sent via a channel, decoded. A picture is reproduced from the received vectors and displayed.
