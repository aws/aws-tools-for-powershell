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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Deletes an hours of operation override in an Amazon Connect hours of operation resource.
    /// </summary>
    [Cmdlet("Remove", "CONNHoursOfOperationOverride", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Service DeleteHoursOfOperationOverride API operation.", Operation = new[] {"DeleteHoursOfOperationOverride"}, SelectReturnType = typeof(Amazon.Connect.Model.DeleteHoursOfOperationOverrideResponse))]
    [AWSCmdletOutput("None or Amazon.Connect.Model.DeleteHoursOfOperationOverrideResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Connect.Model.DeleteHoursOfOperationOverrideResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveCONNHoursOfOperationOverrideCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter HoursOfOperationId
        /// <summary>
        /// <para>
        /// <para>The identifier for the hours of operation.</para>
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
        public System.String HoursOfOperationId { get; set; }
        #endregion
        
        #region Parameter HoursOfOperationOverrideId
        /// <summary>
        /// <para>
        /// <para>The identifier for the hours of operation override.</para>
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
        public System.String HoursOfOperationOverrideId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.DeleteHoursOfOperationOverrideResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HoursOfOperationOverrideId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CONNHoursOfOperationOverride (DeleteHoursOfOperationOverride)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.DeleteHoursOfOperationOverrideResponse, RemoveCONNHoursOfOperationOverrideCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HoursOfOperationId = this.HoursOfOperationId;
            #if MODULAR
            if (this.HoursOfOperationId == null && ParameterWasBound(nameof(this.HoursOfOperationId)))
            {
                WriteWarning("You are passing $null as a value for parameter HoursOfOperationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HoursOfOperationOverrideId = this.HoursOfOperationOverrideId;
            #if MODULAR
            if (this.HoursOfOperationOverrideId == null && ParameterWasBound(nameof(this.HoursOfOperationOverrideId)))
            {
                WriteWarning("You are passing $null as a value for parameter HoursOfOperationOverrideId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.DeleteHoursOfOperationOverrideRequest();
            
            if (cmdletContext.HoursOfOperationId != null)
            {
                request.HoursOfOperationId = cmdletContext.HoursOfOperationId;
            }
            if (cmdletContext.HoursOfOperationOverrideId != null)
            {
                request.HoursOfOperationOverrideId = cmdletContext.HoursOfOperationOverrideId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
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
        
        private Amazon.Connect.Model.DeleteHoursOfOperationOverrideResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.DeleteHoursOfOperationOverrideRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "DeleteHoursOfOperationOverride");
            try
            {
                #if DESKTOP
                return client.DeleteHoursOfOperationOverride(request);
                #elif CORECLR
                return client.DeleteHoursOfOperationOverrideAsync(request).GetAwaiter().GetResult();
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
            public System.String HoursOfOperationId { get; set; }
            public System.String HoursOfOperationOverrideId { get; set; }
            public System.String InstanceId { get; set; }
            public System.Func<Amazon.Connect.Model.DeleteHoursOfOperationOverrideResponse, RemoveCONNHoursOfOperationOverrideCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
