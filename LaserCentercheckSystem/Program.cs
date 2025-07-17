using LaserIntelliWeldingSystem.FileIO.XMLFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using LaserIntelliWeldingSystem.Communication;
using System.Diagnostics;
using System.Reflection;

namespace LaserIntelliWeldingSystem
{
    internal static class Program
    {

        [DllImport("user32.dll")]
        public static extern bool SetProcessDPIAware();

        /// <summary>
        /// 该函数设置由不同线程产生的窗口的显示状态  
        /// </summary>  
        /// <param name="hWnd">窗口句柄</param>  
        /// <param name="cmdShow">指定窗口如何显示。查看允许值列表</param>  
        /// <returns>如果窗口原来可见，返回值为非零；如果窗口原来被隐藏，返回值为零</returns>                      
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        private const int SW_SHOWNOMAL = 9;

        /// <summary>  
        ///  该函数将创建指定窗口的线程设置到前台，并且激活该窗口
        ///  系统给创建前台窗口的线程分配的权限稍高于其他线程。   
        /// </summary>  
        /// <param name="hWnd">将被激活并被调入前台的窗口句柄</param>  
        /// <returns>如果窗口设入了前台，返回值为非零；如果窗口未被设入前台，返回值为零</returns>  
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);


        #region 调用Win32API,进程中已经有一个实例在运行,激活其窗口并显示在最前端
        private static void HandleRunningInstance(Process instance)
        {
            //MessageBox.Show("已经在运行!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UIMessageBox.ShowError("PROCESS IS HAVE BEEN OPENED");
            ShowWindowAsync(instance.MainWindowHandle, SW_SHOWNOMAL);//调用API函数,正常显示窗口
            SetForegroundWindow(instance.MainWindowHandle);//将窗口放置在最前端  

        }
        #endregion

        #region 在进程中查找是否已经有实例在运行
        //确保程序只运行一个实例
        public static Process RunningInstance()
        {
            Process currentProcess = Process.GetCurrentProcess();
            Process[] Processes = Process.GetProcessesByName(currentProcess.ProcessName);
            //遍历与当前进程名称相同的进程列表
            foreach (Process process in Processes)
            {
                //如果实例已经存在,则忽略当前进程
                if (process.Id != currentProcess.Id)
                {
                    //保证要打开的进程 同 已经存在的进程来自同一个文件路径
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == currentProcess.MainModule.FileName)
                    {
                        //返回另一个进程实例
                        return process;
                    }
                }
            }
            return null; //找不到其他进程实例，返回nulL。          
        }
        #endregion


        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process instance = RunningInstance();
            if (instance != null) //进程中已经有一个实例在运行
            {
                HandleRunningInstance(instance);
            }
            else
            {
                SetProcessDPIAware();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                try
                {

                    //增加一个英文的内置资源配置
                    UIStyles.BuiltInResources.TryAdd(CultureInfos.en_US.LCID, new Lang_en_US());
                    //从项目方案生成多语言配置文件，生成文件在可执行文件夹的Language目录下
                    //生成后界面没有修改的情况下，可注释掉下一行，只运行一次即可
                    TranslateHelper.LoadCsproj(@"D:\A-A-项目类\03_研发项目\MRDF-2506 激光器喷嘴检测设备\软件\LaserCheckSystem\LaserCentercheckSystem\LaserCentercheckSystem.csproj");
                }
                catch(Exception e)
                {
                    string msg = e.ToString();
                }
                Application.Run(new FormMain());
            }
        }
    }
}
