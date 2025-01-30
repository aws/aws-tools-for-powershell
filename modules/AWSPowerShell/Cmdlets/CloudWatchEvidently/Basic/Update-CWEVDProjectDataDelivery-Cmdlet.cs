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
using Amazon.CloudWatchEvidently;
using Amazon.CloudWatchEvidently.Model;

namespace Amazon.PowerShell.Cmdlets.CWEVD
{
    /// <summary>
    /// Updates the data storage options for this project. If you store evaluation events,
    /// you an keep them and analyze them on your own. If you choose not to store evaluation
    /// events, Evidently deletes them after using them to produce metrics and other experiment
    /// results that you can view.
    /// 
    ///  
    /// <para>
    /// You can't specify both <c>cloudWatchLogs</c> and <c>s3Destination</c> in the same
    /// operation.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CWEVDProjectDataDelivery", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchEvidently.Model.Project")]
    [AWSCmdlet("Calls the Amazon CloudWatch Evidently UpdateProjectDataDelivery API operation.", Operation = new[] {"UpdateProjectDataDelivery"}, SelectReturnType = typeof(Amazon.CloudWatchEvidently.Model.UpdateProjectDataDeliveryResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchEvidently.Model.Project or Amazon.CloudWatchEvidently.Model.UpdateProjectDataDeliveryResponse",
        "This cmdlet returns an Amazon.CloudWatchEvidently.Model.Project object.",
        "The service call response (type Amazon.CloudWatchEvidently.Model.UpdateProjectDataDeliveryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCWEVDProjectDataDeliveryCmdlet : AmazonCloudWatchEvidentlyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3Destination_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the bucket in which Evidently stores evaluation events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3Destination_Bucket { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogs_LogGroup
        /// <summary>
        /// <para>
        /// <para>The name of the log group where the project stores evaluation events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CloudWatchLogs_LogGroup { get; set; }
        #endregion
        
        #region Parameter S3Destination_Prefix
        /// <summary>
        /// <para>
        /// <para>The bucket prefix in which Evidently stores evaluation events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3Destination_Prefix { get; set; }
        #endregion
        
        #region Parameter Project
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the project that you want to modify the data storage options for.</para>
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
        public System.String Project { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Project'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchEvidently.Model.UpdateProjectDataDeliveryResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchEvidently.Model.UpdateProjectDataDeliveryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Project";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Project parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Project' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Project' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Project), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CWEVDProjectDataDelivery (UpdateProjectDataDelivery)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchEvidently.Model.UpdateProjectDataDeliveryResponse, UpdateCWEVDProjectDataDeliveryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Project;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CloudWatchLogs_LogGroup = this.CloudWatchLogs_LogGroup;
            context.Project = this.Project;
            #if MODULAR
            if (this.Project == null && ParameterWasBound(nameof(this.Project)))
            {
                WriteWarning("You are passing $null as a value for parameter Project which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Destination_Bucket = this.S3Destination_Bucket;
            context.S3Destination_Prefix = this.S3Destination_Prefix;
            
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
            var request = new Amazon.CloudWatchEvidently.Model.UpdateProjectDataDeliveryRequest();
            
            
             // populate CloudWatchLogs
            var requestCloudWatchLogsIsNull = true;
            request.CloudWatchLogs = new Amazon.CloudWatchEvidently.Model.CloudWatchLogsDestinationConfig();
            System.String requestCloudWatchLogs_cloudWatchLogs_LogGroup = null;
            if (cmdletContext.CloudWatchLogs_LogGroup != null)
            {
                requestCloudWatchLogs_cloudWatchLogs_LogGroup = cmdletContext.CloudWatchLogs_LogGroup;
            }
            if (requestCloudWatchLogs_cloudWatchLogs_LogGroup != null)
            {
                request.CloudWatchLogs.LogGroup = requestCloudWatchLogs_cloudWatchLogs_LogGroup;
                requestCloudWatchLogsIsNull = false;
            }
             // determine if request.CloudWatchLogs should be set to null
            if (requestCloudWatchLogsIsNull)
            {
                request.CloudWatchLogs = null;
            }
            if (cmdletContext.Project != null)
            {
                request.Project = cmdletContext.Project;
            }
            
             // populate S3Destination
            var requestS3DestinationIsNull = true;
            request.S3Destination = new Amazon.CloudWatchEvidently.Model.S3DestinationConfig();
            System.String requestS3Destination_s3Destination_Bucket = null;
            if (cmdletContext.S3Destination_Bucket != null)
            {
                requestS3Destination_s3Destination_Bucket = cmdletContext.S3Destination_Bucket;
            }
            if (requestS3Destination_s3Destination_Bucket != null)
            {
                request.S3Destination.Bucket = requestS3Destination_s3Destination_Bucket;
                requestS3DestinationIsNull = false;
            }
            System.String requestS3Destination_s3Destination_Prefix = null;
            if (cmdletContext.S3Destination_Prefix != null)
            {
                requestS3Destination_s3Destination_Prefix = cmdletContext.S3Destination_Prefix;
            }
            if (requestS3Destination_s3Destination_Prefix != null)
            {
                request.S3Destination.Prefix = requestS3Destination_s3Destination_Prefix;
                requestS3DestinationIsNull = false;
            }
             // determine if request.S3Destination should be set to null
            if (requestS3DestinationIsNull)
            {
                request.S3Destination = null;
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
        
        private Amazon.CloudWatchEvidently.Model.UpdateProjectDataDeliveryResponse CallAWSServiceOperation(IAmazonCloudWatchEvidently client, Amazon.CloudWatchEvidently.Model.UpdateProjectDataDeliveryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Evidently", "UpdateProjectDataDelivery");
            try
            {
                #if DESKTOP
                return client.UpdateProjectDataDelivery(request);
                #elif CORECLR
                return client.UpdateProjectDataDeliveryAsync(request).GetAwaiter().GetResult();
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
            public System.String CloudWatchLogs_LogGroup { get; set; }
            public System.String Project { get; set; }
            public System.String S3Destination_Bucket { get; set; }
            public System.String S3Destination_Prefix { get; set; }
            public System.Func<Amazon.CloudWatchEvidently.Model.UpdateProjectDataDeliveryResponse, UpdateCWEVDProjectDataDeliveryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Project;
        }
        
    }
}
