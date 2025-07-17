using GlobalCameraModuleCs;
using GlobalVariableModuleCs;
using IMVSCnnFlawModuCCs;
using IMVSCnnInstanceSegmentModuCCs;
using LaserIntelliWeldingSystem.Communication;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VM.Core;
using VM.PlatformSDKCS;
using VMControls.Winform.Release;

namespace LaserIntelliWeldingSystem.VisionSystem
{
    public class VisionMasterFunc
    {
        ~VisionMasterFunc()
        {

        }

        const string TAG = "VisionMasterFunc";
        string ErrorMessage;

        public string SolutionPath = Application.StartupPath + "\\Sol\\";
        public bool IsSolutionLoad = false;//true表示方案加载成功，false表示方案加载失败
        public VmProcedure[] workProcedure;
        public bool[] VmProcedureRunFinished;
        //public bool[] VmProcedureRunResult;
        //public bool CameraStatus;
        public List<UIButton>[] ProcedureButton;
        public List<UIButton> GolButton = new List<UIButton>();
        public ProcessInfoList vmProcessInfoList;//流程列表
        public ImageBaseData iGetImage;
        public string CameraSn;
        public const string SavePathboot = "D:\\LaserCheckImage";
        public string CenterCheckSaveDatetime = string.Format("\\CenterCheck\\{0}", DateTime.Now.ToString("yyyyMMdd"));
        public string StainsCheckSaveDatetime = string.Format("\\StainsCheck\\{0}", DateTime.Now.ToString("yyyyMMdd"));
        public const string DLModel = "DL_Model.bin";
        public const string DLSegmentModel = "DL_DecModel.bin";

        public bool InizVmSolution()
        {
            try
            {
                if (!Directory.Exists(SolutionPath))
                    Directory.CreateDirectory(SolutionPath);
                string SolutionFile = SolutionPath + GlobalCommData.IniFile.ReadValue("VisionMasterSoltion", "Name");
                VmSolution.Load(SolutionFile, "");
                //方案加载完成后，关闭所有模块的结果回调，提高运行效率
                VmSolution.Instance.DisableModulesCallback();
                GlobalCommData.ShowLog(TAG, "Load Solution Succeed!");
                SetModelPath();
                IsSolutionLoad = true;
                GlobalCommData.mRunCenterResult.InitializeCfg();
                GlobalCommData.mRunStainsResult.InitializeCfg();
                CameraSn = GetGloCameraSN();
                WriteValue();
            }
            catch
            {
                GlobalCommData.ShowLog(TAG, "Load Solution Fail!", MessageLevel.Error, MessageType.Debug);
                IsSolutionLoad = false;
            }
            return IsSolutionLoad;
        }

        public void DisposeVm()
        {
            if (IsSolutionLoad)
                VmSolution.Instance?.Dispose();
        }

        public void SaveVMSolution()
        {
            VmSolution.Save();
        }

        public void SetModelPath()
        {
            try
            {
                IMVSCnnFlawModuCTool mCnnModuCTool = (IMVSCnnFlawModuCTool)VmSolution.Instance["Flow2.DL Image Segmentation CPU1"];
                mCnnModuCTool.ModuParams.LoadModelPath = SolutionPath + DLModel;

                IMVSCnnInstanceSegmentModuCTool mCnnSegmentModuCTool = (IMVSCnnInstanceSegmentModuCTool)VmSolution.Instance["Flow2.Segment"];
                mCnnSegmentModuCTool.ModuParams.LoadModelPath = SolutionPath + DLSegmentModel;
            }
            catch
            {

            }
        }

        public void SetGloVariable(string variableName, string Value)
        {
            try
            {
                GlobalVariableModuleTool globalVar = (GlobalVariableModuleTool)VmSolution.Instance["Global Variable1"];
                globalVar.SetGlobalVar(variableName, Value);
            }
            catch
            { }
        }

        void WriteValue()
        {
            SetGloVariable("CenterCheckExp", GlobalCommData.mRunCenterResult.CenterCheckExp.ToString());
            SetGloVariable("StainsCheckExp", GlobalCommData.mRunStainsResult.StainsCheckExp.ToString());

            SetGloVariable("StainsLimitMin", GlobalCommData.mRunStainsResult.StainsLimitMin.ToString());
            SetGloVariable("StainsLimitMax", GlobalCommData.mRunStainsResult.StainsLimitMax.ToString());

            SetGloVariable("PixelRate", GlobalCommData.mRunCenterResult.PixelRate.ToString());

            SetGloVariable("SavePath", SavePathboot + CenterCheckSaveDatetime);
            SetGloVariable("StainsSavePath", SavePathboot + StainsCheckSaveDatetime);
        }

