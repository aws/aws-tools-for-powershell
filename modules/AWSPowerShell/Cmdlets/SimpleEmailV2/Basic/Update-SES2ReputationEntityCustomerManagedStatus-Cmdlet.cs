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
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

namespace Amazon.PowerShell.Cmdlets.SES2
{
    /// <summary>
    /// Update the customer-managed sending status for a reputation entity. This allows you
    /// to enable, disable, or reinstate sending for the entity.
    /// 
    ///  
    /// <para>
    /// The customer-managed status works in conjunction with the Amazon Web Services Amazon
    /// SES-managed status to determine the overall sending capability. When you update the
    /// customer-managed status, the Amazon Web Services Amazon SES-managed status remains
    /// unchanged. If Amazon Web Services Amazon SES has disabled the entity, it will not
    /// be allowed to send regardless of the customer-managed status setting. When you reinstate
    /// an entity through the customer-managed status, it can continue sending only if the
    /// Amazon Web Services Amazon SES-managed status also permits sending, even if there
    /// are active reputation findings, until the findings are resolved or new violations
    /// occur.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SES2ReputationEntityCustomerManagedStatus", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) UpdateReputationEntityCustomerManagedStatus API operation.", Operation = new[] {"UpdateReputationEntityCustomerManagedStatus"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.UpdateReputationEntityCustomerManagedStatusResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleEmailV2.Model.UpdateReputationEntityCustomerManagedStatusResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleEmailV2.Model.UpdateReputationEntityCustomerManagedStatusResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSES2ReputationEntityCustomerManagedStatusCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ReputationEntityReference
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the reputation entity. For resource-type entities, this
        /// is the Amazon Resource Name (ARN) of the resource.</para>
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
        public System.String ReputationEntityReference { get; set; }
        #endregion
        
        #region Parameter ReputationEntityType
        /// <summary>
        /// <para>
        /// <para>The type of reputation entity. Currently, only <c>RESOURCE</c> type entities are supported.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.ReputationEntityType")]
        public Amazon.SimpleEmailV2.ReputationEntityType ReputationEntityType { get; set; }
        #endregion
        
        #region Parameter SendingStatus
        /// <summary>
        /// <para>
        /// <para>The new customer-managed sending status for the reputation entity. This can be one
        /// of the following:</para><ul><li><para><c>ENABLED</c> – Allow sending for this entity.</para></li><li><para><c>DISABLED</c> – Prevent sending for this entity.</para></li><li><para><c>REINSTATED</c> – Allow sending even if there are active reputation findings.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.SendingStatus")]
        public Amazon.SimpleEmailV2.SendingStatus SendingStatus { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.UpdateReputationEntityCustomerManagedStatusResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReputationEntityReference), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SES2ReputationEntityCustomerManagedStatus (UpdateReputationEntityCustomerManagedStatus)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.UpdateReputationEntityCustomerManagedStatusResponse, UpdateSES2ReputationEntityCustomerManagedStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ReputationEntityReference = this.ReputationEntityReference;
            #if MODULAR
            if (this.ReputationEntityReference == null && ParameterWasBound(nameof(this.ReputationEntityReference)))
            {
                WriteWarning("You are passing $null as a value for parameter ReputationEntityReference which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReputationEntityType = this.ReputationEntityType;
            #if MODULAR
            if (this.ReputationEntityType == null && ParameterWasBound(nameof(this.ReputationEntityType)))
            {
                WriteWarning("You are passing $null as a value for parameter ReputationEntityType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SendingStatus = this.SendingStatus;
            #if MODULAR
            if (this.SendingStatus == null && ParameterWasBound(nameof(this.SendingStatus)))
            {
                WriteWarning("You are passing $null as a value for parameter SendingStatus which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleEmailV2.Model.UpdateReputationEntityCustomerManagedStatusRequest();
            
            if (cmdletContext.ReputationEntityReference != null)
            {
                request.ReputationEntityReference = cmdletContext.ReputationEntityReference;
            }
            if (cmdletContext.ReputationEntityType != null)
            {
                request.ReputationEntityType = cmdletContext.ReputationEntityType;
            }
            if (cmdletContext.SendingStatus != null)
            {
                request.SendingStatus = cmdletContext.SendingStatus;
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
        
        private Amazon.SimpleEmailV2.Model.UpdateReputationEntityCustomerManagedStatusResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.UpdateReputationEntityCustomerManagedStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "UpdateReputationEntityCustomerManagedStatus");
            try
            {
                #if DESKTOP
                return client.UpdateReputationEntityCustomerManagedStatus(request);
                #elif CORECLR
                return client.UpdateReputationEntityCustomerManagedStatusAsync(request).GetAwaiter().GetResult();
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
            public System.String ReputationEntityReference { get; set; }
            public Amazon.SimpleEmailV2.ReputationEntityType ReputationEntityType { get; set; }
            public Amazon.SimpleEmailV2.SendingStatus SendingStatus { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.UpdateReputationEntityCustomerManagedStatusResponse, UpdateSES2ReputationEntityCustomerManagedStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
