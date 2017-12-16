using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Threading;
using System.IO.Ports; // 아두이노 연결을 위해 추가하는 겁니당~!

namespace test
{
    public partial class Form1 : Form
    {
        private SerialPort arduSerialPort = new SerialPort(); // 시리얼 포트 생성
        Personal_Info info = new Personal_Info(); // class 생성
        int flag = 0;
        int cnt = 0;
        int sum = 0;
        int rect_Width = 0;
        int rect_Height = 0;

        public Form1()
        {
            this.StartPosition=System.Windows.Forms.FormStartPosition.CenterScreen; // 시작위치 중앙

            InitializeComponent();
            /*
            //아두이노 보드가 연결된 포트의 이름
            arduSerialPort.PortName = "COM3"; // 포트이름이 바꼈다면 수정 요망~!
            //아두이노 보드 통신 속도
            arduSerialPort.BaudRate = 9600;
            //지정한 포트 열기
            arduSerialPort.Open();
            */

            /*
                    arduSerialPort.Write("3"); // 다리 올려준다!
                    arduSerialPort.Write("0");//발끝 스트레칭!
                    arduSerialPort.Write("1");//발끝 스트레칭 끝!
                    arduSerialPort.Write("2");//다리 스트레칭 끝!
            */

            Back.Hide(); // 선택화면 - 뒤로가기 버튼
            Confirm.Hide(); // 선택화면 - 확인
            M_Box.Hide(); // 선택화면 - 분
            Select_Beginner.Hide(); // 선택화면 - 초보자 버튼
            Select_Master.Hide(); // 선택화면 - 숙련자 버튼
            pictureBox2.Hide();// 선택화면 - 배경
            pictureBox3.Hide();
            pictureBox4.Hide();
        }
        
        private void Main_Start_Click(object sender, EventArgs e)
        {
            Main_Start.Hide();
            Main_Manual.Hide();
            Main_Exit.Hide();
            pictureBox1.Hide();

            pictureBox2.Show();
            Select_Beginner.Show();
            Select_Master.Show();
            Back.Show();           
        }

        // 타이머 함수
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (info.cnt >= 0) // 2번째부터는 카메라 5초 뒤 실행
            {
                timer1.Interval = 5000;
            }

            CvCapture camera = new CvCapture(0); // 카메라 생성       
            CvWindow win = new CvWindow(); // 윈도우창 생성

            //CvHaarClassifierCascade face_classifier =
            //    CvHaarClassifierCascade.FromFile("C:\\김유민\\Visual Studio 2017\\haarcascade_frontalface_alt.xml"); // 얼굴 인식 Haar 알고리즘 불러오기

            //CvHaarClassifierCascade eye_classifier =
            //    CvHaarClassifierCascade.FromFile("C:\\김유민\\Visual Studio 2017\\haarcascade_eye.xml"); // 눈 인식 Haar 알고리즘 불러오기

            CvHaarClassifierCascade face_classifier =
                CvHaarClassifierCascade.FromFile("./haarcascade_frontalface_alt.xml"); // 얼굴 인식 Haar 알고리즘 불러오기

            CvHaarClassifierCascade eye_classifier =
                CvHaarClassifierCascade.FromFile("./haarcascade_eye.xml"); // 눈 인식 Haar 알고리즘 불러오기

            CvMemStorage storage_face = new CvMemStorage(); // 얼굴 저장 메모리
            CvMemStorage storage_eye = new CvMemStorage(); // 눈 저장 메모리

            bool check = true;

            info.time = DateTime.Now;
            TimeSpan timecal = DateTime.Now - info.time;

