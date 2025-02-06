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
using Amazon.MediaPackageVod;
using Amazon.MediaPackageVod.Model;

namespace Amazon.PowerShell.Cmdlets.EMPV
{
    /// <summary>
    /// Changes the packaging group's properities to configure log subscription
    /// </summary>
    [Cmdlet("Update", "EMPVLog", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaPackageVod.Model.ConfigureLogsResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaPackage VOD ConfigureLogs API operation.", Operation = new[] {"ConfigureLogs"}, SelectReturnType = typeof(Amazon.MediaPackageVod.Model.ConfigureLogsResponse))]
    [AWSCmdletOutput("Amazon.MediaPackageVod.Model.ConfigureLogsResponse",
        "This cmdlet returns an Amazon.MediaPackageVod.Model.ConfigureLogsResponse object containing multiple properties."
    )]
    public partial class UpdateEMPVLogCmdlet : AmazonMediaPackageVodClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// The ID of a MediaPackage VOD PackagingGroup resource.
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
        
        #region Parameter EgressAccessLogs_LogGroupName
        /// <summary>
        /// <para>
        /// Customize the log group name.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EgressAccessLogs_LogGroupName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaPackageVod.Model.ConfigureLogsResponse).
        /// Specifying the name of a property of type Amazon.MediaPackageVod.Model.ConfigureLogsResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMPVLog (ConfigureLogs)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaPackageVod.Model.ConfigureLogsResponse, UpdateEMPVLogCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EgressAccessLogs_LogGroupName = this.EgressAccessLogs_LogGroupName;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MediaPackageVod.Model.ConfigureLogsRequest();
            
            
             // populate EgressAccessLogs
            var requestEgressAccessLogsIsNull = true;
            request.EgressAccessLogs = new Amazon.MediaPackageVod.Model.EgressAccessLogs();
            System.String requestEgressAccessLogs_egressAccessLogs_LogGroupName = null;
            if (cmdletContext.EgressAccessLogs_LogGroupName != null)
            {
                requestEgressAccessLogs_egressAccessLogs_LogGroupName = cmdletContext.EgressAccessLogs_LogGroupName;
            }
            if (requestEgressAccessLogs_egressAccessLogs_LogGroupName != null)
            {
                request.EgressAccessLogs.LogGroupName = requestEgressAccessLogs_egressAccessLogs_LogGroupName;
                requestEgressAccessLogsIsNull = false;
            }
             // determine if request.EgressAccessLogs should be set to null
            if (requestEgressAccessLogsIsNull)
            {
                request.EgressAccessLogs = null;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
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
        
        private Amazon.MediaPackageVod.Model.ConfigureLogsResponse CallAWSServiceOperation(IAmazonMediaPackageVod client, Amazon.MediaPackageVod.Model.ConfigureLogsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaPackage VOD", "ConfigureLogs");
            try
            {
                #if DESKTOP
                return client.ConfigureLogs(request);
                #elif CORECLR
                return client.ConfigureLogsAsync(request).GetAwaiter().GetResult();
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
            public System.String EgressAccessLogs_LogGroupName { get; set; }
            public System.String Id { get; set; }
            public System.Func<Amazon.MediaPackageVod.Model.ConfigureLogsResponse, UpdateEMPVLogCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
