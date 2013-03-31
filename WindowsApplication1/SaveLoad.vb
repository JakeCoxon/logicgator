Module SaveLoad


    ' Unsigned byte: 0 to 255
    ' Unsigned char: 0 to 255
    ' Unsigned short (2 bytes): 0 to 65,535

    ' Bytes are unsigned by default
    ' Shorts are signed by default, use UShort

    ' If a control is deleted in the file, it should still work provided
    ' there are no links to it

    ' File looks like this
    ' <Char><Char><Char><UShort><UShort>              L, G, F, Number of gates, Number of links
    ' Gates:
    '   <UShort><Byte><Byte><Bool><UShort><UShort>    ID, ControlType, GateType, Value, X, Y
    ' Links:
    '   <UShort><UShort><Byte>                        ID1, ID2, Input number

    Private Structure ControlStructure
        Public ID As UShort
        Public ControlType As Byte ' 1 for Input, 2 for Gate, 3 for Output
        Public GateType As Byte
        Public Value As Boolean
        Public X As UShort
        Public Y As UShort
    End Structure
    Private Structure LinkStructure
        Public ID1 As UShort ' left gate
        Public ID2 As UShort ' right gate
        Public Num As Byte   ' Is it joined to C1 (1) or C2 (2)
    End Structure

    Private Sub WriteControlStructure(ByVal save As IO.BinaryWriter, ByVal struct As ControlStructure)
        save.Write(CUShort(struct.ID))
        save.Write(CByte(struct.ControlType))
        save.Write(CByte(struct.GateType))
        save.Write(CBool(struct.Value))
        save.Write(CUShort(struct.X))
        save.Write(CUShort(struct.Y))
    End Sub

    Private Function ReadControlStructure(ByVal load As IO.BinaryReader) As ControlStructure
        Dim struct As ControlStructure
        struct.ID = load.ReadUInt16()
        struct.ControlType = load.ReadByte()
        If struct.ControlType < 1 Or struct.ControlType > 3 Then
            Throw New Exception("Invalid control type")
        End If
        struct.GateType = load.ReadByte()
        struct.Value = load.ReadBoolean()
        struct.X = load.ReadUInt16()
        struct.Y = load.ReadUInt16()
        Return struct
    End Function

    Private Sub WriteLinkStructure(ByVal save As IO.BinaryWriter, ByVal struct As LinkStructure)
        save.Write(CUShort(struct.ID1))
        save.Write(CUShort(struct.ID2))
        save.Write(CByte(struct.Num))
    End Sub
    Private Function ReadLinkStructure(ByVal load As IO.BinaryReader) As LinkStructure
        Dim struct As LinkStructure
        struct.ID1 = load.ReadUInt16()
        struct.ID2 = load.ReadUInt16()
        struct.Num = load.ReadByte()
        If struct.Num <> 1 And struct.Num <> 2 Then
            Throw New Exception("Invalid Link-Number type")
        End If
        Return struct
    End Function

    Private Sub WriteControl(ByVal save As IO.BinaryWriter, ByVal ControlType As Integer, ByVal control As DragControl)
        Dim struct As ControlStructure

        struct.ID = control.SaveID
        struct.ControlType = ControlType
        struct.GateType = control.Type
        struct.Value = control.Value
        struct.X = Math.Abs(control.Left)
        struct.Y = Math.Abs(control.Top)

        WriteControlStructure(save, struct)
    End Sub


    Public Sub Save(ByVal File As SaveFileDialog)

        Dim fs As IO.Stream = File.OpenFile()

        Dim save As New IO.BinaryWriter(fs)

        ' Write 3 magic numbers 4C 47 46 to assert that this is a LogicGator File
        save.Write(CChar("L"))
        save.Write(CChar("G"))
        save.Write(CChar("F"))

        Dim links As New List(Of Link)

        ' Todo: perhaps write number of inputs, gates and outputs seperately?
        Dim count As Integer = Main.InputsList.Count + Main.GatesList.Count + Main.OutputsList.Count

        ' Insert links for inputs
        For Each control As InputControl In Main.InputsList
            For Each l As LinkFinish In control.Outputs
                Dim link As New Link()
                link.Start = control
                link.Finish = l
                links.Add(link)
            Next
        Next

        ' Insert links for gates
        For Each control As GateControl In Main.GatesList
            For Each l As LinkFinish In control.Outputs
                Dim link As New Link()
                link.Start = control
                link.Finish = l
                links.Add(link)
            Next
        Next


        ' Write the number of gates and the number of links
        save.Write(CUShort(count))
        save.Write(CUShort(links.Count))

        Dim index As Integer = 0

        ' Loop through each gate and write them to the file
        For Each control As InputControl In Main.InputsList
            control.SaveID = index
            WriteControl(save, 1, control)
            index += 1
        Next

        For Each control As GateControl In Main.GatesList
            control.SaveID = index
            WriteControl(save, 2, control)
            index += 1
        Next

        For Each control As OutputControl In Main.OutputsList
            control.SaveID = index
            WriteControl(save, 3, control)
            index += 1
        Next

        ' Write each link to the file
        For Each link As Link In links
            Dim control1 As DragControl = link.Start
            Dim control2 As DragControl = link.Finish.Control

            Dim struct As LinkStructure

            struct.ID1 = control1.SaveID
            struct.ID2 = control2.SaveID

            If link.Finish.Type = LinkFinishType.Input1 Then
                struct.Num = 1
            ElseIf link.Finish.Type = LinkFinishType.Input2 Then
                struct.Num = 2
            Else
                Throw New Exception("Invalid Input number")
            End If

            WriteLinkStructure(save, struct)

        Next

        save.Close()

    End Sub
    Public Sub Load(ByVal File As OpenFileDialog)
        ' Open the file from the file dialog
        Dim fs As IO.Stream = File.OpenFile()
        Dim load As New IO.BinaryReader(fs)

        ' Read three magic numbers and test them against LGF
        Dim magic As Char() = load.ReadChars(3)
        If Not (magic(0) = "L" And magic(1) = "G" And magic(2) = "F") Then
            MsgBox("This is not a valid LogicGator File", MsgBoxStyle.Critical)
            Return
        End If

        ' Read the number of controls and links
        Dim controlcount As UShort = load.ReadUInt16()
        Dim linkcount As UShort = load.ReadUInt16()

        ' Create a list of structures for the controls and links
        ' No actual controls are created yet
        Dim controls As New List(Of ControlStructure)
        Dim links As New List(Of LinkStructure)

        ' Read the structures
        Try
            For I = 0 To controlcount - 1
                Dim struct As ControlStructure = ReadControlStructure(load)
                controls.Add(struct)
            Next
        Catch ex As Exception
            load.Close()
            MsgBox("Couldn't read file. Perhaps the file is corrupt." & vbNewLine & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        ' Read the links
        Try
            For I = 0 To linkcount - 1
                Dim struct As LinkStructure = ReadLinkStructure(load)
                links.Add(struct)
            Next
        Catch ex As Exception
            load.Close()
            MsgBox("Couldn't read file. Perhaps the file is corrupt." & vbNewLine & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        load.Close()


        CreateFromList(controls, links)

    End Sub

    Private Sub CreateFromList(ByVal controls As List(Of ControlStructure), ByVal links As List(Of LinkStructure))

        Main.CreateNew()

        Dim NumberedControls As New List(Of DragControl)

        ' Updates the capacity of NumberedControls so it doesn't have to keep
        ' updating during the loop. Clever isn't it?
        NumberedControls.Capacity = controls.Count

        For Each struct As ControlStructure In controls

            Dim control As DragControl
            If struct.ControlType = 1 Then
                Dim input As InputControl = Main.AddInputControl(struct.GateType)
                ' Only set the value if the input is not named
                If Not input.IsNamed Then
                    input.Value = struct.Value
                End If

                control = input

            ElseIf struct.ControlType = 2 Then
                control = Main.AddGateControl(struct.GateType)
            ElseIf struct.ControlType = 3 Then
                control = Main.AddOutputControl()
            Else
                Throw New Exception("Unusual input number")
            End If

            control.SaveID = struct.ID
            control.Location = New Point(struct.X, struct.Y)

            NumberedControls.Insert(struct.ID, control)

        Next

        For Each struct As LinkStructure In links

            Dim Control1 As DragControl = NumberedControls(struct.ID1)
            Dim Control2 As DragControl = NumberedControls(struct.ID2)
            If struct.Num = 1 Then
                Main.CreateLink(Control1, CreateLinkFinish(Control2, LinkFinishType.Input1))
            Else
                Main.CreateLink(Control1, CreateLinkFinish(Control2, LinkFinishType.Input2))
            End If

        Next
    End Sub
End Module
