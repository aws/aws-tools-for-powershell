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
using Amazon.CloudWatchEvents;
using Amazon.CloudWatchEvents.Model;

namespace Amazon.PowerShell.Cmdlets.CWE
{
    /// <summary>
    /// Creates an archive of events with the specified settings. When you create an archive,
    /// incoming events might not immediately start being sent to the archive. Allow a short
    /// period of time for changes to take effect. If you do not specify a pattern to filter
    /// events sent to the archive, all events are sent to the archive except replayed events.
    /// Replayed events are not sent to an archive.
    /// </summary>
    [Cmdlet("New", "CWEArchive", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchEvents.Model.CreateArchiveResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Events CreateArchive API operation.", Operation = new[] {"CreateArchive"}, SelectReturnType = typeof(Amazon.CloudWatchEvents.Model.CreateArchiveResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchEvents.Model.CreateArchiveResponse",
        "This cmdlet returns an Amazon.CloudWatchEvents.Model.CreateArchiveResponse object containing multiple properties."
    )]
    public partial class NewCWEArchiveCmdlet : AmazonCloudWatchEventsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ArchiveName
        /// <summary>
        /// <para>
        /// <para>The name for the archive to create.</para>
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
        public System.String ArchiveName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the archive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EventPattern
        /// <summary>
        /// <para>
        /// <para>An event pattern to use to filter events sent to the archive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EventPattern { get; set; }
        #endregion
        
        #region Parameter EventSourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the event bus that sends events to the archive.</para>
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
        public System.String EventSourceArn { get; set; }
        #endregion
        
        #region Parameter RetentionDay
        /// <summary>
        /// <para>
        /// <para>The number of days to retain events for. Default value is 0. If set to 0, events are
        /// retained indefinitely</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetentionDays")]
        public System.Int32? RetentionDay { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchEvents.Model.CreateArchiveResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchEvents.Model.CreateArchiveResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ArchiveName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWEArchive (CreateArchive)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchEvents.Model.CreateArchiveResponse, NewCWEArchiveCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ArchiveName = this.ArchiveName;
            #if MODULAR
            if (this.ArchiveName == null && ParameterWasBound(nameof(this.ArchiveName)))
            {
                WriteWarning("You are passing $null as a value for parameter ArchiveName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.EventPattern = this.EventPattern;
            context.EventSourceArn = this.EventSourceArn;
            #if MODULAR
            if (this.EventSourceArn == null && ParameterWasBound(nameof(this.EventSourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EventSourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RetentionDay = this.RetentionDay;
            
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
            var request = new Amazon.CloudWatchEvents.Model.CreateArchiveRequest();
            
            if (cmdletContext.ArchiveName != null)
            {
                request.ArchiveName = cmdletContext.ArchiveName;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EventPattern != null)
            {
                request.EventPattern = cmdletContext.EventPattern;
            }
            if (cmdletContext.EventSourceArn != null)
            {
                request.EventSourceArn = cmdletContext.EventSourceArn;
            }
            if (cmdletContext.RetentionDay != null)
            {
                request.RetentionDays = cmdletContext.RetentionDay.Value;
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
        
        private Amazon.CloudWatchEvents.Model.CreateArchiveResponse CallAWSServiceOperation(IAmazonCloudWatchEvents client, Amazon.CloudWatchEvents.Model.CreateArchiveRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Events", "CreateArchive");
            try
            {
                return client.CreateArchiveAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ArchiveName { get; set; }
            public System.String Description { get; set; }
            public System.String EventPattern { get; set; }
            public System.String EventSourceArn { get; set; }
            public System.Int32? RetentionDay { get; set; }
            public System.Func<Amazon.CloudWatchEvents.Model.CreateArchiveResponse, NewCWEArchiveCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
