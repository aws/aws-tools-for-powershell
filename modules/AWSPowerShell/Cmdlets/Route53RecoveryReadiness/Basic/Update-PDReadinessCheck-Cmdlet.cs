/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Route53RecoveryReadiness;
using Amazon.Route53RecoveryReadiness.Model;

namespace Amazon.PowerShell.Cmdlets.PD
{
    /// <summary>
    /// Updates a readiness check.
    /// </summary>
    [Cmdlet("Update", "PDReadinessCheck", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53RecoveryReadiness.Model.UpdateReadinessCheckResponse")]
    [AWSCmdlet("Calls the AWS Route53 Recovery Readiness UpdateReadinessCheck API operation.", Operation = new[] {"UpdateReadinessCheck"}, SelectReturnType = typeof(Amazon.Route53RecoveryReadiness.Model.UpdateReadinessCheckResponse))]
    [AWSCmdletOutput("Amazon.Route53RecoveryReadiness.Model.UpdateReadinessCheckResponse",
        "This cmdlet returns an Amazon.Route53RecoveryReadiness.Model.UpdateReadinessCheckResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePDReadinessCheckCmdlet : AmazonRoute53RecoveryReadinessClientCmdlet, IExecutor
    {
        
        #region Parameter ReadinessCheckName
        /// <summary>
        /// <para>
        /// <para>Name of a readiness check.</para>
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
        public System.String ReadinessCheckName { get; set; }
        #endregion
        
        #region Parameter ResourceSetName
        /// <summary>
        /// <para>
        /// <para>The name of the resource set to be checked.</para>
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
        public System.String ResourceSetName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53RecoveryReadiness.Model.UpdateReadinessCheckResponse).
        /// Specifying the name of a property of type Amazon.Route53RecoveryReadiness.Model.UpdateReadinessCheckResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReadinessCheckName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PDReadinessCheck (UpdateReadinessCheck)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53RecoveryReadiness.Model.UpdateReadinessCheckResponse, UpdatePDReadinessCheckCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ReadinessCheckName = this.ReadinessCheckName;
            #if MODULAR
            if (this.ReadinessCheckName == null && ParameterWasBound(nameof(this.ReadinessCheckName)))
            {
                WriteWarning("You are passing $null as a value for parameter ReadinessCheckName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceSetName = this.ResourceSetName;
            #if MODULAR
            if (this.ResourceSetName == null && ParameterWasBound(nameof(this.ResourceSetName)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceSetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Route53RecoveryReadiness.Model.UpdateReadinessCheckRequest();
            
            if (cmdletContext.ReadinessCheckName != null)
            {
                request.ReadinessCheckName = cmdletContext.ReadinessCheckName;
            }
            if (cmdletContext.ResourceSetName != null)
            {
                request.ResourceSetName = cmdletContext.ResourceSetName;
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
        
        private Amazon.Route53RecoveryReadiness.Model.UpdateReadinessCheckResponse CallAWSServiceOperation(IAmazonRoute53RecoveryReadiness client, Amazon.Route53RecoveryReadiness.Model.UpdateReadinessCheckRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Route53 Recovery Readiness", "UpdateReadinessCheck");
            try
            {
                #if DESKTOP
                return client.UpdateReadinessCheck(request);
                #elif CORECLR
                return client.UpdateReadinessCheckAsync(request).GetAwaiter().GetResult();
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
            public System.String ReadinessCheckName { get; set; }
            public System.String ResourceSetName { get; set; }
            public System.Func<Amazon.Route53RecoveryReadiness.Model.UpdateReadinessCheckResponse, UpdatePDReadinessCheckCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
