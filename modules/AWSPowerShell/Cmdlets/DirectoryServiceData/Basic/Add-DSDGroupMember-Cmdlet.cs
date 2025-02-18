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
using Amazon.DirectoryServiceData;
using Amazon.DirectoryServiceData.Model;

namespace Amazon.PowerShell.Cmdlets.DSD
{
    /// <summary>
    /// Adds an existing user, group, or computer as a group member.
    /// </summary>
    [Cmdlet("Add", "DSDGroupMember", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Directory Service Data AddGroupMember API operation.", Operation = new[] {"AddGroupMember"}, SelectReturnType = typeof(Amazon.DirectoryServiceData.Model.AddGroupMemberResponse))]
    [AWSCmdletOutput("None or Amazon.DirectoryServiceData.Model.AddGroupMemberResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.DirectoryServiceData.Model.AddGroupMemberResponse) be returned by specifying '-Select *'."
    )]
    public partial class AddDSDGroupMemberCmdlet : AmazonDirectoryServiceDataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para> The identifier (ID) of the directory that's associated with the group. </para>
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
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter GroupName
        /// <summary>
        /// <para>
        /// <para> The name of the group. </para>
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
        public System.String GroupName { get; set; }
        #endregion
        
        #region Parameter MemberName
        /// <summary>
        /// <para>
        /// <para> The <c>SAMAccountName</c> of the user, group, or computer to add as a group member.
        /// </para>
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
        public System.String MemberName { get; set; }
        #endregion
        
        #region Parameter MemberRealm
        /// <summary>
        /// <para>
        /// <para> The domain name that's associated with the group member. This parameter is required
        /// only when adding a member outside of your Managed Microsoft AD domain to a group inside
        /// of your Managed Microsoft AD domain. This parameter defaults to the Managed Microsoft
        /// AD domain. </para><note><para> This parameter is case insensitive. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MemberRealm { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para> A unique and case-sensitive identifier that you provide to make sure the idempotency
        /// of the request, so multiple identical calls have the same effect as one single call.
        /// </para><para> A client token is valid for 8 hours after the first request that uses it completes.
        /// After 8 hours, any request with the same client token is treated as a new request.
        /// If the request succeeds, any future uses of that token will be idempotent for another
        /// 8 hours. </para><para> If you submit a request with the same client token but change one of the other parameters
        /// within the 8-hour idempotency window, Directory Service Data returns an <c>ConflictException</c>.
        /// </para><note><para> This parameter is optional when using the CLI or SDK. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectoryServiceData.Model.AddGroupMemberResponse).
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-DSDGroupMember (AddGroupMember)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectoryServiceData.Model.AddGroupMemberResponse, AddDSDGroupMemberCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DirectoryId = this.DirectoryId;
            #if MODULAR
            if (this.DirectoryId == null && ParameterWasBound(nameof(this.DirectoryId)))
            {
                WriteWarning("You are passing $null as a value for parameter DirectoryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GroupName = this.GroupName;
            #if MODULAR
            if (this.GroupName == null && ParameterWasBound(nameof(this.GroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter GroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MemberName = this.MemberName;
            #if MODULAR
            if (this.MemberName == null && ParameterWasBound(nameof(this.MemberName)))
            {
                WriteWarning("You are passing $null as a value for parameter MemberName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MemberRealm = this.MemberRealm;
            
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
            var request = new Amazon.DirectoryServiceData.Model.AddGroupMemberRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            if (cmdletContext.GroupName != null)
            {
                request.GroupName = cmdletContext.GroupName;
            }
            if (cmdletContext.MemberName != null)
            {
                request.MemberName = cmdletContext.MemberName;
            }
            if (cmdletContext.MemberRealm != null)
            {
                request.MemberRealm = cmdletContext.MemberRealm;
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
        
        private Amazon.DirectoryServiceData.Model.AddGroupMemberResponse CallAWSServiceOperation(IAmazonDirectoryServiceData client, Amazon.DirectoryServiceData.Model.AddGroupMemberRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Directory Service Data", "AddGroupMember");
            try
            {
                return client.AddGroupMemberAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String DirectoryId { get; set; }
            public System.String GroupName { get; set; }
            public System.String MemberName { get; set; }
            public System.String MemberRealm { get; set; }
            public System.Func<Amazon.DirectoryServiceData.Model.AddGroupMemberResponse, AddDSDGroupMemberCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
