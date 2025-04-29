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
using Amazon.ApplicationCostProfiler;
using Amazon.ApplicationCostProfiler.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ACP
{
    /// <summary>
    /// Ingests application usage data from Amazon Simple Storage Service (Amazon S3).
    /// 
    ///  
    /// <para>
    /// The data must already exist in the S3 location. As part of the action, AWS Application
    /// Cost Profiler copies the object from your S3 bucket to an S3 bucket owned by Amazon
    /// for processing asynchronously.
    /// </para>
    /// </summary>
    [Cmdlet("Import", "ACPApplicationUsage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon ApplicationCostProfiler ImportApplicationUsage API operation.", Operation = new[] {"ImportApplicationUsage"}, SelectReturnType = typeof(Amazon.ApplicationCostProfiler.Model.ImportApplicationUsageResponse))]
    [AWSCmdletOutput("System.String or Amazon.ApplicationCostProfiler.Model.ImportApplicationUsageResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ApplicationCostProfiler.Model.ImportApplicationUsageResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ImportACPApplicationUsageCmdlet : AmazonApplicationCostProfilerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SourceS3Location_Bucket
        /// <summary>
        /// <para>
        /// <para>Name of the bucket.</para>
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
        public System.String SourceS3Location_Bucket { get; set; }
        #endregion
        
        #region Parameter SourceS3Location_Key
        /// <summary>
        /// <para>
        /// <para>Key of the object.</para>
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
        public System.String SourceS3Location_Key { get; set; }
        #endregion
        
        #region Parameter SourceS3Location_Region
        /// <summary>
        /// <para>
        /// <para>Region of the bucket. Only required for Regions that are disabled by default. For
        /// more infomration about Regions that are disabled by default, see <a href="https://docs.aws.amazon.com/general/latest/gr/rande-manage.html#rande-manage-enable">
        /// Enabling a Region</a> in the <i>AWS General Reference guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApplicationCostProfiler.S3BucketRegion")]
        public Amazon.ApplicationCostProfiler.S3BucketRegion SourceS3Location_Region { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ImportId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationCostProfiler.Model.ImportApplicationUsageResponse).
        /// Specifying the name of a property of type Amazon.ApplicationCostProfiler.Model.ImportApplicationUsageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ImportId";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-ACPApplicationUsage (ImportApplicationUsage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationCostProfiler.Model.ImportApplicationUsageResponse, ImportACPApplicationUsageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.SourceS3Location_Bucket = this.SourceS3Location_Bucket;
            #if MODULAR
            if (this.SourceS3Location_Bucket == null && ParameterWasBound(nameof(this.SourceS3Location_Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceS3Location_Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceS3Location_Key = this.SourceS3Location_Key;
            #if MODULAR
            if (this.SourceS3Location_Key == null && ParameterWasBound(nameof(this.SourceS3Location_Key)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceS3Location_Key which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceS3Location_Region = this.SourceS3Location_Region;
            
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
            var request = new Amazon.ApplicationCostProfiler.Model.ImportApplicationUsageRequest();
            
            
             // populate SourceS3Location
            var requestSourceS3LocationIsNull = true;
            request.SourceS3Location = new Amazon.ApplicationCostProfiler.Model.SourceS3Location();
            System.String requestSourceS3Location_sourceS3Location_Bucket = null;
            if (cmdletContext.SourceS3Location_Bucket != null)
            {
                requestSourceS3Location_sourceS3Location_Bucket = cmdletContext.SourceS3Location_Bucket;
            }
            if (requestSourceS3Location_sourceS3Location_Bucket != null)
            {
                request.SourceS3Location.Bucket = requestSourceS3Location_sourceS3Location_Bucket;
                requestSourceS3LocationIsNull = false;
            }
            System.String requestSourceS3Location_sourceS3Location_Key = null;
            if (cmdletContext.SourceS3Location_Key != null)
            {
                requestSourceS3Location_sourceS3Location_Key = cmdletContext.SourceS3Location_Key;
            }
            if (requestSourceS3Location_sourceS3Location_Key != null)
            {
                request.SourceS3Location.Key = requestSourceS3Location_sourceS3Location_Key;
                requestSourceS3LocationIsNull = false;
            }
            Amazon.ApplicationCostProfiler.S3BucketRegion requestSourceS3Location_sourceS3Location_Region = null;
            if (cmdletContext.SourceS3Location_Region != null)
            {
                requestSourceS3Location_sourceS3Location_Region = cmdletContext.SourceS3Location_Region;
            }
            if (requestSourceS3Location_sourceS3Location_Region != null)
            {
                request.SourceS3Location.Region = requestSourceS3Location_sourceS3Location_Region;
                requestSourceS3LocationIsNull = false;
            }
             // determine if request.SourceS3Location should be set to null
            if (requestSourceS3LocationIsNull)
            {
                request.SourceS3Location = null;
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
        
        private Amazon.ApplicationCostProfiler.Model.ImportApplicationUsageResponse CallAWSServiceOperation(IAmazonApplicationCostProfiler client, Amazon.ApplicationCostProfiler.Model.ImportApplicationUsageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ApplicationCostProfiler", "ImportApplicationUsage");
            try
            {
                return client.ImportApplicationUsageAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String SourceS3Location_Bucket { get; set; }
            public System.String SourceS3Location_Key { get; set; }
            public Amazon.ApplicationCostProfiler.S3BucketRegion SourceS3Location_Region { get; set; }
            public System.Func<Amazon.ApplicationCostProfiler.Model.ImportApplicationUsageResponse, ImportACPApplicationUsageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ImportId;
        }
        
    }
}
