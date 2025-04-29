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
using System.Threading;
using Amazon.MachineLearning;
using Amazon.MachineLearning.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ML
{
    /// <summary>
    /// Creates a <c>DataSource</c> object. A <c>DataSource</c> references data that can be
    /// used to perform <c>CreateMLModel</c>, <c>CreateEvaluation</c>, or <c>CreateBatchPrediction</c>
    /// operations.
    /// 
    ///  
    /// <para><c>CreateDataSourceFromS3</c> is an asynchronous operation. In response to <c>CreateDataSourceFromS3</c>,
    /// Amazon Machine Learning (Amazon ML) immediately returns and sets the <c>DataSource</c>
    /// status to <c>PENDING</c>. After the <c>DataSource</c> has been created and is ready
    /// for use, Amazon ML sets the <c>Status</c> parameter to <c>COMPLETED</c>. <c>DataSource</c>
    /// in the <c>COMPLETED</c> or <c>PENDING</c> state can be used to perform only <c>CreateMLModel</c>,
    /// <c>CreateEvaluation</c> or <c>CreateBatchPrediction</c> operations. 
    /// </para><para>
    ///  If Amazon ML can't accept the input source, it sets the <c>Status</c> parameter to
    /// <c>FAILED</c> and includes an error message in the <c>Message</c> attribute of the
    /// <c>GetDataSource</c> operation response. 
    /// </para><para>
    /// The observation data used in a <c>DataSource</c> should be ready to use; that is,
    /// it should have a consistent structure, and missing data values should be kept to a
    /// minimum. The observation data must reside in one or more .csv files in an Amazon Simple
    /// Storage Service (Amazon S3) location, along with a schema that describes the data
    /// items by name and type. The same schema must be used for all of the data files referenced
    /// by the <c>DataSource</c>. 
    /// </para><para>
    /// After the <c>DataSource</c> has been created, it's ready to use in evaluations and
    /// batch predictions. If you plan to use the <c>DataSource</c> to train an <c>MLModel</c>,
    /// the <c>DataSource</c> also needs a recipe. A recipe describes how each input variable
    /// will be used in training an <c>MLModel</c>. Will the variable be included or excluded
    /// from training? Will the variable be manipulated; for example, will it be combined
    /// with another variable or will it be split apart into word combinations? The recipe
    /// provides answers to these questions.
    /// </para>
    /// </summary>
    [Cmdlet("New", "MLDataSourceFromS3", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Machine Learning CreateDataSourceFromS3 API operation.", Operation = new[] {"CreateDataSourceFromS3"}, SelectReturnType = typeof(Amazon.MachineLearning.Model.CreateDataSourceFromS3Response))]
    [AWSCmdletOutput("System.String or Amazon.MachineLearning.Model.CreateDataSourceFromS3Response",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MachineLearning.Model.CreateDataSourceFromS3Response) can be returned by specifying '-Select *'."
    )]
    public partial class NewMLDataSourceFromS3Cmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ComputeStatistic
        /// <summary>
        /// <para>
        /// <para>The compute statistics for a <c>DataSource</c>. The statistics are generated from
        /// the observation data referenced by a <c>DataSource</c>. Amazon ML uses the statistics
        /// internally during <c>MLModel</c> training. This parameter must be set to <c>true</c>
        /// if the <code />DataSource<code /> needs to be used for <c>MLModel</c> training.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeStatistics")]
        public System.Boolean? ComputeStatistic { get; set; }
        #endregion
        
        #region Parameter DataSpec_DataLocationS3
        /// <summary>
        /// <para>
        /// <para>The location of the data file(s) used by a <c>DataSource</c>. The URI specifies a
        /// data file or an Amazon Simple Storage Service (Amazon S3) directory or bucket containing
        /// data files.</para>
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
        public System.String DataSpec_DataLocationS3 { get; set; }
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
        /// <para> A JSON string that represents the schema for an Amazon S3 <c>DataSource</c>. The
        /// <c>DataSchema</c> defines the structure of the observation data in the data file(s)
        /// referenced in the <c>DataSource</c>.</para><para>You must provide either the <c>DataSchema</c> or the <c>DataSchemaLocationS3</c>.</para><para>Define your <c>DataSchema</c> as a series of key-value pairs. <c>attributes</c> and
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
        
        #region Parameter DataSpec_DataSchemaLocationS3
        /// <summary>
        /// <para>
        /// <para>Describes the schema location in Amazon S3. You must provide either the <c>DataSchema</c>
        /// or the <c>DataSchemaLocationS3</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSpec_DataSchemaLocationS3 { get; set; }
        #endregion
        
        #region Parameter DataSourceId
        /// <summary>
        /// <para>
        /// <para>A user-supplied identifier that uniquely identifies the <c>DataSource</c>. </para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataSourceId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MachineLearning.Model.CreateDataSourceFromS3Response).
        /// Specifying the name of a property of type Amazon.MachineLearning.Model.CreateDataSourceFromS3Response will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DataSourceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MLDataSourceFromS3 (CreateDataSourceFromS3)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MachineLearning.Model.CreateDataSourceFromS3Response, NewMLDataSourceFromS3Cmdlet>(Select) ??
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
            context.DataSpec_DataLocationS3 = this.DataSpec_DataLocationS3;
            #if MODULAR
            if (this.DataSpec_DataLocationS3 == null && ParameterWasBound(nameof(this.DataSpec_DataLocationS3)))
            {
                WriteWarning("You are passing $null as a value for parameter DataSpec_DataLocationS3 which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataSpec_DataRearrangement = this.DataSpec_DataRearrangement;
            context.DataSpec_DataSchema = this.DataSpec_DataSchema;
            context.DataSpec_DataSchemaLocationS3 = this.DataSpec_DataSchemaLocationS3;
            
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
            var request = new Amazon.MachineLearning.Model.CreateDataSourceFromS3Request();
            
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
            request.DataSpec = new Amazon.MachineLearning.Model.S3DataSpec();
            System.String requestDataSpec_dataSpec_DataLocationS3 = null;
            if (cmdletContext.DataSpec_DataLocationS3 != null)
            {
                requestDataSpec_dataSpec_DataLocationS3 = cmdletContext.DataSpec_DataLocationS3;
            }
            if (requestDataSpec_dataSpec_DataLocationS3 != null)
            {
                request.DataSpec.DataLocationS3 = requestDataSpec_dataSpec_DataLocationS3;
                requestDataSpecIsNull = false;
            }
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
            System.String requestDataSpec_dataSpec_DataSchemaLocationS3 = null;
            if (cmdletContext.DataSpec_DataSchemaLocationS3 != null)
            {
                requestDataSpec_dataSpec_DataSchemaLocationS3 = cmdletContext.DataSpec_DataSchemaLocationS3;
            }
            if (requestDataSpec_dataSpec_DataSchemaLocationS3 != null)
            {
                request.DataSpec.DataSchemaLocationS3 = requestDataSpec_dataSpec_DataSchemaLocationS3;
                requestDataSpecIsNull = false;
            }
             // determine if request.DataSpec should be set to null
            if (requestDataSpecIsNull)
            {
                request.DataSpec = null;
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
        
        private Amazon.MachineLearning.Model.CreateDataSourceFromS3Response CallAWSServiceOperation(IAmazonMachineLearning client, Amazon.MachineLearning.Model.CreateDataSourceFromS3Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Machine Learning", "CreateDataSourceFromS3");
            try
            {
                return client.CreateDataSourceFromS3Async(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DataSpec_DataLocationS3 { get; set; }
            public System.String DataSpec_DataRearrangement { get; set; }
            public System.String DataSpec_DataSchema { get; set; }
            public System.String DataSpec_DataSchemaLocationS3 { get; set; }
            public System.Func<Amazon.MachineLearning.Model.CreateDataSourceFromS3Response, NewMLDataSourceFromS3Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataSourceId;
        }
        
    }
}
