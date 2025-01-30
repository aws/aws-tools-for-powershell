/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.MachineLearning;
using Amazon.MachineLearning.Model;

namespace Amazon.PowerShell.Cmdlets.ML
{
    /// <summary>
    /// Creates a <c>DataSource</c> from a database hosted on an Amazon Redshift cluster.
    /// A <c>DataSource</c> references data that can be used to perform either <c>CreateMLModel</c>,
    /// <c>CreateEvaluation</c>, or <c>CreateBatchPrediction</c> operations.
    /// 
    ///  
    /// <para><c>CreateDataSourceFromRedshift</c> is an asynchronous operation. In response to
    /// <c>CreateDataSourceFromRedshift</c>, Amazon Machine Learning (Amazon ML) immediately
    /// returns and sets the <c>DataSource</c> status to <c>PENDING</c>. After the <c>DataSource</c>
    /// is created and ready for use, Amazon ML sets the <c>Status</c> parameter to <c>COMPLETED</c>.
    /// <c>DataSource</c> in <c>COMPLETED</c> or <c>PENDING</c> states can be used to perform
    /// only <c>CreateMLModel</c>, <c>CreateEvaluation</c>, or <c>CreateBatchPrediction</c>
    /// operations. 
    /// </para><para>
    ///  If Amazon ML can't accept the input source, it sets the <c>Status</c> parameter to
    /// <c>FAILED</c> and includes an error message in the <c>Message</c> attribute of the
    /// <c>GetDataSource</c> operation response. 
    /// </para><para>
    /// The observations should be contained in the database hosted on an Amazon Redshift
    /// cluster and should be specified by a <c>SelectSqlQuery</c> query. Amazon ML executes
    /// an <c>Unload</c> command in Amazon Redshift to transfer the result set of the <c>SelectSqlQuery</c>
    /// query to <c>S3StagingLocation</c>.
    /// </para><para>
    /// After the <c>DataSource</c> has been created, it's ready for use in evaluations and
    /// batch predictions. If you plan to use the <c>DataSource</c> to train an <c>MLModel</c>,
    /// the <c>DataSource</c> also requires a recipe. A recipe describes how each input variable
    /// will be used in training an <c>MLModel</c>. Will the variable be included or excluded
    /// from training? Will the variable be manipulated; for example, will it be combined
    /// with another variable or will it be split apart into word combinations? The recipe
    /// provides answers to these questions.
    /// </para><para>
    /// You can't change an existing datasource, but you can copy and modify the settings
    /// from an existing Amazon Redshift datasource to create a new datasource. To do so,
    /// call <c>GetDataSource</c> for an existing datasource and copy the values to a <c>CreateDataSource</c>
    /// call. Change the settings that you want to change and make sure that all required
    /// fields have the appropriate values.
    /// </para>
    /// </summary>
    [Cmdlet("New", "MLDataSourceFromRedshift", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Machine Learning CreateDataSourceFromRedshift API operation.", Operation = new[] {"CreateDataSourceFromRedshift"}, SelectReturnType = typeof(Amazon.MachineLearning.Model.CreateDataSourceFromRedshiftResponse))]
    [AWSCmdletOutput("System.String or Amazon.MachineLearning.Model.CreateDataSourceFromRedshiftResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MachineLearning.Model.CreateDataSourceFromRedshiftResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewMLDataSourceFromRedshiftCmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DatabaseInformation_ClusterIdentifier
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DataSpec_DatabaseInformation_ClusterIdentifier")]
        public System.String DatabaseInformation_ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter ComputeStatistic
        /// <summary>
        /// <para>
        /// <para>The compute statistics for a <c>DataSource</c>. The statistics are generated from
        /// the observation data referenced by a <c>DataSource</c>. Amazon ML uses the statistics
        /// internally during <c>MLModel</c> training. This parameter must be set to <c>true</c>
        /// if the <c>DataSource</c> needs to be used for <c>MLModel</c> training.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeStatistics")]
        public System.Boolean? ComputeStatistic { get; set; }
        #endregion
        
        #region Parameter DatabaseInformation_DatabaseName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DataSpec_DatabaseInformation_DatabaseName")]
        public System.String DatabaseInformation_DatabaseName { get; set; }
        #endregion
        
        #region Parameter DataSpec_DataRearrangement
        /// <summary>
        /// <para>
        /// <para>A JSON string that represents the splitting and rearrangement processing to be applied
        /// to a <c>DataSource</c>. If the <c>DataRearrangement</c> parameter is not provided,
        /// all of the input data is used to create the <c>Datasource</c>.</para><para>There are multiple parameters that control what data is used to create a datasource:</para><ul><li><para><b><c>percentBegin</c></b></para><para>Use <c>percentBegin</c> to indicate the beginning of the range of the data used to
        /// create the Datasource. If you do not include <c>percentBegin</c> and <c>percentEnd</c>,
        /// Amazon ML includes all of the data when creating the datasource.</para></li><li><para><b><c>percentEnd</c></b></para><para>Use <c>percentEnd</c> to indicate the end of the range of the data used to create
        /// the Datasource. If you do not include <c>percentBegin</c> and <c>percentEnd</c>, Amazon
        /// ML includes all of the data when creating the datasource.</para></li><li><para><b><c>complement</c></b></para><para>The <c>complement</c> parameter instructs Amazon ML to use the data that is not included
        /// in the range of <c>percentBegin</c> to <c>percentEnd</c> to create a datasource. The
        /// <c>complement</c> parameter is useful if you need to create complementary datasources
        /// for training and evaluation. To create a complementary datasource, use the same values
        /// for <c>percentBegin</c> and <c>percentEnd</c>, along with the <c>complement</c> parameter.</para><para>For example, the following two datasources do not share any data, and can be used
        /// to train and evaluate a model. The first datasource has 25 percent of the data, and
        /// the second one has 75 percent of the data.</para><para>Datasource for evaluation: <c>{"splitting":{"percentBegin":0, "percentEnd":25}}</c></para><para>Datasource for training: <c>{"splitting":{"percentBegin":0, "percentEnd":25, "complement":"true"}}</c></para></li><li><para><b><c>strategy</c></b></para><para>To change how Amazon ML splits the data for a datasource, use the <c>strategy</c>
        /// parameter.</para><para>The default value for the <c>strategy</c> parameter is <c>sequential</c>, meaning
        /// that Amazon ML takes all of the data records between the <c>percentBegin</c> and <c>percentEnd</c>
        /// parameters for the datasource, in the order that the records appear in the input data.</para><para>The following two <c>DataRearrangement</c> lines are examples of sequentially ordered
        /// training and evaluation datasources:</para><para>Datasource for evaluation: <c>{"splitting":{"percentBegin":70, "percentEnd":100, "strategy":"sequential"}}</c></para><para>Datasource for training: <c>{"splitting":{"percentBegin":70, "percentEnd":100, "strategy":"sequential",
        /// "complement":"true"}}</c></para><para>To randomly split the input data into the proportions indicated by the percentBegin
        /// and percentEnd parameters, set the <c>strategy</c> parameter to <c>random</c> and
        /// provide a string that is used as the seed value for the random data splitting (for
        /// example, you can use the S3 path to your data as the random seed string). If you choose
        /// the random split strategy, Amazon ML assigns each row of data a pseudo-random number
        /// between 0 and 100, and then selects the rows that have an assigned number between
        /// <c>percentBegin</c> and <c>percentEnd</c>. Pseudo-random numbers are assigned using
        /// both the input seed string value and the byte offset as a seed, so changing the data
        /// results in a different split. Any existing ordering is preserved. The random splitting
        /// strategy ensures that variables in the training and evaluation data are distributed
        /// similarly. It is useful in the cases where the input data may have an implicit sort
        /// order, which would otherwise result in training and evaluation datasources containing
        /// non-similar data records.</para><para>The following two <c>DataRearrangement</c> lines are examples of non-sequentially
        /// ordered training and evaluation datasources:</para><para>Datasource for evaluation: <c>{"splitting":{"percentBegin":70, "percentEnd":100, "strategy":"random",
        /// "randomSeed"="s3://my_s3_path/bucket/file.csv"}}</c></para><para>Datasource for training: <c>{"splitting":{"percentBegin":70, "percentEnd":100, "strategy":"random",
        /// "randomSeed"="s3://my_s3_path/bucket/file.csv", "complement":"true"}}</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSpec_DataRearrangement { get; set; }
        #endregion
        
        #region Parameter DataSpec_DataSchema
        /// <summary>
        /// <para>
        /// <para>A JSON string that represents the schema for an Amazon Redshift <c>DataSource</c>.
        /// The <c>DataSchema</c> defines the structure of the observation data in the data file(s)
        /// referenced in the <c>DataSource</c>.</para><para>A <c>DataSchema</c> is not required if you specify a <c>DataSchemaUri</c>.</para><para>Define your <c>DataSchema</c> as a series of key-value pairs. <c>attributes</c> and
        /// <c>excludedVariableNames</c> have an array of key-value pairs for their value. Use
        /// the following format to define your <c>DataSchema</c>.</para><para>{ "version": "1.0",</para><para>"recordAnnotationFieldName": "F1",</para><para>"recordWeightFieldName": "F2",</para><para>"targetFieldName": "F3",</para><para>"dataFormat": "CSV",</para><para>"dataFileContainsHeader": true,</para><para>"attributes": [</para><para>{ "fieldName": "F1", "fieldType": "TEXT" }, { "fieldName": "F2", "fieldType": "NUMERIC"
        /// }, { "fieldName": "F3", "fieldType": "CATEGORICAL" }, { "fieldName": "F4", "fieldType":
        /// "NUMERIC" }, { "fieldName": "F5", "fieldType": "CATEGORICAL" }, { "fieldName": "F6",
        /// "fieldType": "TEXT" }, { "fieldName": "F7", "fieldType": "WEIGHTED_INT_SEQUENCE" },
        /// { "fieldName": "F8", "fieldType": "WEIGHTED_STRING_SEQUENCE" } ],</para><para>"excludedVariableNames": [ "F6" ] }</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSpec_DataSchema { get; set; }
        #endregion
        
        #region Parameter DataSpec_DataSchemaUri
        /// <summary>
        /// <para>
        /// <para>Describes the schema location for an Amazon Redshift <c>DataSource</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSpec_DataSchemaUri { get; set; }
        #endregion
        
        #region Parameter DataSourceId
        /// <summary>
        /// <para>
        /// <para>A user-supplied ID that uniquely identifies the <c>DataSource</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DataSourceId { get; set; }
        #endregion
        
        #region Parameter DataSourceName
        /// <summary>
        /// <para>
        /// <para>A user-supplied name or description of the <c>DataSource</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSourceName { get; set; }
        #endregion
        
        #region Parameter DatabaseCredentials_Password
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DataSpec_DatabaseCredentials_Password")]
        public System.String DatabaseCredentials_Password { get; set; }
        #endregion
        
        #region Parameter RoleARN
        /// <summary>
        /// <para>
        /// <para>A fully specified role Amazon Resource Name (ARN). Amazon ML assumes the role on behalf
        /// of the user to create the following:</para><ul><li><para>A security group to allow Amazon ML to execute the <c>SelectSqlQuery</c> query on
        /// an Amazon Redshift cluster</para></li><li><para>An Amazon S3 bucket policy to grant Amazon ML read/write permissions on the <c>S3StagingLocation</c></para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String RoleARN { get; set; }
        #endregion
        
        #region Parameter DataSpec_S3StagingLocation
        /// <summary>
        /// <para>
        /// <para>Describes an Amazon S3 location to store the result set of the <c>SelectSqlQuery</c>
        /// query.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DataSpec_S3StagingLocation { get; set; }
        #endregion
        
        #region Parameter DataSpec_SelectSqlQuery
        /// <summary>
        /// <para>
        /// <para>Describes the SQL Query to execute on an Amazon Redshift database for an Amazon Redshift
        /// <c>DataSource</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DataSpec_SelectSqlQuery { get; set; }
        #endregion
        
        #region Parameter DatabaseCredentials_Username
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DataSpec_DatabaseCredentials_Username")]
        public System.String DatabaseCredentials_Username { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataSourceId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MachineLearning.Model.CreateDataSourceFromRedshiftResponse).
        /// Specifying the name of a property of type Amazon.MachineLearning.Model.CreateDataSourceFromRedshiftResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DataSourceId";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DataSourceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MLDataSourceFromRedshift (CreateDataSourceFromRedshift)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MachineLearning.Model.CreateDataSourceFromRedshiftResponse, NewMLDataSourceFromRedshiftCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ComputeStatistic = this.ComputeStatistic;
            context.DataSourceId = this.DataSourceId;
            #if MODULAR
            if (this.DataSourceId == null && ParameterWasBound(nameof(this.DataSourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter DataSourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataSourceName = this.DataSourceName;
            context.DatabaseCredentials_Password = this.DatabaseCredentials_Password;
            #if MODULAR
            if (this.DatabaseCredentials_Password == null && ParameterWasBound(nameof(this.DatabaseCredentials_Password)))
            {
                WriteWarning("You are passing $null as a value for parameter DatabaseCredentials_Password which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DatabaseCredentials_Username = this.DatabaseCredentials_Username;
            #if MODULAR
            if (this.DatabaseCredentials_Username == null && ParameterWasBound(nameof(this.DatabaseCredentials_Username)))
            {
                WriteWarning("You are passing $null as a value for parameter DatabaseCredentials_Username which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DatabaseInformation_ClusterIdentifier = this.DatabaseInformation_ClusterIdentifier;
            #if MODULAR
            if (this.DatabaseInformation_ClusterIdentifier == null && ParameterWasBound(nameof(this.DatabaseInformation_ClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DatabaseInformation_ClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DatabaseInformation_DatabaseName = this.DatabaseInformation_DatabaseName;
            #if MODULAR
            if (this.DatabaseInformation_DatabaseName == null && ParameterWasBound(nameof(this.DatabaseInformation_DatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatabaseInformation_DatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataSpec_DataRearrangement = this.DataSpec_DataRearrangement;
            context.DataSpec_DataSchema = this.DataSpec_DataSchema;
            context.DataSpec_DataSchemaUri = this.DataSpec_DataSchemaUri;
            context.DataSpec_S3StagingLocation = this.DataSpec_S3StagingLocation;
            #if MODULAR
            if (this.DataSpec_S3StagingLocation == null && ParameterWasBound(nameof(this.DataSpec_S3StagingLocation)))
            {
                WriteWarning("You are passing $null as a value for parameter DataSpec_S3StagingLocation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataSpec_SelectSqlQuery = this.DataSpec_SelectSqlQuery;
            #if MODULAR
            if (this.DataSpec_SelectSqlQuery == null && ParameterWasBound(nameof(this.DataSpec_SelectSqlQuery)))
            {
                WriteWarning("You are passing $null as a value for parameter DataSpec_SelectSqlQuery which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleARN = this.RoleARN;
            #if MODULAR
            if (this.RoleARN == null && ParameterWasBound(nameof(this.RoleARN)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.MachineLearning.Model.CreateDataSourceFromRedshiftRequest();
            
            if (cmdletContext.ComputeStatistic != null)
            {
                request.ComputeStatistics = cmdletContext.ComputeStatistic.Value;
            }
            if (cmdletContext.DataSourceId != null)
            {
                request.DataSourceId = cmdletContext.DataSourceId;
            }
            if (cmdletContext.DataSourceName != null)
            {
                request.DataSourceName = cmdletContext.DataSourceName;
            }
            
             // populate DataSpec
            var requestDataSpecIsNull = true;
            request.DataSpec = new Amazon.MachineLearning.Model.RedshiftDataSpec();
            System.String requestDataSpec_dataSpec_DataRearrangement = null;
            if (cmdletContext.DataSpec_DataRearrangement != null)
            {
                requestDataSpec_dataSpec_DataRearrangement = cmdletContext.DataSpec_DataRearrangement;
            }
            if (requestDataSpec_dataSpec_DataRearrangement != null)
            {
                request.DataSpec.DataRearrangement = requestDataSpec_dataSpec_DataRearrangement;
                requestDataSpecIsNull = false;
            }
            System.String requestDataSpec_dataSpec_DataSchema = null;
            if (cmdletContext.DataSpec_DataSchema != null)
            {
                requestDataSpec_dataSpec_DataSchema = cmdletContext.DataSpec_DataSchema;
            }
            if (requestDataSpec_dataSpec_DataSchema != null)
            {
                request.DataSpec.DataSchema = requestDataSpec_dataSpec_DataSchema;
                requestDataSpecIsNull = false;
            }
            System.String requestDataSpec_dataSpec_DataSchemaUri = null;
            if (cmdletContext.DataSpec_DataSchemaUri != null)
            {
                requestDataSpec_dataSpec_DataSchemaUri = cmdletContext.DataSpec_DataSchemaUri;
            }
            if (requestDataSpec_dataSpec_DataSchemaUri != null)
            {
                request.DataSpec.DataSchemaUri = requestDataSpec_dataSpec_DataSchemaUri;
                requestDataSpecIsNull = false;
            }
            System.String requestDataSpec_dataSpec_S3StagingLocation = null;
            if (cmdletContext.DataSpec_S3StagingLocation != null)
            {
                requestDataSpec_dataSpec_S3StagingLocation = cmdletContext.DataSpec_S3StagingLocation;
            }
            if (requestDataSpec_dataSpec_S3StagingLocation != null)
            {
                request.DataSpec.S3StagingLocation = requestDataSpec_dataSpec_S3StagingLocation;
                requestDataSpecIsNull = false;
            }
            System.String requestDataSpec_dataSpec_SelectSqlQuery = null;
            if (cmdletContext.DataSpec_SelectSqlQuery != null)
            {
                requestDataSpec_dataSpec_SelectSqlQuery = cmdletContext.DataSpec_SelectSqlQuery;
            }
            if (requestDataSpec_dataSpec_SelectSqlQuery != null)
            {
                request.DataSpec.SelectSqlQuery = requestDataSpec_dataSpec_SelectSqlQuery;
                requestDataSpecIsNull = false;
            }
            Amazon.MachineLearning.Model.RedshiftDatabaseCredentials requestDataSpec_dataSpec_DatabaseCredentials = null;
            
             // populate DatabaseCredentials
            var requestDataSpec_dataSpec_DatabaseCredentialsIsNull = true;
            requestDataSpec_dataSpec_DatabaseCredentials = new Amazon.MachineLearning.Model.RedshiftDatabaseCredentials();
            System.String requestDataSpec_dataSpec_DatabaseCredentials_databaseCredentials_Password = null;
            if (cmdletContext.DatabaseCredentials_Password != null)
            {
                requestDataSpec_dataSpec_DatabaseCredentials_databaseCredentials_Password = cmdletContext.DatabaseCredentials_Password;
            }
            if (requestDataSpec_dataSpec_DatabaseCredentials_databaseCredentials_Password != null)
            {
                requestDataSpec_dataSpec_DatabaseCredentials.Password = requestDataSpec_dataSpec_DatabaseCredentials_databaseCredentials_Password;
                requestDataSpec_dataSpec_DatabaseCredentialsIsNull = false;
            }
            System.String requestDataSpec_dataSpec_DatabaseCredentials_databaseCredentials_Username = null;
            if (cmdletContext.DatabaseCredentials_Username != null)
            {
                requestDataSpec_dataSpec_DatabaseCredentials_databaseCredentials_Username = cmdletContext.DatabaseCredentials_Username;
            }
            if (requestDataSpec_dataSpec_DatabaseCredentials_databaseCredentials_Username != null)
            {
                requestDataSpec_dataSpec_DatabaseCredentials.Username = requestDataSpec_dataSpec_DatabaseCredentials_databaseCredentials_Username;
                requestDataSpec_dataSpec_DatabaseCredentialsIsNull = false;
            }
             // determine if requestDataSpec_dataSpec_DatabaseCredentials should be set to null
            if (requestDataSpec_dataSpec_DatabaseCredentialsIsNull)
            {
                requestDataSpec_dataSpec_DatabaseCredentials = null;
            }
            if (requestDataSpec_dataSpec_DatabaseCredentials != null)
            {
                request.DataSpec.DatabaseCredentials = requestDataSpec_dataSpec_DatabaseCredentials;
                requestDataSpecIsNull = false;
            }
            Amazon.MachineLearning.Model.RedshiftDatabase requestDataSpec_dataSpec_DatabaseInformation = null;
            
             // populate DatabaseInformation
            var requestDataSpec_dataSpec_DatabaseInformationIsNull = true;
            requestDataSpec_dataSpec_DatabaseInformation = new Amazon.MachineLearning.Model.RedshiftDatabase();
            System.String requestDataSpec_dataSpec_DatabaseInformation_databaseInformation_ClusterIdentifier = null;
            if (cmdletContext.DatabaseInformation_ClusterIdentifier != null)
            {
                requestDataSpec_dataSpec_DatabaseInformation_databaseInformation_ClusterIdentifier = cmdletContext.DatabaseInformation_ClusterIdentifier;
            }
            if (requestDataSpec_dataSpec_DatabaseInformation_databaseInformation_ClusterIdentifier != null)
            {
                requestDataSpec_dataSpec_DatabaseInformation.ClusterIdentifier = requestDataSpec_dataSpec_DatabaseInformation_databaseInformation_ClusterIdentifier;
                requestDataSpec_dataSpec_DatabaseInformationIsNull = false;
            }
            System.String requestDataSpec_dataSpec_DatabaseInformation_databaseInformation_DatabaseName = null;
            if (cmdletContext.DatabaseInformation_DatabaseName != null)
            {
                requestDataSpec_dataSpec_DatabaseInformation_databaseInformation_DatabaseName = cmdletContext.DatabaseInformation_DatabaseName;
            }
            if (requestDataSpec_dataSpec_DatabaseInformation_databaseInformation_DatabaseName != null)
            {
                requestDataSpec_dataSpec_DatabaseInformation.DatabaseName = requestDataSpec_dataSpec_DatabaseInformation_databaseInformation_DatabaseName;
                requestDataSpec_dataSpec_DatabaseInformationIsNull = false;
            }
             // determine if requestDataSpec_dataSpec_DatabaseInformation should be set to null
            if (requestDataSpec_dataSpec_DatabaseInformationIsNull)
            {
                requestDataSpec_dataSpec_DatabaseInformation = null;
            }
            if (requestDataSpec_dataSpec_DatabaseInformation != null)
            {
                request.DataSpec.DatabaseInformation = requestDataSpec_dataSpec_DatabaseInformation;
                requestDataSpecIsNull = false;
            }
             // determine if request.DataSpec should be set to null
            if (requestDataSpecIsNull)
            {
                request.DataSpec = null;
            }
            if (cmdletContext.RoleARN != null)
            {
                request.RoleARN = cmdletContext.RoleARN;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.MachineLearning.Model.CreateDataSourceFromRedshiftResponse CallAWSServiceOperation(IAmazonMachineLearning client, Amazon.MachineLearning.Model.CreateDataSourceFromRedshiftRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Machine Learning", "CreateDataSourceFromRedshift");
            try
            {
                #if DESKTOP
                return client.CreateDataSourceFromRedshift(request);
                #elif CORECLR
                return client.CreateDataSourceFromRedshiftAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.Boolean? ComputeStatistic { get; set; }
            public System.String DataSourceId { get; set; }
            public System.String DataSourceName { get; set; }
            public System.String DatabaseCredentials_Password { get; set; }
            public System.String DatabaseCredentials_Username { get; set; }
            public System.String DatabaseInformation_ClusterIdentifier { get; set; }
            public System.String DatabaseInformation_DatabaseName { get; set; }
            public System.String DataSpec_DataRearrangement { get; set; }
            public System.String DataSpec_DataSchema { get; set; }
            public System.String DataSpec_DataSchemaUri { get; set; }
            public System.String DataSpec_S3StagingLocation { get; set; }
            public System.String DataSpec_SelectSqlQuery { get; set; }
            public System.String RoleARN { get; set; }
            public System.Func<Amazon.MachineLearning.Model.CreateDataSourceFromRedshiftResponse, NewMLDataSourceFromRedshiftCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataSourceId;
        }
        
    }
}
