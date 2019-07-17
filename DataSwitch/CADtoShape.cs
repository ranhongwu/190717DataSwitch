using System.Collections;
using System.Collections.Generic;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Windows.Forms;

/*-------------------------------------------------------------------------------------------------
     Author: Ran Hongwu
     Date: 2019/07/17
     Description:将CAD要素类中的点线面和注记按相应的"Layer"属性导出为shp文件
     
     Alter History
        Version        |Date            |Log
        ------------------------------------------------------------
        v1.0           |2019/07/17      |
        ------------------------------------------------------------
         
     --------------------------------------------------------------------------------------------------*/

namespace DataSwitch
{
    /// <summary>
    /// 提供将CAD要素类的指定"Layer"属性要素转换为shp文件的方法
    /// </summary>
    public class CADtoShape
    {
        #region 定义变量
        /// <summary>
        /// 定义CAD工作空间
        /// </summary>
        private IWorkspaceFactory pWorkspaceFactory=new CadWorkspaceFactoryClass();
        private IFeatureWorkspace pFeaWorkspace;
        private string CADPath;
        private string SavePath;
        private string TypeTag;
        IFeatureClassContainer pFeaClassContainer;
        #endregion


        #region 构造函数
        /// <summary>
        /// 初始化CADtoShape类（进行转换操作时）
        /// </summary>
        /// <param name="_CADPath">"*.dwg"文件的路径</param>
        public CADtoShape(string _CADPath,string savePath,string _TypeTag)
        {
            CADPath = _CADPath;
            //建立存储点线面的文件夹
            int index = CADPath.LastIndexOf("\\");
            string name = CADPath.Substring(index + 1);
            string path = CADPath.Substring(0, index);
            pFeaWorkspace = pWorkspaceFactory.OpenFromFile(path, 0) as IFeatureWorkspace;
            SavePath = savePath;//导出要素的路径
            TypeTag = _TypeTag;
            IFeatureDataset pFeaDataset = pFeaWorkspace.OpenFeatureDataset(name);
            pFeaClassContainer = pFeaDataset as IFeatureClassContainer;
        }

        /// <summary>
        /// 初始化CADtoShape类（遍历属性表操作时）
        /// </summary>
        /// <param name="_CADPath"></param>
        public CADtoShape(string _CADPath)
        {
            CADPath = _CADPath;
            //建立存储点线面的文件夹
            int index = CADPath.LastIndexOf("\\");
            string name = CADPath.Substring(index + 1);
            string path = CADPath.Substring(0, index);
            pFeaWorkspace = pWorkspaceFactory.OpenFromFile(path, 0) as IFeatureWorkspace;
            IFeatureDataset pFeaDataset = pFeaWorkspace.OpenFeatureDataset(name);
            pFeaClassContainer = pFeaDataset as IFeatureClassContainer;
        }
        #endregion


