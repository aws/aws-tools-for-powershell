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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Deletes a grant. Typically, you retire a grant when you no longer need its permissions.
    /// To identify the grant to retire, use a <a href="https://docs.aws.amazon.com/kms/latest/developerguide/grants.html#grant_token">grant
    /// token</a>, or both the grant ID and a key identifier (key ID or key ARN) of the KMS
    /// key. The <a>CreateGrant</a> operation returns both values.
    /// 
    ///  
    /// <para>
    /// This operation can be called by the <i>retiring principal</i> for a grant, by the
    /// <i>grantee principal</i> if the grant allows the <c>RetireGrant</c> operation, and
    /// by the Amazon Web Services account in which the grant is created. It can also be called
    /// by principals to whom permission for retiring a grant is delegated. For details, see
    /// <a href="https://docs.aws.amazon.com/kms/latest/developerguide/grant-manage.html#grant-delete">Retiring
    /// and revoking grants</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para>
    /// For detailed information about grants, including grant terminology, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/grants.html">Grants
    /// in KMS</a> in the <i><i>Key Management Service Developer Guide</i></i>. For examples
    /// of working with grants in several programming languages, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-grants.html">Programming
    /// grants</a>. 
    /// </para><para><b>Cross-account use</b>: Yes. You can retire a grant on a KMS key in a different
    /// Amazon Web Services account.
    /// </para><para><b>Required permissions</b>: Permission to retire a grant is determined primarily
    /// by the grant. For details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/grant-manage.html#grant-delete">Retiring
    /// and revoking grants</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>CreateGrant</a></para></li><li><para><a>ListGrants</a></para></li><li><para><a>ListRetirableGrants</a></para></li><li><para><a>RevokeGrant</a></para></li></ul><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-eventual-consistency.html">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Disable", "KMSGrant", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Key Management Service RetireGrant API operation.", Operation = new[] {"RetireGrant"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.RetireGrantResponse))]
    [AWSCmdletOutput("None or Amazon.KeyManagementService.Model.RetireGrantResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.KeyManagementService.Model.RetireGrantResponse) be returned by specifying '-Select *'."
    )]
    public partial class DisableKMSGrantCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks if your request will succeed. <c>DryRun</c> is an optional parameter. </para><para>To learn more about how to use this parameter, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-dryrun.html">Testing
        /// your KMS API calls</a> in the <i>Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter GrantId
        /// <summary>
        /// <para>
        /// <para>Identifies the grant to retire. To get the grant ID, use <a>CreateGrant</a>, <a>ListGrants</a>,
        /// or <a>ListRetirableGrants</a>.</para><ul><li><para>Grant ID Example - 0123456789012345678901234567890123456789012345678901234567890123</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GrantId { get; set; }
        #endregion
        
        #region Parameter GrantToken
        /// <summary>
        /// <para>
        /// <para>Identifies the grant to be retired. You can use a grant token to identify a new grant
        /// even before it has achieved eventual consistency.</para><para>Only the <a>CreateGrant</a> operation returns a grant token. For details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/grants.html#grant_token">Grant
        /// token</a> and <a href="https://docs.aws.amazon.com/kms/latest/developerguide/grants.html#terms-eventual-consistency">Eventual
        /// consistency</a> in the <i>Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GrantToken { get; set; }
        #endregion
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>The key ARN KMS key associated with the grant. To find the key ARN, use the <a>ListKeys</a>
        /// operation.</para><para>For example: <c>arn:aws:kms:us-east-2:444455556666:key/1234abcd-12ab-34cd-56ef-1234567890ab</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KeyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.RetireGrantResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GrantToken), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Disable-KMSGrant (RetireGrant)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.RetireGrantResponse, DisableKMSGrantCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
            context.GrantId = this.GrantId;
            context.GrantToken = this.GrantToken;
            context.KeyId = this.KeyId;
            
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
            var request = new Amazon.KeyManagementService.Model.RetireGrantRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.GrantId != null)
            {
                request.GrantId = cmdletContext.GrantId;
            }
            if (cmdletContext.GrantToken != null)
            {
                request.GrantToken = cmdletContext.GrantToken;
            }
            if (cmdletContext.KeyId != null)
            {
                request.KeyId = cmdletContext.KeyId;
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
        
        private Amazon.KeyManagementService.Model.RetireGrantResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.RetireGrantRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "RetireGrant");
            try
            {
                return client.RetireGrantAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public System.String GrantId { get; set; }
            public System.String GrantToken { get; set; }
            public System.String KeyId { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.RetireGrantResponse, DisableKMSGrantCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
