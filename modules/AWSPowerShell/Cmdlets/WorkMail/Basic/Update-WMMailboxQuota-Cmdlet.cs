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
using Amazon.WorkMail;
using Amazon.WorkMail.Model;

namespace Amazon.PowerShell.Cmdlets.WM
{
    /// <summary>
    /// Updates a user's current mailbox quota for a specified organization and user.
    /// </summary>
    [Cmdlet("Update", "WMMailboxQuota", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon WorkMail UpdateMailboxQuota API operation.", Operation = new[] {"UpdateMailboxQuota"}, SelectReturnType = typeof(Amazon.WorkMail.Model.UpdateMailboxQuotaResponse))]
    [AWSCmdletOutput("None or Amazon.WorkMail.Model.UpdateMailboxQuotaResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.WorkMail.Model.UpdateMailboxQuotaResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateWMMailboxQuotaCmdlet : AmazonWorkMailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MailboxQuota
        /// <summary>
        /// <para>
        /// <para>The updated mailbox quota, in MB, for the specified user.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? MailboxQuota { get; set; }
        #endregion
        
        #region Parameter OrganizationId
        /// <summary>
        /// <para>
        /// <para>The identifier for the organization that contains the user for whom to update the
        /// mailbox quota.</para>
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
        public System.String OrganizationId { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The identifer for the user for whom to update the mailbox quota.</para><para>The identifier can be the <i>UserId</i>, <i>Username</i>, or <i>email</i>. The following
        /// identity formats are available:</para><ul><li><para>User ID: 12345678-1234-1234-1234-123456789012 or S-1-1-12-1234567890-123456789-123456789-1234</para></li><li><para>Email address: user@domain.tld</para></li><li><para>User name: user</para></li></ul>
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
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkMail.Model.UpdateMailboxQuotaResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the OrganizationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^OrganizationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^OrganizationId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OrganizationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WMMailboxQuota (UpdateMailboxQuota)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkMail.Model.UpdateMailboxQuotaResponse, UpdateWMMailboxQuotaCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.OrganizationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MailboxQuota = this.MailboxQuota;
            #if MODULAR
            if (this.MailboxQuota == null && ParameterWasBound(nameof(this.MailboxQuota)))
            {
                WriteWarning("You are passing $null as a value for parameter MailboxQuota which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OrganizationId = this.OrganizationId;
            #if MODULAR
            if (this.OrganizationId == null && ParameterWasBound(nameof(this.OrganizationId)))
            {
                WriteWarning("You are passing $null as a value for parameter OrganizationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserId = this.UserId;
            #if MODULAR
            if (this.UserId == null && ParameterWasBound(nameof(this.UserId)))
            {
                WriteWarning("You are passing $null as a value for parameter UserId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WorkMail.Model.UpdateMailboxQuotaRequest();
            
            if (cmdletContext.MailboxQuota != null)
            {
                request.MailboxQuota = cmdletContext.MailboxQuota.Value;
            }
            if (cmdletContext.OrganizationId != null)
            {
                request.OrganizationId = cmdletContext.OrganizationId;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
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
        
        private Amazon.WorkMail.Model.UpdateMailboxQuotaResponse CallAWSServiceOperation(IAmazonWorkMail client, Amazon.WorkMail.Model.UpdateMailboxQuotaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkMail", "UpdateMailboxQuota");
            try
            {
                #if DESKTOP
                return client.UpdateMailboxQuota(request);
                #elif CORECLR
                return client.UpdateMailboxQuotaAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MailboxQuota { get; set; }
            public System.String OrganizationId { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.WorkMail.Model.UpdateMailboxQuotaResponse, UpdateWMMailboxQuotaCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
