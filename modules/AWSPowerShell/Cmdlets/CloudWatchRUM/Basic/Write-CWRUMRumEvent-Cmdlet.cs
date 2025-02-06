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
using Amazon.CloudWatchRUM;
using Amazon.CloudWatchRUM.Model;

namespace Amazon.PowerShell.Cmdlets.CWRUM
{
    /// <summary>
    /// Sends telemetry events about your application performance and user behavior to CloudWatch
    /// RUM. The code snippet that RUM generates for you to add to your application includes
    /// <c>PutRumEvents</c> operations to send this data to RUM.
    /// 
    ///  
    /// <para>
    /// Each <c>PutRumEvents</c> operation can send a batch of events from one user session.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWRUMRumEvent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the CloudWatch RUM PutRumEvents API operation.", Operation = new[] {"PutRumEvents"}, SelectReturnType = typeof(Amazon.CloudWatchRUM.Model.PutRumEventsResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatchRUM.Model.PutRumEventsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatchRUM.Model.PutRumEventsResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteCWRUMRumEventCmdlet : AmazonCloudWatchRUMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BatchId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for this batch of RUM event data.</para>
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
        public System.String BatchId { get; set; }
        #endregion
        
        #region Parameter AppMonitorDetails_Id
        /// <summary>
        /// <para>
        /// <para>The unique ID of the app monitor.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AppMonitorDetails_Id { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the app monitor that is sending this data.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter AppMonitorDetails_Name
        /// <summary>
        /// <para>
        /// <para>The name of the app monitor.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AppMonitorDetails_Name { get; set; }
        #endregion
        
        #region Parameter RumEvent
        /// <summary>
        /// <para>
        /// <para>An array of structures that contain the telemetry event data.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("RumEvents")]
        public Amazon.CloudWatchRUM.Model.RumEvent[] RumEvent { get; set; }
        #endregion
        
        #region Parameter UserDetails_SessionId
        /// <summary>
        /// <para>
        /// <para>The session ID that the performance events are from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserDetails_SessionId { get; set; }
        #endregion
        
        #region Parameter UserDetails_UserId
        /// <summary>
        /// <para>
        /// <para>The ID of the user for this user session. This ID is generated by RUM and does not
        /// include any personally identifiable information about the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserDetails_UserId { get; set; }
        #endregion
        
