using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Honeywell.Tools.GraphicsMatch.Library
{
    public interface IFXBPointFileParser
    {
        bool FxbPointParseInputFile(IProject pii_Project, ProgressStatus pii_ProgressStatus, UpdateProgress pii_UpdateProgress);

        bool Delete(List<IImportedFile> pilst_FxbPointFiles, IProject pii_Project);

        DataTable Load(IProject pii_Project);

        DataRow SearchFxbTxtRecord(int pi32_FileID, IProject pii_Project);
    }
}
