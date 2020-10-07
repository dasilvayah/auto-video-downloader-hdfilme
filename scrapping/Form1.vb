Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.Extensions
Imports OpenQA.Selenium.Remote
Imports System.Collections.ObjectModel
Imports System.Text.RegularExpressions
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Security.Authentication.ExtendedProtection
Imports System.Drawing.Imaging

Public Class Form1
    Private driver As IWebDriver

    Private dest_folder As String

    Private f_series As Integer

    Dim a_videos_list As New List(Of String)()

    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        End
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        link.Text = "https://hdfilme.cx/filme1/2020"
        dest_path.Text = Directory.GetCurrentDirectory()
        ProgressBar1.Maximum = 100
        dest_folder = dest_path.Text
    End Sub

    Private Sub Start_Click(sender As Object, e As EventArgs) Handles Start.Click
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()

        a_videos_list.Clear()

        Dim site_login_url, site_link, site_user, site_pass, video_mode As String
        site_login_url = "https://hdfilme.cx/login"
        site_link = link.Text
        site_user = ""
        site_pass = ""
        dest_folder = dest_path.Text

        If RadioHigh.Checked = True Then
            video_mode = "high"
        ElseIf RadioLow.Checked = True Then
            video_mode = "low"
        End If

        Dim InputSeriesPageNumbers As String() = {}
        Dim SeriesPageNumbersList As New List(Of String)()
        Dim SeriesPageNumbers As String() = {}

        check_series(driver, site_link)

        If f_series = 2 Or f_series = 3 Then
            Dim Message, PageInputTitle, DefaultValue
            Message = "Enter page numbers e.g. 1-5,7,11,35"
            PageInputTitle = "InputBox Demo"
            DefaultValue = "1"
            Dim InputBoxPages As String
            InputBoxPages = InputBox(Message, PageInputTitle, DefaultValue)
            InputSeriesPageNumbers = InputBoxPages.Split(New Char() {","c})

            For Each page_number In InputSeriesPageNumbers
                Dim page_numbers_in_hyphen As String() = {}
                page_numbers_in_hyphen = page_number.Split(New Char() {"-"c})

                If page_numbers_in_hyphen.Count = 2 Then
                    Dim checkNum As Integer
                    If Not (Integer.TryParse(page_numbers_in_hyphen(0), checkNum) And Integer.TryParse(page_numbers_in_hyphen(1), checkNum)) Then
                        Dim Msg, Style, PageErrorTitle, Response
                        Msg = "Error parsing page numbers! Enter page numbers e.g. 1-5,7,11,35"
                        Style = vbOKOnly
                        PageErrorTitle = "MsgBox Demonstration"
                        Response = MsgBox(Msg, Style, PageErrorTitle)
                        If Response = vbOK Then
                            Exit Sub
                        End If
                    End If
                    Dim page_range_1, page_range_2 As Integer
                    page_range_1 = CInt(page_numbers_in_hyphen(0))
                    page_range_2 = CInt(page_numbers_in_hyphen(1))
                    If page_range_1 = page_range_2 Then
                        SeriesPageNumbersList.Add(page_range_1)
                    ElseIf page_range_1 < page_range_2 Then
                        For i = page_range_1 To page_range_2
                            SeriesPageNumbersList.Add(i)
                        Next
                    ElseIf page_range_1 > page_range_2 Then
                        For i = page_range_1 To page_range_2 Step -1
                            SeriesPageNumbersList.Add(i)
                        Next
                    End If
                ElseIf page_numbers_in_hyphen.Count = 1 Then
                    Dim num As Integer
                    If Not Integer.TryParse(page_number, num) Then
                        Dim Msg, Style, PageErrorTitle, Response
                        Msg = "Error parsing page numbers! Enter page numbers e.g. 1-5,7,11,35"
                        Style = vbOKOnly
                        PageErrorTitle = "MsgBox Demonstration"
                        Response = MsgBox(Msg, Style, PageErrorTitle)
                        If Response = vbOK Then
                            Exit Sub
                        End If
                    End If
                    SeriesPageNumbersList.Add(page_number)
                Else
                    Dim Msg, Style, PageErrorTitle, Response
                    Msg = "Error parsing page numbers! Enter page numbers e.g. 1-5,7,11,35"
                    Style = vbOKOnly
                    PageErrorTitle = "MsgBox Demonstration"
                    Response = MsgBox(Msg, Style, PageErrorTitle)
                    If Response = vbOK Then
                        Exit Sub
                    End If
                End If
            Next
            SeriesPageNumbers = SeriesPageNumbersList.ToArray()
        End If

        Dim driverS As ChromeDriverService
        Dim driverO As ChromeOptions
        driverS = ChromeDriverService.CreateDefaultService
        driverS.HideCommandPromptWindow = True
        driverO = New ChromeOptions
        driverO.AddArgument("--incognito")
        driverO.AddArgument("--disable-extensions")
        driverO.AddUserProfilePreference("download.default_directory", dest_folder)
        driverO.AddUserProfilePreference("intl.accept_languages", "en")
        driverO.AddUserProfilePreference("disable-popup-blocking", "true")
        'driverO.AddArgument("--headless")
        driverO.AddArgument("--window-position=550,0")

        'Dim driver As IWebDriver
        driver = New ChromeDriver(driverS, driverO)
        driver.Navigate().GoToUrl(site_login_url)

        For i = 1 To 60
            If driver.Url.Substring(0, 24) <> site_login_url Then
                i = 61
                System.Threading.Thread.Sleep(5000)
            Else
                System.Threading.Thread.Sleep(5000)
            End If
        Next i

        If driver.Url.Substring(0, 24) <> site_login_url Then
            If f_series = 3 Then

                Dim search_key_words As String()
                Dim search_key As String = ""

                search_key_words = site_link.Substring(30).Split(New Char() {"+"c})
                For Each search_key_word In search_key_words
                    search_key = search_key + search_key_word + " "
                Next
                search_key = search_key.Substring(0, search_key.Length - 1)

                Dim search_input As IWebElement
                Dim search_button As IWebElement
                Try
                    search_input = driver.FindElement(By.Name("key"))
                    search_button = driver.FindElement(By.ClassName("bg-search"))
                    search_input.SendKeys(search_key)
                    System.Threading.Thread.Sleep(1000)
                    search_button.Click()
                    System.Threading.Thread.Sleep(5000)
                Catch ex As Exception

                End Try

            Else
                driver.Navigate().GoToUrl(site_link)
                System.Threading.Thread.Sleep(5000)
            End If

            If f_series = 0 Then
                Dim page_count As Integer
                page_count = get_pagination_count(driver)

                If page_count > 0 Then
                    For i = 1 To page_count
                        System.Threading.Thread.Sleep(5000)
                        get_video_list(driver)
                        click_next_button(driver)
                    Next
                Else
                    get_video_list(driver)
                End If
            ElseIf f_series = 1 Then
                get_carousel_list(driver)
            Else
                Dim page_count As Integer

                page_count = UBound(SeriesPageNumbers) - LBound(SeriesPageNumbers) + 1

                For Each SeriesPageNumber In SeriesPageNumbers
                    System.Threading.Thread.Sleep(5000)
                    go_page(driver, SeriesPageNumber)
                    get_series_list(driver, SeriesPageNumber)
                Next
                Dim a_videos_array As String() = a_videos_list.ToArray()
                get_carousel_list(driver, a_videos_array)
            End If

        Else
            f_series = 1
            driver.Close()
            MsgBox("Please login again.", 0)
        End If

    End Sub

    Private Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click
        Dim video_url As String
        Dim video_cnt As Integer
        video_cnt = 0

        'Dim driver As IWebDriver

        For i As Integer = 0 To ListBox1.SelectedItems.Count - 1
            video_cnt = video_cnt + 1
            video_url = ListBox1.SelectedItems(i).ToString()
            If f_series = 0 Then
                driver.Navigate().GoToUrl(video_url + "/deutsch")
            ElseIf f_series = 1 Or f_series = 2 Then
                driver.Navigate().GoToUrl(video_url)
            End If

            System.Threading.Thread.Sleep(3000)
            click_download_btn(driver)
            System.Threading.Thread.Sleep(3000)

            video_url = get_downurl_list(driver)
            If video_url <> "" Then
                ListBox2.Items.Add(video_url)
                ListBox2.Refresh()
                ListBox2.Update()

                driver.Navigate().GoToUrl(video_url)
                Dim strArr() As String
                Dim filename As String
                strArr = video_url.Split("=")
                filename = strArr(strArr.Length - 1)
                filename = filename.Replace("+", " ")
                For j = 0 To 400
                    If My.Computer.FileSystem.FileExists(dest_folder + "/" + filename) Then
                        j = 401
                    Else
                        System.Threading.Thread.Sleep(3000)
                    End If
                Next j
            End If
        Next

        driver.Close()
    End Sub

    Private Sub btn_test_Click(sender As Object, e As EventArgs) Handles btn_test.Click
        Dim s1 As String = String.Empty

        For i As Integer = 0 To ListBox1.SelectedItems.Count - 1
            s1 = ListBox1.SelectedItems(i)
            ListBox2.Items.Add(s1)
        Next

    End Sub

    Private Function check_series(ByVal driver As ChromeDriver, ByVal url As String) As Integer
        If Not url Like "https://hdfilme.cx/serien1" And Not url Like "https://hdfilme.cx/search?key=" Then
            f_series = 0
        ElseIf url Like "https://hdfilme.cx/serien1" And url <> "https://hdfilme.cx/serien1" Then
            f_series = 1
        ElseIf url = "https://hdfilme.cx/serien1" Then
            f_series = 2
        ElseIf url.Substring(0, 30) = "https://hdfilme.cx/search?key=" Then
            f_series = 3
        End If
    End Function

    Private Function get_pagination_count(ByVal driver As ChromeDriver) As Integer
        Dim ul_pagination As IWebElement
        Try
            ul_pagination = driver.FindElement(By.ClassName("slimScrollGlobal"))
            Dim all_pagination_li As ReadOnlyCollection(Of IWebElement)
            all_pagination_li = ul_pagination.FindElements(By.XPath(".//li"))

            Return all_pagination_li.Count
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Function click_next_button(ByVal driver As ChromeDriver) As IWebElement
        Dim ul_pagination As IWebElement
        Try
            ul_pagination = driver.FindElement(By.ClassName("pagination-append-url"))
            Dim all_pagination_li As ReadOnlyCollection(Of IWebElement)
            all_pagination_li = ul_pagination.FindElements(By.XPath(".//li"))
            all_pagination_li(all_pagination_li.Count - 2).Click()
        Catch ex As Exception

        End Try
    End Function

    Private Function go_page(ByVal driver As ChromeDriver, PageNumber As String) As IWebElement
        Dim ul_pagination As IWebElement
        Dim ul_pages As IWebElement
        Dim pageNo As Integer
        pageNo = CInt(PageNumber)
        Try
            ul_pagination = driver.FindElement(By.ClassName("pagination-append-url"))
            Dim all_pagination_li As ReadOnlyCollection(Of IWebElement)
            all_pagination_li = ul_pagination.FindElements(By.XPath(".//li"))
            all_pagination_li(0).Click()
            ul_pages = driver.FindElement(By.ClassName("slimScrollGlobal"))
            Dim all_pages_li As ReadOnlyCollection(Of IWebElement)
            all_pages_li = ul_pages.FindElements(By.XPath(".//li"))

            driver.ExecuteScript("arguments[0].scrollIntoView();", all_pages_li(pageNo - 1))
            all_pages_li(pageNo - 1).Click()
            System.Threading.Thread.Sleep(5000)
        Catch ex As Exception

        End Try
    End Function
    Private Function get_video_list(ByVal driver As ChromeDriver)
        Dim ul_videos As IWebElement
        Try
            ul_videos = driver.FindElement(By.ClassName("products"))
            Dim all_video_li, a_videos As ReadOnlyCollection(Of IWebElement)
            all_video_li = ul_videos.FindElements(By.XPath(".//li"))

            Dim li_video As IWebElement
            For i = 0 To all_video_li.Count - 1
                li_video = all_video_li(i)
                a_videos = li_video.FindElements(By.XPath(".//a"))
                ListBox1.Items.Add(a_videos(0).GetAttribute("href"))
                ListBox1.Refresh()
                ListBox1.Update()
            Next

        Catch ex As Exception

        End Try
    End Function

    Private Function get_series_list(ByVal driver As ChromeDriver, SeriesPageNumber As String)
        Dim ul_videos As IWebElement
        Try
            ul_videos = driver.FindElement(By.ClassName("products"))
            Dim all_video_li, a_videos As ReadOnlyCollection(Of IWebElement)
            all_video_li = ul_videos.FindElements(By.XPath(".//li"))

            Dim li_video As IWebElement

            For i = 0 To all_video_li.Count - 1
                li_video = all_video_li(i)
                a_videos = li_video.FindElements(By.XPath(".//a"))
                a_videos_list.Add(a_videos(0).GetAttribute("href"))
            Next
        Catch ex As Exception

        End Try
    End Function

    Private Function click_download_btn(ByVal driver As ChromeDriver)
        Dim btn_down As IWebElement
        Try
            btn_down = driver.FindElement(By.XPath("//a[@id='download-btn']"))
            'MsgBox(btn_down.Text)
            btn_down.Click()
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Function get_downurl_list(ByVal driver As ChromeDriver) As String
        Dim ul_videos As IWebElement
        Dim video_mode As Integer
        If RadioHigh.Checked = True Then
            video_mode = 2
        ElseIf RadioLow.Checked = True Then
            video_mode = 1
        End If

        Try
            ul_videos = driver.FindElement(By.XPath("//ul[@id='list-link-download']"))
            Dim all_video_li, a_videos As ReadOnlyCollection(Of IWebElement)
            all_video_li = ul_videos.FindElements(By.XPath(".//li"))

            Dim li_video As IWebElement
            If all_video_li.Count > 2 Then
                li_video = all_video_li(video_mode)
                a_videos = li_video.FindElements(By.XPath(".//a"))
                Return a_videos(0).GetAttribute("href")
            Else
                Return ""
            End If

        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function get_carousel_list(ByVal driver As ChromeDriver)
        Dim ul_videos As ReadOnlyCollection(Of IWebElement)
        Dim site_link As String
        site_link = link.Text
        Try
            driver.Navigate().GoToUrl(site_link + "/folge-1")
            System.Threading.Thread.Sleep(3000)
            ul_videos = driver.FindElements(By.ClassName("list-film"))

            If ul_videos(0).Text <> "" Then
                Dim all_video_li As ReadOnlyCollection(Of IWebElement)
                all_video_li = ul_videos(0).FindElements(By.XPath(".//li"))

                For i = 1 To all_video_li.Count - 1
                    ListBox1.Items.Add(site_link + "/folge-" + i.ToString())
                    ListBox1.Refresh()
                    ListBox1.Update()
                Next
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Function get_carousel_list(ByVal driver As ChromeDriver, video_url_array As String())
        Dim ul_videos As ReadOnlyCollection(Of IWebElement)
        Dim site_link As String
        site_link = link.Text
        For Each video_url In video_url_array
            Try
                driver.Navigate().GoToUrl(video_url + "/folge-1")
                System.Threading.Thread.Sleep(3000)
                ul_videos = driver.FindElements(By.ClassName("list-film"))
                If ul_videos(0).Text <> "" Then
                    Dim all_video_li As ReadOnlyCollection(Of IWebElement)
                    all_video_li = ul_videos(0).FindElements(By.XPath(".//li"))

                    For i = 1 To all_video_li.Count - 1
                        ListBox1.Items.Add(video_url + "/folge-" + i.ToString())
                        ListBox1.Refresh()
                        ListBox1.Update()
                    Next
                End If
            Catch ex As Exception

            End Try
        Next
    End Function

    Private Sub btn_copy_1_Click(sender As Object, e As EventArgs) Handles btn_copy_1.Click
        Dim s1 As String = String.Empty

        For i As Integer = 0 To ListBox1.SelectedItems.Count - 1
            s1 &= ListBox1.Items.Item(ListBox1.SelectedIndex) & Environment.NewLine
        Next

        Clipboard.SetText(s1)
    End Sub

    Private Sub btn_copy_2_Click(sender As Object, e As EventArgs) Handles btn_copy_2.Click
        Dim s1 As String = String.Empty

        For i As Integer = 0 To ListBox2.SelectedItems.Count - 1
            s1 &= ListBox2.Items.Item(ListBox2.SelectedIndex) & Environment.NewLine
        Next

        Clipboard.SetText(s1)
    End Sub

    Private Sub btn_dest_Click(sender As Object, e As EventArgs) Handles btn_dest.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            dest_path.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    
End Class
