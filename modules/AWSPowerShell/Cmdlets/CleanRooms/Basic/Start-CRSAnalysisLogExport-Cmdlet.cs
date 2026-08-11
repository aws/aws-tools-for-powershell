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
    /// Starts an export of the Apache Spark logs for a protected query to an Amazon S3 bucket
    /// that you own. Use the exported logs to diagnose a query that failed or that ran more
    /// slowly than you expected.
    /// 
    ///  
    /// <para>
    /// Clean Rooms exports a redacted copy of the Spark logs instead of the raw logs. Analyze
    /// the exported logs with the tooling of your choice, such as Spark History Server. For
    /// details about what the exported logs contain, see <a href="https://docs.aws.amazon.com/clean-rooms/latest/userguide/export-analysis-logs-contents.html">https://docs.aws.amazon.com/clean-rooms/latest/userguide/export-analysis-logs-contents.html</a>.
    /// </para><para>
    /// The export runs asynchronously and returns with a <c>status</c> of <c>IN_PROGRESS</c>.
    /// Call <c>GetAnalysisLogExport</c> to poll for the final status.
    /// </para><important><para>
    /// To use this operation, you must have the <c>CAN_EXPORT_QUERY_ANALYSIS_LOG</c> ability
    /// for your membership. You must also be the query runner or the query payer. Having
    /// the ability alone is not sufficient.
    /// </para><para>
    /// The query must have reached a terminal state, and it must have reached the execution
    /// stage. A query that failed validation or that was canceled before it started produces
    /// no Spark logs.
    /// </para><para>
    /// Log export isn't supported for queries that use differential privacy, and isn't supported
    /// for PySpark jobs.
    /// </para><para>
    /// The destination bucket must be in the same Amazon Web Services Region as the collaboration.
    /// Cross-Region export isn't supported.
    /// </para></important><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/clean-rooms/latest/userguide/export-analysis-logs.html">https://docs.aws.amazon.com/clean-rooms/latest/userguide/export-analysis-logs.html</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "CRSAnalysisLogExport", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CleanRooms.Model.AnalysisLogExport")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service StartAnalysisLogExport API operation.", Operation = new[] {"StartAnalysisLogExport"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.StartAnalysisLogExportResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.AnalysisLogExport or Amazon.CleanRooms.Model.StartAnalysisLogExportResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.AnalysisLogExport object.",
        "The service call response (type Amazon.CleanRooms.Model.StartAnalysisLogExportResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartCRSAnalysisLogExportCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AnalysisId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the protected query that you want to export the analysis
        /// logs for.</para>
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
        public System.String AnalysisId { get; set; }
        #endregion
        
        #region Parameter AnalysisType
        /// <summary>
        /// <para>
        /// <para>The type of analysis that the logs are exported for. Currently, only <c>PROTECTED_QUERY</c>
        /// is supported.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CleanRooms.LogExportAnalysisType")]
        public Amazon.CleanRooms.LogExportAnalysisType AnalysisType { get; set; }
        #endregion
        
        #region Parameter ResultConfiguration_OutputConfiguration_S3_Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket that the exported analysis logs are written to. The bucket must be in
        /// the same Amazon Web Services Region as the collaboration.</para>
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
        public System.String ResultConfiguration_OutputConfiguration_S3_Bucket { get; set; }
        #endregion
        
        #region Parameter ResultConfiguration_OutputConfiguration_S3_KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The S3 key prefix under which the exported analysis logs are written.</para><para>Only one export can be in progress at a time for a given query and destination. To
        /// export the same query twice at once, use a different key prefix for the second export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResultConfiguration_OutputConfiguration_S3_KeyPrefix { get; set; }
        #endregion
        
        #region Parameter MembershipIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the membership to export the analysis logs for. Currently
        /// accepts a membership ID.</para>
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
        public System.String MembershipIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AnalysisLogExport'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.StartAnalysisLogExportResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.StartAnalysisLogExportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AnalysisLogExport";
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.AnalysisId),
                nameof(this.MembershipIdentifier)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CRSAnalysisLogExport (StartAnalysisLogExport)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.StartAnalysisLogExportResponse, StartCRSAnalysisLogExportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AnalysisId = this.AnalysisId;
            #if MODULAR
            if (this.AnalysisId == null && ParameterWasBound(nameof(this.AnalysisId)))
            {
                WriteWarning("You are passing $null as a value for parameter AnalysisId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AnalysisType = this.AnalysisType;
            #if MODULAR
            if (this.AnalysisType == null && ParameterWasBound(nameof(this.AnalysisType)))
            {
                WriteWarning("You are passing $null as a value for parameter AnalysisType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MembershipIdentifier = this.MembershipIdentifier;
            #if MODULAR
            if (this.MembershipIdentifier == null && ParameterWasBound(nameof(this.MembershipIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResultConfiguration_OutputConfiguration_S3_Bucket = this.ResultConfiguration_OutputConfiguration_S3_Bucket;
            #if MODULAR
            if (this.ResultConfiguration_OutputConfiguration_S3_Bucket == null && ParameterWasBound(nameof(this.ResultConfiguration_OutputConfiguration_S3_Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter ResultConfiguration_OutputConfiguration_S3_Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResultConfiguration_OutputConfiguration_S3_KeyPrefix = this.ResultConfiguration_OutputConfiguration_S3_KeyPrefix;
            
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
            var request = new Amazon.CleanRooms.Model.StartAnalysisLogExportRequest();
            
            if (cmdletContext.AnalysisId != null)
            {
                request.AnalysisId = cmdletContext.AnalysisId;
            }
            if (cmdletContext.AnalysisType != null)
            {
                request.AnalysisType = cmdletContext.AnalysisType;
            }
            if (cmdletContext.MembershipIdentifier != null)
            {
                request.MembershipIdentifier = cmdletContext.MembershipIdentifier;
            }
            
             // populate ResultConfiguration
            var requestResultConfigurationIsNull = true;
            request.ResultConfiguration = new Amazon.CleanRooms.Model.AnalysisLogExportResultConfiguration();
            Amazon.CleanRooms.Model.AnalysisLogExportOutputConfiguration requestResultConfiguration_resultConfiguration_OutputConfiguration = null;
            
             // populate OutputConfiguration
            var requestResultConfiguration_resultConfiguration_OutputConfigurationIsNull = true;
            requestResultConfiguration_resultConfiguration_OutputConfiguration = new Amazon.CleanRooms.Model.AnalysisLogExportOutputConfiguration();
            Amazon.CleanRooms.Model.AnalysisLogExportS3OutputConfiguration requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3 = null;
            
             // populate S3
            var requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3IsNull = true;
            requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3 = new Amazon.CleanRooms.Model.AnalysisLogExportS3OutputConfiguration();
            System.String requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3_resultConfiguration_OutputConfiguration_S3_Bucket = null;
            if (cmdletContext.ResultConfiguration_OutputConfiguration_S3_Bucket != null)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3_resultConfiguration_OutputConfiguration_S3_Bucket = cmdletContext.ResultConfiguration_OutputConfiguration_S3_Bucket;
            }
            if (requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3_resultConfiguration_OutputConfiguration_S3_Bucket != null)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3.Bucket = requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3_resultConfiguration_OutputConfiguration_S3_Bucket;
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3IsNull = false;
            }
            System.String requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3_resultConfiguration_OutputConfiguration_S3_KeyPrefix = null;
            if (cmdletContext.ResultConfiguration_OutputConfiguration_S3_KeyPrefix != null)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3_resultConfiguration_OutputConfiguration_S3_KeyPrefix = cmdletContext.ResultConfiguration_OutputConfiguration_S3_KeyPrefix;
            }
            if (requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3_resultConfiguration_OutputConfiguration_S3_KeyPrefix != null)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3.KeyPrefix = requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_S3_resultConfiguration_OutputConfiguration_S3_KeyPrefix;
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
        
        private Amazon.CleanRooms.Model.StartAnalysisLogExportResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.StartAnalysisLogExportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "StartAnalysisLogExport");
            try
            {
                return client.StartAnalysisLogExportAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AnalysisId { get; set; }
            public Amazon.CleanRooms.LogExportAnalysisType AnalysisType { get; set; }
            public System.String MembershipIdentifier { get; set; }
            public System.String ResultConfiguration_OutputConfiguration_S3_Bucket { get; set; }
            public System.String ResultConfiguration_OutputConfiguration_S3_KeyPrefix { get; set; }
            public System.Func<Amazon.CleanRooms.Model.StartAnalysisLogExportResponse, StartCRSAnalysisLogExportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AnalysisLogExport;
        }
        
    }
}
