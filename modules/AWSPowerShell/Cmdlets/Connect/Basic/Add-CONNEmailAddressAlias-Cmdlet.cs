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
using Amazon.Connect;
using Amazon.Connect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Associates an email address alias with an existing email address in an Amazon Connect
    /// instance. This creates a forwarding relationship where emails sent to the alias email
    /// address are automatically forwarded to the primary email address. 
    /// 
    ///  
    /// <para><b>Use cases</b></para><para>
    /// Following are common uses cases for this API:
    /// </para><ul><li><para><b>Unified customer support</b>: Create multiple entry points (for example, support@example.com,
    /// help@example.com, customercare@example.com) that all forward to a single agent queue
    /// for streamlined management.
    /// </para></li><li><para><b>Department consolidation</b>: Forward emails from legacy department addresses
    /// (for example, sales@example.com, info@example.com) to a centralized customer service
    /// email during organizational restructuring.
    /// </para></li><li><para><b>Brand management</b>: Enable you to use familiar brand-specific email addresses
    /// that forward to the appropriate Amazon Connect instance email address.
    /// </para></li></ul><para><b>Important things to know</b></para><ul><li><para>
    /// Each email address can have a maximum of one alias. You cannot create multiple aliases
    /// for the same email address. 
    /// </para></li><li><para>
    /// If the alias email address already receives direct emails, it continues to receive
    /// direct emails plus forwarded emails.
    /// </para></li><li><para>
    /// You cannot chain email aliases together (that is, create an alias of an alias).
    /// </para></li></ul><para><c>AssociateEmailAddressAlias</c> does not return the following information:
    /// </para><ul><li><para>
    /// A confirmation of the alias relationship details (you must call <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_DescribeEmailAddress.html">DescribeEmailAddress</a>
    /// to verify).
    /// </para></li><li><para>
    /// The timestamp of when the association occurred.
    /// </para></li><li><para>
    /// The status of the forwarding configuration.
    /// </para></li></ul><para><b>Endpoints</b>: See <a href="https://docs.aws.amazon.com/general/latest/gr/connect_region.html">Amazon
    /// Connect endpoints and quotas</a>.
    /// </para><para><b>Related operations</b></para><ul><li><para><a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_DisassociateEmailAddressAlias.html">DisassociateEmailAddressAlias</a>:
    /// Removes the alias association between two email addresses in an Amazon Connect instance.
    /// </para></li><li><para><a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_DescribeEmailAddress.html">DescribeEmailAddress</a>:
    /// View current alias configurations for an email address.
    /// </para></li><li><para><a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_SearchEmailAddresses.html">SearchEmailAddresses</a>:
    /// Find email addresses and their alias relationships across an instance.
    /// </para></li><li><para><a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_CreateEmailAddress.html">CreateEmailAddress</a>:
    /// Create new email addresses that can participate in alias relationships.
    /// </para></li><li><para><a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_DeleteEmailAddress.html">DeleteEmailAddress</a>:
    /// Remove email addresses (automatically removes any alias relationships).
    /// </para></li><li><para><a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_UpdateEmailAddressMetadata.html">UpdateEmailAddressMetadata</a>:
    /// Modify email address properties (does not affect alias relationships).
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Add", "CONNEmailAddressAlias", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Service AssociateEmailAddressAlias API operation.", Operation = new[] {"AssociateEmailAddressAlias"}, SelectReturnType = typeof(Amazon.Connect.Model.AssociateEmailAddressAliasResponse))]
    [AWSCmdletOutput("None or Amazon.Connect.Model.AssociateEmailAddressAliasResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Connect.Model.AssociateEmailAddressAliasResponse) be returned by specifying '-Select *'."
    )]
    public partial class AddCONNEmailAddressAliasCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AliasConfiguration_EmailAddressId
        /// <summary>
        /// <para>
        /// <para>The email address ID.</para>
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
        public System.String AliasConfiguration_EmailAddressId { get; set; }
        #endregion
        
        #region Parameter EmailAddressId
        /// <summary>
        /// <para>
        /// <para>The identifier of the email address.</para>
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
        public System.String EmailAddressId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="https://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.AssociateEmailAddressAliasResponse).
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.EmailAddressId),
                nameof(this.InstanceId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-CONNEmailAddressAlias (AssociateEmailAddressAlias)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.AssociateEmailAddressAliasResponse, AddCONNEmailAddressAliasCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AliasConfiguration_EmailAddressId = this.AliasConfiguration_EmailAddressId;
            #if MODULAR
            if (this.AliasConfiguration_EmailAddressId == null && ParameterWasBound(nameof(this.AliasConfiguration_EmailAddressId)))
            {
                WriteWarning("You are passing $null as a value for parameter AliasConfiguration_EmailAddressId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.EmailAddressId = this.EmailAddressId;
            #if MODULAR
            if (this.EmailAddressId == null && ParameterWasBound(nameof(this.EmailAddressId)))
            {
                WriteWarning("You are passing $null as a value for parameter EmailAddressId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.AssociateEmailAddressAliasRequest();
            
            
             // populate AliasConfiguration
            var requestAliasConfigurationIsNull = true;
            request.AliasConfiguration = new Amazon.Connect.Model.AliasConfiguration();
            System.String requestAliasConfiguration_aliasConfiguration_EmailAddressId = null;
            if (cmdletContext.AliasConfiguration_EmailAddressId != null)
            {
                requestAliasConfiguration_aliasConfiguration_EmailAddressId = cmdletContext.AliasConfiguration_EmailAddressId;
            }
            if (requestAliasConfiguration_aliasConfiguration_EmailAddressId != null)
            {
                request.AliasConfiguration.EmailAddressId = requestAliasConfiguration_aliasConfiguration_EmailAddressId;
                requestAliasConfigurationIsNull = false;
            }
             // determine if request.AliasConfiguration should be set to null
            if (requestAliasConfigurationIsNull)
            {
                request.AliasConfiguration = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EmailAddressId != null)
            {
                request.EmailAddressId = cmdletContext.EmailAddressId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
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
        
        private Amazon.Connect.Model.AssociateEmailAddressAliasResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.AssociateEmailAddressAliasRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "AssociateEmailAddressAlias");
            try
            {
                return client.AssociateEmailAddressAliasAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AliasConfiguration_EmailAddressId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String EmailAddressId { get; set; }
            public System.String InstanceId { get; set; }
            public System.Func<Amazon.Connect.Model.AssociateEmailAddressAliasResponse, AddCONNEmailAddressAliasCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
