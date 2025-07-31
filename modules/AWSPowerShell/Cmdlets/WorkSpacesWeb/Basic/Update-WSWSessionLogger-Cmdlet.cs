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
using Amazon.WorkSpacesWeb;
using Amazon.WorkSpacesWeb.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WSW
{
    /// <summary>
    /// Updates the details of a session logger.
    /// </summary>
    [Cmdlet("Update", "WSWSessionLogger", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WorkSpacesWeb.Model.SessionLogger")]
    [AWSCmdlet("Calls the Amazon WorkSpaces Web UpdateSessionLogger API operation.", Operation = new[] {"UpdateSessionLogger"}, SelectReturnType = typeof(Amazon.WorkSpacesWeb.Model.UpdateSessionLoggerResponse))]
    [AWSCmdletOutput("Amazon.WorkSpacesWeb.Model.SessionLogger or Amazon.WorkSpacesWeb.Model.UpdateSessionLoggerResponse",
        "This cmdlet returns an Amazon.WorkSpacesWeb.Model.SessionLogger object.",
        "The service call response (type Amazon.WorkSpacesWeb.Model.UpdateSessionLoggerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateWSWSessionLoggerCmdlet : AmazonWorkSpacesWebClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EventFilter_All
        /// <summary>
        /// <para>
        /// <para>The filter that monitors all of the available events, including any new events emitted
        /// in the future.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.WorkSpacesWeb.Model.Unit EventFilter_All { get; set; }
        #endregion
        
        #region Parameter S3_Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket name where logs are delivered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogConfiguration_S3_Bucket")]
        public System.String S3_Bucket { get; set; }
        #endregion
        
        #region Parameter S3_BucketOwner
        /// <summary>
        /// <para>
        /// <para>The expected bucket owner of the target S3 bucket. The caller must have permissions
        /// to write to the target bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogConfiguration_S3_BucketOwner")]
        public System.String S3_BucketOwner { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The updated display name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter S3_FolderStructure
        /// <summary>
        /// <para>
        /// <para>The folder structure that defines the organizational structure for log files in S3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogConfiguration_S3_FolderStructure")]
        [AWSConstantClassSource("Amazon.WorkSpacesWeb.FolderStructure")]
        public Amazon.WorkSpacesWeb.FolderStructure S3_FolderStructure { get; set; }
        #endregion
        
        #region Parameter EventFilter_Include
        /// <summary>
        /// <para>
        /// <para>The filter that monitors only the listed set of events. New events are not auto-monitored.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] EventFilter_Include { get; set; }
        #endregion
        
        #region Parameter S3_KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The S3 path prefix that determines where log files are stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogConfiguration_S3_KeyPrefix")]
        public System.String S3_KeyPrefix { get; set; }
        #endregion
        
        #region Parameter S3_LogFileFormat
        /// <summary>
        /// <para>
        /// <para>The format of the LogFile that is written to S3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogConfiguration_S3_LogFileFormat")]
        [AWSConstantClassSource("Amazon.WorkSpacesWeb.LogFileFormat")]
        public Amazon.WorkSpacesWeb.LogFileFormat S3_LogFileFormat { get; set; }
        #endregion
        
        #region Parameter SessionLoggerArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the session logger to update.</para>
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
        public System.String SessionLoggerArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SessionLogger'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpacesWeb.Model.UpdateSessionLoggerResponse).
        /// Specifying the name of a property of type Amazon.WorkSpacesWeb.Model.UpdateSessionLoggerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SessionLogger";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SessionLoggerArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WSWSessionLogger (UpdateSessionLogger)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpacesWeb.Model.UpdateSessionLoggerResponse, UpdateWSWSessionLoggerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DisplayName = this.DisplayName;
            context.EventFilter_All = this.EventFilter_All;
            if (this.EventFilter_Include != null)
            {
                context.EventFilter_Include = new List<System.String>(this.EventFilter_Include);
            }
            context.S3_Bucket = this.S3_Bucket;
            context.S3_BucketOwner = this.S3_BucketOwner;
            context.S3_FolderStructure = this.S3_FolderStructure;
            context.S3_KeyPrefix = this.S3_KeyPrefix;
            context.S3_LogFileFormat = this.S3_LogFileFormat;
            context.SessionLoggerArn = this.SessionLoggerArn;
            #if MODULAR
            if (this.SessionLoggerArn == null && ParameterWasBound(nameof(this.SessionLoggerArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionLoggerArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WorkSpacesWeb.Model.UpdateSessionLoggerRequest();
            
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            
             // populate EventFilter
            var requestEventFilterIsNull = true;
            request.EventFilter = new Amazon.WorkSpacesWeb.Model.EventFilter();
            Amazon.WorkSpacesWeb.Model.Unit requestEventFilter_eventFilter_All = null;
            if (cmdletContext.EventFilter_All != null)
            {
                requestEventFilter_eventFilter_All = cmdletContext.EventFilter_All;
            }
            if (requestEventFilter_eventFilter_All != null)
            {
                request.EventFilter.All = requestEventFilter_eventFilter_All;
                requestEventFilterIsNull = false;
            }
            List<System.String> requestEventFilter_eventFilter_Include = null;
            if (cmdletContext.EventFilter_Include != null)
            {
                requestEventFilter_eventFilter_Include = cmdletContext.EventFilter_Include;
            }
            if (requestEventFilter_eventFilter_Include != null)
            {
                request.EventFilter.Include = requestEventFilter_eventFilter_Include;
                requestEventFilterIsNull = false;
            }
             // determine if request.EventFilter should be set to null
            if (requestEventFilterIsNull)
            {
                request.EventFilter = null;
            }
            
             // populate LogConfiguration
            var requestLogConfigurationIsNull = true;
            request.LogConfiguration = new Amazon.WorkSpacesWeb.Model.LogConfiguration();
            Amazon.WorkSpacesWeb.Model.S3LogConfiguration requestLogConfiguration_logConfiguration_S3 = null;
            
             // populate S3
            var requestLogConfiguration_logConfiguration_S3IsNull = true;
            requestLogConfiguration_logConfiguration_S3 = new Amazon.WorkSpacesWeb.Model.S3LogConfiguration();
            System.String requestLogConfiguration_logConfiguration_S3_s3_Bucket = null;
            if (cmdletContext.S3_Bucket != null)
            {
                requestLogConfiguration_logConfiguration_S3_s3_Bucket = cmdletContext.S3_Bucket;
            }
            if (requestLogConfiguration_logConfiguration_S3_s3_Bucket != null)
            {
                requestLogConfiguration_logConfiguration_S3.Bucket = requestLogConfiguration_logConfiguration_S3_s3_Bucket;
                requestLogConfiguration_logConfiguration_S3IsNull = false;
            }
            System.String requestLogConfiguration_logConfiguration_S3_s3_BucketOwner = null;
            if (cmdletContext.S3_BucketOwner != null)
            {
                requestLogConfiguration_logConfiguration_S3_s3_BucketOwner = cmdletContext.S3_BucketOwner;
            }
            if (requestLogConfiguration_logConfiguration_S3_s3_BucketOwner != null)
            {
                requestLogConfiguration_logConfiguration_S3.BucketOwner = requestLogConfiguration_logConfiguration_S3_s3_BucketOwner;
                requestLogConfiguration_logConfiguration_S3IsNull = false;
            }
            Amazon.WorkSpacesWeb.FolderStructure requestLogConfiguration_logConfiguration_S3_s3_FolderStructure = null;
            if (cmdletContext.S3_FolderStructure != null)
            {
                requestLogConfiguration_logConfiguration_S3_s3_FolderStructure = cmdletContext.S3_FolderStructure;
            }
            if (requestLogConfiguration_logConfiguration_S3_s3_FolderStructure != null)
            {
                requestLogConfiguration_logConfiguration_S3.FolderStructure = requestLogConfiguration_logConfiguration_S3_s3_FolderStructure;
                requestLogConfiguration_logConfiguration_S3IsNull = false;
            }
            System.String requestLogConfiguration_logConfiguration_S3_s3_KeyPrefix = null;
            if (cmdletContext.S3_KeyPrefix != null)
            {
                requestLogConfiguration_logConfiguration_S3_s3_KeyPrefix = cmdletContext.S3_KeyPrefix;
            }
            if (requestLogConfiguration_logConfiguration_S3_s3_KeyPrefix != null)
            {
                requestLogConfiguration_logConfiguration_S3.KeyPrefix = requestLogConfiguration_logConfiguration_S3_s3_KeyPrefix;
                requestLogConfiguration_logConfiguration_S3IsNull = false;
            }
            Amazon.WorkSpacesWeb.LogFileFormat requestLogConfiguration_logConfiguration_S3_s3_LogFileFormat = null;
            if (cmdletContext.S3_LogFileFormat != null)
            {
                requestLogConfiguration_logConfiguration_S3_s3_LogFileFormat = cmdletContext.S3_LogFileFormat;
            }
            if (requestLogConfiguration_logConfiguration_S3_s3_LogFileFormat != null)
            {
                requestLogConfiguration_logConfiguration_S3.LogFileFormat = requestLogConfiguration_logConfiguration_S3_s3_LogFileFormat;
                requestLogConfiguration_logConfiguration_S3IsNull = false;
            }
             // determine if requestLogConfiguration_logConfiguration_S3 should be set to null
            if (requestLogConfiguration_logConfiguration_S3IsNull)
            {
                requestLogConfiguration_logConfiguration_S3 = null;
            }
            if (requestLogConfiguration_logConfiguration_S3 != null)
            {
                request.LogConfiguration.S3 = requestLogConfiguration_logConfiguration_S3;
                requestLogConfigurationIsNull = false;
            }
             // determine if request.LogConfiguration should be set to null
            if (requestLogConfigurationIsNull)
            {
                request.LogConfiguration = null;
            }
            if (cmdletContext.SessionLoggerArn != null)
            {
                request.SessionLoggerArn = cmdletContext.SessionLoggerArn;
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
        
        private Amazon.WorkSpacesWeb.Model.UpdateSessionLoggerResponse CallAWSServiceOperation(IAmazonWorkSpacesWeb client, Amazon.WorkSpacesWeb.Model.UpdateSessionLoggerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces Web", "UpdateSessionLogger");
            try
            {
                return client.UpdateSessionLoggerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DisplayName { get; set; }
            public Amazon.WorkSpacesWeb.Model.Unit EventFilter_All { get; set; }
            public List<System.String> EventFilter_Include { get; set; }
            public System.String S3_Bucket { get; set; }
            public System.String S3_BucketOwner { get; set; }
            public Amazon.WorkSpacesWeb.FolderStructure S3_FolderStructure { get; set; }
            public System.String S3_KeyPrefix { get; set; }
            public Amazon.WorkSpacesWeb.LogFileFormat S3_LogFileFormat { get; set; }
            public System.String SessionLoggerArn { get; set; }
            public System.Func<Amazon.WorkSpacesWeb.Model.UpdateSessionLoggerResponse, UpdateWSWSessionLoggerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SessionLogger;
        }
        
    }
}
