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
using Amazon.IdentityStore;
using Amazon.IdentityStore.Model;

namespace Amazon.PowerShell.Cmdlets.IDS
{
    /// <summary>
    /// Delete a membership within a group given <c>MembershipId</c>.
    /// </summary>
    [Cmdlet("Remove", "IDSGroupMembership", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Identity Store DeleteGroupMembership API operation.", Operation = new[] {"DeleteGroupMembership"}, SelectReturnType = typeof(Amazon.IdentityStore.Model.DeleteGroupMembershipResponse))]
    [AWSCmdletOutput("None or Amazon.IdentityStore.Model.DeleteGroupMembershipResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IdentityStore.Model.DeleteGroupMembershipResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveIDSGroupMembershipCmdlet : AmazonIdentityStoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IdentityStoreId
        /// <summary>
        /// <para>
        /// <para>The globally unique identifier for the identity store.</para>
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
        public System.String IdentityStoreId { get; set; }
        #endregion
        
        #region Parameter MembershipId
        /// <summary>
        /// <para>
        /// <para>The identifier for a <c>GroupMembership</c> in an identity store.</para>
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
        public System.String MembershipId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityStore.Model.DeleteGroupMembershipResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MembershipId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-IDSGroupMembership (DeleteGroupMembership)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityStore.Model.DeleteGroupMembershipResponse, RemoveIDSGroupMembershipCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IdentityStoreId = this.IdentityStoreId;
            #if MODULAR
            if (this.IdentityStoreId == null && ParameterWasBound(nameof(this.IdentityStoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityStoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MembershipId = this.MembershipId;
            #if MODULAR
            if (this.MembershipId == null && ParameterWasBound(nameof(this.MembershipId)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IdentityStore.Model.DeleteGroupMembershipRequest();
            
            if (cmdletContext.IdentityStoreId != null)
            {
                request.IdentityStoreId = cmdletContext.IdentityStoreId;
            }
            if (cmdletContext.MembershipId != null)
            {
                request.MembershipId = cmdletContext.MembershipId;
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
        
        private Amazon.IdentityStore.Model.DeleteGroupMembershipResponse CallAWSServiceOperation(IAmazonIdentityStore client, Amazon.IdentityStore.Model.DeleteGroupMembershipRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity Store", "DeleteGroupMembership");
            try
            {
                #if DESKTOP
                return client.DeleteGroupMembership(request);
                #elif CORECLR
                return client.DeleteGroupMembershipAsync(request).GetAwaiter().GetResult();
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
            public System.String IdentityStoreId { get; set; }
            public System.String MembershipId { get; set; }
            public System.Func<Amazon.IdentityStore.Model.DeleteGroupMembershipResponse, RemoveIDSGroupMembershipCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