            while (CvWindow.WaitKey(10) != 27 && check) // <0 : 아무키나 누르면 종료, !=27 esc 누르면 종료            
            {
                using (IplImage camera_img = camera.QueryFrame())
                {
                    storage_face.Clear();
                    storage_eye.Clear();

                    Cv.Flip(camera_img, camera_img, FlipMode.Y); // 좌우반전

                    CvSeq<CvAvgComp> faces = Cv.HaarDetectObjects(camera_img, face_classifier, storage_face, 1.5, 1,
                        HaarDetectionType.ScaleImage, new CvSize(0, 0), new CvSize(200, 200)); // 얼굴 인식 동작
                   
                    for (int i = 0; i < faces.Total; i++)
                    {
                        camera_img.Rectangle(faces[i].Value.Rect, CvColor.Red); // 인식 된 얼굴에 빨간 사각형 그리기
                       
                        CvSeq<CvAvgComp> eyes = Cv.HaarDetectObjects(camera_img, eye_classifier, storage_eye, 1.5, 1,
                            HaarDetectionType.ScaleImage, new CvSize(35, 35), new CvSize(50, 50)); // 눈 인식 동작

                        for (int j = 0; j < eyes.Total; j++) // eyes.Total is changing continuously
                        {                           
                            if (eyes[j].Value.Rect.X > faces[i].Value.Rect.X && eyes[j].Value.Rect.Y > faces[i].Value.Rect.Y
                                && eyes[j].Value.Rect.X + eyes[j].Value.Rect.Width < faces[i].Value.Rect.X + faces[i].Value.Rect.Width
                                && eyes[j].Value.Rect.Y + eyes[j].Value.Rect.Height < (faces[i].Value.Rect.Y + faces[i].Value.Rect.Height) - 60)
                            {
                                camera_img.Rectangle(eyes[j].Value.Rect, CvColor.Yellow); // 인식 된 눈에 노란 사각형 그리기
                                //Console.WriteLine("eyes : {0}", eyes[j]);
                                Console.WriteLine("Comparing X, Y with Recognition X, Y");
                                Console.WriteLine(">> eye  X : {0}, eye  Y : {1}", eyes[j].Value.Rect.X, eyes[j].Value.Rect.Y);

                                // 좌표 저장 (왼눈, 오른눈 랜덤으로 됨..)
                                //info.eye_X = eyes[j].Value.Rect.X;
                                //info.eye_Y = eyes[j].Value.Rect.Y;
                                info.eye_X = faces[i].Value.Rect.X;
                                info.eye_Y = faces[i].Value.Rect.Y;
                                Console.WriteLine(">> face X : {0}, face Y : {1}", faces[i].Value.Rect.X, faces[i].Value.Rect.Y);
                                Cv.DrawRect(camera_img, info.area_X, info.area_Y, info.area_X + rect_Width, info.area_Y + rect_Height, CvColor.Green);
                            }                            
                        }
                    }

                    win.Image = camera_img;

                    // 영상 동작 시간
                    timecal = DateTime.Now - info.time;

                    //if (timecal.Minutes == info.minutes) // info.minutes(설정한 분) 뒤에 check가 false로 변하면서 카메라 자동 꺼짐
                    if (timecal.Seconds == 3)
                    {
                        check = false;
                    }
                }

                timer1.Stop();
            }

            // 눈 범위 설정 -> 벗어나면 label 보이기, 숨기기
            if (info.eye_X < info.area_X - 15 || info.eye_X > info.area_X + 15 || info.eye_Y < info.area_Y - 15 || info.eye_Y > info.area_Y + 15)
            {
                info.wrongCount++;

                if (info.wrongCount == 2)
                {
                    Console.Beep(512, 300);
                    Console.Beep(650, 300);
                    Console.Beep(768, 300);
                    System.Windows.Forms.MessageBox.Show("자세를 바르게 하세요");
                    timer1.Stop();
                    info.wrongCount = 0;
                }
                //else
                //{
                //    timer1.Start();
                //}
            }            

            info.cnt++;
            win.Close();
            Cv.ReleaseCapture(camera); // 메모리 해제
            //camera.Dispose(); // 메모리 해제
            Console.WriteLine("메모리 해제");
            Console.WriteLine("저장된 좌표 X : {0}, Y : {1}", info.eye_X, info.eye_Y);
            Console.WriteLine("");

            timer1.Start();

