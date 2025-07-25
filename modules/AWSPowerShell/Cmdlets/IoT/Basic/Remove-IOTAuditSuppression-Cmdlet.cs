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
using Amazon.IoT;
using Amazon.IoT.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Deletes a Device Defender audit suppression. 
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">DeleteAuditSuppression</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "IOTAuditSuppression", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT DeleteAuditSuppression API operation.", Operation = new[] {"DeleteAuditSuppression"}, SelectReturnType = typeof(Amazon.IoT.Model.DeleteAuditSuppressionResponse))]
    [AWSCmdletOutput("None or Amazon.IoT.Model.DeleteAuditSuppressionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoT.Model.DeleteAuditSuppressionResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveIOTAuditSuppressionCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ResourceIdentifier_Account
        /// <summary>
        /// <para>
        /// <para>The account with which the resource is associated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceIdentifier_Account { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_CaCertificateId
        /// <summary>
        /// <para>
        /// <para>The ID of the CA certificate used to authorize the certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceIdentifier_CaCertificateId { get; set; }
        #endregion
        
        #region Parameter CheckName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String CheckName { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceIdentifier_ClientId { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_CognitoIdentityPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Cognito identity pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceIdentifier_CognitoIdentityPoolId { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_DeviceCertificateArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the identified device certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceIdentifier_DeviceCertificateArn { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_DeviceCertificateId
        /// <summary>
        /// <para>
        /// <para>The ID of the certificate attached to the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceIdentifier_DeviceCertificateId { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that has overly permissive actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceIdentifier_IamRoleArn { get; set; }
        #endregion
        
        #region Parameter IssuerCertificateIdentifier_IssuerCertificateSerialNumber
        /// <summary>
        /// <para>
        /// <para>The issuer certificate serial number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceIdentifier_IssuerCertificateIdentifier_IssuerCertificateSerialNumber")]
        public System.String IssuerCertificateIdentifier_IssuerCertificateSerialNumber { get; set; }
        #endregion
        
        #region Parameter IssuerCertificateIdentifier_IssuerCertificateSubject
        /// <summary>
        /// <para>
        /// <para>The subject of the issuer certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceIdentifier_IssuerCertificateIdentifier_IssuerCertificateSubject")]
        public System.String IssuerCertificateIdentifier_IssuerCertificateSubject { get; set; }
        #endregion
        
        #region Parameter IssuerCertificateIdentifier_IssuerId
        /// <summary>
        /// <para>
        /// <para>The issuer ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceIdentifier_IssuerCertificateIdentifier_IssuerId")]
        public System.String IssuerCertificateIdentifier_IssuerId { get; set; }
        #endregion
        
        #region Parameter PolicyVersionIdentifier_PolicyName
        /// <summary>
        /// <para>
        /// <para>The name of the policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceIdentifier_PolicyVersionIdentifier_PolicyName")]
        public System.String PolicyVersionIdentifier_PolicyName { get; set; }
        #endregion
        
        #region Parameter PolicyVersionIdentifier_PolicyVersionId
        /// <summary>
        /// <para>
        /// <para>The ID of the version of the policy associated with the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceIdentifier_PolicyVersionIdentifier_PolicyVersionId")]
        public System.String PolicyVersionIdentifier_PolicyVersionId { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_RoleAliasArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role alias that has overly permissive actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceIdentifier_RoleAliasArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.DeleteAuditSuppressionResponse).
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CheckName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-IOTAuditSuppression (DeleteAuditSuppression)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.DeleteAuditSuppressionResponse, RemoveIOTAuditSuppressionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CheckName = this.CheckName;
            #if MODULAR
            if (this.CheckName == null && ParameterWasBound(nameof(this.CheckName)))
            {
                WriteWarning("You are passing $null as a value for parameter CheckName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceIdentifier_Account = this.ResourceIdentifier_Account;
            context.ResourceIdentifier_CaCertificateId = this.ResourceIdentifier_CaCertificateId;
            context.ResourceIdentifier_ClientId = this.ResourceIdentifier_ClientId;
            context.ResourceIdentifier_CognitoIdentityPoolId = this.ResourceIdentifier_CognitoIdentityPoolId;
            context.ResourceIdentifier_DeviceCertificateArn = this.ResourceIdentifier_DeviceCertificateArn;
            context.ResourceIdentifier_DeviceCertificateId = this.ResourceIdentifier_DeviceCertificateId;
            context.ResourceIdentifier_IamRoleArn = this.ResourceIdentifier_IamRoleArn;
            context.IssuerCertificateIdentifier_IssuerCertificateSerialNumber = this.IssuerCertificateIdentifier_IssuerCertificateSerialNumber;
            context.IssuerCertificateIdentifier_IssuerCertificateSubject = this.IssuerCertificateIdentifier_IssuerCertificateSubject;
            context.IssuerCertificateIdentifier_IssuerId = this.IssuerCertificateIdentifier_IssuerId;
            context.PolicyVersionIdentifier_PolicyName = this.PolicyVersionIdentifier_PolicyName;
            context.PolicyVersionIdentifier_PolicyVersionId = this.PolicyVersionIdentifier_PolicyVersionId;
            context.ResourceIdentifier_RoleAliasArn = this.ResourceIdentifier_RoleAliasArn;
            
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
            var request = new Amazon.IoT.Model.DeleteAuditSuppressionRequest();
            
            if (cmdletContext.CheckName != null)
            {
                request.CheckName = cmdletContext.CheckName;
            }
            
             // populate ResourceIdentifier
            var requestResourceIdentifierIsNull = true;
            request.ResourceIdentifier = new Amazon.IoT.Model.ResourceIdentifier();
            System.String requestResourceIdentifier_resourceIdentifier_Account = null;
            if (cmdletContext.ResourceIdentifier_Account != null)
            {
                requestResourceIdentifier_resourceIdentifier_Account = cmdletContext.ResourceIdentifier_Account;
            }
            if (requestResourceIdentifier_resourceIdentifier_Account != null)
            {
                request.ResourceIdentifier.Account = requestResourceIdentifier_resourceIdentifier_Account;
                requestResourceIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_CaCertificateId = null;
            if (cmdletContext.ResourceIdentifier_CaCertificateId != null)
            {
                requestResourceIdentifier_resourceIdentifier_CaCertificateId = cmdletContext.ResourceIdentifier_CaCertificateId;
            }
            if (requestResourceIdentifier_resourceIdentifier_CaCertificateId != null)
            {
                request.ResourceIdentifier.CaCertificateId = requestResourceIdentifier_resourceIdentifier_CaCertificateId;
                requestResourceIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_ClientId = null;
            if (cmdletContext.ResourceIdentifier_ClientId != null)
            {
                requestResourceIdentifier_resourceIdentifier_ClientId = cmdletContext.ResourceIdentifier_ClientId;
            }
            if (requestResourceIdentifier_resourceIdentifier_ClientId != null)
            {
                request.ResourceIdentifier.ClientId = requestResourceIdentifier_resourceIdentifier_ClientId;
                requestResourceIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_CognitoIdentityPoolId = null;
            if (cmdletContext.ResourceIdentifier_CognitoIdentityPoolId != null)
            {
                requestResourceIdentifier_resourceIdentifier_CognitoIdentityPoolId = cmdletContext.ResourceIdentifier_CognitoIdentityPoolId;
            }
            if (requestResourceIdentifier_resourceIdentifier_CognitoIdentityPoolId != null)
            {
                request.ResourceIdentifier.CognitoIdentityPoolId = requestResourceIdentifier_resourceIdentifier_CognitoIdentityPoolId;
                requestResourceIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_DeviceCertificateArn = null;
            if (cmdletContext.ResourceIdentifier_DeviceCertificateArn != null)
            {
                requestResourceIdentifier_resourceIdentifier_DeviceCertificateArn = cmdletContext.ResourceIdentifier_DeviceCertificateArn;
            }
            if (requestResourceIdentifier_resourceIdentifier_DeviceCertificateArn != null)
            {
                request.ResourceIdentifier.DeviceCertificateArn = requestResourceIdentifier_resourceIdentifier_DeviceCertificateArn;
                requestResourceIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_DeviceCertificateId = null;
            if (cmdletContext.ResourceIdentifier_DeviceCertificateId != null)
            {
                requestResourceIdentifier_resourceIdentifier_DeviceCertificateId = cmdletContext.ResourceIdentifier_DeviceCertificateId;
            }
            if (requestResourceIdentifier_resourceIdentifier_DeviceCertificateId != null)
            {
                request.ResourceIdentifier.DeviceCertificateId = requestResourceIdentifier_resourceIdentifier_DeviceCertificateId;
                requestResourceIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_IamRoleArn = null;
            if (cmdletContext.ResourceIdentifier_IamRoleArn != null)
            {
                requestResourceIdentifier_resourceIdentifier_IamRoleArn = cmdletContext.ResourceIdentifier_IamRoleArn;
            }
            if (requestResourceIdentifier_resourceIdentifier_IamRoleArn != null)
            {
                request.ResourceIdentifier.IamRoleArn = requestResourceIdentifier_resourceIdentifier_IamRoleArn;
                requestResourceIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_RoleAliasArn = null;
            if (cmdletContext.ResourceIdentifier_RoleAliasArn != null)
            {
                requestResourceIdentifier_resourceIdentifier_RoleAliasArn = cmdletContext.ResourceIdentifier_RoleAliasArn;
            }
            if (requestResourceIdentifier_resourceIdentifier_RoleAliasArn != null)
            {
                request.ResourceIdentifier.RoleAliasArn = requestResourceIdentifier_resourceIdentifier_RoleAliasArn;
                requestResourceIdentifierIsNull = false;
            }
            Amazon.IoT.Model.PolicyVersionIdentifier requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier = null;
            
             // populate PolicyVersionIdentifier
            var requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifierIsNull = true;
            requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier = new Amazon.IoT.Model.PolicyVersionIdentifier();
            System.String requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyName = null;
            if (cmdletContext.PolicyVersionIdentifier_PolicyName != null)
            {
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyName = cmdletContext.PolicyVersionIdentifier_PolicyName;
            }
            if (requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyName != null)
            {
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier.PolicyName = requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyName;
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyVersionId = null;
            if (cmdletContext.PolicyVersionIdentifier_PolicyVersionId != null)
            {
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyVersionId = cmdletContext.PolicyVersionIdentifier_PolicyVersionId;
            }
            if (requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyVersionId != null)
            {
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier.PolicyVersionId = requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyVersionId;
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifierIsNull = false;
            }
             // determine if requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier should be set to null
            if (requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifierIsNull)
            {
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier = null;
            }
            if (requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier != null)
            {
                request.ResourceIdentifier.PolicyVersionIdentifier = requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier;
                requestResourceIdentifierIsNull = false;
            }
            Amazon.IoT.Model.IssuerCertificateIdentifier requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifier = null;
            
             // populate IssuerCertificateIdentifier
            var requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifierIsNull = true;
            requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifier = new Amazon.IoT.Model.IssuerCertificateIdentifier();
            System.String requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifier_issuerCertificateIdentifier_IssuerCertificateSerialNumber = null;
            if (cmdletContext.IssuerCertificateIdentifier_IssuerCertificateSerialNumber != null)
            {
                requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifier_issuerCertificateIdentifier_IssuerCertificateSerialNumber = cmdletContext.IssuerCertificateIdentifier_IssuerCertificateSerialNumber;
            }
            if (requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifier_issuerCertificateIdentifier_IssuerCertificateSerialNumber != null)
            {
                requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifier.IssuerCertificateSerialNumber = requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifier_issuerCertificateIdentifier_IssuerCertificateSerialNumber;
                requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifier_issuerCertificateIdentifier_IssuerCertificateSubject = null;
            if (cmdletContext.IssuerCertificateIdentifier_IssuerCertificateSubject != null)
            {
                requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifier_issuerCertificateIdentifier_IssuerCertificateSubject = cmdletContext.IssuerCertificateIdentifier_IssuerCertificateSubject;
            }
            if (requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifier_issuerCertificateIdentifier_IssuerCertificateSubject != null)
            {
                requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifier.IssuerCertificateSubject = requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifier_issuerCertificateIdentifier_IssuerCertificateSubject;
                requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifier_issuerCertificateIdentifier_IssuerId = null;
            if (cmdletContext.IssuerCertificateIdentifier_IssuerId != null)
            {
                requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifier_issuerCertificateIdentifier_IssuerId = cmdletContext.IssuerCertificateIdentifier_IssuerId;
            }
            if (requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifier_issuerCertificateIdentifier_IssuerId != null)
            {
                requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifier.IssuerId = requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifier_issuerCertificateIdentifier_IssuerId;
                requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifierIsNull = false;
            }
             // determine if requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifier should be set to null
            if (requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifierIsNull)
            {
                requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifier = null;
            }
            if (requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifier != null)
            {
                request.ResourceIdentifier.IssuerCertificateIdentifier = requestResourceIdentifier_resourceIdentifier_IssuerCertificateIdentifier;
                requestResourceIdentifierIsNull = false;
            }
             // determine if request.ResourceIdentifier should be set to null
            if (requestResourceIdentifierIsNull)
            {
                request.ResourceIdentifier = null;
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
        
        private Amazon.IoT.Model.DeleteAuditSuppressionResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.DeleteAuditSuppressionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "DeleteAuditSuppression");
            try
            {
                return client.DeleteAuditSuppressionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CheckName { get; set; }
            public System.String ResourceIdentifier_Account { get; set; }
            public System.String ResourceIdentifier_CaCertificateId { get; set; }
            public System.String ResourceIdentifier_ClientId { get; set; }
            public System.String ResourceIdentifier_CognitoIdentityPoolId { get; set; }
            public System.String ResourceIdentifier_DeviceCertificateArn { get; set; }
            public System.String ResourceIdentifier_DeviceCertificateId { get; set; }
            public System.String ResourceIdentifier_IamRoleArn { get; set; }
            public System.String IssuerCertificateIdentifier_IssuerCertificateSerialNumber { get; set; }
            public System.String IssuerCertificateIdentifier_IssuerCertificateSubject { get; set; }
            public System.String IssuerCertificateIdentifier_IssuerId { get; set; }
            public System.String PolicyVersionIdentifier_PolicyName { get; set; }
            public System.String PolicyVersionIdentifier_PolicyVersionId { get; set; }
            public System.String ResourceIdentifier_RoleAliasArn { get; set; }
            public System.Func<Amazon.IoT.Model.DeleteAuditSuppressionResponse, RemoveIOTAuditSuppressionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