        #region 集成方法，直接在前端调用
        /// <summary>
        /// 返回点线面注记的Layer字段属性唯一值列表
        /// </summary>
        /// <param name="tab">标注要素类型的标签，值为"Point","Polyline","Polygon","Annotation"</param>
        /// <returns>返回"Layer"属性字段的唯一值列表</returns>
        public List<string> getUniqueAttByFeaType(string tab)
        {
            List<string> uniqueAtt = new List<string>();
            IFeatureClass pFeatureClass;
            try
            {
                switch (tab)
                {
                    //点
                    case "1":
                        pFeatureClass = pFeaClassContainer.ClassByName["Point"];
                        uniqueAtt = getUniqueValue(pFeatureClass, "Layer");
                        break;
                    //线
                    case "2":
                        pFeatureClass = pFeaClassContainer.ClassByName["Polyline"];
                        uniqueAtt = getUniqueValue(pFeatureClass, "Layer");
                        break;
                    //面
                    case "3":
                        pFeatureClass = pFeaClassContainer.ClassByName["Polygon"];
                        uniqueAtt = getUniqueValue(pFeatureClass, "Layer");
                        break;
                    //注记
                    case "4":
                        pFeatureClass = pFeaClassContainer.ClassByName["Annotation"];
                        uniqueAtt = getUniqueValue(pFeatureClass, "Layer");
                        break;
                    default:
                        break;
                }
                return uniqueAtt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        
        /// <summary>
        /// 将CAD的"*.dwg"文件根据要素类型（点线面）和选择的唯一值属性，转换为相应名称的FeatureClass
        /// </summary>
        public void CADLayerToFeatureClass(List<string> FeatureClassNameList)
        {
            List<IFeatureClass> featureClassList = new List<IFeatureClass>();
            //存在不同要素类型但是"Layer"属性唯一值相同的情况，需要进行区分
            List<string> fileNameList = new List<string>();
            for(int i = 0; i < FeatureClassNameList.Count; i++)
            {
                fileNameList.Add(String.Concat(TypeTag.ToUpper(),"-", FeatureClassNameList[i]));
            }
            IFeatureClass CADFeatureClass;
            int n = FeatureClassNameList.Count;
            int x = pFeaClassContainer.ClassCount;
            CADFeatureClass = pFeaClassContainer.ClassByName[TypeTag];
            try
            {
                featureClassList = ExportFeatureClassByAtt(CADFeatureClass, SavePath, fileNameList);
                for (int i = 0; i < n; i++)
                {
                    CreateFeatureClassByAtt(fileNameList[i], featureClassList[i], CADFeatureClass);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        #region 工具方法
        /// <summary>
        /// 复制featureclass图形和属性的方法
        /// </summary>
        /// <param name="name">待创建要素类的名称</param>
        /// <param name="target_FeatureClass">需要写入图形和属性的空要素</param>
        /// <param name="CADFeatureClass">需要复制的CAD要素类</param>
        public void CreateFeatureClassByAtt(string name,IFeatureClass target_FeatureClass,IFeatureClass CADFeatureClass)
        {
            List<string> AttList = new List<string>();
            IQueryFilter pQueryFilter = new QueryFilterClass();
            IFeatureCursor pFeaCursor;
            IFeature pFeature;
            IFeatureBuffer pFeaBuffer = null;
            AttList = getUniqueValue(CADFeatureClass, "Layer");
            pQueryFilter.WhereClause = "Layer = '" + name.Substring(name.IndexOf('-')+1) + "'";
            pFeaCursor = CADFeatureClass.Search(pQueryFilter, false);
            //用IFeatureBuffer提高运算速度
            IFeatureCursor targetCursor = target_FeatureClass.Insert(true);
            while ((pFeature = pFeaCursor.NextFeature()) != null)
            {
                pFeaBuffer = target_FeatureClass.CreateFeatureBuffer();
                IGeoDataset pGeoDataset = pFeature.Class as IGeoDataset;
                pFeaBuffer.Shape = pFeature.Shape;
                for (int j = 2; j < CADFeatureClass.Fields.FieldCount; j++)
                {
                    try
                    {
                        pFeaBuffer.set_Value(j, pFeature.Value[CADFeatureClass.FindField(target_FeatureClass.Fields.Field[j].Name)]);
                    }catch
                    {
                       continue;
                    }   
                }
                targetCursor.InsertFeature(pFeaBuffer);
                targetCursor.Flush();
            }
        }

        /// <summary>
        /// 查找某一属性的唯一值，返回属性唯一值的列表
        /// </summary>
        /// <param name="pFeatureClass">待查找的FeatureClass</param>
        /// <param name="field">待查找唯一值的字段</param>
        /// <returns>返回字段唯一值字符串的唯一值列表</returns>
        public List<string> getUniqueValue(IFeatureClass pFeatureClass, string field)
        {
            string s = pFeatureClass.AliasName;
            List<string> uniqueValue = new List<string>();
            IFeatureCursor pCursor = pFeatureClass.Search(null, false);
            IDataStatistics pDataStat = new DataStatisticsClass();
            pDataStat.Field = field;
            pDataStat.Cursor = pCursor as ICursor;
            IEnumerator pEnumerator = pDataStat.UniqueValues;
            pEnumerator.Reset();
            while (pEnumerator.MoveNext())
            {
                uniqueValue.Add(pEnumerator.Current.ToString());
            }
            return uniqueValue;
        }

        /// <summary>
        /// 根据属性不同建立空的shp文件
        /// </summary>
        /// <param name="CADfeatureClass">待转换的CAD要素类</param>
        /// <param name="ShpPath">存储新建空shp文件的路径</param>
        /// <returns>返回创建好的FeatureClass列表</returns>
        private List<IFeatureClass> ExportFeatureClassByAtt(IFeatureClass CADfeatureClass, string ShpPath, List<string> FieldName)
        {
            List<string> AttList = new List<string>();
            List<IFeatureClass> feaClassList = new List<IFeatureClass>();
            IFeatureClass target_FeatureClass;
            ISpatialReferenceFactory spatialReferenceFactory = new SpatialReferenceEnvironmentClass();
            string s = CADfeatureClass.ShapeType.ToString();

            //定义属性字段
            DataManager DM = new DataManager();
            IFields pFields = new FieldsClass();
            IFieldsEdit pFieldsEdit = (IFieldsEdit)pFields;
            IField pField = new FieldClass();
            IFieldEdit pFieldEdit = (IFieldEdit)pField;

            //设置地理属性字段，点线面，空间参考等
            pFieldEdit.Name_2 = "shape";
            pFieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
            IGeometryDef pGeoDef = new GeometryDefClass();
            IGeometryDefEdit pGeoDefEdit = pGeoDef as IGeometryDefEdit;
            pGeoDefEdit.GeometryType_2 = CADfeatureClass.ShapeType;
            pGeoDefEdit.HasM_2 = true;
            pGeoDefEdit.HasZ_2 = true;
            ISpatialReference spatialReference = DataManager.getSpatialReference(CADfeatureClass);
            pFieldEdit.GeometryDef_2 = pGeoDef;
            pFieldsEdit.AddField(pField);

            //遍历各字段设置其他属性字段
            for (int i = 2; i < CADfeatureClass.Fields.FieldCount; i++)
            {
                pField = new FieldClass();
                pFieldEdit = (IFieldEdit)pField;
                pFieldEdit.Name_2 = CADfeatureClass.Fields.Field[i].Name;
                pFieldEdit.AliasName_2 = CADfeatureClass.Fields.Field[i].AliasName;
                pFieldEdit.Type_2 = CADfeatureClass.Fields.Field[i].Type;
                pFieldsEdit.AddField(pField);
            }
            AttList = getUniqueValue(CADfeatureClass, "Layer");
            int n = FieldName.Count;
            for (int i = 0; i < n; i++)
            {
                //建立空的shapefile
                target_FeatureClass = DM.CreateVoidShp(ShpPath, FieldName[i], pFields, spatialReference);
                feaClassList.Add(target_FeatureClass);
            }
            return feaClassList;
        }
        #endregion
    }
}