        public void WriteNewDaysPath()
        {
            CenterCheckSaveDatetime = string.Format("\\CenterCheck\\{0}", DateTime.Now.ToString("yyyyMMdd"));
            StainsCheckSaveDatetime = string.Format("\\StainsCheck\\{0}", DateTime.Now.ToString("yyyyMMdd"));
            SetGloVariable("SavePath", SavePathboot + CenterCheckSaveDatetime);
            SetGloVariable("StainsSavePath", SavePathboot + StainsCheckSaveDatetime);
        }

        public string GetGloCameraSN()
        {
            try
            {
                GlobalCameraModuleTool globalCamera = (GlobalCameraModuleTool)VmSolution.Instance["Global Camera1"];
                CameraInfoList cameraInfoList = globalCamera.ModuParams.GetCameraInfoList();
                if (cameraInfoList.nNum <= 0)
                    return "-1";
                else
                    return globalCamera.ModuParams.GetChosenCameraSN();
            }
            catch
            {
                return "-2";
            }
        }

        public void SettingProcedureSource()
        {
            if (!IsSolutionLoad) return;
            vmProcessInfoList = VmSolution.Instance.GetAllProcedureList();
            if (vmProcessInfoList.nNum <= 0) return;
            workProcedure = new VmProcedure[vmProcessInfoList.nNum];
            VmProcedureRunFinished = new bool[vmProcessInfoList.nNum];
            //VmProcedureRunResult = new bool[vmProcessInfoList.nNum];
            for (int i = 0; i < vmProcessInfoList.nNum; i++)
            {
                workProcedure[i] = VmSolution.Instance[vmProcessInfoList.astProcessInfo[i].strProcessName] as VmProcedure;
            }
            if (workProcedure[0] != null)
            {
                workProcedure[0].OnWorkEndStatusCallBack += VisionMasterFunc_OnWorkEndStatusCallBack;
            }
            if (workProcedure[1] != null)
            {
                workProcedure[1].OnWorkEndStatusCallBack += VisionMasterFunc_OnWorkEndStatusCallBack1;
            }

        }

        public void GetALLListProcedureButton()
        {
            ModuleInfoList moduleInfoList = VmSolution.Instance.GetAllModuleList();
            int ModulesCount = (int)moduleInfoList.nNum;
            ProcedureButton = new List<UIButton>[vmProcessInfoList.nNum];
            for (int m = 0; m < vmProcessInfoList.nNum; m++)
            {
                ProcedureButton[m] = new List<UIButton>();
            }

            for (int i = 0; i < ModulesCount; i++)
            {
                if (moduleInfoList.astModuleInfo[i].nProcessID == 10999)
                {
                    UIButton newBurron = new UIButton();
                    newBurron.Name = moduleInfoList.astModuleInfo[i].strModuleName;
                    newBurron.Text = moduleInfoList.astModuleInfo[i].strDisplayName;
                    newBurron.AutoSize = true;
                    GolButton.Add(newBurron);
                }
                else
                {

                    UIButton newBurron = new UIButton();
                    newBurron.Name = moduleInfoList.astModuleInfo[i].strModuleName;
                    newBurron.Text = vmProcessInfoList.astProcessInfo[moduleInfoList.astModuleInfo[i].nProcessID - 10000].strProcessName + "." + moduleInfoList.astModuleInfo[i].strDisplayName;
                    newBurron.AutoSize = true;
                    ProcedureButton[moduleInfoList.astModuleInfo[i].nProcessID - 10000].Add(newBurron);
                }
            }

        }

        public void ShowworkProcedure(VmRenderControl vmRender, int ProcedureIndex)
        {
            if (!IsSolutionLoad) return;
            if (workProcedure[ProcedureIndex] == null) return;
            vmRender.ModuleSource = workProcedure[ProcedureIndex];
        }

        public void ClearStatus()
        {
            VmProcedureRunFinished[0] = false;
            VmProcedureRunFinished[1] = false;
        }

