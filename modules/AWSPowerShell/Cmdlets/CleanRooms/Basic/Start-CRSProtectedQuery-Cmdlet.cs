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
using Amazon.CleanRooms;
using Amazon.CleanRooms.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Creates a protected query that is started by Clean Rooms.
    /// </summary>
    [Cmdlet("Start", "CRSProtectedQuery", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CleanRooms.Model.ProtectedQuery")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service StartProtectedQuery API operation.", Operation = new[] {"StartProtectedQuery"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.StartProtectedQueryResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.ProtectedQuery or Amazon.CleanRooms.Model.StartProtectedQueryResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.ProtectedQuery object.",
        "The service call response (type Amazon.CleanRooms.Model.StartProtectedQueryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartCRSProtectedQueryCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Member_AccountId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResultConfiguration_OutputConfiguration_Member_AccountId")]
        public System.String Member_AccountId { get; set; }
        #endregion
        
        #region Parameter SqlParameters_AnalysisTemplateArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) associated with the analysis template within a collaboration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SqlParameters_AnalysisTemplateArn { get; set; }
        #endregion
        
        #region Parameter S3_Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket to unload the protected query results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResultConfiguration_OutputConfiguration_S3_Bucket")]
        public System.String S3_Bucket { get; set; }
        #endregion
        
        #region Parameter S3_KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The S3 prefix to unload the protected query results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResultConfiguration_OutputConfiguration_S3_KeyPrefix")]
        public System.String S3_KeyPrefix { get; set; }
        #endregion
        
        #region Parameter Distribute_Location
        /// <summary>
        /// <para>
        /// <para> A list of locations where you want to distribute the protected query results. Each
        /// location must specify either an S3 destination or a collaboration member destination.</para><important><para>You can't specify more than one S3 location.</para><para>You can't specify the query runner's account as a member location.</para><para>You must include either an S3 or member output configuration for each location, but
        /// not both.</para></important><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResultConfiguration_OutputConfiguration_Distribute_Locations")]
        public Amazon.CleanRooms.Model.ProtectedQueryDistributeOutputConfigurationLocation[] Distribute_Location { get; set; }
        #endregion
        
        #region Parameter MembershipIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the membership to run this query against. Currently accepts
        /// a membership ID.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String MembershipIdentifier { get; set; }
        #endregion
        
        #region Parameter Worker_Number
        /// <summary>
        /// <para>
        /// <para> The number of workers.</para><para>SQL queries support a minimum value of 2 and a maximum value of 400. </para><para>PySpark jobs support a minimum value of 4 and a maximum value of 128.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeConfiguration_Worker_Number")]
        public System.Int32? Worker_Number { get; set; }
        #endregion
        
        #region Parameter SqlParameters_Parameter
        /// <summary>
        /// <para>
        /// <para>The protected query SQL parameters.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SqlParameters_Parameters")]
        public System.Collections.Hashtable SqlParameters_Parameter { get; set; }
        #endregion
        
        #region Parameter SqlParameters_QueryString
        /// <summary>
        /// <para>
        /// <para>The query string to be submitted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SqlParameters_QueryString { get; set; }
        #endregion
        
        #region Parameter S3_ResultFormat
        /// <summary>
        /// <para>
        /// <para>Intended file format of the result.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResultConfiguration_OutputConfiguration_S3_ResultFormat")]
        [AWSConstantClassSource("Amazon.CleanRooms.ResultFormat")]
        public Amazon.CleanRooms.ResultFormat S3_ResultFormat { get; set; }
        #endregion
        
        #region Parameter S3_SingleFileOutput
        /// <summary>
        /// <para>
        /// <para>Indicates whether files should be output as a single file (<c>TRUE</c>) or output
        /// as multiple files (<c>FALSE</c>). This parameter is only supported for analyses with
        /// the Spark analytics engine.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResultConfiguration_OutputConfiguration_S3_SingleFileOutput")]
        public System.Boolean? S3_SingleFileOutput { get; set; }
        #endregion
        
        #region Parameter Properties_Spark
        /// <summary>
        /// <para>
        /// <para>The Spark configuration properties for SQL workloads. This map contains key-value
        /// pairs that configure Apache Spark settings to optimize performance for your data processing
        /// jobs. You can specify up to 50 Spark properties, with each key being 1-200 characters
        /// and each value being 0-500 characters. These properties allow you to adjust compute
        /// capacity for large datasets and complex workloads.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeConfiguration_Worker_Properties_Spark")]
        public System.Collections.Hashtable Properties_Spark { get; set; }
        #endregion
        
        #region Parameter Worker_Type
        /// <summary>
        /// <para>
        /// <para> The worker compute configuration type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeConfiguration_Worker_Type")]
        [AWSConstantClassSource("Amazon.CleanRooms.WorkerComputeType")]
        public Amazon.CleanRooms.WorkerComputeType Worker_Type { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of the protected query to be started.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CleanRooms.ProtectedQueryType")]
        public Amazon.CleanRooms.ProtectedQueryType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ProtectedQuery'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.StartProtectedQueryResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.StartProtectedQueryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ProtectedQuery";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MembershipIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CRSProtectedQuery (StartProtectedQuery)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.StartProtectedQueryResponse, StartCRSProtectedQueryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Worker_Number = this.Worker_Number;
            if (this.Properties_Spark != null)
            {
                context.Properties_Spark = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Properties_Spark.Keys)
                {
                    context.Properties_Spark.Add((String)hashKey, (System.String)(this.Properties_Spark[hashKey]));
                }
            }
            context.Worker_Type = this.Worker_Type;
            context.MembershipIdentifier = this.MembershipIdentifier;
            #if MODULAR
            if (this.MembershipIdentifier == null && ParameterWasBound(nameof(this.MembershipIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Distribute_Location != null)
            {
                context.Distribute_Location = new List<Amazon.CleanRooms.Model.ProtectedQueryDistributeOutputConfigurationLocation>(this.Distribute_Location);
            }
            context.Member_AccountId = this.Member_AccountId;
            context.S3_Bucket = this.S3_Bucket;
            context.S3_KeyPrefix = this.S3_KeyPrefix;
            context.S3_ResultFormat = this.S3_ResultFormat;
            context.S3_SingleFileOutput = this.S3_SingleFileOutput;
            context.SqlParameters_AnalysisTemplateArn = this.SqlParameters_AnalysisTemplateArn;
            if (this.SqlParameters_Parameter != null)
            {
                context.SqlParameters_Parameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SqlParameters_Parameter.Keys)
                {
                    context.SqlParameters_Parameter.Add((String)hashKey, (System.String)(this.SqlParameters_Parameter[hashKey]));
                }
            }
            context.SqlParameters_QueryString = this.SqlParameters_QueryString;
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CleanRooms.Model.StartProtectedQueryRequest();
            
            
             // populate ComputeConfiguration
            var requestComputeConfigurationIsNull = true;
            request.ComputeConfiguration = new Amazon.CleanRooms.Model.ComputeConfiguration();
            Amazon.CleanRooms.Model.WorkerComputeConfiguration requestComputeConfiguration_computeConfiguration_Worker = null;
            
             // populate Worker
            var requestComputeConfiguration_computeConfiguration_WorkerIsNull = true;
            requestComputeConfiguration_computeConfiguration_Worker = new Amazon.CleanRooms.Model.WorkerComputeConfiguration();
            System.Int32? requestComputeConfiguration_computeConfiguration_Worker_worker_Number = null;
            if (cmdletContext.Worker_Number != null)
            {
                requestComputeConfiguration_computeConfiguration_Worker_worker_Number = cmdletContext.Worker_Number.Value;
            }
            if (requestComputeConfiguration_computeConfiguration_Worker_worker_Number != null)
            {
                requestComputeConfiguration_computeConfiguration_Worker.Number = requestComputeConfiguration_computeConfiguration_Worker_worker_Number.Value;
                requestComputeConfiguration_computeConfiguration_WorkerIsNull = false;
            }
            Amazon.CleanRooms.WorkerComputeType requestComputeConfiguration_computeConfiguration_Worker_worker_Type = null;
            if (cmdletContext.Worker_Type != null)
            {
                requestComputeConfiguration_computeConfiguration_Worker_worker_Type = cmdletContext.Worker_Type;
            }
            if (requestComputeConfiguration_computeConfiguration_Worker_worker_Type != null)
            {
                requestComputeConfiguration_computeConfiguration_Worker.Type = requestComputeConfiguration_computeConfiguration_Worker_worker_Type;
                requestComputeConfiguration_computeConfiguration_WorkerIsNull = false;
            }
            Amazon.CleanRooms.Model.WorkerComputeConfigurationProperties requestComputeConfiguration_computeConfiguration_Worker_computeConfiguration_Worker_Properties = null;
            
             // populate Properties
            var requestComputeConfiguration_computeConfiguration_Worker_computeConfiguration_Worker_PropertiesIsNull = true;
            requestComputeConfiguration_computeConfiguration_Worker_computeConfiguration_Worker_Properties = new Amazon.CleanRooms.Model.WorkerComputeConfigurationProperties();
            Dictionary<System.String, System.String> requestComputeConfiguration_computeConfiguration_Worker_computeConfiguration_Worker_Properties_properties_Spark = null;
            if (cmdletContext.Properties_Spark != null)
            {
                requestComputeConfiguration_computeConfiguration_Worker_computeConfiguration_Worker_Properties_properties_Spark = cmdletContext.Properties_Spark;
            }
            if (requestComputeConfiguration_computeConfiguration_Worker_computeConfiguration_Worker_Properties_properties_Spark != null)
            {
                requestComputeConfiguration_computeConfiguration_Worker_computeConfiguration_Worker_Properties.Spark = requestComputeConfiguration_computeConfiguration_Worker_computeConfiguration_Worker_Properties_properties_Spark;
                requestComputeConfiguration_computeConfiguration_Worker_computeConfiguration_Worker_PropertiesIsNull = false;
            }
             // determine if requestComputeConfiguration_computeConfiguration_Worker_computeConfiguration_Worker_Properties should be set to null
            if (requestComputeConfiguration_computeConfiguration_Worker_computeConfiguration_Worker_PropertiesIsNull)
            {
                requestComputeConfiguration_computeConfiguration_Worker_computeConfiguration_Worker_Properties = null;
            }
            if (requestComputeConfiguration_computeConfiguration_Worker_computeConfiguration_Worker_Properties != null)
            {
                requestComputeConfiguration_computeConfiguration_Worker.Properties = requestComputeConfiguration_computeConfiguration_Worker_computeConfiguration_Worker_Properties;
                requestComputeConfiguration_computeConfiguration_WorkerIsNull = false;
            }
             // determine if requestComputeConfiguration_computeConfiguration_Worker should be set to null
            if (requestComputeConfiguration_computeConfiguration_WorkerIsNull)
            {
                requestComputeConfiguration_computeConfiguration_Worker = null;
            }
            if (requestComputeConfiguration_computeConfiguration_Worker != null)
            {
                request.ComputeConfiguration.Worker = requestComputeConfiguration_computeConfiguration_Worker;
                requestComputeConfigurationIsNull = false;
            }
             // determine if request.ComputeConfiguration should be set to null
            if (requestComputeConfigurationIsNull)
            {
                request.ComputeConfiguration = null;
            }
            if (cmdletContext.MembershipIdentifier != null)
            {
                request.MembershipIdentifier = cmdletContext.MembershipIdentifier;
            }
            
             // populate ResultConfiguration
            var requestResultConfigurationIsNull = true;
            request.ResultConfiguration = new Amazon.CleanRooms.Model.ProtectedQueryResultConfiguration();
            Amazon.CleanRooms.Model.ProtectedQueryOutputConfiguration requestResultConfiguration_resultConfiguration_OutputConfiguration = null;
            
             // populate OutputConfiguration
            var requestResultConfiguration_resultConfiguration_OutputConfigurationIsNull = true;
            requestResultConfiguration_resultConfiguration_OutputConfiguration = new Amazon.CleanRooms.Model.ProtectedQueryOutputConfiguration();
            Amazon.CleanRooms.Model.ProtectedQueryDistributeOutputConfiguration requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Distribute = null;
            
             // populate Distribute
            var requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_DistributeIsNull = true;
            requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Distribute = new Amazon.CleanRooms.Model.ProtectedQueryDistributeOutputConfiguration();
            List<Amazon.CleanRooms.Model.ProtectedQueryDistributeOutputConfigurationLocation> requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Distribute_distribute_Location = null;
            if (cmdletContext.Distribute_Location != null)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Distribute_distribute_Location = cmdletContext.Distribute_Location;
            }
            if (requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Distribute_distribute_Location != null)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Distribute.Locations = requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Distribute_distribute_Location;
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_DistributeIsNull = false;
            }
             // determine if requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Distribute should be set to null
            if (requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_DistributeIsNull)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Distribute = null;
            }
            if (requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Distribute != null)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration.Distribute = requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Distribute;
                requestResultConfiguration_resultConfiguration_OutputConfigurationIsNull = false;
            }
            Amazon.CleanRooms.Model.ProtectedQueryMemberOutputConfiguration requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Member = null;
            
             // populate Member
            var requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_MemberIsNull = true;
            requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Member = new Amazon.CleanRooms.Model.ProtectedQueryMemberOutputConfiguration();
            System.String requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Member_member_AccountId = null;
            if (cmdletContext.Member_AccountId != null)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Member_member_AccountId = cmdletContext.Member_AccountId;
            }
            if (requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Member_member_AccountId != null)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Member.AccountId = requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Member_member_AccountId;
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_MemberIsNull = false;
            }
             // determine if requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Member should be set to null
            if (requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_MemberIsNull)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Member = null;
            }
            if (requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Member != null)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration.Member = requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Member;
                requestResultConfiguration_resultConfiguration_OutputConfigurationIsNull = false;
            }
            Amazon.CleanRooms.Model.ProtectedQueryS3OutputConfiguration requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3 = null;
            
             // populate S3
            var requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3IsNull = true;
            requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3 = new Amazon.CleanRooms.Model.ProtectedQueryS3OutputConfiguration();
            System.String requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3_s3_Bucket = null;
            if (cmdletContext.S3_Bucket != null)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3_s3_Bucket = cmdletContext.S3_Bucket;
            }
            if (requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3_s3_Bucket != null)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3.Bucket = requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3_s3_Bucket;
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3IsNull = false;
            }
            System.String requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3_s3_KeyPrefix = null;
            if (cmdletContext.S3_KeyPrefix != null)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3_s3_KeyPrefix = cmdletContext.S3_KeyPrefix;
            }
            if (requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3_s3_KeyPrefix != null)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3.KeyPrefix = requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3_s3_KeyPrefix;
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3IsNull = false;
            }
            Amazon.CleanRooms.ResultFormat requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3_s3_ResultFormat = null;
            if (cmdletContext.S3_ResultFormat != null)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3_s3_ResultFormat = cmdletContext.S3_ResultFormat;
            }
            if (requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3_s3_ResultFormat != null)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3.ResultFormat = requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3_s3_ResultFormat;
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3IsNull = false;
            }
            System.Boolean? requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3_s3_SingleFileOutput = null;
            if (cmdletContext.S3_SingleFileOutput != null)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3_s3_SingleFileOutput = cmdletContext.S3_SingleFileOutput.Value;
            }
            if (requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3_s3_SingleFileOutput != null)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3.SingleFileOutput = requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3_s3_SingleFileOutput.Value;
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3IsNull = false;
            }
             // determine if requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3 should be set to null
            if (requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3IsNull)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3 = null;
            }
            if (requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3 != null)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration.S3 = requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3;
                requestResultConfiguration_resultConfiguration_OutputConfigurationIsNull = false;
            }
             // determine if requestResultConfiguration_resultConfiguration_OutputConfiguration should be set to null
            if (requestResultConfiguration_resultConfiguration_OutputConfigurationIsNull)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration = null;
            }
            if (requestResultConfiguration_resultConfiguration_OutputConfiguration != null)
            {
                request.ResultConfiguration.OutputConfiguration = requestResultConfiguration_resultConfiguration_OutputConfiguration;
                requestResultConfigurationIsNull = false;
            }
             // determine if request.ResultConfiguration should be set to null
            if (requestResultConfigurationIsNull)
            {
                request.ResultConfiguration = null;
            }
            
             // populate SqlParameters
            var requestSqlParametersIsNull = true;
            request.SqlParameters = new Amazon.CleanRooms.Model.ProtectedQuerySQLParameters();
            System.String requestSqlParameters_sqlParameters_AnalysisTemplateArn = null;
            if (cmdletContext.SqlParameters_AnalysisTemplateArn != null)
            {
                requestSqlParameters_sqlParameters_AnalysisTemplateArn = cmdletContext.SqlParameters_AnalysisTemplateArn;
            }
            if (requestSqlParameters_sqlParameters_AnalysisTemplateArn != null)
            {
                request.SqlParameters.AnalysisTemplateArn = requestSqlParameters_sqlParameters_AnalysisTemplateArn;
                requestSqlParametersIsNull = false;
            }
            Dictionary<System.String, System.String> requestSqlParameters_sqlParameters_Parameter = null;
            if (cmdletContext.SqlParameters_Parameter != null)
            {
                requestSqlParameters_sqlParameters_Parameter = cmdletContext.SqlParameters_Parameter;
            }
            if (requestSqlParameters_sqlParameters_Parameter != null)
            {
                request.SqlParameters.Parameters = requestSqlParameters_sqlParameters_Parameter;
                requestSqlParametersIsNull = false;
            }
            System.String requestSqlParameters_sqlParameters_QueryString = null;
            if (cmdletContext.SqlParameters_QueryString != null)
            {
                requestSqlParameters_sqlParameters_QueryString = cmdletContext.SqlParameters_QueryString;
            }
            if (requestSqlParameters_sqlParameters_QueryString != null)
            {
                request.SqlParameters.QueryString = requestSqlParameters_sqlParameters_QueryString;
                requestSqlParametersIsNull = false;
            }
             // determine if request.SqlParameters should be set to null
            if (requestSqlParametersIsNull)
            {
                request.SqlParameters = null;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.CleanRooms.Model.StartProtectedQueryResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.StartProtectedQueryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "StartProtectedQuery");
            try
            {
                return client.StartProtectedQueryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? Worker_Number { get; set; }
            public Dictionary<System.String, System.String> Properties_Spark { get; set; }
            public Amazon.CleanRooms.WorkerComputeType Worker_Type { get; set; }
            public System.String MembershipIdentifier { get; set; }
            public List<Amazon.CleanRooms.Model.ProtectedQueryDistributeOutputConfigurationLocation> Distribute_Location { get; set; }
            public System.String Member_AccountId { get; set; }
            public System.String S3_Bucket { get; set; }
            public System.String S3_KeyPrefix { get; set; }
            public Amazon.CleanRooms.ResultFormat S3_ResultFormat { get; set; }
            public System.Boolean? S3_SingleFileOutput { get; set; }
            public System.String SqlParameters_AnalysisTemplateArn { get; set; }
            public Dictionary<System.String, System.String> SqlParameters_Parameter { get; set; }
            public System.String SqlParameters_QueryString { get; set; }
            public Amazon.CleanRooms.ProtectedQueryType Type { get; set; }
            public System.Func<Amazon.CleanRooms.Model.StartProtectedQueryResponse, StartCRSProtectedQueryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ProtectedQuery;
        }
        
    }
}
