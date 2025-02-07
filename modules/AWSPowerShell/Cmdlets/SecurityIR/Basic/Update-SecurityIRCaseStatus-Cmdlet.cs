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
using Amazon.SecurityIR;
using Amazon.SecurityIR.Model;

namespace Amazon.PowerShell.Cmdlets.SecurityIR
{
    /// <summary>
    /// Grants permission to update the status for a designated cases. Options include <c>Submitted
    /// | Detection and Analysis | Eradication, Containment and Recovery | Post-Incident Activities
    /// | Closed</c>.
    /// </summary>
    [Cmdlet("Update", "SecurityIRCaseStatus", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityIR.SelfManagedCaseStatus")]
    [AWSCmdlet("Calls the Security Incident Response UpdateCaseStatus API operation.", Operation = new[] {"UpdateCaseStatus"}, SelectReturnType = typeof(Amazon.SecurityIR.Model.UpdateCaseStatusResponse))]
    [AWSCmdletOutput("Amazon.SecurityIR.SelfManagedCaseStatus or Amazon.SecurityIR.Model.UpdateCaseStatusResponse",
        "This cmdlet returns an Amazon.SecurityIR.SelfManagedCaseStatus object.",
        "The service call response (type Amazon.SecurityIR.Model.UpdateCaseStatusResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSecurityIRCaseStatusCmdlet : AmazonSecurityIRClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CaseId
        /// <summary>
        /// <para>
        /// <para>Required element for UpdateCaseStatus to identify the case to update.</para>
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
        public System.String CaseId { get; set; }
        #endregion
        
        #region Parameter CaseStatus
        /// <summary>
        /// <para>
        /// <para>Required element for UpdateCaseStatus to identify the status for a case. Options include
        /// <c>Submitted | Detection and Analysis | Containment, Eradication and Recovery | Post-incident
        /// Activities</c>. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SecurityIR.SelfManagedCaseStatus")]
        public Amazon.SecurityIR.SelfManagedCaseStatus CaseStatus { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CaseStatus'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityIR.Model.UpdateCaseStatusResponse).
        /// Specifying the name of a property of type Amazon.SecurityIR.Model.UpdateCaseStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CaseStatus";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CaseId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CaseId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CaseId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CaseId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SecurityIRCaseStatus (UpdateCaseStatus)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityIR.Model.UpdateCaseStatusResponse, UpdateSecurityIRCaseStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CaseId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CaseId = this.CaseId;
            #if MODULAR
            if (this.CaseId == null && ParameterWasBound(nameof(this.CaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter CaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CaseStatus = this.CaseStatus;
            #if MODULAR
            if (this.CaseStatus == null && ParameterWasBound(nameof(this.CaseStatus)))
            {
                WriteWarning("You are passing $null as a value for parameter CaseStatus which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecurityIR.Model.UpdateCaseStatusRequest();
            
            if (cmdletContext.CaseId != null)
            {
                request.CaseId = cmdletContext.CaseId;
            }
            if (cmdletContext.CaseStatus != null)
            {
                request.CaseStatus = cmdletContext.CaseStatus;
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
        
        private Amazon.SecurityIR.Model.UpdateCaseStatusResponse CallAWSServiceOperation(IAmazonSecurityIR client, Amazon.SecurityIR.Model.UpdateCaseStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Security Incident Response", "UpdateCaseStatus");
            try
            {
                #if DESKTOP
                return client.UpdateCaseStatus(request);
                #elif CORECLR
                return client.UpdateCaseStatusAsync(request).GetAwaiter().GetResult();
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
            public System.String CaseId { get; set; }
            public Amazon.SecurityIR.SelfManagedCaseStatus CaseStatus { get; set; }
            public System.Func<Amazon.SecurityIR.Model.UpdateCaseStatusResponse, UpdateSecurityIRCaseStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CaseStatus;
        }
        
    }
}
