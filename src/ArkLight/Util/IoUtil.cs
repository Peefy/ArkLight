using System.IO;

namespace ArkLight.Util
{
    public class IoUtil
    {

        /// <summary>
        /// 检查文件是否真实存在。
        /// </summary>
        /// <param name="path">文件全名（包括路径）。</param>
        /// <returns>Boolean</returns>
        public static bool IsFileExists(string path)
        {
            try
            {
                return File.Exists(path);
            }
            catch
            { return false; }
        }

        /// <summary>
        /// 检查目录是否真实存在。
        /// </summary>
        /// <param name="path">目录路径.</param>
        /// <returns>Boolean</returns>
        public static bool IsDirectoryExists(string path)
        {
            try
            {
                return Directory.Exists(Path.GetDirectoryName(path));
            }
            catch
            { return false; }
        }

        /// <summary>
        /// 查找文件中是否存在匹配行。
        /// </summary>
        /// <param name="fi">目标文件.</param>
        /// <param name="lineText">要查找的行文本.</param>
        /// <param name="lowerUpper">是否区分大小写.</param>
        /// <returns>Boolean</returns>
        public static bool FindLineTextFromFile(FileInfo fi, string lineText, bool lowerUpper)
        {
            bool b = false;
            try
            {
                if (fi.Exists)
                {
                    StreamReader sr = new StreamReader(fi.FullName);
                    string g = "";
                    do
                    {
                        g = sr.ReadLine();
                        if (lowerUpper)
                        {
                            if (NumberUtil.ToObjectString(g).Trim() == NumberUtil.ToObjectString(lineText).Trim())
                            {
                                b = true;
                                break;
                            }
                        }
                        else
                        {
                            if (NumberUtil.ToObjectString(g).Trim().ToLower() == NumberUtil.ToObjectString(lineText).Trim().ToLower())
                            {
                                b = true;
                                break;
                            }
                        }
                    }
                    while (sr.Peek() != -1);
                    sr.Close();
                }
            }
            catch
            { b = false; }
            return b;
        }
    }

}
