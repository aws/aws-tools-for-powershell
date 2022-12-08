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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Set a verification state and provide a description of that verification state on a
    /// violation (detect alarm).
    /// </summary>
    [Cmdlet("Write", "IOTVerificationStateOnViolation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT PutVerificationStateOnViolation API operation.", Operation = new[] {"PutVerificationStateOnViolation"}, SelectReturnType = typeof(Amazon.IoT.Model.PutVerificationStateOnViolationResponse))]
    [AWSCmdletOutput("None or Amazon.IoT.Model.PutVerificationStateOnViolationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoT.Model.PutVerificationStateOnViolationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteIOTVerificationStateOnViolationCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter VerificationState
        /// <summary>
        /// <para>
        /// <para>The verification state of the violation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoT.VerificationState")]
        public Amazon.IoT.VerificationState VerificationState { get; set; }
        #endregion
        
        #region Parameter VerificationStateDescription
        /// <summary>
        /// <para>
        /// <para>The description of the verification state of the violation (detect alarm).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VerificationStateDescription { get; set; }
        #endregion
        
        #region Parameter ViolationId
        /// <summary>
        /// <para>
        /// <para>The violation ID.</para>
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
        public System.String ViolationId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.PutVerificationStateOnViolationResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ViolationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-IOTVerificationStateOnViolation (PutVerificationStateOnViolation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.PutVerificationStateOnViolationResponse, WriteIOTVerificationStateOnViolationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.VerificationState = this.VerificationState;
            #if MODULAR
            if (this.VerificationState == null && ParameterWasBound(nameof(this.VerificationState)))
            {
                WriteWarning("You are passing $null as a value for parameter VerificationState which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VerificationStateDescription = this.VerificationStateDescription;
            context.ViolationId = this.ViolationId;
            #if MODULAR
            if (this.ViolationId == null && ParameterWasBound(nameof(this.ViolationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ViolationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoT.Model.PutVerificationStateOnViolationRequest();
            
            if (cmdletContext.VerificationState != null)
            {
                request.VerificationState = cmdletContext.VerificationState;
            }
            if (cmdletContext.VerificationStateDescription != null)
            {
                request.VerificationStateDescription = cmdletContext.VerificationStateDescription;
            }
            if (cmdletContext.ViolationId != null)
            {
                request.ViolationId = cmdletContext.ViolationId;
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
        
        private Amazon.IoT.Model.PutVerificationStateOnViolationResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.PutVerificationStateOnViolationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "PutVerificationStateOnViolation");
            try
            {
                #if DESKTOP
                return client.PutVerificationStateOnViolation(request);
                #elif CORECLR
                return client.PutVerificationStateOnViolationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.IoT.VerificationState VerificationState { get; set; }
            public System.String VerificationStateDescription { get; set; }
            public System.String ViolationId { get; set; }
            public System.Func<Amazon.IoT.Model.PutVerificationStateOnViolationResponse, WriteIOTVerificationStateOnViolationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