        private void VisionMasterFunc_OnWorkEndStatusCallBack1(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            GlobalCommData.mRunStainsResult.IniResult();
            string strMessage = null;
            try
            {
                List<VmDynamicIODefine.IoNameInfo> ioNameInfos = workProcedure[1].ModuResult.GetAllOutputNameInfo();
                if (ioNameInfos.Count != 0)//Determine the number of process results
                {

                    int iGetImage = workProcedure[1].ModuResult.GetOutputInt("iGetImage").pIntVal[0];
                    if (iGetImage != GlobalCommData.mRunStainsResult.iGetimageFail)
                    {
                        CameraSn = GetGloCameraSN();
                        GlobalCommData.mRunStainsResult.iGetimageFail = iGetImage;
                        GlobalCommData.mRunStainsResult.bGetimage = false;
                    }
                    else
                    {
                        GlobalCommData.mRunStainsResult.bGetimage = true;
                        int iDLModule = workProcedure[1].ModuResult.GetOutputInt("iSegment").pIntVal[0];
                        if (iDLModule != 1)
                        {
                            GlobalCommData.mRunStainsResult.bDLModule = false;
                        }
                        else
                        {
                            GlobalCommData.mRunStainsResult.bDLModule = true;

                            //GlobalCommData.mRunStainsResult.iFindStains = 0;
                            GlobalCommData.mRunStainsResult.iFindStains = workProcedure[1].ModuResult.GetOutputInt("iBlackStains").pIntVal[0];
                            if (GlobalCommData.mRunStainsResult.iFindStains <= 0)
                                GlobalCommData.mRunStainsResult.bPass = true;
                            else
                                GlobalCommData.mRunStainsResult.bPass = false;


                        }
                    }

                    //string strResult = workProcedure[0].ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
                    if (!GlobalCommData.mRunStainsResult.bGetimage) strMessage = "Stains Check Lose Camera";
                    else strMessage = "Stains Check Result:" + GlobalCommData.mRunStainsResult.bPass + "; Process running time：" + workProcedure[1].ProcessTime.ToString() + "ms";
                    GlobalCommData.ShowLog(TAG, strMessage, MessageLevel.Info);
                }
                else
                {
                    strMessage = "Failed to get results On Stains Check: The result is empty!";
                    GlobalCommData.ShowLog(TAG, strMessage);
                }

            }
            catch
            {
                strMessage = "Failed to get results On Stains Check";
                GlobalCommData.ShowLog(TAG, strMessage);
            }
            VmProcedureRunFinished[1] = true;
        }

        private void VisionMasterFunc_OnWorkEndStatusCallBack(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            GlobalCommData.mRunCenterResult.IniResult();
            string strMessage = null;
            try
            {
                List<VmDynamicIODefine.IoNameInfo> ioNameInfos = workProcedure[0].ModuResult.GetAllOutputNameInfo();
                if (ioNameInfos.Count != 0)//Determine the number of process results
                {

                    int iGetImage = workProcedure[0].ModuResult.GetOutputInt("iGetImage").pIntVal[0];
                    if (iGetImage != GlobalCommData.mRunCenterResult.iGetimageFail)
                    {
                        CameraSn = GetGloCameraSN();
                        GlobalCommData.mRunCenterResult.iGetimageFail = iGetImage;
                        GlobalCommData.mRunCenterResult.bGetimage = false;
                    }
                    else
                    {
                        GlobalCommData.mRunCenterResult.bGetimage = true;
                        int iMatch = workProcedure[0].ModuResult.GetOutputInt("iMatch").pIntVal[0];
                        if (iMatch != 1)
                        {
                            GlobalCommData.mRunCenterResult.bMatchNozzle = false;
                        }
                        else
                        {
                            GlobalCommData.mRunCenterResult.bMatchNozzle = true;
                            int iFindNozzle = workProcedure[0].ModuResult.GetOutputInt("iFindNozzle").pIntVal[0];
                            if (iFindNozzle != 1)
                            {
                                GlobalCommData.mRunCenterResult.bFindNozzle = false;
                            }
                            else
                            {
                                GlobalCommData.mRunCenterResult.bFindNozzle = true;
                                int iFindLaser = workProcedure[0].ModuResult.GetOutputInt("iFindLaser").pIntVal[0];
                                if (iFindLaser != 1)
                                {
                                    GlobalCommData.mRunCenterResult.bFindLaser = false;
                                }
                                else
                                {
                                    GlobalCommData.mRunCenterResult.bFindLaser = true;
                                    string strNozzleRad = workProcedure[0].ModuResult.GetOutputString("strNozzleRad").astStringVal[0].strValue;
                                    string strLaserRad = workProcedure[0].ModuResult.GetOutputString("strLaserRad").astStringVal[0].strValue;
                                    string strDistance = workProcedure[0].ModuResult.GetOutputString("strDistance").astStringVal[0].strValue;

                                    GlobalCommData.mRunCenterResult.GetDistance(strNozzleRad, strLaserRad, strDistance);
                                }
                            }
                        }
                    }

                    //string strResult = workProcedure[0].ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
                    if (!GlobalCommData.mRunCenterResult.bGetimage) strMessage = "Center Check Lose Camera";
                    else strMessage = "Center Check Result:" + GlobalCommData.mRunCenterResult.bPass + "; Process running time：" + workProcedure[0].ProcessTime.ToString() + "ms";

                    //strMessage = "Center Check Result:" + GlobalCommData.mRunCenterResult.bPass + "; Process running time：" + workProcedure[0].ProcessTime.ToString() + "ms";
                    GlobalCommData.ShowLog(TAG, strMessage, MessageLevel.Info);
                }
                else
                {
                    strMessage = "Failed to get results On Center Check: The result is empty!";
                    GlobalCommData.ShowLog(TAG, strMessage);
                }

            }
            catch
            {
                strMessage = "Failed to get results On Center Check";
                GlobalCommData.ShowLog(TAG, strMessage);
            }
            VmProcedureRunFinished[0] = true;
        }

