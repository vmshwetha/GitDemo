/****************************************************************************************
 *                              COPYRIGHT (c) 2011-2012                                 *
 *                              HONEYWELL INTERNATIONAL INC.                            *
 *                                 ALL RIGHTS RESERVED                                  *
 *                                                                                      *
 *  Legal rights of Honeywell International Inc. in this software is distinct           *
 *  from ownership of any medium in which the software is embodied. Copyright           *
 *  notices must be reproduced in any copies authorized by Honeywell International Inc. *
 *                                                                                      *
 *  File Name    :                                                                      *
 *  Description  :                                                                      *
 *  Author(s)    :                                                                      *
 *  Reviewer(s)  :                                                                      *
 *                                                                                      *
 *  Revision History:                                                                   *
 *  ---------------------------------------------------------------------------------   *
 *  |  Date       |           Description                     |    Author           |   *
 *  ---------------------------------------------------------------------------------   *
 *  | 22-dec-2011 | Initial Version of this document          |   R M Shabu         |   *
 *                                                              Rakshitha Prabhu        *
 *                                                                                      *
 ****************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Honeywell.Tools.GraphicsMatch.Library
{
    public interface IGlobal
    {

        IDestinationSystemTypes DestinationSystemTypes
        {
            get;
        }         

        ISourceSystemTypes SourceSystemTypes
        {
            get;
        }

        IFileParser FileParser
        {
            get;
        }

        //Start : Added code for parsing foxboro txt/cmd Files
        IFXBPointFileParser FxbPointFileParser
        {
            get;
        }
        //End : Added code for parsing foxboro txt/cmd Files

        IImageFileParser ImageFileParser
        {
            get;
        }

        IBaileyPointFileParser PointFileParser
        {
            get;
        }

        IEBFileParser EBFileParser
        {
            get;
        }
        IIntermediateMigration IntermediateMigration
        {
            get;
        }

        IGraphicsGeneration GraphicsGeneration
        {
            get;
        }
        IShapeGraphicsGeneration ShapeGraphicsGeneration
        {
            get;
        }

       IProjects Projects
        {
            get;
        }

        IObjectMappingCollection ObjectMappingCollection
        {
            get;
            set;
        }

        IParameterMappingCollection ParameterMappingCollection
        {
            get;
            set;
        }

        IShapeMappingCollection ShapeMappingCollection
        {
            get;
            set;
        }          

        IDefaultValueMappingCollection DefaultValueMappingCollection
        {
            get;
            set;
        }

        IPointTypeParameterMapCollection PointTypeParameterMapCollection
        {
            get;
            set;
        }

        IKeywordMapCollection KeywordMapCollection
        {
            get;
            set;
        }

        IDatabaseExport DatabaseExport
        {
            get;
            set;
        }

        IDatabaseImport DatabaseImport
        {
            get;
            set;
        }

        IObjectReplacement ObjectReplacement
        {
            get;
        }

        IRuleUtility RuleUtility
        {
            get;
        }

        ISearchUtility SearchUtility
        {
            get;
        }

        IValidations ValidationUtility
        {
            get;
        }

        IDatabaseManager ProjectDAL
        {
            get; 
        } 
        string LogFilePath
        {
            get;
        }

        IPropertyValueConversion PropertyValueConversion
        {
            get;
        }
        ILogComponent Logging
        {
            get;
        }

        string GlobalLogPath
        {
            get;
           
        }
        IDatabaseManager GetDatabaseManager(string pistr_TempPath);

        DataTable ObjectReplacementFunctionality
        {
            get;
        }
        IReport Report
        { 
            get;
        }

        string OfficeVersion
        {
            get;
            set;
        }
    }
     
}
