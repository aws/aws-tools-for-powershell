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
using Amazon.Cloud9;
using Amazon.Cloud9.Model;

namespace Amazon.PowerShell.Cmdlets.C9
{
    /// <summary>
    /// Changes the settings of an existing environment member for an Cloud9 development environment.
    /// 
    ///  <important><para>
    /// Cloud9 is no longer available to new customers. Existing customers of Cloud9 can continue
    /// to use the service as normal. <a href="http://aws.amazon.com/blogs/devops/how-to-migrate-from-aws-cloud9-to-aws-ide-toolkits-or-aws-cloudshell/">Learn
    /// more"</a></para></important>
    /// </summary>
    [Cmdlet("Update", "C9EnvironmentMembership", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Cloud9.Model.EnvironmentMember")]
    [AWSCmdlet("Calls the AWS Cloud9 UpdateEnvironmentMembership API operation.", Operation = new[] {"UpdateEnvironmentMembership"}, SelectReturnType = typeof(Amazon.Cloud9.Model.UpdateEnvironmentMembershipResponse))]
    [AWSCmdletOutput("Amazon.Cloud9.Model.EnvironmentMember or Amazon.Cloud9.Model.UpdateEnvironmentMembershipResponse",
        "This cmdlet returns an Amazon.Cloud9.Model.EnvironmentMember object.",
        "The service call response (type Amazon.Cloud9.Model.UpdateEnvironmentMembershipResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateC9EnvironmentMembershipCmdlet : AmazonCloud9ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the environment for the environment member whose settings you want to change.</para>
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
        public System.String EnvironmentId { get; set; }
        #endregion
        
        #region Parameter Permission
        /// <summary>
        /// <para>
        /// <para>The replacement type of environment member permissions you want to associate with
        /// this environment member. Available values include:</para><ul><li><para><c>read-only</c>: Has read-only access to the environment.</para></li><li><para><c>read-write</c>: Has read-write access to the environment.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Permissions")]
        [AWSConstantClassSource("Amazon.Cloud9.MemberPermissions")]
        public Amazon.Cloud9.MemberPermissions Permission { get; set; }
        #endregion
        
        #region Parameter UserArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the environment member whose settings you want to
        /// change.</para>
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
        public System.String UserArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Membership'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Cloud9.Model.UpdateEnvironmentMembershipResponse).
        /// Specifying the name of a property of type Amazon.Cloud9.Model.UpdateEnvironmentMembershipResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Membership";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-C9EnvironmentMembership (UpdateEnvironmentMembership)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Cloud9.Model.UpdateEnvironmentMembershipResponse, UpdateC9EnvironmentMembershipCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EnvironmentId = this.EnvironmentId;
            #if MODULAR
            if (this.EnvironmentId == null && ParameterWasBound(nameof(this.EnvironmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Permission = this.Permission;
            #if MODULAR
            if (this.Permission == null && ParameterWasBound(nameof(this.Permission)))
            {
                WriteWarning("You are passing $null as a value for parameter Permission which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserArn = this.UserArn;
            #if MODULAR
            if (this.UserArn == null && ParameterWasBound(nameof(this.UserArn)))
            {
                WriteWarning("You are passing $null as a value for parameter UserArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Cloud9.Model.UpdateEnvironmentMembershipRequest();
            
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
            }
            if (cmdletContext.Permission != null)
            {
                request.Permissions = cmdletContext.Permission;
            }
            if (cmdletContext.UserArn != null)
            {
                request.UserArn = cmdletContext.UserArn;
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
        
        private Amazon.Cloud9.Model.UpdateEnvironmentMembershipResponse CallAWSServiceOperation(IAmazonCloud9 client, Amazon.Cloud9.Model.UpdateEnvironmentMembershipRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cloud9", "UpdateEnvironmentMembership");
            try
            {
                return client.UpdateEnvironmentMembershipAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String EnvironmentId { get; set; }
            public Amazon.Cloud9.MemberPermissions Permission { get; set; }
            public System.String UserArn { get; set; }
            public System.Func<Amazon.Cloud9.Model.UpdateEnvironmentMembershipResponse, UpdateC9EnvironmentMembershipCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Membership;
        }
        
    }
}