        #region Parameter AppMonitorDetails_Version
        /// <summary>
        /// <para>
        /// <para>The version of the app monitor.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AppMonitorDetails_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchRUM.Model.PutRumEventsResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWRUMRumEvent (PutRumEvents)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchRUM.Model.PutRumEventsResponse, WriteCWRUMRumEventCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppMonitorDetails_Id = this.AppMonitorDetails_Id;
            context.AppMonitorDetails_Name = this.AppMonitorDetails_Name;
            context.AppMonitorDetails_Version = this.AppMonitorDetails_Version;
            context.BatchId = this.BatchId;
            #if MODULAR
            if (this.BatchId == null && ParameterWasBound(nameof(this.BatchId)))
            {
                WriteWarning("You are passing $null as a value for parameter BatchId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RumEvent != null)
            {
                context.RumEvent = new List<Amazon.CloudWatchRUM.Model.RumEvent>(this.RumEvent);
            }
            #if MODULAR
            if (this.RumEvent == null && ParameterWasBound(nameof(this.RumEvent)))
            {
                WriteWarning("You are passing $null as a value for parameter RumEvent which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserDetails_SessionId = this.UserDetails_SessionId;
            context.UserDetails_UserId = this.UserDetails_UserId;
            
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
            var request = new Amazon.CloudWatchRUM.Model.PutRumEventsRequest();
            
            
             // populate AppMonitorDetails
            var requestAppMonitorDetailsIsNull = true;
            request.AppMonitorDetails = new Amazon.CloudWatchRUM.Model.AppMonitorDetails();
            System.String requestAppMonitorDetails_appMonitorDetails_Id = null;
            if (cmdletContext.AppMonitorDetails_Id != null)
            {
                requestAppMonitorDetails_appMonitorDetails_Id = cmdletContext.AppMonitorDetails_Id;
            }
            if (requestAppMonitorDetails_appMonitorDetails_Id != null)
            {
                request.AppMonitorDetails.Id = requestAppMonitorDetails_appMonitorDetails_Id;
                requestAppMonitorDetailsIsNull = false;
            }
            System.String requestAppMonitorDetails_appMonitorDetails_Name = null;
            if (cmdletContext.AppMonitorDetails_Name != null)
            {
                requestAppMonitorDetails_appMonitorDetails_Name = cmdletContext.AppMonitorDetails_Name;
            }
            if (requestAppMonitorDetails_appMonitorDetails_Name != null)
            {
                request.AppMonitorDetails.Name = requestAppMonitorDetails_appMonitorDetails_Name;
                requestAppMonitorDetailsIsNull = false;
            }
            System.String requestAppMonitorDetails_appMonitorDetails_Version = null;
            if (cmdletContext.AppMonitorDetails_Version != null)
            {
                requestAppMonitorDetails_appMonitorDetails_Version = cmdletContext.AppMonitorDetails_Version;
            }
            if (requestAppMonitorDetails_appMonitorDetails_Version != null)
            {
                request.AppMonitorDetails.Version = requestAppMonitorDetails_appMonitorDetails_Version;
                requestAppMonitorDetailsIsNull = false;
            }
             // determine if request.AppMonitorDetails should be set to null
            if (requestAppMonitorDetailsIsNull)
            {
                request.AppMonitorDetails = null;
            }
            if (cmdletContext.BatchId != null)
            {
                request.BatchId = cmdletContext.BatchId;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.RumEvent != null)
            {
                request.RumEvents = cmdletContext.RumEvent;
            }
            
             // populate UserDetails
            var requestUserDetailsIsNull = true;
            request.UserDetails = new Amazon.CloudWatchRUM.Model.UserDetails();
            System.String requestUserDetails_userDetails_SessionId = null;
            if (cmdletContext.UserDetails_SessionId != null)
            {
                requestUserDetails_userDetails_SessionId = cmdletContext.UserDetails_SessionId;
            }
            if (requestUserDetails_userDetails_SessionId != null)
            {
                request.UserDetails.SessionId = requestUserDetails_userDetails_SessionId;
                requestUserDetailsIsNull = false;
            }
            System.String requestUserDetails_userDetails_UserId = null;
            if (cmdletContext.UserDetails_UserId != null)
            {
                requestUserDetails_userDetails_UserId = cmdletContext.UserDetails_UserId;
            }
            if (requestUserDetails_userDetails_UserId != null)
            {
                request.UserDetails.UserId = requestUserDetails_userDetails_UserId;
                requestUserDetailsIsNull = false;
            }
             // determine if request.UserDetails should be set to null
            if (requestUserDetailsIsNull)
            {
                request.UserDetails = null;
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
        
        private Amazon.CloudWatchRUM.Model.PutRumEventsResponse CallAWSServiceOperation(IAmazonCloudWatchRUM client, Amazon.CloudWatchRUM.Model.PutRumEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch RUM", "PutRumEvents");
            try
            {
                #if DESKTOP
                return client.PutRumEvents(request);
                #elif CORECLR
                return client.PutRumEventsAsync(request).GetAwaiter().GetResult();
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
            public System.String AppMonitorDetails_Id { get; set; }
            public System.String AppMonitorDetails_Name { get; set; }
            public System.String AppMonitorDetails_Version { get; set; }
            public System.String BatchId { get; set; }
            public System.String Id { get; set; }
            public List<Amazon.CloudWatchRUM.Model.RumEvent> RumEvent { get; set; }
            public System.String UserDetails_SessionId { get; set; }
            public System.String UserDetails_UserId { get; set; }
            public System.Func<Amazon.CloudWatchRUM.Model.PutRumEventsResponse, WriteCWRUMRumEventCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
