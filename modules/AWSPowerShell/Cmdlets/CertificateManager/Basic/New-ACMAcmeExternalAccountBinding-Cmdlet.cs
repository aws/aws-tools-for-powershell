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
using Amazon.CertificateManager;
using Amazon.CertificateManager.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ACM
{
    /// <summary>
    /// Creates an external account binding (EAB) for an ACME endpoint. An EAB provides credentials
    /// that authorize an ACME client to register an account with the endpoint. Each EAB is
    /// associated with an IAM role that controls what certificate operations the ACME client
    /// can perform.
    /// </summary>
    [Cmdlet("New", "ACMAcmeExternalAccountBinding", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CertificateManager.Model.AcmeExternalAccountBinding")]
    [AWSCmdlet("Calls the AWS Certificate Manager CreateAcmeExternalAccountBinding API operation.", Operation = new[] {"CreateAcmeExternalAccountBinding"}, SelectReturnType = typeof(Amazon.CertificateManager.Model.CreateAcmeExternalAccountBindingResponse))]
    [AWSCmdletOutput("Amazon.CertificateManager.Model.AcmeExternalAccountBinding or Amazon.CertificateManager.Model.CreateAcmeExternalAccountBindingResponse",
        "This cmdlet returns an Amazon.CertificateManager.Model.AcmeExternalAccountBinding object.",
        "The service call response (type Amazon.CertificateManager.Model.CreateAcmeExternalAccountBindingResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewACMAcmeExternalAccountBindingCmdlet : AmazonCertificateManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AcmeEndpointArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the ACME endpoint.</para>
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
        public System.String AcmeEndpointArn { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role to associate with the external account
        /// binding.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>One or more tags to associate with the external account binding.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.CertificateManager.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Expiration_Type
        /// <summary>
        /// <para>
        /// <para>The time unit for the expiration value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CertificateManager.TimeType")]
        public Amazon.CertificateManager.TimeType Expiration_Type { get; set; }
        #endregion
        
        #region Parameter Expiration_Value
        /// <summary>
        /// <para>
        /// <para>The numeric value of the expiration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Expiration_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ExternalAccountBinding'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CertificateManager.Model.CreateAcmeExternalAccountBindingResponse).
        /// Specifying the name of a property of type Amazon.CertificateManager.Model.CreateAcmeExternalAccountBindingResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ExternalAccountBinding";
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.AcmeEndpointArn),
                nameof(this.RoleArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ACMAcmeExternalAccountBinding (CreateAcmeExternalAccountBinding)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CertificateManager.Model.CreateAcmeExternalAccountBindingResponse, NewACMAcmeExternalAccountBindingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AcmeEndpointArn = this.AcmeEndpointArn;
            #if MODULAR
            if (this.AcmeEndpointArn == null && ParameterWasBound(nameof(this.AcmeEndpointArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AcmeEndpointArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Expiration_Type = this.Expiration_Type;
            context.Expiration_Value = this.Expiration_Value;
            context.IdempotencyToken = this.IdempotencyToken;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.CertificateManager.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.CertificateManager.Model.CreateAcmeExternalAccountBindingRequest();
            
            if (cmdletContext.AcmeEndpointArn != null)
            {
                request.AcmeEndpointArn = cmdletContext.AcmeEndpointArn;
            }
            
             // populate Expiration
            var requestExpirationIsNull = true;
            request.Expiration = new Amazon.CertificateManager.Model.Expiration();
            Amazon.CertificateManager.TimeType requestExpiration_expiration_Type = null;
            if (cmdletContext.Expiration_Type != null)
            {
                requestExpiration_expiration_Type = cmdletContext.Expiration_Type;
            }
            if (requestExpiration_expiration_Type != null)
            {
                request.Expiration.Type = requestExpiration_expiration_Type;
                requestExpirationIsNull = false;
            }
            System.Int64? requestExpiration_expiration_Value = null;
            if (cmdletContext.Expiration_Value != null)
            {
                requestExpiration_expiration_Value = cmdletContext.Expiration_Value.Value;
            }
            if (requestExpiration_expiration_Value != null)
            {
                request.Expiration.Value = requestExpiration_expiration_Value.Value;
                requestExpirationIsNull = false;
            }
             // determine if request.Expiration should be set to null
            if (requestExpirationIsNull)
            {
                request.Expiration = null;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.CertificateManager.Model.CreateAcmeExternalAccountBindingResponse CallAWSServiceOperation(IAmazonCertificateManager client, Amazon.CertificateManager.Model.CreateAcmeExternalAccountBindingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager", "CreateAcmeExternalAccountBinding");
            try
            {
                return client.CreateAcmeExternalAccountBindingAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AcmeEndpointArn { get; set; }
            public Amazon.CertificateManager.TimeType Expiration_Type { get; set; }
            public System.Int64? Expiration_Value { get; set; }
            public System.String IdempotencyToken { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.CertificateManager.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.CertificateManager.Model.CreateAcmeExternalAccountBindingResponse, NewACMAcmeExternalAccountBindingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ExternalAccountBinding;
        }
        
    }
}