        public bool RunProcedureIndex(int Index)
        {
            try
            {
                if (vmProcessInfoList.nNum <= 0) return false;
                VmProcedureRunFinished[Index] = false;
                if (null == workProcedure[Index])
                {
                    ErrorMessage = "Vision Precedure Run Fail:Precedure is NULL!";
                    GlobalCommData.ShowLog(TAG, ErrorMessage, MessageLevel.Error, MessageType.Debug);
                    return false;
                }

                workProcedure[Index].Run();
                GlobalCommData.ShowLog(TAG, "Vision Precedure Running");
            }
            catch (VmException ex)
            {
                ErrorMessage = "Vision Precedure Run Fail!. Error Code: " + Convert.ToString(ex.errorCode, 16);
                GlobalCommData.ShowLog(TAG, ErrorMessage, MessageLevel.Error, MessageType.Debug);
                return false;
            }
            return true;
        }

        public bool RunContinueProcedureIndex(int Index)
        {
            try
            {
                if (vmProcessInfoList.nNum <= 0) return false;

                if (null == workProcedure[Index])
                {
                    ErrorMessage = "Vision Precedure Run Fail:Precedure is NULL!";
                    GlobalCommData.ShowLog(TAG, ErrorMessage, MessageLevel.Error, MessageType.Debug);
                    return false;
                }

                workProcedure[Index].ContinuousRunEnable = true;
                GlobalCommData.ShowLog(TAG, "Vision Precedure Running Continuous");
            }
            catch (VmException ex)
            {
                ErrorMessage = "Vision Precedure Run Fail!. Error Code: " + Convert.ToString(ex.errorCode, 16);
                GlobalCommData.ShowLog(TAG, ErrorMessage, MessageLevel.Error, MessageType.Debug);
                return false;
            }
            return true;
        }

        public bool StopContinueProcedureIndex(int Index)
        {
            try
            {
                if (vmProcessInfoList.nNum <= 0) return false;

                if (null == workProcedure[Index])
                {
                    ErrorMessage = "Vision Precedure Stop Fail:Precedure is NULL!";
                    GlobalCommData.ShowLog(TAG, ErrorMessage, MessageLevel.Error, MessageType.Debug);
                    return false;
                }

                workProcedure[Index].ContinuousRunEnable = false;
                GlobalCommData.ShowLog(TAG, "Vision Precedure Stop Continuous");
            }
            catch (VmException ex)
            {
                ErrorMessage = "Vision Precedure Stop Fail!. Error Code: " + Convert.ToString(ex.errorCode, 16);
                GlobalCommData.ShowLog(TAG, ErrorMessage, MessageLevel.Error, MessageType.Debug);
                return false;
            }
            return true;
        }

        public VmModule GetVmMoudle(string Name)
        {
            return (VmModule)VmSolution.Instance[Name];
        }

    }


}
