Imports System.Numerics
Imports System.Threading

' http://mathworld.wolfram.com/TuppersSelf-ReferentialFormula.html
' https://en.wikipedia.org/wiki/Tupper%27s_self-referential_formula
' http://web.aanet.com.au/superseed/ajmcrae/TupperPlot/TupperPlot.html

Public Class FormMain
    Private formulas As New List(Of TupperNumber) From {
                New TupperNumber("Original", "960939379918958884971672962127852754715004339660129306651505519271702802395266424689642842174350718121267153782770623355993237280874144307891325963941337723487857735749823926629715517173716995165232890538221612403238855866184013235585136048828693337902491454229288667081096184496091705183454067827731551705405381627380967602565625016981482083418783163849115590225610003652351370343874461848378737238198224849863465033159410054974700593138339226497249461751545728366702369745461014655997933798537483143786841806593422227898388722980000748404719"),
                New TupperNumber("Numberfile", "303806070865572866031751250918065607014467617914163950035270707450320041057114313385749228968381954636799976994584906098745041343072501800127159961545776706978316181756362419365889060790623288892778282002043429864165130978316168867287667782725331344103500208649583141543527583788390252405864023808233218448774298829164870750597087310894266897065827181303310413221265782968041758750119939207639351330801224867963167967948417211743362420509278810485528088034105437921040081332351088863761021907550273331128689029002497473198571824127875735394560"),
                New TupperNumber("Hello Kitty", "280571970700545905821725622087309287373754832640573241615803346592531584666391027055206116229719428091285109078919291391243327016592547877048428352464118441606554289270349698720131549205376135597978166794121567729254921079068996169964270616561360860022609895896212144118748871961048338040267733583589492224428935427196690972766524462905219168388481179884927190582816809570724696354553529821316937396725225304484248606525124204599582797844785584648337248401432832419983040510711160478396120070586578352909059680053459731844400472567840768", True),
                New TupperNumber("Matt was'ere", "960939379918958884971672962127852754715004339660129306651505519271702802395266424689642842174350718121267153782770623355993237280874144307891325963941337723487857735749823926629715517173716995165232890538221619561473865746304976129424093469921873058694492149444647882055806603996307772920108275439090931487231139508469267169521581872227293630931364751681875244141639118844172571080588839278417813855101724217755801034516516847318278139146496085068307449373183066378525002863703739215155304174822734164455483814441481301873381703922338834284527"),
                New TupperNumber("Black", "4858487703217654168507377107565676789145697178497253677539145555247620343537955749299116772611982962556356527603203744742682135448820545638134012705381689785851604674225344958377377969928942335793703373498110479735981161931616997837568312568489938311294622859986621379234205529965392091893253288500432782862263410646820171439206408889517627953930924005233285455643232746873900205120036557171717499335122490912065694632935352302178602108137941774883061885522205403967593003199773578952627785152838963495027790689532144351329310799436758088941551"),
                New TupperNumber("Brilliant", "4858485390999670448746903365089768368617710768834660012388173288524654178949978049944868710538516294877620353668483662935366626602594892897569165290588305741935268286384067811525624923136045761864695167648227909735247894905965266601185832734111836916088387799895732529972503459120508643887020302642994308338647923034771820182176605372325447019828390655784620186786800227025791813364831939280414817063175745207785502331527315365160190730899210873764484648366569393500481770411621586799225038123596991242202831343689507264087498985286559034507247", True),
                New TupperNumber("Hi", "4858487703217654168507377107565676789145697178497253677539145554140400556563348457512621699552747286085329444453043522900867835463627684534139226325784627721780019652435679672060185499344481895879597287975234500151317725245852409763852709693688220657683702347418782610255113158808524311487014418886047810569817609678586115532162928674412170506858046678219743015209486120043646095926634954062732814611648174267133979088112998666426487409616547319073396109952551746956070812851300828038476951990269985021914749161087249691331087153600392647933935", True, True),
                New TupperNumber("Rickroll", "14858462014267026184847463044915295278652559471591461531013601246041965909968094014491328087054144021193212514675485743667375869739370703586080318750673599857073936072704236551128661305329214452063954886672927963421329856355362323968050725018605956217987665927348135695300854844311400104197079621092723521753309226640825505538014409958939864243727226216233149978784317818476120179448775057160615305444510286889595001504618712029211557750363872865223404300289202234085132824642926552052553745992310827455707348992")
    }

    Private scaleFactor As Integer = 10

    Private bmp As DirectBitmap
    Private w As Integer = 106
    Private h As Integer = 17
    Private topMargin As Integer
    Private hasErrors As Boolean
    Private ignoreEvents As Boolean
    Private selectedFormulaIndex As Integer

    Private r As BigInteger

    Private isFirst As Boolean = True

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        Me.BackColor = Color.White

        topMargin = TextBoxNumber.Margin.Top * 2 + TextBoxNumber.Height + 12

        bmp = New DirectBitmap(w * scaleFactor, h * scaleFactor)
        Me.Width = w * scaleFactor + 10 * 2 + (Me.Width - Me.DisplayRectangle.Width)
        Me.Height = h * scaleFactor + 10 * 2 + (Me.Height - Me.DisplayRectangle.Height) + topMargin
        Me.Left = (My.Computer.Screen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (My.Computer.Screen.WorkingArea.Height - Me.Height) / 2

        AddHandler TextBoxNumber.TextChanged, Sub() UpdateTupperNumber()
        AddHandler CheckBoxInvertColors.CheckedChanged, Sub() UpdateTupperNumber()
        AddHandler CheckBoxFlipXY.CheckedChanged, Sub() UpdateTupperNumber()
        AddHandler ComboBoxFormulas.SelectedIndexChanged, Sub()
                                                              If ignoreEvents Then Exit Sub
                                                              ignoreEvents = True
                                                              selectedFormulaIndex = ComboBoxFormulas.SelectedIndex
                                                              Dim formula As TupperNumber = CType(ComboBoxFormulas.SelectedItem, TupperNumber)
                                                              TextBoxNumber.Text = formula.Number.ToString()
                                                              TextBoxNumber.SelectionStart = TextBoxNumber.Text.Length
                                                              CheckBoxInvertColors.Checked = formula.InvertColors
                                                              CheckBoxFlipXY.Checked = formula.FlipXY
                                                              ignoreEvents = False
                                                              UpdateTupperNumber()
                                                          End Sub

        For Each f In formulas
            ComboBoxFormulas.Items.Add(f)
        Next
        ComboBoxFormulas.SelectedIndex = 0

        AddHandler ComboBoxFormulas.TextChanged, Sub()
                                                     Dim selIndex As Integer = ComboBoxFormulas.SelectedIndex
                                                     If selIndex <> -1 AndAlso selIndex <> selectedFormulaIndex Then Exit Sub
                                                     formulas(selectedFormulaIndex).Name = ComboBoxFormulas.Text
                                                     UpdateTupperNumber()
                                                 End Sub
    End Sub

    Private Sub UpdateTupperNumber()
        If ignoreEvents Then Exit Sub
        ignoreEvents = True

        hasErrors = False
        Try
            ComboBoxFormulas.Items(selectedFormulaIndex) = New TupperNumber(ComboBoxFormulas.Text,
                                                             TextBoxNumber.Text,
                                                             CheckBoxFlipXY.Checked,
                                                             CheckBoxInvertColors.Checked)
        Catch ex As Exception
            hasErrors = True
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        UpdateBitmap()
        ignoreEvents = False
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        e.Graphics.FillRectangle(Brushes.Gainsboro, 0, 0, Me.Width, topMargin + 4)
        e.Graphics.DrawImageUnscaled(bmp.Bitmap, 10, 10 + topMargin)
    End Sub

    Private Sub UpdateBitmap()
        Dim t As Boolean

        Dim formula As TupperNumber = If(hasErrors, New TupperNumber("", "0"), CType(ComboBoxFormulas.Items(selectedFormulaIndex), TupperNumber))

        For y As Integer = 0 To h - 1
            For x As Integer = 0 To w - 1
                t = Tupper(x, y + formula.Number)
                DrawBit(x, y, If(If(formula.InvertColors, Not t, t), Color.Black, Color.White), formula)
            Next
        Next

        Me.Invalidate()
    End Sub

    Private Sub DrawBit(x1 As Integer, y1 As Integer, color As Color, formula As TupperNumber)
        Dim offset As Integer

        For y = y1 * scaleFactor To y1 * scaleFactor + scaleFactor - 1
            For x = x1 * scaleFactor To x1 * scaleFactor + scaleFactor - 1
                offset = (bmp.Width - If(formula.FlipXY, bmp.Width - x - 1, x) - 1) * 4 +
                         (If(formula.FlipXY, bmp.Height - y - 1, y) * bmp.Width * 4)

                bmp.Bits(offset + 3) = color.A
                bmp.Bits(offset + 2) = color.R
                bmp.Bits(offset + 1) = color.G
                bmp.Bits(offset + 0) = color.B
            Next
        Next
    End Sub

    Private Function Tupper(x As BigInteger, y As BigInteger) As Boolean
        Dim exp As Integer = -17 * x - (y Mod 17)

        If exp < 0 Then
            r = ((y / 17) / BigInteger.Pow(2, -exp)) Mod 2
        Else
            r = ((y / 17) * BigInteger.Pow(2, exp)) Mod 2
        End If
        r *= 10

        Return 5 < r
    End Function
End Class
