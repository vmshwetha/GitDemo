using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Honeywell.Tools.GraphicsMatch.Library
{
  
    public interface IEBFileParser
    {
      bool EBParseInputFile(IProject pii_Project,ProgressStatus pii_ProgressStatus, UpdateProgress pii_UpdateProgress);
      
      bool Delete(List<IImportedFile> pilst_EBFiles, IProject pii_Project);

      DataTable Load(IProject pii_Project);

      DataRow SearchEBRecord(int pi32_FileID, IProject pii_Project);
    }

}
