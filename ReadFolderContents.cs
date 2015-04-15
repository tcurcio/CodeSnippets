/*
	A simple console app that recursively checks a folder for files.
	
*/
static string rootPath = "ROOTPATH";
        static void Main(string[] args)
        {
            
            System.IO.DirectoryInfo ob = new System.IO.DirectoryInfo(@"D:\documentUploads");

            foreach (System.IO.DirectoryInfo dt in ob.GetDirectories())
            {
                ProcessDirectory(dt.FullName);  
            }

            ReadFiles(ob.FullName);

            Console.ReadLine();
        }

        static void ReadFiles(string dir)
        {
            //upload file
                if (new System.IO.DirectoryInfo(dir).GetFiles().Length > 0)
                {
                    foreach (System.IO.FileInfo ft in new System.IO.DirectoryInfo(dir).GetFiles())
                    {
                        System.IO.File.Move(ft.FullName, rootPath + ft.Name);
                    }
                }
        }


        static void ProcessDirectory(string dir)
        {
            if (new System.IO.DirectoryInfo(dir).GetDirectories().Length == 0)
            {
                ReadFiles(dir);
            }
            else
            {

                ReadFiles(dir);

                foreach (System.IO.DirectoryInfo dt in new System.IO.DirectoryInfo(dir).GetDirectories())
                {
                    ReadFiles(dt.FullName);

                    if (dt.GetDirectories().Length > 0)
                    {
                        foreach (System.IO.DirectoryInfo obj in dt.GetDirectories())
                        {
                            Console.WriteLine("foldername: " + obj.FullName);
                            ProcessDirectory(obj.FullName);
                        }
                    }
                    
                }
            }
        }