            if(flag==1)
            {
                timer1.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {            
            TimeSpan total_timecal = DateTime.Now -info.total_time;
            //Console.WriteLine(">> 실시간 : {0}", DateTime.Now);
            //Console.WriteLine(">> 시간간격 : {0}", total_timecal); // 시간, 분, 초
            //Console.WriteLine(">> 분 : {0}", total_timecal.Minutes);
            Console.WriteLine("sec : {0}", total_timecal.Seconds); // 초
            /*
            if (total_timecal.Minutes == 1 && total_timecal.Seconds == 30 && total_timecal.Milliseconds <= 100) // 일단 1분 지나면 스트레칭 작동하게 코딩해놓음 , total_timecal.Seconds == 10 으로 해보기 , 1분 마다
            {
                arduSerialPort.Write("0");//스트레칭    
               // Console.WriteLine("milli sec : {0}", total_timecal.Milliseconds);   
            }

            if (total_timecal.Minutes == 3 && total_timecal.Seconds == 0) // 일단 1분 지나면 스트레칭 작동하게 코딩해놓음 , total_timecal.Seconds == 10 으로 해보기 , 1분 마다
            {
                arduSerialPort.Write("0");//스트레칭    
               // Console.WriteLine("milli sec : {0}", total_timecal.Milliseconds);
            }
            */
            if (total_timecal.Minutes == info.minutes)
            {
                timer2.Stop();
                timer1.Stop();
                Console.Beep(512, 300);
                Console.Beep(650, 300);
                Console.Beep(768, 300);
                pictureBox3.Hide();
                pictureBox4.Show();
                System.Windows.Forms.MessageBox.Show("시간이 완료되었습니다");
                flag = 1;
            }
        }

        private void Select_Beginner_Click(object sender, EventArgs e)
        {
            //Form1에서 Form2로 값을 전달하기위한 이벤트!
            info.difficulty = 1;
            Form2 form2 = new Form2(); // 새 폼 생성
            form2.Passvalue = info.difficulty; // form2로 스테이지 보내줘야 함.

            form2.Owner = this; // 새 폼의 오너를 현재 폼으로
            //form2.Show(); -> 이렇게 하면 Form1로 값이 반환 X
            form2.ShowDialog(); // 새 폼 보여주기

            info.minutes = form2.Passvalue; // 전달 받음

            if (info.minutes != 0)
            {  
                M_Box.Show();
                this.M_Box.Text = info.minutes + "분";
                Confirm.Show(); // 선택화면 - 확인
            }
            else
            {
                M_Box.Hide();
                Confirm.Hide();
            }
        }

        private void Select_Master_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(); // 새 폼 생성
            form2.Passvalue = 100; // form2로 스테이지 보내줘야 함.

            form2.Owner = this; // 새 폼의 오너를 현재 폼으로
            //form2.Show(); -> 이렇게 하면 Form1로 값이 반환 X
            form2.ShowDialog(); // 새 폼 보여주기

            info.minutes = form2.Passvalue; // 전달 받음

            if (info.minutes != 0)
            {
                M_Box.Show();
                this.M_Box.Text = info.minutes + "분";
                Confirm.Show(); // 선택화면 - 확인
            }
            else
            {
                M_Box.Hide();
                Confirm.Hide();
            }
        }

        private void Main_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // 나가기    
        }

        //선택화면에서 뒤로
        private void Back_Click(object sender, EventArgs e)
        {
            M_Box.Hide();
            Confirm.Hide();
            Select_Master.Hide();
            Select_Beginner.Hide();
            Back.Hide();
            pictureBox2.Hide();
            pictureBox3.Hide();
            pictureBox4.Hide();

            pictureBox1.Show();
            Main_Start.Show();
            Main_Manual.Show();
            Main_Exit.Show();
        }

        //선택창 확인버튼 누르면 -> 영상인식 넘어가야함
        private void Confirm_Click(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            pictureBox2.Hide();
            pictureBox4.Hide();
            M_Box.Hide();
            Confirm.Hide();
            Select_Beginner.Hide();
            Select_Master.Hide();
            pictureBox3.Show();
            MessageBox.Show("눈이 제대로 인식되었다면 ESC버튼을 눌러주세요");

            CvCapture camera = new CvCapture(0); // 카메라 생성
            CvWindow win = new CvWindow(); // 윈도우창 생성
            
            CvHaarClassifierCascade face_classifier =
                CvHaarClassifierCascade.FromFile("./haarcascade_frontalface_alt.xml"); // 얼굴 인식 Haar 알고리즘 불러오기

            CvHaarClassifierCascade eye_classifier =
                CvHaarClassifierCascade.FromFile("./haarcascade_eye.xml"); // 눈 인식 Haar 알고리즘 불러오기

            CvMemStorage storage_face = new CvMemStorage(); // 얼굴 저장 메모리
            CvMemStorage storage_eye = new CvMemStorage(); // 눈 저장 메모리

            while (CvWindow.WaitKey(10) != 27) // <0 : 아무키나 누르면 종료, !=27 esc 누르면 종료
            {
                using (IplImage camera_img = camera.QueryFrame())
                {
                    storage_face.Clear();
                    storage_eye.Clear();

                    Cv.Flip(camera_img, camera_img, FlipMode.Y); // 좌우반전

                    CvSeq<CvAvgComp> faces = Cv.HaarDetectObjects(camera_img, face_classifier, storage_face, 1.5, 1,
                        HaarDetectionType.ScaleImage, new CvSize(0, 0), new CvSize(200, 200)); // 얼굴 인식 동작

                    for (int i = 0; i < faces.Total; i++)
                    {
                        camera_img.Rectangle(faces[i].Value.Rect, CvColor.Red); // 인식 된 얼굴에 빨간 사각형 그리기

                        CvSeq<CvAvgComp> eyes = Cv.HaarDetectObjects(camera_img, eye_classifier, storage_eye, 1.5, 1,
                            HaarDetectionType.ScaleImage, new CvSize(35, 35), new CvSize(50, 50)); // 눈 인식 동작

                        for (int j = 0; j < eyes.Total; j++) // eyes.Total is changing continuously
                        {
                            if (eyes[j].Value.Rect.X > faces[i].Value.Rect.X && eyes[j].Value.Rect.Y > faces[i].Value.Rect.Y
                                && eyes[j].Value.Rect.X + eyes[j].Value.Rect.Width < faces[i].Value.Rect.X + faces[i].Value.Rect.Width
                                && eyes[j].Value.Rect.Y + eyes[j].Value.Rect.Height < (faces[i].Value.Rect.Y + faces[i].Value.Rect.Height) - 60)
                            {
                                camera_img.Rectangle(eyes[j].Value.Rect, CvColor.Yellow); // 인식 된 눈에 노란 사각형 그리기
                                Console.WriteLine("Recognition X, Y");
                                Console.WriteLine(">> eye X : {0}, eye Y : {1}", eyes[j].Value.Rect.X, eyes[j].Value.Rect.Y);

                                // 좌표 저장 (왼눈, 오른눈 랜덤으로 됨..) -> recognition 버튼에서 처음에 눈 좌표 저장, 이를 토대로 범위 벗어났는지 아닌지 판별
                                //info.area_X = eyes[j].Value.Rect.X;
                                //info.area_Y = eyes[j].Value.Rect.Y;
                                info.area_X = faces[i].Value.Rect.X;
                                info.area_Y = faces[i].Value.Rect.Y;
                                rect_Width = faces[i].Value.Rect.Width;
                                rect_Height = faces[i].Value.Rect.Height;
                                Console.WriteLine(">> face X : {0}, face Y : {1}", faces[i].Value.Rect.X, faces[i].Value.Rect.Y);
                            }
                        }
                    }

                    win.Image = camera_img;
                }
            }

            win.Close();
            Cv.ReleaseCapture(camera);
            Console.WriteLine("메모리 해제");
                        
            info.total_time = DateTime.Now; // 스타트 누를 때부터 초세기 (전체시간)

            timer1.Enabled = true; // 타이머 동작

            timer2.Enabled = true;
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Start();        

            if (info.cnt == 0) // 처음 start 버튼 누를 때 0.5초 뒤 바로 카메라 동작
            {
                timer1.Interval = 500;
            }

            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();            
        }

        private void Main_Manual_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(); // 새 폼 생성
            form3.Show();

        }       
    }
}

// 개인정보 클래스
public class Personal_Info
{
    public DateTime time; // 시간
    public int cnt; // 5번 이상 벗어나면 경고 나오게 하는 기능에서 count 변수
    public int eye_X; // 실시간 눈 x좌표
    public int eye_Y; // 실시간 눈 y좌표
    public int area_X; // 범위 판단용 눈 x좌표
    public int area_Y; // 범위 판단용 눈 y좌표
    public int difficulty; // 난이도
    //public int minutes; // 시간 설정
    public int wrongCount; // 몇 번 잘못된 자세인지 세는 변수 

    public DateTime total_time;
    public int minutes;
}